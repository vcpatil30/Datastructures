using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class DLLNode
    {
        public int Val;
        public DLLNode Next;
        public DLLNode Prev;

        public DLLNode(int val)
        {
            this.Val = val;
            this.Next = null;
            this.Prev = null;
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

        public void AddAt(int index, int val)
        {
            DLLNode pred = Head, succ=null, newNode = new DLLNode(val);
            
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

            dl.AddAt(0, 0);
            dl.AddAt(1, 1);
            dl.AddAt(2, 2);
            dl.AddAt(3, 3);
            dl.AddAt(4, 4);

            dl.Print();
            dl.Delete(2);
            dl.Print();
        }
    }


    
}