using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class MedianOfStream
    {
        public Heap minHeap = new Heap();
        public Heap maxHeap = new Heap();

        public void AddNumber(int num)
        {
            maxHeap.AddMaxHeap(num);
            if(maxHeap.size > minHeap.size + 1)
            {
                int maxNum = maxHeap.RemoveFromMaxHeap();
                minHeap.AddMinHeap(maxNum);
            }
        }

        public void PrintMedian()
        {
            int tot = maxHeap.size + minHeap.size;
            if(tot%2 == 0) //even
                Console.WriteLine("Median: {0}, {1}", maxHeap.Root, minHeap.Root);
            else 
                Console.WriteLine("Median: {0}", maxHeap.Root);
        }

        static public  void TestMedian()
        {
            int[] nums = new int[]{ 1, 16, 2, 60, 22, 55, 11, 8, 5, 3};
            MedianOfStream median = new MedianOfStream();
            
            foreach(int num in nums)
                median.AddNumber(num);

            median.PrintMedian();

            Heap heap = new Heap();
            heap.InitMinHeap(nums);

            Console.WriteLine("Removing one by one all elements from MinHeap (Essentially decending sorted order)");
            while(heap.size>0)
            {
                Console.Write("{0},", heap.RemoveFromMinHeap());
            }
            Console.WriteLine("");

        }

    }
    
}
