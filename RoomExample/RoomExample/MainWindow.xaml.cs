using System;
using System.Collections.Generic;
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
using RooomLibrary;

namespace RoomExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room room1 = new Room();
        Room room2 = new Room();
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// Открытие первой комнаты
        /// </summary>
        /// <param name "sender"></param>
        /// <param name "e"></param> ссылма: 1
        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            openBtn2.IsEnabled = true; //разрешить открыть вторую

            //инициализация полей класса и генерация числа человек
            room1.RoomLength = rnd.Next(2, 11);
            room1.RoomWidt = rnd.Next(2, 11);
            int numP = rnd.Next(1, 9);

            //вывод сгенерированных данных в метки
            LabelLength1.Content = room1.RoomLength;
            LabelWidth1.Content = room1.RoomWidt;
            LabelNumPerson1.Content = numP;

            //вычисление периметра, площади, метража и вывод в метки
            LabelPerimeter1.Content = room1.RoomPerimeter();
            LabelArea1.Content = room1.RoomArea();
            LabelPersonArea1.Content = Math.Round(room1.PersonArea(numP), 3);
        }

        private void openBtn2_Click(object sender, RoutedEventArgs e)
        {
            allBtn.IsEnabled = true; //разрешить суммировать площади комнат

            //ввод данных инициализация полей класса
            room2.RoomLength = Convert.ToDouble(TBLength2.Text);
            room2.RoomWidt = Convert.ToDouble(TBWidth2.Text);
            int numP = Convert.ToInt32(TBNumPerson2.Text);

            //вычисления периметра, площади, метража и вывод в метки
            LabelPerimeter2.Content = room2.RoomPerimeter();
            LabelArea2.Content = room2.RoomArea();
            LabelPersonArea2.Content = Math.Round(room2.PersonArea(numP), 3);
        }

        private void allBtn_Click(object sender, RoutedEventArgs e)
        {
            labelAllArea.Content = room1.RoomArea() + room2.RoomArea();
        }
    }

}
