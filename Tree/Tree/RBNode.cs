using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class RBNode
    {
        public int value;
        public bool color;
        public RBNode parent;
        public RBNode left;
        public RBNode right;
        public RBNode(int value)
        {
            this.value = value;
        }

    }
}
