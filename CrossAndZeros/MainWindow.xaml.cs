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

namespace CrossAndZeros
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static int[,] mas = new int[3, 3] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };

        bool turn = true;
        int count = 0;
        //flse O
        //true X

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.Equals(""))
            {
                int value = -1;
                if (turn)
                {
                    ((Button)sender).Content = "X";

                    //var brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("textures/X.png", UriKind.Relative));
                    //((Button)sender).Background = brush;

                    //((Button)sender).Background = new ImageBrush(new BitmapImage(new Uri("textures/X.png")));
                    turn = false;
                    value = 1;
                }
                else
                {
                    ((Button)sender).Content = "O";

                    //var brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("textures/O.png", UriKind.Relative));
                    //((Button)sender).Background = brush;

                    //((Button)sender).Background = new ImageBrush(new BitmapImage(new Uri("textures/O.png")));
                    turn = true;
                    value = 0;
                }
                switch (((Button)sender).Name)
                {
                    case "button1":
                        mas[0, 0] = value;
                        break;
                    case "button2":
                        mas[0, 1] = value;
                        break;
                    case "button3":
                        mas[0, 2] = value;
                        break;
                    case "button4":
                        mas[1, 0] = value;
                        break;
                    case "button5":
                        mas[1, 1] = value;
                        break;
                    case "button6":
                        mas[1, 2] = value;
                        break;
                    case "button7":
                        mas[2, 0] = value;
                        break;
                    case "button8":
                        mas[2, 1] = value;
                        break;
                    case "button9":
                        mas[2, 2] = value;
                        break;
                    default:
                        break;
                }
                check();
                count++;
            }
        }
        private void check()
        {
            bool end = false;
            string res = "O";
            if(!turn)
                res = "X";
            for (int i = 0; i < 3; i++)
                if ((mas[i, 0] == mas[i, 1] && mas[i, 1] == mas[i, 2] && mas[i, 1] != -1)|| (mas[0, i] == mas[1, i] && mas[1, i] == mas[2, i] && mas[0, i] != -1))
                    end = true;
            //for (int j=0;j<3;j++)
            //    if (mas[0, j] == mas[1, j] && mas[1, j] == mas[2, j] && mas[0, j] != -1)
            //        end = true;
            if ((mas[2, 0] == mas[1, 1] && mas[1, 1] == mas[0, 2] && mas[1, 1] != -1) || (mas[0, 0] == mas[1, 1] && mas[1, 1] == mas[2, 2] && mas[1, 1] != -1))
                end = true;
            if (count == 8 && !end)
            {
                locked();
                MessageBox.Show("Draw!");
            }
            if(end)
            {
                locked();
                MessageBox.Show("Congratulations!!! " + res + " Wins!");
            }
        }

        private void locked()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)

                reset();
            //if (e.Key == Key.Enter
            //    MessageBox.Show("Finish processing with " + iter + " iterations!");
        }
        private void reset()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
            button1.Background = null;
            button2.Background = null;
            button3.Background = null;
            button4.Background = null;
            button5.Background = null;
            button6.Background = null;
            button7.Background = null;
            button8.Background = null;
            button9.Background = null;
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
            button9.Content = "";

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    mas[i, j] = -1;

            turn = true;
            count = 0;
        }

        private void buttonR_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }
    }
}
