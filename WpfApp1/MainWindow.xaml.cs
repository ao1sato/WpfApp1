using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Пример_таблицы_WPF;



namespace WpfApp1
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] mas;
        int[] masw;

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void b1_Click(object sender, RoutedEventArgs e)//заполнение
        {
            if (int.TryParse(diap.Text, out int randMax) && int.TryParse(col.Text, out int count)&& int.TryParse(strok.Text,out int stroki))
            {

                Class1.InitMas(out mas, count, stroki, randMax);
                data.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else
            {
                MessageBox.Show("ошибка, попробуй снова, мб получится");
            }

        }

        private void b4_Click(object sender, RoutedEventArgs e)//результат
        {
            if (mas != null && int.TryParse(col.Text, out int columns) && int.TryParse(strok.Text, out int rows))
            {
                int[] result = Class1.Miner(mas, columns, rows);
                data2.ItemsSource = VisualArray.ToDataTable(result).DefaultView;
            }
            else
            {
                MessageBox.Show("введите столбцы и строки"); //luuluujlullululululululuulu
            }
        }


        private void b5_Click(object sender, RoutedEventArgs e) //очистка
        {
            data.ItemsSource = null;
            data2.ItemsSource = null;
            col.Clear();
            diap.Clear();
            col.Focus();
            strok.Clear();
        }

        private void b2_Click(object sender, RoutedEventArgs e)//выход
        {
            this.Close();
        }

        private void b3_Click(object sender, RoutedEventArgs e)//инфа
        {
            MessageBox.Show("Дана матрица размера M × N. Для каждого столбца матрицы найти произведение \r\nего элементов.");
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)// меню-выход
        {
            this.Close();
        }

        

        private void MenuItem_Click3(object sender, RoutedEventArgs e)//меню-сохронить
        {
            Class1.save_file(mas);
        }

        private void MenuItem_Click4(object sender, RoutedEventArgs e)//меню-открыть
        {
            Class1.open_file(ref mas);
            data.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;

        }

        private void data_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Определяем номер столбца
            int indexColumn = data.CurrentCell.Column.DisplayIndex;
            //Определяем номер строки
            int indexRow = data.SelectedIndex;
            // Получнем текущую строку
            DataRowView row = (DataRowView)data.Items[indexRow];
            
            // Заносим полученное значение в массив
            masw[indexColumn] = Convert.ToInt32(row[indexColumn].ToString());
            masw[indexColumn] = Convert.ToInt32(row["col" + (indexColumn + 1)].ToString());
        }
    }
}
