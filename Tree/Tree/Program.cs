using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*BTree tree = new BTree();
            int values_count = 15;
            int[] values = new int[values_count];
            for(int i = 0; i < values_count; i++)
            {
                values[i] = i;
            }
            Random rnd = new Random(1234);
            
            values = values.OrderBy(x => rnd.Next()).ToArray();

            foreach (int temp in values)
            {
                tree.Add(temp);
            }
            //var list2 = tree.PrintTree(true);
            
            tree.change();
            var list = tree.get_tree_list();
            foreach (var lst in list)
            {
                Console.WriteLine(lst);
            }
            tree.PrintTree();
            Console.WriteLine();
            Console.WriteLine("Высота: " + tree.GetHeight());
            Console.WriteLine("Максимальный элемент: " + tree.GetMaxValueRec());
            Console.WriteLine("Минимальный элемент: " + tree.GetMinValueRec());
            */
            /*RBTree tree = new RBTree();
            int values_count = 15;
            int[] values = new int[values_count];
            for (int i = 0; i < values_count; i++)
            {
                values[i] = i;
            }
            Random rnd = new Random(12534);

            values = values.OrderBy(x => rnd.Next()).ToArray();

            foreach (int temp in values)
            {
                tree.Insert(temp);
            }
            */
            //tree.PrintTree();
            var tree2 = new AVLTree();
            tree2.Insert(1);
            tree2.Insert(0);

            tree2.Insert(8);
            
            tree2.Insert(5);
            tree2.PrintRotCount();
            tree2.PrintRBTree();
            Console.Write("\n");
            tree2.Insert(10);
            tree2.PrintRotCount();
            tree2.PrintRBTree();
            Console.Write("\n");
            tree2.Insert(6);
            tree2.PrintRotCount();
            tree2.PrintRBTree();
            Console.Write("\n");
            /*tree2.Insert(4);
            tree2.PrintRBTree();
            Console.Write("\n");

            tree2.PrintRBTree();*/
            Console.Write("\n");
            tree2.PrintRotCount();
            tree2.Insert(2);
            tree2.Insert(3);
            
            tree2.PrintRBTree();
            Console.Write("\n");
            tree2.PrintRotCount();
            tree2.Delete(5);
            tree2.PrintRBTree();
            Console.Write("\n");
            tree2.PrintRotCount();
        }
    }
}
