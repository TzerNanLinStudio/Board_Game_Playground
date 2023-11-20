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
using GameCore_ChineseCheckers;

namespace UI_ChineseCheckers
{
    /// <summary>
    /// SinglePoint.xaml 的互動邏輯
    /// </summary>
    public partial class SinglePoint : UserControl
    {
        public delegate void ButtonHandler(int r_X, int r_Y, GameColor r_CurrentColor);
        public event ButtonHandler ButtonHandleEvent;

        public int[] CoordinateValue;
        public GameColor CurrentColor;

        public SinglePoint()
        {
            InitializeComponent();
            InitializeDetail();
        }

        private void InitializeDetail()
        {
            CurrentColor = GameColor.White;
            CoordinateValue = new int[2] { -1, -1 };
        }

        public void InitializeDetail(GameColor r_CurrentColor, int[] r_CoordinateValue)
        {
            CurrentColor = r_CurrentColor;
            CoordinateValue = new int[2] { r_CoordinateValue[0], r_CoordinateValue[1] };

            Btn_ColorChange(CurrentColor);
        }

        public void Btn_ColorChange(GameColor m_BoxColor)
        {
            try
            {
                switch (m_BoxColor)
                {
                    case GameColor.Black:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Black);
                        }
                        break;

                    case GameColor.White:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.White);
                        }
                        break;

                    case GameColor.Gray:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Gray);
                        }
                        break;

                    case GameColor.Blue:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Blue);
                        }
                        break;

                    case GameColor.LightBlue:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.LightBlue);
                        }
                        break;

                    case GameColor.Green:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Green);
                        }
                        break;

                    case GameColor.LightGreen:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.LightGreen);
                        }
                        break;

                    case GameColor.Red:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Red);
                        }
                        break;

                    case GameColor.Orange:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Orange);
                        }
                        break;

                    case GameColor.Purple:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Purple);
                        }
                        break;

                    case GameColor.Pink:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Pink);
                        }
                        break;

                    case GameColor.LightRed:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Pink);
                        }
                        break;

                    case GameColor.Yellow:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.Yellow);
                        }
                        break;

                    case GameColor.LightYellow:
                        {
                            Dispatcher.Invoke(() => Btn_Intersection.Background = Brushes.LightYellow);
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

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as System.Windows.Controls.Button).Name)
                {
                    case "Btn_Intersection":
                        {
                            ButtonHandleEvent(CoordinateValue[0], CoordinateValue[1], CurrentColor); //另一端未設定的Bug怎麼辦???
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception Occurred When Button Clicked. Message:" + Ex.Message);
            }
        }
    }
}
