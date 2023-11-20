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
    /// FiveBox.xaml 的互動邏輯
    /// </summary>
    public partial class FiveBox : UserControl
    {
        public delegate void GridHandler(GameColor m_PieceColor, string m_PieceName, string m_Instruction);
        public event GridHandler GridHandleEvent;

        public GameColor PieceColor = GameColor.Gray;
        public string PieceName = "";

        public FiveBox()
        {
            InitializeComponent();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            GridHandleEvent(PieceColor, PieceName, "FiveBox_MouseUp");
        }

        public void OneBox_E1_ColorChange(GameColor m_PieceColor, string m_PieceName, int[][] m_Value)
        {
            PieceColor = m_PieceColor;
            PieceName = m_PieceName;

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    ((StackPanel_FiveBox.Children[x] as StackPanel).Children[y] as OneBox_E1).X = x;
                    ((StackPanel_FiveBox.Children[x] as StackPanel).Children[y] as OneBox_E1).Y = y;
                    if (m_Value[x][y] == 1)
                        ((StackPanel_FiveBox.Children[x] as StackPanel).Children[y] as OneBox_E1).Border_ColorChange(m_PieceColor);
                    else
                        ((StackPanel_FiveBox.Children[x] as StackPanel).Children[y] as OneBox_E1).Border_ColorChange(GameColor.Gray);
                }
            }
        }
    }
}
