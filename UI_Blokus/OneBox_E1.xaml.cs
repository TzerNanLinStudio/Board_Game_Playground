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
    /// OneBox_E1.xaml 的互動邏輯
    /// </summary>
    public partial class OneBox_E1 : UserControl
    {
        public int X = -1;
        public int Y = -1;
        public GameColor BoxColor = GameColor.Gray;

        public OneBox_E1()
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
                            Border_Color.Background = Brushes.Black;
                        }
                        break;

                    case GameColor.White:
                        {
                            BoxColor = m_BoxColor;
                            Border_Color.Background = Brushes.White;
                        }
                        break;

                    case GameColor.Gray:
                        {
                            BoxColor = m_BoxColor;
                            Border_Color.Background = Brushes.Gray;
                        }
                        break;

                    case GameColor.Blue:
                        {
                            BoxColor = m_BoxColor;
                            Border_Color.Background = Brushes.Blue;
                        }
                        break;

                    case GameColor.Green:
                        {
                            BoxColor = m_BoxColor;
                            Border_Color.Background = Brushes.Green;
                        }
                        break;

                    case GameColor.Red:
                        {
                            BoxColor = m_BoxColor;
                            Border_Color.Background = Brushes.Red;
                        }
                        break;

                    case GameColor.Yellow:
                        {
                            BoxColor = m_BoxColor;
                            Border_Color.Background = Brushes.Yellow;
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
    }
}
