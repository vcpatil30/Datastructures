using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class BST
    {
        public BSTNode BST_LCA_Iterative(BSTNode cur, BSTNode n1, BSTNode n2)
        {
            while(cur != null)
            {
                if(n1.Val < cur.Val && n2.Val < cur.Val)
                    cur = cur.Left;
                else if(n1.Val > cur.Val && n2.Val > cur.Val)
                    cur = cur.Right;
                else
                    return cur;
            }
            return null;
        }

        public BSTNode BST_LCA_Recursive(BSTNode cur, BSTNode n1, BSTNode n2)
        {
            if(n1.Val < cur.Val && n2.Val < cur.Val)
                return BST_LCA_Recursive(cur.Left, n1, n2);
            else if(n1.Val > cur.Val && n2.Val > cur.Val)
                return BST_LCA_Recursive( cur.Right, n1, n2);
            else
                return cur;
        }

      

        public static void TestBST_LCA()
        {
            //int[] nums = {5, 3, 10, 1, 4, 7, 12, };
            int[] nums = {5, 3, 10, 1, 4, 7, 12, 7, 7, 8, 8}; //If you have duplicates like 7 here and 8, it won't work as it find always the first node of 7 Or 8 by value

            BST bst = new BST();
            bst.InitIterative(nums);

            BSTNode n1 = bst.FindIterative(1);
            BSTNode n2 = bst.FindIterative(4);
            BSTNode n3 = bst.FindIterative(12);
            BSTNode n4 = bst.FindIterative(7);
            BSTNode n6 = bst.FindIterative(8);

            BSTNode lca1 = bst.BST_LCA_Iterative(bst.Root, n1, n2);
            if(lca1 != null)
                Console.WriteLine("LCA Found: {0}", lca1.Val);

            BSTNode lca2 = bst.BST_LCA_Iterative(bst.Root, n1, n3);
            if(lca2 != null)
                Console.WriteLine("LCA Found: {0}", lca2.Val);

            BSTNode lca3 = bst.BST_LCA_Iterative(bst.Root, n2, n3);
            if(lca3 != null)
                Console.WriteLine("LCA Found: {0}", lca3.Val);

            BSTNode lca4 = bst.BST_LCA_Iterative(bst.Root, n4, n3);
            if(lca4 != null)
                Console.WriteLine("LCA Found: {0}", lca4.Val);

            BSTNode lca5 = bst.BST_LCA_Iterative(bst.Root, n4, n6);
            if(lca5 != null)
                Console.WriteLine("LCA Found: {0}", lca5.Val);

        }
    }
}