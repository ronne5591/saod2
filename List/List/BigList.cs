using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class BigList<T> : IEnumerable
    {
        public int count;
        public ListNode<T> head;
        public ListNode<T> last;

        public BigList()
        {
            count = 0;
            head = null;
        }

        public void Add(T value)
        {
            ListNode<T> toAdd = new ListNode<T>(value);
            if (count == 0)
            {
                head = toAdd;
                last = toAdd;
            }
            else
            {
                var temp = head;
                while(temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = toAdd;
                last = toAdd;
            }
            count++;
        }

        public void AddFirst(T value)
        {
            ListNode<T> toAdd = new ListNode<T>(value);
            if (head == null)
            {
                head = toAdd;
                last = head;
            }
            else
            {
                toAdd.Next = head;
                head = toAdd;
            }
            count++;
        }

        public void AddLast(T value)
        {
            
            if(count == 0)
            {
                AddFirst(value);
                count++;
                return;
            }
            ListNode<T> toAdd = new ListNode<T>(value);
            last.Next = toAdd;
            last = toAdd;
            count++;
        }

        public void Insert(T value, int index)
        {
            if(index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            ListNode<T> toAdd = new ListNode<T>(value);
            var temp = head;
            if (index == 0)
            {
                toAdd.Next = head;
                head = toAdd;
                count++;
                return;
            }
            else if(index == count - 1)
            {
                last.Next = toAdd;
                last = toAdd;
                count++;
                return;
            }
            for(int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            toAdd.Next = temp.Next;
            temp.Next = toAdd;
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var temp = head;
            if (index == 0)
            {
                head = head.Next;
                count--;
                return;
            }
            else if (index == count - 1)
            {
                while(temp.Next != last)
                {
                    temp = temp.Next;
                }
                temp.Next = null;
                last = temp;
                count--;
                return;
            }
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            temp.Next = temp.Next.Next;
            count--;
        }

        public ListNode<T> GetFirst()
        {
            return head;
        }

        public ListNode<T> GetLast()
        {
            return last;
        }

        public void Clear()
        {
            head = null;
            last = null;
            count = 0;
        }

        public int IndexOf(T value)
        {
            var temp = head;
            int i = 0;
            while(temp != null)
            {
                if (temp.value.Equals(value))
                {
                    return i;
                }
                temp = temp.Next;
                i++;
            }
            return -1;
        }

        public T Find(int index)
        {
            var temp = head;
            int i = 0;
            while (temp != null)
            {
                if (i == index)
                {
                    return temp.value;
                }
                temp = temp.Next;
                i++;
            }
            T badResult = default(T);
            return badResult;
        }

        public int Size()
        {
            return count;
        }

        public void WriteList()
        {
            var temp = head;

            while(temp != null)
            {
                
                Console.Write("{0} -> ", temp.value);
                temp = temp.Next;
            }
            Console.Write("null\n");
        }

        public void Set(int index, T value)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var temp = head;
            int i = 0;
            while (temp != null)
            {
                if (i == index)
                {
                    temp.value = value;
                }
                temp = temp.Next;
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= count; ++i)
                yield return this[i];

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                return Find(index);
            }
            set
            {
                Set(index, value);
            }
        }

    }
}
