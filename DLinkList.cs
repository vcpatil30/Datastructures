using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class DLLNode
    {
        public int Val;
        public string Key; //Added only for LRU Cache 
        public int Frequency; //Added only for LFU Cache 
        public DLLNode Next;
        public DLLNode Prev;

        public DLLNode(string key, int val) //Added only for LRU & LFU Cache 
        {
            this.Key = key;
            this.Val = val;
            this.Next = this.Prev = null;
            this.Frequency = 0;             //Only for LFU Cache
        }

        public DLLNode(int val)
        {
            this.Val = val;
            this.Next = this.Prev = null;
        }
    }

    public partial class DLinkList
    {
        public DLLNode Head = new DLLNode(0);
        public DLLNode Tail = new DLLNode(0);
        public int Size;
 
        public DLinkList()
        {
            Head.Next = Tail;
            Tail.Prev = Head;
        }

        public void AddAt(int index, int val) //index starts at 0
        {
            DLLNode pred = Head, succ=null, newNode = new DLLNode(val);
            if(index>Size)
                index = Size;

            for(int i=0; i<index; i++)
            {
                pred = pred.Next;
            }
            succ = pred.Next;

            newNode.Prev = pred;
            newNode.Next = succ;
            pred.Next = newNode;
            succ.Prev = newNode;
            this.Size ++;
        }

        public void AddFirst(DLLNode newNode)
        {
            DLLNode pred = Head, succ=Head.Next;
            
            newNode.Prev = pred;
            newNode.Next = succ;
            pred.Next = newNode;
            succ.Prev = newNode;
            this.Size ++;
        }

        public void Delete(int index)
        {
            DLLNode pred = Head, succ=null;
                 
            for(int i=0; i<index; i++)
            {
                pred = pred.Next;   
            }
            succ = pred.Next.Next;

            pred.Next = succ;
            succ.Prev = pred;
            this.Size--;
        }

        public bool Delete(DLLNode delNode)
        {
            DLLNode pred = delNode.Prev, succ=delNode.Next;

            if(pred == null || succ == null )
                return false; //Can NOT delete Head Or Tail

            pred.Next = succ;
            succ.Prev = pred;
            this.Size--;
            return true;
        }

        public DLLNode DeleteLast()
        {
            DLLNode dLLNode = GetLast();
            if(Delete(dLLNode))
                return dLLNode;
            else 
                return null;
        }

        public DLLNode GetLast()
        {
            return this.Tail.Prev;
        }

        public void Print()
        {
            DLLNode cur = this.Head.Next;

            for(int i=0; i<Size; i++)
            {
                Console.Write("{0},", cur.Val);
                cur = cur.Next;
            }
            Console.WriteLine("");
        }
 
        static public void TestDLinkList()
        {
            DLinkList dl = new DLinkList();

            dl.AddAt(1, 1);
            dl.AddAt(0, 0);
            dl.AddAt(2, 2);
            dl.AddAt(3, 3);
            dl.AddAt(4, 4);

            dl.Print();
            dl.Delete(2);
            dl.DeleteLast();
            dl.Print();
        }
    }


    
}