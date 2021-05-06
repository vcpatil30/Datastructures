using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
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

        //==========================Count Good Nodes of Binary Tree =================================
        //A node X is good if in the path from root to X there are no nodes with a value greater than X.
        public int GoodNode()
        {
            return GoodNode(this.Root, this.Root.Val);
        }
        public int GoodNode(BTNode node, int max)  //Basically recursive DFS
        {
            if(node==null)
                return 0;

            max = node.Val > max? node.Val : max;

            if(node.Val >= max)
            {
                Console.Write($"{node.Val}, ");
                return (1 + GoodNode(node.Left, max) + GoodNode(node.Right, max));
            }
            else
                return (GoodNode(node.Left, max) + GoodNode(node.Right, max));
        }


        //=================================== Count all the nodes with single child =======================================
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


        //==========================Add to BinaryTree =================================

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

        //========================== DFS traversal (Inorder)  =================================
        public void GetInorderRecursive(BTNode node, List<int> nums)
        {
            if(node==null)
                return;

            GetInorderRecursive(node.Left, nums);
            nums.Add(node.Val);
            GetInorderRecursive(node.Right, nums);
        }
        
        //==========================Searialize & Deserialize Binary Tree =================================
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
            int i = 0;
            this.Root = Deserialize(strTokens, ref i);
        }

        
        public BTNode Deserialize(string[] strTokens, ref int i)
        {
            if(strTokens[i] == "X")
                return null;

            BTNode newNode = new BTNode(int.Parse(strTokens[i]));

            ++i; newNode.Left = Deserialize(strTokens,  ref i); 
            ++i; newNode.Right = Deserialize(strTokens, ref i);
            return newNode;
        }


        //=====================================Difference between sums of odd level and even level nodes of a Binary Tree====================
        public void DiffBetweenEvenAndOddLevelNodes(BTNode node, int level, ref int diff)
        {
            if(node == null)
                return;

            if(level%2 == 0)
                diff += node.Val;
            else 
                diff -= node.Val;

            DiffBetweenEvenAndOddLevelNodes(node.Left, level+1, ref diff);
            DiffBetweenEvenAndOddLevelNodes(node.Right, level+1, ref diff);
        }

        //This is really elegant solution I found on internet. Basically left and right are at next level so by subtracting from current level
        //it is making the sign of current as +ve and next leve as -ve. (it's bit mind bending but very elegant) https://www.geeksforgeeks.org/difference-between-sums-of-odd-and-even-levels/?ref=rp
        public virtual int DiffBetweenEvenAndOddLevelNodes_1(BTNode node) 
        {
            if (node == null)// Base case 
            {
                return 0;
            }
    
            // Difference for root is (Root's  data - Difference for left subtree - Difference for right subtree)
            return node.Val - DiffBetweenEvenAndOddLevelNodes_1(node.Left)
                            - DiffBetweenEvenAndOddLevelNodes_1(node.Right);
        }

        public void DiffBetweenEvenAndOddLevelNodes_Iterative() //need to finish this ??????
        {
            Queue<BTNode> queue = new Queue<BTNode>();
            queue.Enqueue(this.Root);

            while(queue.Count != 0)
            {
                BTNode cur = queue.Dequeue();
                                
            }
        }

        //==========================Test methods =================================
        public static void TestInorderTree()
        {
            int[] nums = Utility.GenerateRandomNumbers(20, 10, 99);
            BT bt = new BT();
            bt.Init(nums);
            
            Utility.DrawTree(bt.Root);

            List<int> list = new List<int>();
            bt.GetInorderRecursive(bt.Root, list);
            Utility.Print(list);
        }

        public static void TestSingleChildTree() //This was asked in my MS interview
        {
            int[] nums = Utility.GenerateRandomNumbers(20, 10, 99);
            BT bt = new BT();
            bt.Init(nums);
            
            Utility.DrawTree(bt.Root);
            Console.WriteLine("Single child Nodes:{0}", bt.CountSingleChildNodes());
        }



        public static void TestDeSerializeTree()
        {
            int[] nums = Utility.GenerateRandomNumbers(20, 10, 99);
            
            BT bt = new BT();
            bt.Init(nums);
            Utility.DrawTree(bt.Root);

            StringBuilder strTree = bt.Serialize();
            Console.WriteLine($"Serialized (PreOrder) Tree: {strTree}");

            BT btNew = new BT();
            btNew.Deserialize(strTree.ToString());
            Utility.DrawTree(btNew.Root);
        }

        public static void TestDiffBetweenEvenAndOddLevelNodes()
        {
            int[] nums = Utility.GenerateRandomNumbers(10, 10, 99);
            BT bt = new BT();
            bt.Init(nums);
            
            Utility.DrawTree(bt.Root);
            
            int diff = 0;
            bt.DiffBetweenEvenAndOddLevelNodes(bt.Root, 0, ref diff);
            Console.WriteLine("Diff: {0}", diff);


            int diff1= bt.DiffBetweenEvenAndOddLevelNodes_1(bt.Root);
            Console.WriteLine("Diff1: {0}", diff1);
        }        

        public static void TestGoodNodes()
        {
            int[] nums = Utility.GenerateRandomNumbers(20, 10, 99);
            BT bt = new BT();
            bt.Init(nums);
            
            Utility.DrawTree(bt.Root);
            
            int goodNodeCount = bt.GoodNode();
            Console.WriteLine("\n Good Nodes: {0}", goodNodeCount);
        }        

    }
}