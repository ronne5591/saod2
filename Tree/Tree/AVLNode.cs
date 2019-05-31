using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class AVLNode
    {
        public int value;
        public AVLNode left;
        public AVLNode right;
        public AVLNode(int value)
        {
            this.value = value;
        }
    }
}
