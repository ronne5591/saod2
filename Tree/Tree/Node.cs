using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node
    {
        public int value;
        public Node left = null;
        public Node right = null;
        public Node()
        {

        }

        public Node(int value)
        {
            this.value = value;
        }
    }
}
