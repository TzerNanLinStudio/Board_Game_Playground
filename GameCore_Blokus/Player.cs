using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore_Blokus
{
    public class Player
    {
        public string PlayerColor;

        public Piece[] PlayerPiece;

        public Player(string m_Color)
        {
            PlayerColor = m_Color;

            PlayerPiece = new Piece[21];
            PlayerPiece[0] = new Piece("Long_I");
            PlayerPiece[1] = new Piece("Long_L");
            PlayerPiece[2] = new Piece("U");
            PlayerPiece[3] = new Piece("Long_Z");
            PlayerPiece[4] = new Piece("Long_T");
            PlayerPiece[5] = new Piece("X");
            PlayerPiece[6] = new Piece("W");
            PlayerPiece[7] = new Piece("V");
            PlayerPiece[8] = new Piece("F");
            PlayerPiece[9] = new Piece("P");
            PlayerPiece[10] = new Piece("Y");
            PlayerPiece[11] = new Piece("N");
            PlayerPiece[12] = new Piece("Short_I");
            PlayerPiece[13] = new Piece("Short_T");
            PlayerPiece[14] = new Piece("Short_L");
            PlayerPiece[15] = new Piece("Short_Z");
            PlayerPiece[16] = new Piece("Square");
            PlayerPiece[17] = new Piece("Normal_3");
            PlayerPiece[18] = new Piece("Crooked_3");
            PlayerPiece[19] = new Piece("2");
            PlayerPiece[20] = new Piece("1");
        }
    }
}
