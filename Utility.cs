using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class Utility
    {
        static public int[] GenerateRandomNumbers(int totalNums, int lowRange, int highRange)
        {
            int[] nums = new int[totalNums];
            Random random = new Random();

            for(int i=0; i<totalNums; i++)
            {
                nums[i] = random.Next(lowRange, highRange);
            }
            return nums;
        }

        static public void Print(List<int> nums)
        {
            Print(nums.ToArray());
        }
        static public void Print(int[] nums)
        {
            foreach(int i in nums)
            {
                Console.Write("{0},", i);
            }
            Console.WriteLine("");
        }
    }
}
