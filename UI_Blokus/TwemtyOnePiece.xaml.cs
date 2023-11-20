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
    /// TwemtyOnePiece.xaml 的互動邏輯
    /// </summary>
    public partial class TwemtyOnePiece : UserControl
    {
        public delegate void TwemtyOnePieceHandler(GameColor m_PieceColor, string m_PieceName, string m_Instruction);
        public event TwemtyOnePieceHandler TwemtyOnePieceHandleEvent;

        public GameColor UserColor = GameColor.Gray;

        public TwemtyOnePiece()
        {
            InitializeComponent();
            InitializeDetail();
        }

        private void InitializeDetail()
        {
            try
            {
                for (int x = 0; x < 7; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        ((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as FiveBox).GridHandleEvent += FiveBox_Event;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void FiveBox_Event(GameColor m_PieceColor, string m_PieceName, string m_Instruction)
        {
            TwemtyOnePieceHandleEvent(m_PieceColor, m_PieceName, m_Instruction);
        }

        public void FiveBox_ColorChange(GameColor m_PieceColor, string m_PieceName, int m_X, int m_Y, int[][] m_Value)
        {
            ((StackPanel_TwentyBox.Children[m_X] as StackPanel).Children[m_Y] as FiveBox).OneBox_E1_ColorChange(m_PieceColor, m_PieceName, m_Value);
        }

        public void FiveBox_Lock(GameColor m_PieceColor, string m_PieceName)
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if(((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as FiveBox).PieceName == m_PieceName)
                    {
                        ((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as FiveBox).Visibility = System.Windows.Visibility.Hidden;
                    }
                }
            }
        }

        public void FiveBox_Unlock()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    ((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as FiveBox).Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        public void TwemtyOnePiece_ColorChange(GameColor m_UserColor)
        {
            UserColor = m_UserColor;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as System.Windows.Controls.Button).Name)
                {
                    case "Btn_Right":
                        {
                            TwemtyOnePieceHandleEvent(UserColor, "Null", "TwemtyOnePiece_TurnRight");
                        }
                        break;

                    case "Btn_Left":
                        {
                            TwemtyOnePieceHandleEvent(UserColor, "Null", "TwemtyOnePiece_TurnLeft");
                        }
                        break;

                    case "Btn_Turn":
                        {
                            TwemtyOnePieceHandleEvent(UserColor, "Null", "TwemtyOnePiece_TurnUp");
                        }
                        break;

                    case "Btn_Pass":
                        {
                            TwemtyOnePieceHandleEvent(UserColor, "Null", "TwemtyOnePiece_PassStep");
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
