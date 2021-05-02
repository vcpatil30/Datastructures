using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class BinarySearch
    {
        static public int Find(int l, int h, int num, int[] nums)
        {
            if(l==h)
            {
                if(num == nums[l])
                    return l;
                else
                    return -1;
            }

            int mid = (l+h)/2;
            if(nums[mid] == num)
                return mid;

            if(num <= nums[mid])
                return Find(l, mid-1, num, nums);
            else
                return Find(mid+1, h, num, nums);
        }

        static public int Find(int num, int[] nums)
        {
            return Find(0,nums.Length-1, num, nums);
        }

        static public void Test()
        {
            int arraySize = 100000, minRange = 0, maxRange = 100, absentNum = maxRange+1;
            int[] nums = Utility.GenerateRandomNumbers(arraySize, minRange, maxRange); 
            QuickSort.Sort(nums);

            while(true)
            {
                Random random = new Random();
                int i = random.Next(0, nums.Length-1);

                int index = Find(nums[i], nums);
                if(index == -1)
                    Console.WriteLine("ERROR: Should have found but Not found");

                index = Find(absentNum, nums);
                if(index != -1)
                    Console.WriteLine("ERROR: Should NOT have found but somehow Found");
                
                Console.WriteLine(".");
            }
        }
    }
}