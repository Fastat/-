using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task4
{
    class Program
    {

        static void viravnivanie(string x, ref string[] array1, ref string[] array2)//выравнивание размерностей массивов
        {
            if (x.Length > array1.Length)
            {
                Array.Resize(ref array1, x.Length);
                if (array1.Length > array2.Length)
                {
                    Array.Resize(ref array2, array1.Length);
                }
                else
                {
                    Array.Resize(ref array1, array2.Length);
                }
            }
        }

        static void inputMass(string x, ref string[] array, ref int flag, int ogranich) //Заполнение массивов символами из переменных типа string
        {
            for (int i = 0; i < ogranich; i++)
            {
                array[i] = Convert.ToString(x[i]);
                if (array[i] == "*")
                {
                    flag++;
                }
            }
        }

        static void ContinInputMass(int start, ref string[] array, int finish) //Выравнивание количества символов в обоих массивах для дальнейшего взаимодействия
        {
            for (int i = start; i < finish; i++)
            {
                array[i] = " ";
            }
        }


        static void ShowArrays(ref string[] array, int finish, int cifra) //Тестовая функция. Требовалась для отладки
        {
            Console.Write("Массив " + cifra + ": ");
            for (int i = 0; i < finish; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.Write(" ");
        }

        static void processing(ref string[] array1, ref string[] array2, int ogranichitel, int flag1, int flag2, bool flag3) //Основной метод программы для сравнивания двух строк
        {
            flag3 = true;
            for (int i = 0; i < ogranichitel; i++)
            {
                if (array1[i] != array2[i])
                {
                    if (flag1 > 0 && flag2 > 0 && (array1[i] == " " || array1[i] == "*"))//Если символ "*" присутствует в обеих строках
                    {
                        array1[i] = array2[i];
                    }
                    else
                    {
                        if (flag1 > 0 && flag2 > 0 && (array2[i] == " " || array2[i] == "*"))//Если символ "*" присутствует в обеих строках
                        {
                            array2[i] = array1[i];
                        }
                        else
                        {
                            if (flag1 > 0 && (array1[i] == " " || array1[i] == "*"))//Если символ "*" присутствует в первой строке
                            {
                                array1[i] = array2[i];
                            }
                            else
                            {
                                if (flag2 > 0 && (array2[i] == " " || array2[i] == "*"))//Если символ "*" присутствует в второй строке
                                {
                                    array2[i] = array1[i];
                                }
                                else
                                {
                                    flag3 = false;
                                    if (flag3 == false)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (flag3 == true)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("KO");
            }
        }

        static void Main(string[] args)
        {
            string a;
            string b;
            if (args.Length <= 1)
            {
                Console.WriteLine("Один или несколько аргументов не были переданы");
                Console.WriteLine("Пожалуйства введите аргументы вручную");
                Console.Write("Строка А: ");
                a = Console.ReadLine();
                Console.Write(" ");
                Console.Write("Строка B: ");
                b = Console.ReadLine();
            }
            else
            {
                a = args[0];
                //Console.WriteLine(args[0]);
                b = args[1];
                //Console.WriteLine(args[1]);
            }

            int n = a.Length;
            int f = 0;
            int f1 = 0;
            bool fV1 = false;
            bool fV2 = false;
            bool fV3 = false;
            string[] x = new string[20];
            string[] y = new string[20];

            viravnivanie(a, ref x, ref y);
            viravnivanie(b, ref x, ref y);

            inputMass(a, ref x, ref f, a.Length);
            inputMass(b, ref y, ref f1, b.Length);

            if (a.Length > b.Length)
            {
                n = b.Length + (a.Length - b.Length);
                fV1 = true;
            }
            else
            {
                if (a.Length < b.Length)
                {
                    n = a.Length + (b.Length - a.Length);
                    fV2 = true;
                }
                else
                {
                    //Console.WriteLine("Строки равны");
                }
            }

            if (fV1 == true)
            {
                ContinInputMass(b.Length, ref y, n);
            }
            else
            {
                if (fV2 == true)
                {
                    ContinInputMass(a.Length, ref x, n);
                }
            }

            processing(ref x, ref y, n, f, f1, fV3);
            Console.ReadLine();
        }
    }
}
