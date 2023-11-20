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
using GameCore_Blokus;

namespace UI_Blokus
{
    /// <summary>
    /// OneBox_E2.xaml 的互動邏輯
    /// </summary>
    public partial class OneBox_E2 : UserControl
    {
        public delegate void BorderHandler(int m_X, int m_Y, GameColor m_BoxColor, string m_Instruction);
        public event BorderHandler BorderHandleEvent;

        public int X = -1;
        public int Y = -1;
        public GameColor BoxColor = GameColor.Gray;

        public OneBox_E2()
        {
            InitializeComponent();
        }

        public void Border_ColorChange(GameColor m_BoxColor)
        {
            try
            {
                switch (m_BoxColor)
                {
                    case GameColor.Black:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.Black);
                        }
                        break;

                    case GameColor.White:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.White);
                        }
                        break;

                    case GameColor.Gray:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.Gray);                          
                        }
                        break;

                    case GameColor.Blue:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.Blue);
                        }
                        break;

                    case GameColor.LightBlue:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.LightBlue);
                        }
                        break;

                    case GameColor.Green:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.Green);
                        }
                        break;

                    case GameColor.LightGreen:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.LightGreen);
                        }
                        break;

                    case GameColor.Red:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.Red);
                        }
                        break;

                    case GameColor.LightRed:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.Pink);
                        }
                        break;

                    case GameColor.Yellow:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.Yellow);
                        }
                        break;

                    case GameColor.LightYellow:
                        {
                            BoxColor = m_BoxColor;
                            Dispatcher.Invoke(() => Border_Color.Background = Brushes.LightYellow);
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                switch ((sender as Border).Name)
                {
                    case "Border_Color":
                        {
                            BorderHandleEvent(X, Y, BoxColor, "MouseUp");
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Box例外發生!");
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                switch ((sender as Border).Name)
                {
                    case "Border_Color":
                        {
                            BorderHandleEvent(X, Y, BoxColor, "MouseMove");
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Box例外發生!");
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                switch ((sender as Border).Name)
                {
                    case "Border_Color":
                        {
                            BorderHandleEvent(X, Y, BoxColor, "MouseLeave");
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Box例外發生!");
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
