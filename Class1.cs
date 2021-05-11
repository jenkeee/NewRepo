using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondtry
{
    /// <summary>
    /// Статический класс для решения задачи
    /// </summary>
    static class StaticClass
    {
        /// <summary>
        /// Получение массива со случайными числами
        /// </summary>
        /// <param name="size">размер массива</param>
        /// <returns>вертает массив</returns>
        public static int[] GetArrayWithRandomNum(int size)
        {
            Random rnd = new Random();
            int[] retArray = new int[size];
            for (int i = 0; i < retArray.Length; i++)
            {
                retArray[i] = rnd.Next(-10_000, 10_000);
            }
            return retArray;
        }
        /// <summary>
        /// Получение количества пар в массиве где только одно из чисел делится на 3
        /// </summary>
        /// <param name="arrayInts">массив</param>
        /// <returns>количество пар</returns>
        public static int GetCountGoodNumbers(int[] arrayInts)
        {
            int count = default;
            for (int i = 0; i < arrayInts.Length - 1; i++)
            {
                if (arrayInts[i] % 3 == 0 ^ arrayInts[i + 1] % 3 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Запись массива в файл
        /// </summary>
        /// <param name="arrInts">массив</param>
        /// <param name="fileName">имя файла</param>
        public static void SaveArrayToFile(int[] arrInts, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            foreach (int item in arrInts)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }
        /// <summary>
        /// Чтение массива из файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <returns>массив</returns>
        public static int[] LoadArrayFromFile(string fileName)
        {
            const int size = 20;
            StreamReader reader = new StreamReader(fileName);
            int[] returnMe = new int[size];
            for (int i = 0; i < size; i++)
            {
                returnMe[i] = int.Parse(reader.ReadLine());
            }
            reader.Close();
            return returnMe;
        }



    }
}
