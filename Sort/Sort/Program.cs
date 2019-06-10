using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            int[] A1 = new int[10];
            int[] A2 = new int[10];
            
            Random R = new Random();
            for (int i = 0; i < A1.Length; i++)
            {
                A1[i] = R.Next(50);
            }
            A2 = A1;
            var Sort = from Ss in A1 orderby Ss select Ss;
            foreach (int Ss in Sort)
                Console.Write(Ss+" ");
            Console.WriteLine("-----------");

            A1 = A2;
            ShellSort(A1);
            foreach (int Ss in A1)
                Console.Write(Ss + " ");

            Console.WriteLine("-----------");
            A1 = A2;
            Quicksort(A1, 0, A1.Length-1);
            foreach (int Ss in A1)
                Console.Write(Ss + " ");

            Console.WriteLine("-----------");
            A1 = A2;
            Array.Sort(A1);
            foreach (int Ss in A1)
                Console.Write(Ss + " ");
        }
        
//Shell
        static int[] ShellSort(int[] array)
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b; 
            b = t;
        }

        //Quick
        void quickSort(int[] numbers, int left, int right)
        {
            int pivot; // разрешающий элемент
            int l_hold = left; //левая граница
            int r_hold = right; // правая граница
            pivot = numbers[left];
            while (left < right) // пока границы не сомкнутся
            {
                while ((numbers[right] >= pivot) && (left < right))
                    right--; // сдвигаем правую границу пока элемент [right] больше [pivot]
                if (left != right) // если границы не сомкнулись
                {
                    numbers[left] = numbers[right]; // перемещаем элемент [right] на место разрешающего
                    left++; // сдвигаем левую границу вправо 
                }
                while ((numbers[left] <= pivot) && (left < right))
                    left++; // сдвигаем левую границу пока элемент [left] меньше [pivot]
                if (left != right) // если границы не сомкнулись
                {
                    numbers[right] = numbers[left]; // перемещаем элемент [left] на место [right]
                    right--; // сдвигаем правую границу вправо 
                }
            }
            numbers[left] = pivot; // ставим разрешающий элемент на место
            pivot = left;
            left = l_hold;
            right = r_hold;
            if (left < pivot) // Рекурсивно вызываем сортировку для левой и правой части массива
                quickSort(numbers, left, pivot - 1);
            if (right > pivot)
                quickSort(numbers, pivot + 1, right);
        }
        //int main()
        //{
        //    int a[SIZE];
        //    // Заполнение массива случайными числами
        //    for (int i = 0; i < SIZE; i++)
        //        a[i] = rand() % 201 - 100;
        //    // Вывод элементов массива до сортировки
        //    for (int i = 0; i < SIZE; i++)
        //        printf("%4d ", a[i]);
        //    printf("\n");
        //    quickSort(a, 0, SIZE - 1); // вызов функции сортировки
        //                               // Вывод элементов массива после сортировки
        //    for (int i = 0; i < SIZE; i++)
        //        printf("%4d ", a[i]);
        //    printf("\n");
        //    getchar();
        //    return 0;
        //}

        //Quick
        static void Quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }

        static int Partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }
    }
}
