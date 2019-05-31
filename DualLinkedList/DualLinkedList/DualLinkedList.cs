using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualLinkedList
{
    class DualLinkedList<T>
    {
        public ListNode<T> first = null;
        public ListNode<T> last = null;
        int count = 0;

        public void AddFirst(T value)
        {
            if(count == 0)
            {
                first = new ListNode<T>(value);
                last = first;
            }
            else
            {
                first.Prev = new ListNode<T>(value);
                first.Prev.Next = first;
                first = first.Prev;
            }
            count++;
        }

        public void AddLast(T value)
        {
            if (count == 0)
            {
                first = new ListNode<T>(value);
                last = first;
            }
            else
            {
                last.Next = new ListNode<T>(value);
                last.Next.Prev = last;
                last = last.Next;
            }
            count++;
        }

        public void InsertAt(int index, T value)
        {
            if(index == 0)
            {
                AddFirst(value);
            }
            else if(index == count)
            {
                AddLast(value);
            }
            else if (count > 0 && index < count)
            {
                if(index < count / 2)
                {
                    var temp = first;
                    int i = 0;
                    while (temp.Next != null)
                    {
                        if(i == index)
                        {
                            var s1 = temp.Prev;
                            var s2 = temp;
                            var toAdd = new ListNode<T>(value);
                            s1.Next = toAdd;
                            toAdd.Prev = s1;
                            s2.Prev = toAdd;
                            toAdd.Next = s2;
                            count++;
                        }
                        i++;
                        temp = temp.Next;
                    }
                }
                else
                {
                    var temp = last;
                    int i = count - 1;
                    while (temp.Prev != null)
                    {
                        if (i == index)
                        {
                            var s1 = temp.Prev;
                            var s2 = temp;
                            var toAdd = new ListNode<T>(value);
                            s1.Next = toAdd;
                            toAdd.Prev = s1;
                            s2.Prev = toAdd;
                            toAdd.Next = s2;
                            count++;
                        }
                        i--;
                        temp = temp.Prev;
                    }
                }
            }
        }

        public void WriteList()
        {
            var temp = first;

            while (temp != null)
            {

                Console.Write("{0} -> ", temp.value);
                temp = temp.Next;
            }
            Console.Write("null\n");
        }

    }
}
