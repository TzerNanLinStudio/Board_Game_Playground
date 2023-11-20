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
    /// TwentyBox.xaml 的互動邏輯
    /// </summary>
    public partial class TwentyBox : UserControl
    {
        public delegate void TwentyBoxHandler(int m_X, int m_Y, GameColor m_BoxColor, string m_Instruction);
        public event TwentyBoxHandler TwentyBoxHandleEvent;

        public TwentyBox()
        {
            InitializeComponent();
            InitializeDetail();
        }

        private void InitializeDetail()
        {
            try
            {
                for (int x = 0; x < 20; x++)
                {
                    for (int y = 0; y < 20; y++)
                    {
                        ((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as OneBox_E2).BorderHandleEvent += Border_Event;
                        ((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as OneBox_E2).X = x;
                        ((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as OneBox_E2).Y = y;
                        ((StackPanel_TwentyBox.Children[x] as StackPanel).Children[y] as OneBox_E2).BoxColor = GameColor.Gray;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void Border_Event(int m_X, int m_Y, GameColor m_BoxColor, string m_Instruction)
        {
            TwentyBoxHandleEvent(m_X, m_Y, m_BoxColor, m_Instruction);
        }

        public void BoxColorChange(int m_X, int m_Y, GameColor m_BoxColor)
        {
            try
            {
                ((StackPanel_TwentyBox.Children[m_X] as StackPanel).Children[m_Y] as OneBox_E2).Border_ColorChange(m_BoxColor);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
