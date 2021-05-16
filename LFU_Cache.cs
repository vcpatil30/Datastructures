using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class LFU_Cache
    {
        int Size;
        //int MinFrequency;
        public Dictionary<string, DLLNode> KVMap;   //Store Key Value
        public SortedDictionary<int, DLinkList> FrequencyMap;  //Store all values by frequency

        public LFU_Cache(int size)
        {
            //MinFrequency = 1;
            Size = size;
            KVMap = new Dictionary<string, DLLNode>(Size);   //Store Key Value
            FrequencyMap = new SortedDictionary<int, DLinkList>();  //Store all values by frequency ToDo: Can we avoid sorted dictionary???
        }

        public bool Get(string key, out int val)
        {
            DLLNode dllNode = null;
            val = 0;

            if(!KVMap.TryGetValue(key, out dllNode))
                return false;

            val = dllNode.Val;
            UpdateFrequency(dllNode);
            return true;
        }

        public void Evict()
        {
            List<int> emptyFreq = new List<int>();
            bool evicted = false;

            //if(FrequencyMap.TryGetValue(this.MinFrequency, out freqList)) //get linked list of LFU (basically start from 1, 2, 3... max is total number of keysused once, hence hard code 1)
            foreach(KeyValuePair<int, DLinkList> kvp in FrequencyMap) //sorted order
            {                                      
                if(!evicted && kvp.Value.Size != 0)
                {                
                    DLLNode dllNode = kvp.Value.DeleteLast();
                    if(null != dllNode)
                        KVMap.Remove(dllNode.Key);
                    
                    evicted = true;
                }

                if(kvp.Value.Size == 0) //If already empty lits, delete them
                    emptyFreq.Add(kvp.Key);
            }

            foreach(int freq in emptyFreq)
            {
                FrequencyMap.Remove(freq); 
            }

        }

        public void UpdateFrequency(DLLNode dllNode)
        {
            DLinkList oldFreqList = null;
            DLinkList newFreqList = null;

            if(dllNode.Frequency != 0 && FrequencyMap.TryGetValue(dllNode.Frequency, out oldFreqList))
            {
                oldFreqList.Delete(dllNode);
                // if(oldFreqList.Size == 0)
                // {
                //     FrequencyMap.Remove(dllNode.Frequency);
                //     if(MinFrequency == dllNode.Frequency)
                //         MinFrequency ++;
                // }
            }

            dllNode.Frequency++;
            if(FrequencyMap.TryGetValue(dllNode.Frequency, out newFreqList))
            {
                newFreqList.AddFirst(dllNode);
            }
            else
            {
                newFreqList = new DLinkList();
                newFreqList.AddFirst(dllNode);
                FrequencyMap[dllNode.Frequency] = newFreqList;
            }
        }

        public void Put(string key, int val)
        {
            DLLNode dllNode = null;
            
            if(!KVMap.TryGetValue(key, out dllNode) && KVMap.Count >= Size)
            {
                Evict();
            }

            if(dllNode == null)
            {
                dllNode = new DLLNode(key, val);
                KVMap[key] = dllNode;
            }
            else
            {
                dllNode.Val = val;      //Update value
            }
            UpdateFrequency(dllNode);
        }

        public void PrintFrequencies()
        {
            Console.WriteLine("-----------------------");
            foreach(KeyValuePair<int,DLinkList> kvp in this.FrequencyMap)
            {
                Console.Write($"[Frequency-{kvp.Key}]: ");
                kvp.Value.Print();
            }
        }

       static public void TestLFU_Cache()
        {
            LFU_Cache lfuCache = new LFU_Cache(3);

            lfuCache.Put("K1", 1);
            lfuCache.Put("K2", 2);
            lfuCache.Put("K3", 3);

            lfuCache.PrintFrequencies();

            lfuCache.Put("K4", 4);

            lfuCache.PrintFrequencies();

            int val = 0;
            if(lfuCache.Get("K1", out val))
                Console.WriteLine("Should NOT have found K1, by adding K4, k1 should have evicted");

            lfuCache.Put("K2", 22);
            lfuCache.Get("K3", out val);
            lfuCache.Get("K3", out val);

            lfuCache.PrintFrequencies();

            lfuCache.Put("K5", 5);

            lfuCache.PrintFrequencies();
            lfuCache.Get("K5", out val);
            lfuCache.PrintFrequencies();

            lfuCache.Put("K6", 6); //This should evict from Frequency 2

            lfuCache.PrintFrequencies();

            if(lfuCache.Get("K4", out val))
                Console.WriteLine("Should NOT have found K4, by updating/accessing K2/k3 and adding K5, K4 (LFUed) should have evicted");
        }
         
       static public void TestLFU_Cache_MinFrequencyTest()
        {
            LFU_Cache lfuCache = new LFU_Cache(3);

            lfuCache.Put("K1", 1);
            lfuCache.Put("K1", 11);
            lfuCache.Put("K1", 111);
            lfuCache.Put("K2", 2);
            lfuCache.Put("K2", 22);
            lfuCache.Put("K2", 222);
            lfuCache.Put("K3", 3);
            lfuCache.Put("K3", 33);
            lfuCache.Put("K3", 333);

            lfuCache.PrintFrequencies();

            lfuCache.Put("K4", 4);

            lfuCache.PrintFrequencies();
       }

       static public void TestLFU_Cache_Stress()
        {
            LFU_Cache lfuCache = new LFU_Cache(50);
            Random random1 = new Random();
            Random random2 = new Random();
            
            for(int i=0; i<100000; i++)
            {
                int val, key = random1.Next(1, 100);
                lfuCache.Put(key.ToString(), key);

                key = random2.Next(10, 100);
                lfuCache.Get(key.ToString(), out val);
                key = random2.Next(10, 100);
                lfuCache.Get(key.ToString(), out val);
            }

            lfuCache.PrintFrequencies();
            Console.WriteLine($"Total KVMap Keys: {lfuCache.KVMap.Count}, Total Frequency Keys: {lfuCache.FrequencyMap.Count}");
       }
    }
}