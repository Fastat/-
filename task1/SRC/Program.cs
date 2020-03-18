using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task1
{
    class Program
    {
        static void percentile(long[] array, int kol, out double rezult) //Поиск перцентеля 90
        {
            Console.WriteLine();
            rezult = kol*(90.0 / 100.0);
            rezult = Math.Ceiling(rezult);
        }

        static void sredarifm(long[] array, int kol, out double sar) // Среднее арифметическое
        {
            sar = 0;
            for (int i = 0; i < kol; i++)
            {
                sar += array[i];
            }
            sar/=kol;
        }

        static void sortirovka(long[] array, int kol) // Сортировка массива для поиска перцентеля
        {
            long x;
            for (int j = 0; j < kol; j++)
            {
                for (int i = 0; i < kol-1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        x = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = x;
                    }
                }
            }
        }


        static void summa(long[] array,int kol, int ogranichitel, double sar, int a ,out double summa) // Сумма элементов массива (Сортированного), в заданном диапазоне
        {                                                                                              // Сумму получил из сортированного массива, так как в задании не уточняется
            summa = 0;                                                                      // какой массив использовать (изначальный или сортированный)
            for (int i = 0; i < kol; i++)
            {
                if (array[i] > sar)
                {
                    a = i;
                    break;
                }
            }

            for (int i = a+1; i < ogranichitel; i++)
            {
                summa += array[i];
            }
        }


        static void readinfo(string filename, out string[] array, out int n)
        {
            StreamReader sr = new StreamReader(filename);
            string a = sr.ReadToEnd();
            array = a.Split(new char[] { '\n', '\r', '/', '/', 'n', 'r' }, StringSplitOptions.RemoveEmptyEntries);
            n = array.Length;
        }
        static void Main(string[] args)
        {
            string file = null;
            if (args.Length == 0)
            {
                Console.Write("Введите ссылку на файл: ");
                file = Convert.ToString(Console.ReadLine());
            }
            else
            {
                file = args[0];
            }
            string[] words;
            double rez;
            int rez1;
            double SrAr;
            double sum;
            int b=0;
            int n;
            readinfo(file, out words, out n);
            long[] x = new long[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = Convert.ToInt64(words[i]);
            }

            sortirovka(x, words.Length);

            percentile(x, words.Length, out rez);

            sredarifm(x, words.Length, out SrAr);

            rez1=Convert.ToInt32(rez);

            summa(x, words.Length, rez1, SrAr, b, out sum);
            Console.WriteLine("Сумма всех элементов массива в диапозоне от среднего значения до 90-го перцентеля (включительно) = " + sum);
            Console.ReadLine();
        }
    }
}
