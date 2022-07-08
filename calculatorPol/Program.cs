using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPol
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg, stroka = ""; //arg - текущий символ. stroka - служит для вывода всего примера
            double num, op2;
            int countNum = 0, countCymbol = 0; //countNum - подсчитывает количество чисел в примере, countCymbol - количество арифметических действий

            Stack<double> st = new Stack<double>();
            Console.WriteLine("Ввод осуществляется по одному символу/числу в Польском формате.\nДля выхода из программы ввести \"end\". Для подсчёта результата ввести \"rez\"." +
                "\nДля знака корня использовать \"sqrt\"");
            while ((arg = Console.ReadLine()) != "end")
            {
            try
                { 
                bool isNum = double.TryParse(arg, out num);
                if ((arg != "rez") & (arg !="")) stroka = stroka + arg + " ";
                    if (isNum)
                    {
                        st.Push(num);
                        countNum += 1;
                    }
                    else
                    {
                        switch (arg)
                        {
                            case "+":
                                st.Push(st.Pop() + st.Pop());
                                countCymbol += 1;
                                break;

                            case "-":
                                st.Push(-1 * (st.Pop() - st.Pop()));
                                countCymbol += 1;
                                break;

                            case "*":
                                op2 = st.Pop();
                                st.Push(st.Pop() * op2);
                                countCymbol += 1;
                                break;

                            case "^":
                                op2 = st.Pop();
                                st.Push(Math.Pow(st.Pop(), op2));
                                countCymbol += 1;
                                break;

                            case "sqrt":
                                op2 = st.Pop();
                                if (op2 >= 0) st.Push(Math.Sqrt(op2));
                                else
                                {
                                    Console.WriteLine("Корень из отрицательного числа не извлекается.");
                                    countNum = 0; countCymbol = 0; stroka = "";
                                }
                                break;

                            case "%":
                                op2 = st.Pop();
                                if (op2 >= 0) st.Push(st.Pop() * op2 / 100);
                                else
                                {
                                    Console.WriteLine("Отрицательный процент не извлекается.");
                                    countNum = 0; countCymbol = 0; stroka = "";
                                }
                                countCymbol += 1;
                                break;

                            case "/":
                                op2 = st.Pop();
                                if (op2 != 0.0)
                                {
                                    st.Push(st.Pop() / op2); countCymbol += 1;
                                }
                                else
                                {
                                    Console.WriteLine("Деление на ноль невозможно.");
                                    countNum = 0; countCymbol = 0; stroka = "";
                                }
                                break;

                            case "":
                                break;

                            case "rez": //вывод
                                if (countNum - 1 == countCymbol) Console.WriteLine("Результат: " + stroka + " = " + st.Pop());
                                else Console.WriteLine("Неверная запись.");
                                countNum = 0; countCymbol = 0; stroka = "";
                                break;

                            default:
                                Console.WriteLine("Неизвестная команда.");
                                countNum = 0; countCymbol = 0; stroka = "";
                                break;
                        }
                    }
                }
                catch
                {
                    countNum = 0; countCymbol = 0; stroka = "";
                    Console.WriteLine("Неверная запись.");
                }
            }
        }
    }
}