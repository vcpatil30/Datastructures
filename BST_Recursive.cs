using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class BSTNode
    {
        public BSTNode Left {get;set;}
        public BSTNode Right {get;set;}
        public int Val {get;set;}

        public BSTNode(int num)
        {
            this.Val = num;
        }
    }

    public partial class BST
    {
        public BSTNode Root {get;set;}


        //In BST always insert at the Left Node
        public BSTNode InsertRecursive(BSTNode node, int num)
        {
            if(node==null)
                return new BSTNode(num);

            if(num < node.Val)
                node.Left = InsertRecursive(node.Left, num);
            else
                node.Right = InsertRecursive(node.Right, num);

            return(node); // Basically this will keep returning the same level pointer to upper level and reassign the .left or .right on every call 
                            //except the bottom most call where it returns newly allocated node which gets assinged to the leaf node (left or right)
        }

        public void InitRecursive(int[] nums)
        {
            foreach(int num in nums)
            {
                BSTNode insertedNode = InsertRecursive(this.Root, num);
                if(this.Root == null)
                    this.Root = insertedNode;
            }
        }

        public BSTNode FindRecursive(int num)
        {
            return FindRecursive(this.Root, num);
        }

        public BSTNode FindRecursive(BSTNode node, int num)
        {
            if(node == null || node.Val == num)
                return node;

            if(num < node.Val)
                return FindRecursive(node.Left, num);
            else
                return FindRecursive(node.Right, num);
        }
        public void GetInorderRecursive(List<int> nums)
        {
            GetInorderRecursive(this.Root, nums);
        }

        public void GetInorderRecursive(BSTNode node, List<int> nums)
        {
            if(node == null)
                return;

            GetInorderRecursive(node.Left, nums);
            nums.Add(node.Val);
            GetInorderRecursive(node.Right, nums);
        }
        public BSTNode DeleteRecursive(int num)
        {
            return DeleteRecursive(this.Root, num);
        }

        public BSTNode DeleteRecursive(BSTNode node, int num)
        {
            if (node == null) /* Base Case: If the tree is empty */
                return node;
    
            /* Otherwise, recur down the tree */
            if (num < node.Val)
                node.Left = DeleteRecursive(node.Left, num);
            else if (num > node.Val)
                node.Right = DeleteRecursive(node.Right, num);
    
            // if key is same as root's key, then This is the
            // node to be deleted
            else {
                // node with only one child or no child
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
    
                // node with two children: Get the
                // inorder successor (smallest
                // in the right subtree)
                node.Val = GetMin(node.Right);
    
                // Delete the inorder successor
                node.Right = DeleteRecursive(node.Right, node.Val);
            }
            return node;
        }

        // public int MinValue(BSTNode node)
        // {
        //     int minv = node.Val;
        //     while (node.Left != null) {
        //         minv = node.Left.Val;
        //         node = node.Left;
        //     }
        //     return minv;
        // }

        public int GetMin()
        {
            return GetMin(this.Root);
        }

        public int GetMin(BSTNode node)
        {
            while(node.Left != null) 
            { 
                node = node.Left; 
            } 
            return node.Val;
        }

        public int GetMax()
        {
            return GetMax(this.Root);
        }

        public int GetMax(BSTNode node)
        { 
            while(node.Right != null) 
            { 
                node = node.Right; 
            } 
            return node.Val;
        }

        public void LevelOrderRecursive(Dictionary<int, List<int>> dict) //Basically recursive BFS
        {
            LevelOrderRecursive(this.Root, 0, dict);
        }
        public void LevelOrderRecursive(BSTNode node, int level, Dictionary<int, List<int>> dict) //Basically recursive BFS
        {
            if(node == null)
                return;

            List<int> levelList = null ;
            if(!dict.TryGetValue(level, out levelList))
            {
                levelList = new List<int>();
                dict[level] = levelList;
            }

            levelList.Add(node.Val);

            if(node.Left != null)
            {
                LevelOrderRecursive(node.Left, level+1, dict);
            }

            if(node.Right != null)
            {
                LevelOrderRecursive(node.Right, level+1, dict);
            }
        }

        public void ZigZagRecursive(Dictionary<int,List<int>> dict) //Basically recursive BFS
        {
            ZigZagRecursive(this.Root, 0, dict);
        }
        public void ZigZagRecursive(BSTNode node, int level, Dictionary<int, List<int>> dict) //Basically recursive DFS
        {
            if(node == null)
                return;

            List<int> levelList = null ;
            if(!dict.TryGetValue(level, out levelList))
            {
                levelList = new List<int>();
                dict[level] = levelList;
            }

            if(level%2==0)
                levelList.Add(node.Val);
            else
                levelList.Insert(0, node.Val);

            if(node.Left != null)
            {
                ZigZagRecursive(node.Left, level+1, dict);
            }

            if(node.Right != null)
            {
                ZigZagRecursive(node.Right, level+1, dict);
            }
        }

         
        public static void TestZigZagAndLevelOrderRecursive()
        {
            int[] nums = {5, 3, 10, 1, 4, 7, 12 };

            BST bst = new BST();
            bst.InitRecursive(nums);

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            bst.LevelOrderRecursive(dict);
            foreach(int key in dict.Keys)
            {
                foreach(int num in dict[key])
                    Console.Write("{0}, ", num);
            }

            Console.WriteLine("");

            Dictionary<int, List<int>> dictZigZag = new Dictionary<int, List<int>>();
            bst.ZigZagRecursive(dictZigZag);
            foreach(int key in dictZigZag.Keys)
            {
                foreach(int num in dictZigZag[key])
                    Console.Write("{0}, ", num);
            }

            Console.WriteLine("");

        }

        public void GetAllGoodNodesRecursive(BSTNode node, int parentNodeValue, List<int> goodNodes)
        {
            if(node == null)
                return;

            if(node.Val>= parentNodeValue)
                goodNodes.Add(node.Val);

            GetAllGoodNodesRecursive(node.Left, node.Val, goodNodes);
            GetAllGoodNodesRecursive(node.Right, node.Val, goodNodes);
        }
        public List<int> GetAllGoodNodesRecursive()
        {
            List<int> goodNodes = new List<int>();
            GetAllGoodNodesRecursive(this.Root, -1, /*min number*/ goodNodes);
            return goodNodes;
        }


        //Is Symetric tree
        // Two trees are a mirror reflection of each other if:
            // Their two roots have the same value.
            // The right subtree of each tree is a mirror reflection of the left subtree of the other tree.


        public bool IsSymmetric(BSTNode node) {
            return IsSymmetric(node.Left, node.Right);
        }

        public bool IsSymmetric(BSTNode t1, BSTNode t2) {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            return (t1.Val == t2.Val)
                && IsSymmetric(t1.Left, t2.Right)
                && IsSymmetric(t1.Right, t2.Left);
        }            

        public static void TestCountGoodNodesInBinaryTreeRecursive()
        {
             BST bst = new BST();
             bst.Root = new BSTNode(3);
             bst.Root.Left = new BSTNode(1);
             bst.Root.Left.Left = new BSTNode(3);
            bst.Root.Right = new BSTNode(4);
            bst.Root.Right.Right = new BSTNode(5);
            bst.Root.Right.Left = new BSTNode(1);

            List<int> goodNodes = bst.GetAllGoodNodesRecursive();

            foreach(int num in goodNodes)
            {
                Console.Write("{0}, ", num);
            }
            Console.WriteLine("");

            //another tree
            BST bst1 = new BST();
            bst1.Root = new BSTNode(3);
            bst1.Root.Left = new BSTNode(3);
            bst1.Root.Left.Left = new BSTNode(4);
            bst1.Root.Left.Right = new BSTNode(2);

            goodNodes = bst1.GetAllGoodNodesRecursive();

            foreach(int num in goodNodes)
            {
                Console.Write("{0}, ", num);
            }
            Console.WriteLine("");

        }

        public static void Print(List<int> nums)
        {
            foreach(int num in nums)
            {
                Console.Write(num);
                Console.Write(",");
            }
            Console.WriteLine("");
        }

        public static void TestBSTRecursive()
        {
            int[] nums = {5, 3, 10, 1, 4, 7, 12, 2 }; //2 should be inserted immediately after root to the left

            BST bstRecursive = new BST();
            bstRecursive.InitRecursive(nums);

            BST bstIterative = new BST();
            bstIterative.InitIterative(nums);

            List<int> nums1 = new List<int>();
            bstRecursive.GetInorderRecursive(nums1);
            Print(nums1);

            List<int> nums2 = new List<int>();
            bstIterative.GetInorderRecursive(nums2);
            Print(nums2);

            if(null != bstRecursive.FindRecursive(1))
                Console.WriteLine("Found");
            else
                Console.WriteLine("NOT Found");

            if(null != bstRecursive.FindIterative(1))
                Console.WriteLine("Found");
            else
                Console.WriteLine("NOT Found");
        }
    }
}


/*

pbulic Remove(node, value)
{ 
    if(!node)
    {   
        return null; 
    } 
    
    if(value == node.value)
    {  
        if(!node.left && !node.right)  // no children
            return null;  
            
        if(!node.left) // one child and it’s the right
            node.right; 
        
        if(!node.right) // one child and it’s the left
            node.left;   
            
        // two kids            
        const temp = this.getMin(node.right); 
        node.value = temp; 
        node.right = this.removeNode(node.right, temp); 
        
        return node; 
    } 
    else if(value < node.value) 
    {     
        node.left = this.removeNode(node.left, value);             
        return node; 
    } 
    else  
    {     
        node.right = this.removeNode(node.right, value);     
        return node;   
    }
};




*/




