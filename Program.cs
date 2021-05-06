using System;


namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearch.Test();
            //BST.TestZigZagAndLevelOrder();
            //BST.TestCountGoodNodesInBinaryTree();
            //BST.TestBST_LCA();
            //BST.TestBSTRecursive();
            //Heap.TestMaxHeap();
            //MedianOfStream.TestMedian();
            //SLinkList.TestSLinkList();
            
            //DLinkList.TestDLinkList();
            //BT.TestBinaryTree();
            //BT.TestDeSerializeTree();
            //BT.TestDiffBetweenEvenAndOddLevelNodes();
            //BT.TestGoodNodes();
            BT.TestInvert();
        }

        static void QuickSortMain(string[] args)
        {
            int[] nums = null;

            while(true)
            {
                try
                {
                    nums = Utility.GenerateRandomNumbers(100000, 1, 100);
                    QuickSort.Sort(nums);
                    Console.WriteLine(".");

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    Utility.Print(nums);
                }
            }

        }
    }
}
