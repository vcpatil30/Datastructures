using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class BST
    {
        public void InsertIterative(int num)
        {
            BSTNode newNode = new BSTNode(num);

            if(this.Root == null)
            {
                this.Root = newNode;
                return;
            }

            BSTNode curNode = this.Root;

            while(curNode != null)
            {
                BSTNode preNode = curNode;

                if(num < curNode.Val)
                {
                    curNode = curNode.Left;
                    if(curNode == null)
                        preNode.Left = newNode;
                }
                else 
                {
                    curNode = curNode.Right;
                    if(curNode == null)
                        preNode.Right = newNode;
                }
            }
        }

        public void InitIterative(int[] nums)
        {
            foreach(int num in nums)
            {
                this.InsertIterative(num);
            }
        }

        public BSTNode FindIterative(int num)
        {
            return FindIterative(this.Root, num);
        }


        public BSTNode FindIterative(BSTNode node, int num)
        {
            while(node != null)
            {
                if(node.Val == num)
                    return node;

                if(num < node.Val)
                    node = node.Left;
                else
                    node = node.Right;
            }
            return null;
        }



        public List<int> LevelOrderInterative() //Basically Iterative BFS
        {
            List<int> result = new List<int>();
            if(Root == null)
            {
                return result;
            }

            Queue<BSTNode> traversalQ = new Queue<BSTNode>();
            traversalQ.Enqueue(Root);

            while(traversalQ.Count != 0)
            {
                BSTNode node = traversalQ.Dequeue();
                if(node.Left != null)
                {
                    traversalQ.Enqueue(node.Left);
                }

                if(node.Right != null)
                {
                    traversalQ.Enqueue(node.Right);
                }
                
                result.Add(node.Val);
            }
            return result;
      }     
 
        public List<List<int>> ZigZagIterative() //Basically Iterative BFS
        {
            List<List<int>> result = new List<List<int>>();
            if(Root ==null)
            {
                return result;
            }

            Queue<BSTNode> traversalQ = new Queue<BSTNode>();
            traversalQ.Enqueue(Root);

            bool leftToRight= true;
    
            while(traversalQ.Count != 0)
            {
                int levelCount = traversalQ.Count;
                List<int> subList = new List<int>();

                for(int i=0; i<levelCount; i++)
                {
                    BSTNode node = traversalQ.Dequeue();
                    if(node.Left != null)
                    {
                        traversalQ.Enqueue(node.Left);
                    }

                    if(node.Right != null)
                    {
                        traversalQ.Enqueue(node.Right);
                    }

                    if(leftToRight)
                        subList.Add(node.Val);
                    else
                        subList.Insert(0, node.Val);
                }
                leftToRight = !leftToRight;
                result.Add(subList);
            }
            return result;
      }     
         
        public static void TestZigZagAndLevelOrderIterative()
        {
            int[] nums = {5, 3, 10, 1, 4, 7, 12 };

            BST bst = new BST();
            bst.InitIterative(nums);

            List<int> levelOrder = bst.LevelOrderInterative();
            foreach(int num in levelOrder )
            {
                Console.Write("{0}, ", num);
            }
            Console.WriteLine("");


            List<List<int>> zigZagOrder = bst.ZigZagIterative();
            foreach(List<int> list in zigZagOrder)
            {
                foreach(int num in list)
                {
                    Console.Write("{0}, ", num);
                }
            }
            Console.WriteLine("");
        }

        public static void TestCountGoodNodesInBinaryTree()
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

        public static void TestBSTIterative()
        {
            int[] nums = {5, 3, 10, 1, 4, 7, 12, 2 }; //2 shuld get inserted immediately after left of root

            BST bst = new BST();
            bst.InitIterative(nums);

            if(null != bst.FindIterative(1))
                Console.WriteLine("Found");
            else
                Console.WriteLine("NOT Found");

            List<int> allNums = new List<int>();
            bst.GetInorderRecursive(allNums);

            foreach(int num in allNums)
            {
                Console.WriteLine(num);
            }
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


public GetMin(node)
{
     if(!node) 
        node = this.root; 
        
    while(node.left) 
    { 
        node = node.left; 
    } 
    return node.value
}

public int GetMax(BSTNode node)
{ 
    if(!node) 
        node = this.root; 
        
    while(node.right) 
    { 
        node = node.right; 
    } 
    return node.value;
}


*/