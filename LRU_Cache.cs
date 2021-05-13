using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class LRU_Cache
    {
        const int Size = 3;
        public Dictionary<string, DLLNode> Map = new Dictionary<string, DLLNode>(Size);
        public DLinkList LRUList = new DLinkList();

        public bool Get(string key, out int val)
        {
            DLLNode dllNode = null;
            val = 0;

            if(!Map.TryGetValue(key, out dllNode))
                return false;

            LRUList.Delete(dllNode);
            LRUList.AddFirst(dllNode);
            val = dllNode.Val;
            return true;
        }

        public void Put(string key, int val)
        {
            DLLNode dllNode = null;
            
            if(!Map.TryGetValue(key, out dllNode) && Map.Count >= Size)
            {
                DLLNode evictNode = LRUList.GetLast();
                Map.Remove(evictNode.Key);
                LRUList.Delete(evictNode);
            }

            if(dllNode == null)
            {
                dllNode = new DLLNode(key, val);
                Map[key] = dllNode;
            }
            else
            {
                dllNode.Val = val;
                LRUList.Delete(dllNode);
            }

            LRUList.AddFirst(dllNode);
        }


       static public void TestLRU_Cache()
        {
            LRU_Cache lruCache = new LRU_Cache();

            lruCache.Put("K1", 1);
            lruCache.Put("K2", 2);
            lruCache.Put("K3", 3);
            lruCache.Put("K4", 4);

            lruCache.LRUList.Print();

            int val = 0;
            if(lruCache.Get("K1", out val))
                Console.WriteLine("Should NOT have found K1, by adding K4, k1 should have evicted");

            lruCache.Put("K2", 22);
            lruCache.Get("K3", out val);
            lruCache.Put("K5", 5);

            if(lruCache.Get("K4", out val))
                Console.WriteLine("Should NOT have found K4, by updating/accessing K2/k3 and adding K5, K4 (LRUed) should have evicted");

            lruCache.LRUList.Print();
        }
         
    }
}