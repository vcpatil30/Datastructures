using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class Heap
    {
        public const int HEAP_SIZE = 1024 * 10;
        public int[] heap = new int[HEAP_SIZE];
        public int size=0;

        public int Root
        {
            get
            { 
                if(size==0)
                    throw new Exception("Emnpty Heap");

                return heap[0];
            }
        }

        //-------------------------------------MaxHeap functions-------------------------------------
        public void AddMaxHeap(int num)
        {
            if(size>=HEAP_SIZE)
                throw new Exception("Heap Full");

            int cur = size++;
            heap[cur]=num;

            while(true)
            {
                int parent = cur/2;

                if(heap[parent] >= heap[cur]) //no need to swap
                    break;

                int temp = heap[parent];
                heap[parent] =  heap[cur];
                heap[cur] = temp;

                cur = parent;
            }
        }

        public int RemoveFromMaxHeap()
        {
            if(size==0)
                throw new Exception("Empty Heap");

            int root = heap[0];
            heap[0] = heap[--size];
            
            int par = 0;
            while(true)
            {
                int lChild = (par * 2)+1;
                int rChild = (par * 2)+2;
                int swapChild=0;

                if(lChild>=size && rChild >= size)
                    break;
                else if(lChild>=size)
                    swapChild = rChild;
                else if(rChild>=size)
                    swapChild = lChild;
                else 
                    swapChild = heap[lChild] > heap[rChild]? lChild: rChild;

                if(heap[par]>heap[swapChild])
                    break;

                int temp = heap[par];
                heap[par] = heap[swapChild];
                heap[swapChild] = temp;

                par = swapChild;
            }
            return root;
        }

        public void InitMaxHeap(int[] nums)
        {
            foreach(int num in nums)
                AddMaxHeap(num);
        }

        //-------------------------------MinHeap Functions ----------------------------------------------------
        public void AddMinHeap(int num)
        {
            if(size>=HEAP_SIZE)
                throw new Exception("Heap Full");

            int cur = size++;
            heap[cur]=num;

            while(true)
            {
                int parent = cur/2;

                if(heap[parent] <= heap[cur]) //no need to swap
                    break;

                int temp = heap[parent];
                heap[parent] =  heap[cur];
                heap[cur] = temp;

                cur = parent;
            }
        }
        public void InitMinHeap(int[] nums)
        {
            foreach(int num in nums)
                AddMinHeap(num);
        }


        public int RemoveFromMinHeap()
        {
            if(size==0)
                throw new Exception("Empty Heap");

            int root = heap[0];
            heap[0] = heap[--size];
            
            int par = 0;
            while(true)
            {
                int lChild = (par * 2)+1;
                int rChild = (par * 2)+2;
                int swapChild=0;

                if(lChild>=size && rChild >= size)
                    break;
                else if(lChild>=size)
                    swapChild = rChild;
                else if(rChild>=size)
                    swapChild = lChild;
                else 
                    swapChild = heap[lChild] < heap[rChild]? lChild: rChild;

                if(heap[par]<heap[swapChild])
                    break;
                    
                int temp = heap[par];
                heap[par] = heap[swapChild];
                heap[swapChild] = temp;

                par = swapChild;
            }
            return root;
        }

        public void PrintHeap(string heapType)
        {
            Console.WriteLine("Printing heap {0}", heapType);
            for(int i=0; i<size; i++)
            {
                Console.Write("{0},", heap[i]);
            }
            Console.WriteLine("");
        }


        static public void TestMaxHeap()
        {
            int[] nums = new int[]{ 1, 16, 2, 60, 22, 55, 11, 8, 5};


            Console.WriteLine("Original Array: ");
            foreach(int num in nums)
            {
                Console.Write("{0},", num);
            }
            Console.WriteLine("");


            Heap maxHeap = new Heap();
            Heap minHeap = new Heap();

            maxHeap.InitMaxHeap(nums);
            maxHeap.PrintHeap("MaxHeap");

            minHeap.InitMinHeap(nums);
            minHeap.PrintHeap("MinHeap");

            Console.WriteLine("Removing one by one all elements from MaxHeap (Essentially decending sorted order)");
            while(maxHeap.size>0)
            {
                Console.Write("{0},", maxHeap.RemoveFromMaxHeap());
            }
            Console.WriteLine("");

            Console.WriteLine("Removing one by one all elements from MinHeap (Essentially ascending sorted order)");
            while(minHeap.size>0)
            {
                Console.Write("{0},", minHeap.RemoveFromMinHeap());
            }
            Console.WriteLine("");
        }
    }
}