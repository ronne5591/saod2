using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class AVLTree
    {
        public AVLNode root = null;
        public int BigRightRotCount = 0;
        public int BigLeftRotCount = 0;
        public int RightRotCount = 0;
        public int LeftRotCount = 0;
        public void Insert(int value)
        {
            var node = new AVLNode(value);
            root = Insert(root, node);
        }

        AVLNode Insert(AVLNode rt, AVLNode node)
        {
            if (rt == null)
            {
                return node;
            }
            if (node.value < rt.value)
            {
                rt.left = Insert(rt.left, node);
                rt = bTree(rt);
            }
            else
            {
                rt.right = Insert(rt.right, node);
                rt = bTree(rt);
            }
            return rt;
        }

        public AVLNode Left_rotate(AVLNode rt)
        {
            var piv = rt.right;
            rt.right = piv.left;
            piv.left = rt;
            LeftRotCount++;
            return piv;
        }

        public AVLNode Right_rotate(AVLNode rt)
        {
            var piv = rt.left;
            rt.left = piv.right;
            piv.right = rt;
            RightRotCount++;
            return piv;
        }

        public AVLNode BigLeft(AVLNode rt)
        {
            var piv = rt.right;
            rt.right = Right_rotate(piv);
            BigLeftRotCount++;
            return Left_rotate(rt);
        }

        public AVLNode BigRight(AVLNode rt)
        {
            var piv = rt.left;
            rt.left = Left_rotate(piv);
            BigRightRotCount++;
            return Right_rotate(rt);
        }

        int getHeight(AVLNode p)
        {
            int h = 0;
            if(p != null)
            {
                int l = getHeight(p.left);
                int r = getHeight(p.right);
                int m = Math.Max(l, r);
                h = m + 1;
            }
            return h;
        }

        int bfactor(AVLNode p)
        {
            return getHeight(p.left) - getHeight(p.right);
        }

        AVLNode bTree(AVLNode p)
        {
            var f = bfactor(p);
            if (f > 1)
            {
                if(bfactor(p.left) > 0)
                {
                    p = Right_rotate(p);
                }
                else
                {
                    p = BigRight(p);
                }
            }
            else if (f < -1)
            {
                if(bfactor(p.right) > 0)
                {
                    p = BigLeft(p);
                }
                else
                {
                    p = Left_rotate(p);
                }
            }
            return p;
        }

        public List<List<int>> get_lists()
        {
            var lst = new List<List<int>>();
            lst.Add(new List<int>());
            print_tree(root, 0, lst);
            return lst;
        }
        public void print_tree(AVLNode n, int step, List<List<int>> lst)
        {
            if (n.right != null)
            {
                print_tree(n.right, step + 1, lst);
            }
            for (int i = 0; i < step; i++)
                lst.Last().Add(-1);
            lst.Last().Add(n.value);
            lst.Add(new List<int>());
            if (n.left != null)
            {
                print_tree(n.left, step + 1, lst);
            }

        }

        public List<string> get_tree_list()
        {
            List<string> rez = new List<string>();
            var lst = get_lists();
            int max = lst.Max(obj => obj.Count);
            for (int i = 0; i < lst.Count; i++)
            {
                var t = Enumerable.Repeat(-1, max - lst[i].Count).ToList();
                lst[i].AddRange(t);
            }
            var temp = new List<List<int>>();
            for (int i = 0; i < max; i++)
            {
                temp.Add(Enumerable.Repeat(-1, lst.Count).ToList());
            }
            for (int count = 0; count < lst.Count; count++)
            {
                for (int count2 = 0; count2 < max; count2++)
                {
                    temp[count2][lst.Count - count - 1] = lst[count][count2];
                }
            }
            lst = temp;
            int maxValueLength = lst.Max(row => row.Max()).ToString().Length;
            for (int i = 0; i < lst.Count; i++)
            {
                var tt = new System.Text.StringBuilder();
                if (lst[i].Max() < 0)
                    continue;
                for (int j = 0; j < temp[i].Count; j++)
                {
                    if (lst[i][j] == -1)
                    {
                        tt.Append(string.Concat(Enumerable.Repeat(' ', maxValueLength)).ToCharArray());
                    }
                    else
                    {
                        tt.Append(lst[i][j].ToString());
                        tt.Append(string.Concat(Enumerable.Repeat(' ', maxValueLength - lst[i][j].ToString().Length)).ToCharArray());
                    }
                }
                rez.Add(tt.ToString());
            }
            return rez;
        }

        public void PrintRBTree()
        {
            var tmp = get_tree_list();
            var str = tmp.ToArray();
            foreach (string s in str)
            {
                Console.WriteLine(s);
            }
        }
        
        public void Delete(int t)
        {
            root = Delete(root, t);
        }

        public AVLNode Delete(AVLNode c, int t)
        {
            if(c == null)
            {
                return null;
            }
            else
            {
                if(t < c.value)
                {
                    c.left = Delete(c.left, t);
                    c = bTree(c);
                }
                else if (t > c.value)
                {
                    c.right = Delete(c.right, t);
                    c = bTree(c);
                }
                else
                {
                    if(c.right != null)
                    {
                        var p = c.right;
                        while(p.left != null)
                        {
                            p = p.left;
                        }
                        c.value = p.value;
                        c.right = Delete(c.right, p.value);
                        c = bTree(c);
                    }
                    else
                    {
                        return c.left;
                    }
                }
            }
            return c;
        }

        public void PrintRotCount()
        {
            Console.WriteLine("BigRight: {0} | BigLeft: {1} | Right: {2} | Left: {3}", BigRightRotCount, BigLeftRotCount, RightRotCount, LeftRotCount);
        }
    }
}
