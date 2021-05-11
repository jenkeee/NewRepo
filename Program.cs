using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;



namespace secondtry
{
    class Program
    {
        #region menu
        ///////////////////////////cсоздадим метод проверки ввода
        static int Checktoparse(string message)
        {
            string num_before;
            bool flag_ornum;
            int num_after;
            do
            {
                                num_before = Console.ReadLine();

                flag_ornum = int.TryParse(num_before, out num_after);
            } while (!flag_ornum);
            return num_after;

        }
        static void Main(string[] args)
        {
            int value;
            do
            {
                Console.Title = ("Меню");
                Console.Clear();
                MyHelper.MyHeader(text: "Главное меню.");
                Console.WriteLine("Введите номер задачи от 1 до 5. принимаются только целые числа.");
                value = Checktoparse(""); // даем значение велью методом GetValue // и там метод уже либо пропустит int32 либо будет бесконечно вызыватся, пока ты не напишиш цифры удовлетворяющие условия
                // гет валью дает нам проверку на вводимы знаки, а диапазон мы сдесь даже не ставили У НАС ВСЕГО 3 КЕЙСА

                MyHelper.MyFooter();
                switch (value)
                {
                    case 1:
                        dz1();
                        break;
                    case 2:
                        dz2();
                        break;
                    case 3:
                        dz3();
                        break;

                }
            } while (true);
            #endregion
        }
        #region задание 1
        /// <summary>
        ///1.	Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
        ///Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
        ///В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
        /// </summary>
        /// 
        /// 
        /// <summary>Метод подсчёта количества пар элементов массива, в которых хотя бы одно число делится на 3</summary>
        /// <param name="array">Массив элементов</param>
        /// <param name="length">Длинна массива элементов</param>
        /// <returns></returns>
        static int GetNumberOfPairs(int[] array, int length)
        {
            int amountOfPairs = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] % 3 == 0 || array[i + 1] % 3 == 0)
                {
                    amountOfPairs++;
                }
            }
            return amountOfPairs;
        }
        static void dz1()
        {
            Console.Clear();
            MyHelper.MyHeader(text: "1.Дан  целочисленный массив  из 20 элементов.");
            const int arrayLength = 20;
            int[] myArray = new int[arrayLength];
            Random random = new Random();
            int result;

            Console.WriteLine("Привет, сейчас мы посчитаем масив из 20ти элементов, и условие проверки будет. (array[i] % 3 == 0 || array[i + 1] % 3 == 0) делится на 3 без остатка");
            Console.Write("\nПолучаем масив в диапазоне (-10000, 10001) \n [");
            for (int i = 0; i < arrayLength; i++)
            {
                myArray[i] = random.Next(-10000, 10001); // от включая идет, а до не включа, поэтому +1 
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine("\b\b ]\n");

            result = GetNumberOfPairs(myArray, arrayLength);

            Console.WriteLine($"Количество пар удовлетворяющих условие: {result}");
            MyHelper.MyFooter();
            Console.ReadKey();
        }
        #endregion
        #region задание 2
        /// <summary>
        ///2.	Реализуйте задачу 1 в виде статического класса StaticClass;
        ///а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        ///б) *Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
        ///в)**Добавьте обработку ситуации отсутствия файла на диске.
        /// </summary>
        static void dz2() // работа так или иначе принесет плоды, я наконецто понял что такое классы и как ими пользоватся подглядев решение  
        {
            Console.Clear();
            MyHelper.MyHeader(text: "Задача 2. Добавление статического класса StaticClass."); // так получилось что нашел интиресную библиотеку Myhelper, буду использовать дальше
                                                                                              // и дорабатывать в чем я сомневаюсь если конечно надо туда лезть
                                                                                              // очень понравился хелпер,
            //Console.Title = "Реализуйте задачу 1 в виде статического класса StaticClass;";
           
            WriteLine("Пункт А. Статический класс решения поставленной задачи.");
            int[] arrInts = StaticClass.GetArrayWithRandomNum(20); //получить массив
            WriteLine("Массив элементов из случайных чисел:");
            Array.ForEach(arrInts, WriteLine); //вывод массива
            WriteLine();
            int count = StaticClass.GetCountGoodNumbers(arrInts); //получить количество пар
            WriteLine($"Кол-во пар элементов массива, в которых только одно число делится на три = {count}");
            MyHelper.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт Б. Статический метод считывания массива из текстового файла.");
            int[] arrLoaded = StaticClass.LoadArrayFromFile(@"..\..\data.txt");
            WriteLine("Массив загруженных элементов из файла:");
            Array.ForEach(arrLoaded, WriteLine); //вывод массива
            WriteLine();
            MyHelper.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт В. Обработка ситуации отсутствия файла на диске.");
            MyHelper.MyPause("Начинаю считывать данные из файла 'не существует.txt'. Нажмите любую кнопку...");

            int[] arrNoLoaded = default; // инициалиируем 
            
                try
                {
                    arrNoLoaded = StaticClass.LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + "data2.txt");
                }
                catch (Exception error)
                {

                    MyHelper.MyPause(error.Message + "\nДальнейшая работа программы невозможна. Нажмите любую кнопку ...");
                    return;
               }
          ///////////////////////////////// пытаюсь понять как не выходить из метода а перейти к следующим инструкциям
            WriteLine("Массив загруженных элементов из файла:");
            Array.ForEach(arrNoLoaded, WriteLine); //вывод массива  // в случае ошибки получаем  arrNoLoaded 
            WriteLine(arrNoLoaded);
            MyHelper.MyFooter();
            ReadKey();

        }
        #endregion
        #region задание 3
        /// <summary>
        ///1.	Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
        ///Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
        ///В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
        /// </summary>
        static void dz3()
        {
            Console.Title = "1.Дан  целочисленный массив  из 20 элементов.";
            Console.Clear();
        }
        #endregion
    }
    #region мои классы
    class Mymassiv
    {
        int[] a; // создадим переменную для масива.


        //  Создание массива и заполненим его случайными числами от min до max
        public Mymassiv(int n, int min, int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min, max);
        }
    }
    #endregion


}
