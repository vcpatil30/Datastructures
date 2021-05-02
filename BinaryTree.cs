using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{

    //-----------------------------------------This is not tested at all----------------------------------------
//-----------------------------------------This is not tested at all----------------------------------------
//-----------------------------------------This is not tested at all----------------------------------------
//-----------------------------------------This is not tested at all----------------------------------------

    public partial class BTNode
    {
        public BTNode Left {get;set;}
        public BTNode Right {get;set;}
        public int Val {get;set;}

        public BTNode(int num)
        {
            this.Val = num;
        }
    }

    public partial class BT
    {        
        public BTNode Root {get;set;}

        public int GoodNode(BTNode node)
        {
            if(node==null)
                return 0;

            return GoodNode(node, node.Val);
        }
        public int GoodNode(BTNode node, int max)  //Basically recursive DFS
        {
            if(node==null)
                return 0;

            max = node.Val >= max? node.Val : max;

            if(node.Val >= max)
                return (1 + GoodNode(node.Left, max) + GoodNode(node.Right, max));
            else
                return (GoodNode(node.Left, max) + GoodNode(node.Right, max));
        }


        //Count all the nodes with single child 
        public int CountSingleChildNodes(BTNode node)
        {
            if(node==null)
                return 0;

            if( (node.Left == null && node.Right != null) || 
                node.Left != null && node.Right == null)
                return 1 + CountSingleChildNodes(node.Left) + CountSingleChildNodes(node.Right);
            else
                return CountSingleChildNodes(node.Left) + CountSingleChildNodes(node.Right);
        }

        public int CountSingleChildNodes()
        {
            return CountSingleChildNodes(this.Root);
        }        


        // If  node does not have its left child, then insert the given node(the one that we have to insert) as its left child.
        // If node does not have its right child then insert the given node as its right child.
        // If the above-given conditions do not apply then search for the node which does not have a child at all and insert the given node there.
        // We can use a queue for implementation of this algorithm, as it is easy to store and retrieve the nodes of the binary tree that way because queue follows the FIFO rule. Also, most of the tree algorithms are implemented using a queue.
        // Looks like this algo goes level by level and fill the tree up, every level nodes are kept in the queue and checked for above first two conditions
        public void Init(int num) //Iterative
        {
            if(this.Root == null)
            {
                this.Root = new BTNode(num);
                return;                
            }

            Queue<BTNode> queue = new Queue<BTNode>();
            queue.Enqueue(this.Root);

            while(queue.Count != 0)
            {
                BTNode node = queue.Dequeue();

                if(node.Left == null)
                {
                    node.Left = new BTNode(num);
                    break;
                }
                else
                {
                    queue.Enqueue(node.Left);
                }                    

                if(node.Right == null)
                {
                    node.Right = new BTNode(num);
                    break;
                }
                else
                {
                    queue.Enqueue(node.Right);
                }    
            }
        }

        public void Init(int[] nums)
        {
            foreach(int num in nums)
            {
                Init(num);
            }
        }

        public void GetInorderRecursive(BTNode node, List<int> nums)
        {
            if(node==null)
                return;

            GetInorderRecursive(node.Left, nums);
            nums.Add(node.Val);
            GetInorderRecursive(node.Right, nums);
        }

        public StringBuilder Serialize()
        {
            StringBuilder sb = new StringBuilder();
            Serialize(this.Root, sb);
            return sb;
        }        

        public void Serialize(BTNode node, StringBuilder sb)
        {
            if(node==null)
            {
                sb.Append("X,");
                return;
            }

            sb.AppendFormat("{0},", node.Val);

            Serialize(node.Left, sb);
            Serialize(node.Right, sb);         
        }

        public void Deserialize(string strBinTree)
        {
            string[] strTokens = strBinTree.Split(',');
            
            foreach(var strToken in strTokens)
            {
                Deserialize(strToken);
            }
        }

        public void Deserialize(string strToken)
        {
            

        }

        public static void TestBinaryTree()
        {
            //int[] nums = {5, 3, 10, 1, 4, 7, 12, 2 }; //2 should be inserted immediately after root to the left
            int[] nums = Utility.GenerateRandomNumbers(30, 10, 90);
            BT bt = new BT();
            bt.Init(nums);
            
            List<int> list = new List<int>();
            bt.GetInorderRecursive(bt.Root, list);
            Utility.Print(list);

            Console.WriteLine("Single child Nodes:{0}", bt.CountSingleChildNodes());

            Console.WriteLine("Serialized: {0}", bt.Serialize());

            //deserialize test
            string strBinTree = "60,87,54,53,59,X,X,35,X,X,28,39,X,X,44,X,X,71,42,20,X,X,24,X,X,55,37,X,X,22,X,X,59,67,40,89,X,X,40,X,X,82,84,X,X,37,X,X,86,20,33,X,X,23,X,X,77,32,X,X,X,";
        }

    }
}