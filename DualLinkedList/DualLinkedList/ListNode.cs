using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualLinkedList
{
    class ListNode<T>
    {
        public ListNode<T> Next = null;
        public ListNode<T> Prev = null;
        public T value;

        public ListNode(T value)
        {
            this.value = value;
        }
    }
}
