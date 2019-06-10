using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n = 10;
        KeyValuePair<string, string>[] data;
        List<List<KeyValuePair<string, string>>> table;
        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            bool isOpen = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (isOpen || openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.Stream fileStream;
                    if (!isOpen)
                    {
                        filePath = openFileDialog.FileName;
                        string line;
                        //Read the contents of the file into a stream
                        fileStream = openFileDialog.OpenFile();
                    }
                    //Get the path of specified file
                    
                    string[] lines = System.IO.File.ReadAllLines(filePath);
                    //MessageBox.Show(Convert.ToString(count));
                    table = new List<List<KeyValuePair<string, string>>>();
                    //int n = 10;

                    for(int i = 0; i !=n; i++)
                    {
                        table.Add(new List<KeyValuePair<string, string>>());
                    }
                    foreach (var i in lines)
                    {
                        string number = i.Substring(0, i.IndexOf(" "));
                        string val = i.Substring(i.IndexOf(" "));
                        int index = Convert.ToInt32(number) % n;


                        //table[index].Add(new KeyValuePair<string, string>(number, val));
                        var k = new KeyValuePair<string, string>(number, val);
                        var t = table[index].BinarySearch(k, new comparer());
                        if (t < 0)
                        {
                            t = ~t;
                        }
                        table[index].Insert(t, k);
                    }
                    List<int> tables_count = new List<int>();
                    int j = 0;
                    int empty = 0;
                    chart1.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series();
                    foreach (var i in table)
                    {
                        if (i.Count == 0)
                        {
                            empty++;
                        }
                        
                        tables_count.Add(Convert.ToInt32(i.Count));
                        chart1.Series[0].Points.AddXY(j, i.Count);
                        j++;
                        //MessageBox.Show(Convert.ToString(i.Count));
                    }
                    int max, min;
                    double avg;
                    avg = tables_count.Average();
                    max = tables_count.Max();
                    min = tables_count.Min();
                    var sum = tables_count.Select(val => (val - avg) * (val - avg)).Sum();
                    var std = Math.Sqrt(sum / tables_count.Count);
                    textBox3.Text = String.Format("Min: {0} \n Max:{1} \n Avg:{2} \n Std: {3} \n Empty: {4}", min, max, avg, std, empty);
                    isOpen = true;
                    
                    #region old
                    /*data = new KeyValuePair<string, string>[count];
                    int i = 0;
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while((line = reader.ReadLine())!= null)
                        {
                            string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            data[i] = new KeyValuePair<string, string>(tmp[0], tmp[1] + " " + tmp[2] + " " + tmp[3] + " " + tmp[4] + " " + tmp[5]);
                            if(i == 5)
                            {
                                MessageBox.Show(line);
                                MessageBox.Show(tmp[3] + " | " + tmp[4] + " | " + tmp[5]);
                            }
                            i++;
                        }
                    }
                    MessageBox.Show(data[5].Key + " | " + data[5].Value);
                    */
                    #endregion
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox2.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox4.Text) % n;
            var t = table[index].BinarySearch(new KeyValuePair<string, string>(textBox4.Text, ""), new comparer());
            if(t < 0)
            {
                textBox5.Text = "Не найдено";
            }
            else
            {
                for (int i = t; i < table[index].Count; i++)
                {
                    if(table[index][i].Key == textBox4.Text)
                    {
                        textBox5.Text += table[index][i].Key + " " + table[index][i].Value + Environment.NewLine;
                    }
                    
                }
                
            }
        }
    }
}
