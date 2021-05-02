using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class QuickSort
    {

        static public int Partition(int[] nums,  int l, int h)
        {
            int pivot = nums[l]; //probably you can take piot as a middle number pibot=num[(l+h)/2)], this will help the worst case scenario timing (which is if the array is already sorted)
            int i = l, j = h;

            int temp = 0;

            while(i<j)
            { 
                while(nums[i]<=pivot && i<h) 
                    i++;
                
                while(nums[j]>pivot && j>0) 
                    j--;
                
                if(i<j) //swap
                {
                    temp = nums[i] ;
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }

            temp = nums[l] ;
            nums[l] = nums[j];
            nums[j] = temp;

            return j;
        }


        static public void Sort(int[] nums, int l, int h)
        {
            if(l<h)
            {
                int j = Partition(nums, l, h);
                Sort(nums, l, j-1);
                Sort(nums, j+1, h);
            }
        }

        static public void Sort(int[] nums)
        {
            //Print(nums);
            Sort(nums, 0, nums.Length-1);
            //Print(nums);
        }
 

    }
}