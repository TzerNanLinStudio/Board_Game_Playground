using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore_Blokus
{
    public class Piece
    {
        public int[][] PieceValue;
        public string PieceName;

        public Piece(string m_Name)
        {
            PieceName = m_Name;
            PieceValue = new int[5][];
            for (int i = 0; i < 5; i++)
                PieceValue[i] = new int[5] { 0, 0, 0, 0, 0 };

            switch (m_Name)
            {
                case "Long_I":
                    {
                        PieceValue[2][0] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[2][4] = 1;
                    }
                    break;

                case "Long_L":
                    {
                        PieceValue[2][0] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][3] = 1;
                    }
                    break;

                case "Long_Z":
                    {
                        PieceValue[1][1] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][3] = 1;
                    }
                    break;

                case "Long_T":
                    {
                        PieceValue[1][1] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][1] = 1;
                    }
                    break;

                case "U":
                    {
                        PieceValue[1][1] = 1;
                        PieceValue[1][2] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[3][1] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "X":
                    {
                        PieceValue[1][2] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "W":
                    {
                        PieceValue[1][3] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][1] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "V":
                    {
                        PieceValue[1][3] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][1] = 1;
                        PieceValue[3][2] = 1;
                        PieceValue[3][3] = 1;
                    }
                    break;

                case "F":
                    {
                        PieceValue[1][2] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][1] = 1;
                    }
                    break;

                case "P":
                    {
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][1] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "Y":
                    {
                        PieceValue[1][2] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[3][2] = 1;
                        PieceValue[4][2] = 1;
                    }
                    break;

                case "N":
                    {
                        PieceValue[1][3] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][2] = 1;
                        PieceValue[4][2] = 1;
                    }
                    break;

                case "Short_I":
                    {
                        PieceValue[2][0] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                    }
                    break;

                case "Short_L":
                    {
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][3] = 1;
                    }
                    break;

                case "Short_Z":
                    {
                        PieceValue[1][1] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "Short_T":
                    {
                        PieceValue[1][2] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[2][3] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "Square":
                    {
                        PieceValue[1][1] = 1;
                        PieceValue[1][2] = 1;
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                    }
                    break;

                case "Normal_3":
                    {
                        PieceValue[1][2] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "Crooked_3":
                    {
                        PieceValue[2][1] = 1;
                        PieceValue[2][2] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "2":
                    {
                        PieceValue[2][2] = 1;
                        PieceValue[3][2] = 1;
                    }
                    break;

                case "1":
                    {
                        PieceValue[2][2] = 1;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
