using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DualLinkedList<int> list = new DualLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.WriteList();
            list.InsertAt(2, 9);
            list.WriteList();
        }
    }
}
