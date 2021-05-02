using System;
using System.Collections.Generic;

namespace DataStructure
{

//-----------------------------------------This is not tested at all----------------------------------------
//-----------------------------------------This is not tested at all----------------------------------------


    public partial class General
    {
        //1647. Minimum Deletions to Make Character Frequencies Unique
        /*
            Input: s = "abaac", cost = [1,2,3,4,5]
            Output: 3
            Explanation: Delete the letter "a" with cost 3 to get "abac" (String without two identical letters next to each other).

            Input: s = "aabaa", cost = [1,2,3,4,1]
            Output: 2
            Explanation: Delete the first and the last character, getting the string ("aba").

        */

    public int Solution(int[] A) 
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach(int num in A)
        {
            map[num] = 0;
        }

        for(int i=1; i<A.Length; i++)
        {
            int temp = 0;
            if(!map.TryGetValue(i, out temp))
                return i;
        }
        return 0;
    }

            public int MinCost(string s, int[] cost)
            {
                int n = s.Length, gsum=0, gmax=0, ans=0;
                for(int i=0; i<n; i++)
                {
                    if(i>0 && s[i] != s[i-1])
                    {
                        ans += gsum - gmax;
                        gsum=0;
                        gmax=0;
                    }
                    gsum = cost[i];
                    gmax = gmax>cost[i]?gmax:cost[i];
                }
                ans+= gsum = gmax;
                return ans;
            }
    }
}