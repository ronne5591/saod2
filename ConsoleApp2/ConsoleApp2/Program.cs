using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(execOp('/', 5, 0));
            Console.WriteLine(GetPolskaKurwa("(5+8)-(10*2)"));
        }

        static bool GetPriority(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
                return false;
            if (op1 == '^')
                return false;
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
                return false;
            else
                return true;
        }

        static int execOp(char ch, int a, int b)
        {
            switch (ch)
            {
                case '+':
                    return a + b;
                case '-':
                    return b - a;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new ArithmeticException();
                    }
                    else
                    {
                        return b / a;
                    }
                default:
                    throw new ArgumentException();
            }
        }

        static int GetPolskaKurwa(string str)
        {
            //Stack<int> values = new Stack<int>();
            String output = "";
            Stack<int> values = new Stack<int>();
            Stack<char> ops = new Stack<char>();
            
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] == ' ')
                {
                    continue;
                }

                if(str[i] >= '0' && str[i] <= '9')
                {
                    string value = "";
                    //int x = 0;
                    while (i < str.Length && (str[i] >= '0' && str[i] <= '9'))
                    {
                        value += str[i];
                        i++;
                    }
                    i--;
                    Console.WriteLine(value);
                    values.Push(Convert.ToInt32(value));
                }
               
                if(str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '^' || str[i] == '/' || str[i] == '(' || str[i] == ')')
                {
                    if (str[i] == '(')
                    {
                        ops.Push(str[i]);
                    }

                    else if (str[i] == ')')
                    {

                        while (ops.Peek() != '(')
                        {
                            values.Push(execOp(ops.Pop(), values.Pop(), values.Pop()));
                            //output += temp.ToString() + " ";

                          
                        }
                        ops.Pop();
                    }

                    else
                    {
                        while (ops.Count !=0 && GetPriority(str[i], ops.Peek()))
                        {
                            values.Push(execOp(ops.Pop(), values.Pop(), values.Pop()));
                        }

                        ops.Push(str[i]);
                    }
                    
                    //values.Push(execOp(ops.Pop(), values.Pop(), values.Pop()));
                    //ops.Push(str[i]);

                }
            }

            //Console.WriteLine("aaaa");
            //Console.WriteLine(ops.Count);
            //Console.WriteLine(values.Count);
            while (ops.Count != 0)
                values.Push(execOp(ops.Pop(), values.Pop(), values.Pop()));
            return values.Pop();
            
            /*while (ops.Count > 0)
                output += ops.Pop() + " ";

            return output;
            */
        }

    }
}
