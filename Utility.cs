using System;
using System.Collections.Generic;
using System.Text;

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

     

        //PrintTree Helpers
        static public void PrintEmptyCells(int num)
        {
            for(int i=0; i<num; i++)
            {
                Console.Write(" ");
            }
        }


        static public int CalculateGap(int n)
        {
            int gap =0;

            for(int i=0; i<n; i++)
            {
                gap = (gap * 2) + 2;
            }
            return gap;
        }


        static public void PrintTree(BTNode node)
        {
            Dictionary<int, List<string>> treeValues = new Dictionary<int, List<string>>();
            PrintTree(node,0,treeValues);

            int height = treeValues.Count-1; 

            for(int level=0; level<height; level++)
            {
                int gapCells = CalculateGap(height-level);
                PrintEmptyCells(gapCells/2); 

                List<string> levelVals = treeValues[level];
                foreach(string val in levelVals)
                {
                    Console.Write("{0,2}", val);
                    PrintEmptyCells(gapCells); 
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static public void PrintTree(BTNode node, int level, Dictionary<int, List<string>> treeValues)
        {
            List<string> levelValues;
            if(!treeValues.TryGetValue(level, out levelValues))
            {
                levelValues = new List<string>();
                treeValues[level] = levelValues;
            }

            if(node==null)
            {
                levelValues.Add("nl");
                return;
            }
            else
            {
                levelValues.Add(node.Val.ToString());
            }

            
            PrintTree(node.Left, level+1,  treeValues);
            PrintTree(node.Right, level+1,  treeValues);
        }
    }
}
