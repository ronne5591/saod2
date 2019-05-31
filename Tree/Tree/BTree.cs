using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class BTree
    {
        public Node root = null;

        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                Insert(value, root);
            }
        }

        public void Insert(int value, Node node)
        {
            if (value < node.value)
            {
                if (node.left == null)
                {
                    node.left = new Node(value);
                }
                else
                {
                    Insert(value, node.left);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new Node(value);
                }
                else
                {
                    Insert(value, node.right);
                }
            }
        }

        public void PrintTree()
        {
            if (root == null)
            {
                return;
            }
            var q = new Queue<Tuple<Node, int>>();
            int lvl = 0;
            q.Enqueue(new Tuple<Node, int>(root, 1));

            while (q.Count != 0)
            {
                var nl = q.Dequeue();
                if (nl.Item1 != null)
                {
                    if (nl.Item2 != lvl)
                    {
                        Console.Write("\nLevel " + nl.Item2 + ": ");
                        lvl = nl.Item2;
                    }
                    Console.Write(nl.Item1.value + " ");
                    q.Enqueue(new Tuple<Node, int>(nl.Item1.left, lvl + 1));
                    q.Enqueue(new Tuple<Node, int>(nl.Item1.right, lvl + 1));
                }
            }
        }

        public List<int> PrintTree(bool b)
        {
            var list = new List<int>();
            pr(root, 0, list);
            return list;
        }
        int[,] matrix;
        void pr(Node node, int s, List<int> list)
        {
            if (node.left != null)
            {
                pr(node.left, s + 2, list);
            }
            list.Add(node.value);
            Console.Write(node.value + " ");
            Console.WriteLine();
            if (node.right != null)
            {
                pr(node.right, s + 2, list);
            }

        }

        int height(Node p)
        {
            if (p == null)
            {
                return 0;
            }
            return 1 + Math.Max(height(p.left), height(p.right));
        }

        public int GetHeight()
        {
            return height(root);
        }

        public void Clear()
        {
            root = null;
        }

        public int MaxValueItr()
        {
            var temp = root;
            int max = root.value;
            while (temp.right != null)
            {
                if (max < temp.right.value)
                {
                    max = temp.right.value;
                }
                temp = temp.right;
            }
            return max;
        }

        public int MinValueItr()
        {
            var temp = root;
            int min = root.value;
            while (temp.left != null)
            {
                if (min > temp.left.value)
                {
                    min = temp.left.value;
                }
                temp = temp.left;
            }
            return min;
        }

        public int MaxValueRec(Node node)
        {
            if (node.right == null)
            {
                return node.value;
            }
            return MaxValueRec(node.right);
        }

        public int GetMaxValueRec()
        {
            return MaxValueRec(root);
        }

        public int MinValueRec(Node node)
        {
            if (node.left == null)
            {
                return node.value;
            }
            return MinValueRec(node.left);
        }

        public int GetMinValueRec()
        {
            return MinValueRec(root);
        }

        public List<List<int>> get_lists()
        {
            var lst = new List<List<int>>();
            lst.Add(new List<int>());
            print_tree(root, 0, lst);
            return lst;
        }
        public void print_tree(Node n, int step, List<List<int>> lst)
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

        public void change()
        {
            root = build(root);
        }

        Node build(Node p)
        {
            var lst = new List<Node>();
            store(p, lst);
            Console.WriteLine(lst.Count);
            return rebuild(lst, 0, lst.Count - 1);
        }

        void store(Node p, List<Node> lst)
        {
            if(p == null)
            {
                return;
            }
            store(p.left, lst);
            lst.Add(p);
            store(p.right, lst);
        }

        Node rebuild(List<Node> lst, int s, int e)
        {
            if (s > e)
            {
                return null;
            }
            int m = (s + e) / 2;
            Node p = lst[m];
            p.left = rebuild(lst, s, m - 1);
            p.right = rebuild(lst, m + 1, e);
            return p;
        }
    }
}
