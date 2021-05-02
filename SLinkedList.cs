using System;
using System.Collections.Generic;

namespace DataStructure
{
    public partial class SLLNode
    {
        public int Val;
        public SLLNode Next;

        public SLLNode(int val)
        {
            this.Val = val;
            this.Next = null;
        }
    }

    public partial class SLinkList
    {
        public SLLNode Head = new SLLNode(0);
        public int Size;
 
        public void AddAt(int index, int val)
        {
            SLLNode pred = Head, newNode = new SLLNode(val);

            for(int i=0; i<index; i++)
            {
                pred = pred.Next;
            }

            newNode.Next = pred.Next;
            pred.Next = newNode;
            this.Size ++;
        }

        public void Delete(int index)
        {
            SLLNode pred = Head, cur = Head.Next;

            for(int i=0; i<index; i++)
            {
                pred = pred.Next;
            }
            pred.Next = pred.Next.Next;
        }

        public void Print()
        {
            SLLNode cur = this.Head.Next;

            while(cur != null)
            {
                Console.Write("{0},", cur.Val);
                cur = cur.Next;
            }
            Console.WriteLine("");
        }
 
        static public void TestSLinkList()
        {
            SLinkList ll = new SLinkList();

            ll.AddAt(0, 0);
            ll.AddAt(1, 1);
            ll.AddAt(2, 2);
            ll.AddAt(3, 3);
            ll.AddAt(4, 4);

            ll.Print();
            ll.Delete(2);
            ll.Print();
        }
    }


    
}