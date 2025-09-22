using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Markup;
using Пример_таблицы_WPF;

namespace WpfApp1
{
    class Class1
    {
        public static void InitMas(out int[,] mas, int column, int stroki, int randMax)
        {
            Random rnd = new Random();
            mas = new Int32[stroki, column];
            for (int i = 0; i < stroki; i++)
                for (int j = 0; j < column; j++)
                    mas[i, j] = rnd.Next(randMax);
        }


        public static int[] Miner(int[,] mas, int column, int rows)
        {
            int[] masq = new Int32[column];
            for (int j = 0; j < column; j++)
            {
                int rez = 0;
                for (int i = 0; i < rows; i++)
                {
                    rez += mas[i,j];

                }
                masq[j] = rez;
            }

            return masq;
        }

        public static void save_file(int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            save.FilterIndex = 1;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                using (StreamWriter file = new StreamWriter(save.FileName))
                {
                    file.WriteLine(mas.GetLength(0)); // строки
                    file.WriteLine(mas.GetLength(1)); // столбцы

                    for (int i = 0; i < mas.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            file.WriteLine(mas[i, j]);
                        }
                    }
                }
                return;
            }
        }


        public static void open_file(ref int[,] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            open.FilterIndex = 1;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                using (StreamReader file = new StreamReader(open.FileName))
                {
                    int rows = Convert.ToInt32(file.ReadLine());
                    int columns = Convert.ToInt32(file.ReadLine());
                    mas = new int[rows, columns];

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (!file.EndOfStream)
                                mas[i, j] = Convert.ToInt32(file.ReadLine());
                        }
                    }
                }
                return;

            }

        }
    }
}


