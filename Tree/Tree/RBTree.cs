using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class RBTree
    {
        public RBNode root;

        public void Insert(int value)
        {
            var node = new RBNode(value);
            node.color = true;
            root = Insert(root, node);
            //Fix(ref root, node);
        }

        public RBNode BigLeft(RBNode rt)
        {
            var piv = rt.right;
            rt.right = Right_rotate(piv);
            return Left_rotate(rt);
        }

        public RBNode BigRight(RBNode rt)
        {
            var piv = rt.left;
            rt.left = Left_rotate(piv);
            return Right_rotate(rt);
        }

        RBNode Insert(RBNode rt, RBNode node)
        {
            if (rt == null)
            {
                return node;
            }
            if (node.value < rt.value)
            {
                rt.left = Insert(rt.left, node);
                rt.left.parent = rt;
            }
            else
            {
                rt.right = Insert(rt.right, node);
                rt.right.parent = rt;
            }
            return rt;
        }

        public RBNode Left_rotate(RBNode rt)
        {
            var piv = rt.right;
            rt.right = piv.left;
            piv.left = rt;
            return piv;
        }

        public RBNode Right_rotate(RBNode rt)
        {
            var piv = rt.left;
            rt.left = piv.right;
            piv.right = rt;
            return piv;
        }

        public void rotLeft(ref RBNode rt, RBNode q)
        {
            var piv = q.right;
            if(q.right != null)
            {
                q.right.parent = q;
            }
            piv.parent = q.parent;
            if (q.parent == null)
            {
                rt = piv;
            }
            else if(q == q.parent.left)
            {
                q.parent.left = piv;
            }
            else
            {
                q.parent.right = piv;
            }
            piv.left = q;
            q.parent = piv;
        }

        public void Fix(ref RBNode rt, RBNode q)
        {
            while ((q != rt)&&(q.color)&&(q.parent.color))
            {
                var p_q = q.parent;
                var grandParent = q.parent.parent;
                if(p_q != grandParent.left)
                {
                    var uncle = grandParent.left;
                    if ((uncle != null) && (uncle.color))
                    {
                        grandParent.color = true;
                        p_q.color = false;
                        uncle.color = false;
                        q = grandParent;
                    }
                    else
                    {
                        rotLeft(ref rt, grandParent);
                        var tc = p_q.color;
                        p_q.color = grandParent.color;
                        grandParent.color = tc;
                        q = p_q;
                    }
                }
            }
            rt.color = false;
        }

        public int PrintTree()
        {
            if (root == null)
            {
                return 0;
            }
            var q = new Queue<Tuple<RBNode, int>>();
            int lvl = 0;
            q.Enqueue(new Tuple<RBNode, int>(root, 1));

            while (q.Count != 0)
            {
                var nl = q.Dequeue();
                if (nl.Item1 != null)
                {
                    if (nl.Item2 != lvl)
                    {
                        if (nl.Item1.color)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        Console.Write("\nLevel " + nl.Item2 + ": ");
                        lvl = nl.Item2;
                        Console.ResetColor();
                    }
                    if (nl.Item1.color)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write(nl.Item1.value + " ");
                    q.Enqueue(new Tuple<RBNode, int>(nl.Item1.left, lvl + 1));
                    q.Enqueue(new Tuple<RBNode, int>(nl.Item1.right, lvl + 1));
                    Console.ResetColor();
                }
            }
            return lvl;
        }
        public void ptr()
        {
            var lst = get_tree_list();
            foreach(var t in lst)
            {
                Console.WriteLine(t);
            }
        }
        public List<List<int>> get_lists()
        {
            var lst = new List<List<int>>();
            lst.Add(new List<int>());
            print_tree(root, 0, lst);
            return lst;
        }
        public void print_tree(RBNode n, int step, List<List<int>> lst)
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
    }
}
