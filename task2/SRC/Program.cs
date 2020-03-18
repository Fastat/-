using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task2
{
    class Program
    {
        static void translate(string[] array, string stroka)//Процедура манипуляций с файлом
        {
            int k = 0;//Счётчик массива нового
            for (int i = 0; i <= stroka.Length - 1; i++)
            {
                if (stroka[i] == '[')//Ищу квадратную скобку, потмоу что в них находятся цифры (Запятые для этого и убирал)
                {
                    for (int j = i + 1; j <= i + 3; j++)
                    {
                        array[k] = Convert.ToString(stroka[j]);//Как только нашёл символ, сразу следующие 3 символа записываю в массив с этими цифрами
                        k++;//Имя файла это счётчик нового массива
                    }
                    Console.Write(" ");
                }
            }
        }


        static void Main(string[] args)
        {
            //string file = "C:\\Users\\Глеб\\Desktop\\file.txt";//Имя файла
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
            string Line;//Переменная для считывания файла
            StreamReader sr = new StreamReader(file);
            Line = sr.ReadLine();//Считал файлик
            Line = Line.Replace(" ", "");//убрал пробелы
            Line = Line.Replace(",", "");//убрал запятые

            string[] coordinat = new string[18];//Создал массив, в который запишу цифры из файла (сам файл у меня в директории проги есть)

            translate(coordinat, Line);//вызвал процедуру манипуляций
            double[] treug1 = new double[9];//Массив для первого треугольника с координатами
            double[] treug2 = new double[9];//Массив для второго треугольника с координатами
            int k = 0;//Опять счётчик массива
            for (int i = 0; i < 18; i++)
            {
                if (i < 9)
                {
                    treug1[i] = Convert.ToDouble(coordinat[i]);//Массив для Первого треугольника с координатами заполненый
                }
                else
                {
                    treug2[k] = Convert.ToDouble(coordinat[i]);//Массив для Второго треугольника с координатами заполнений
                    k++;
                }
            }

            double a, b, c, a1, b1, c1;//Переменный для сравнения сторон треугольника
            treangle tre = new treangle();

            tre.lenght(treug1, out a, out b, out c);//Метод класса
            tre.lenght(treug2, out a1, out b1, out c1);//Метод класса
            tre.proverka(a, b, c, a1, b1, c1);//Метод класса
            //Console.WriteLine("Аргументы = "+args[0]);
            Console.ReadLine();
        }
    }

    class treangle
    {

        public treangle()
        {
        }

        public void lenght(double[] array, out double a, out double b, out double c)//Длинна сторон
        {

            a = Math.Sqrt(Math.Pow((array[3] - array[0]), 2) + Math.Pow((array[4] - array[1]), 2) + Math.Pow((array[5] - array[2]), 2));
            b = Math.Sqrt(Math.Pow((array[6] - array[3]), 2) + Math.Pow((array[7] - array[4]), 2) + Math.Pow((array[8] - array[5]), 2));
            c = Math.Sqrt(Math.Pow((array[6] - array[0]), 2) + Math.Pow((array[7] - array[1]), 2) + Math.Pow((array[8] - array[2]), 2));
        }

        public void proverka(double a, double b, double c, double a1, double b1, double c1)//Проверка условия подобности треугольников
        {
            if (a == a1 && b == b1 && c == c1)
            {
                Console.WriteLine("Треугольники подобны!");
            }
            else
            {
                Console.WriteLine("Данные треугольники не являются подобными!");
            }
        }
    }
}
