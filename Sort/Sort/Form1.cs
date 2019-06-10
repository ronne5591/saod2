using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sort
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
        static public int[] A1;// = new int[100000];
        static public int[] A2;// = new int[100000];
        public Form1()
        {
            InitializeComponent();
            A1 = new int[Convert.ToInt64(numericUpDown1.Value)];
            A2 = new int[Convert.ToInt64(numericUpDown1.Value)];
            Random R = new Random();
            for (int i = 0; i < A1.Length; i++)
            {
                A1[i] = R.Next(100000);
                A2[i] = A1[i];
            }
        }

        void Reset()
        {
            for (int i = 0; i < A1.Length; i++)
            {
                A1[i] = A2[i];
            }
        }

        static void OrderBy(int[] array)
        {
            A1 = (from element in array orderby element ascending select element)
                   .ToArray();
        }

        static void ArraySort(int[] array)
        {
            Array.Sort(array);
        }

//Quick
        void quickSort(int[] numbers, int left, int right)
        {
            int pivot;
            int l_hold = left; 
            int r_hold = right; 
            pivot = numbers[left];
            while (left < right)
            {
                while ((numbers[right] >= pivot) && (left < right))
                    right--; 
                if (left != right) 
                {
                    numbers[left] = numbers[right]; 
                    left++; 
                }
                while ((numbers[left] <= pivot) && (left < right))
                    left++;
                if (left != right) 
                {
                    numbers[right] = numbers[left]; 
                    right--;
                }
            }
            numbers[left] = pivot;
            pivot = left;
            left = l_hold;
            right = r_hold;
            if (left < pivot)
                quickSort(numbers, left, pivot - 1);
            if (right > pivot)
                quickSort(numbers, pivot + 1, right);
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
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            if (Shella.Checked)
            {
                myStopwatch.Start();
                ShellSort(A1);
                myStopwatch.Stop();
            }
            if (Sort.Checked)
            {
                myStopwatch.Start();
                ArraySort(A1);
                myStopwatch.Stop();
            }
            if (Order_By.Checked)
            {
                myStopwatch.Start();
                OrderBy(A1);
                myStopwatch.Stop();
            }

            if (quick2.Checked)
            {
                myStopwatch.Start();
                quickSort(A1, 0, A1.Length - 1);
                myStopwatch.Stop();
            }
            TimeSpan b = myStopwatch.Elapsed;
            textBox1.Text = Convert.ToString(b);
            myStopwatch.Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            A1 = new int[Convert.ToInt64(numericUpDown1.Value)];
            A2 = new int[Convert.ToInt64(numericUpDown1.Value)];
            Random R = new Random();
            for (int i = 0; i < A1.Length; i++)
            {
                A1[i] = R.Next(100000);
                A2[i] = A1[i];
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
