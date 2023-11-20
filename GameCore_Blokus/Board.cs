using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore_Blokus
{
    public struct BoardPoint
    {
        public BoardPoint(bool m_BeClicked, GameColor m_CurrentColor)
        {
            BeClicked = m_BeClicked;
            CurrentColor = m_CurrentColor;
        }

        public bool BeClicked { get; set; }
        public GameColor CurrentColor { get; set; }
    }

    public class Board
    {
        public BoardPoint[][] BoardValue;

        public Board()
        {
            BoardValue = new BoardPoint[20][];

            for (int i = 0; i < 20; i++)
            {
                BoardValue[i] = new BoardPoint[20];

                for (int j = 0; j < 20; j++)
                {
                    BoardValue[i][j] = new BoardPoint(false, GameColor.Gray);
                }
            }
        }

        public void Board_Reset()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    BoardValue[i][j].BeClicked = false;
                    BoardValue[i][j].CurrentColor = GameColor.Gray;
                }
            }
        }
    }
}
