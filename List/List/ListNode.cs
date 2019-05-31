using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class ListNode<T>
    {
        public T value;
        public ListNode<T> Next;

        public ListNode(T value)
        {
            this.value = value;
        }
    }
}
