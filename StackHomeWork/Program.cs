using StackApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp
{
    public class MyLinkedList<T>
    {
        public Elem<T> First { get; set; }


        public void AddFirst(T item)
        {
            Elem<T> newElem = new Elem<T>();
            newElem.Info = item;
            newElem.Next = First;

            First = newElem;
        }

        public void AddLast(T item)
        {
            if (First == null)
            {
                AddFirst(item);
                return;
            }
            var el = First;
            while (el.Next != null)
                el = el.Next;

            el.Next = new Elem<T> { Info = item };
        }

        public void RemoveValue(T x)
        {
            while (First != null && First.Info.Equals(x))
            {
                First = First.Next;
            }
            if (First == null)
            {
                return;
            }

            var elem = First;
            while (elem.Next != null)
            {
                if (elem.Next.Info.Equals(x))
                    elem.Next = elem.Next.Next;
                else
                    elem = elem.Next;
            }
        }

        public void RemoveAtIndex(int k)
        {
            if (First == null) { return; }
            if (k == 0)
            {
                First = First.Next;
                return;
            }
            int index = 0;
            var current = First;
            while (First != null)
            {
                if (index == k - 1)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                index++;
                current = current.Next;
            }
            
            
        }

        public void Clear() { First = null; }

        public int Count()
        {
            int counter = 0;
            if (First == null) { return counter; }
            
            while (First != null)
            {
                counter++;
                First = First.Next;
            }
            return counter;
        }


        public bool Contains(T item)
        {
            var current = First;
            while (current != null)
            {
                if (current.Info.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public bool CountOfValue(T item)
        {
            int counterValue = 0;
            if (First == null) { return counterValue; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var el = First;
            while (el != null)
            {
                sb.Append($"{el.Info} -> ");
                el = el.Next;
            }
            sb.Append("null");
            return sb.ToString();
        }



    }

    public class Elem<T>
    {
        public T Info { get; set; }
        public Elem<T> Next { get; set; }
    }

    public class Program
    {
       static void Main()
        {
            MyLinkedList<int> lst = new MyLinkedList<int>();

            for (int i = 0; i < 10; i++)
                lst.AddLast(5);

            lst.AddLast(6);
            for (int i = 0; i < 10; i++)
                lst.AddLast(5);


            Console.WriteLine(lst);
            lst.RemoveValue(5);
            Console.WriteLine(lst);



            MyLinkedList<string> l2 = new MyLinkedList<string>();

            l2.AddLast("a");
            l2.AddLast("abc");
            l2.AddLast("xxx");
            l2.AddLast("zzz");

            Console.WriteLine(l2);
            l2.RemoveValue("a");
            Console.WriteLine(l2);
        }

    }
}

