using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore_ChineseCheckers
{
    public class GameBoard
    {
        public GamePosition[][] LocationArray;

        public GameBoard()
        {
            LocationArray = new GamePosition[17][]; 
            LocationArray[0] = new GamePosition[1]; 
            for (int i = 0; i < LocationArray[0].Length; i++)
                LocationArray[0][i] = new GamePosition();
            LocationArray[1] = new GamePosition[2]; 
            for (int i = 0; i < LocationArray[1].Length; i++)
                LocationArray[1][i] = new GamePosition();
            LocationArray[2] = new GamePosition[3]; 
            for (int i = 0; i < LocationArray[2].Length; i++)
                LocationArray[2][i] = new GamePosition();
            LocationArray[3] = new GamePosition[4]; 
            for (int i = 0; i < LocationArray[3].Length; i++)
                LocationArray[3][i] = new GamePosition();
            LocationArray[4] = new GamePosition[13]; 
            for (int i = 0; i < LocationArray[4].Length; i++)
                LocationArray[4][i] = new GamePosition();
            LocationArray[5] = new GamePosition[12]; 
            for (int i = 0; i < LocationArray[5].Length; i++)
                LocationArray[5][i] = new GamePosition();
            LocationArray[6] = new GamePosition[11]; 
            for (int i = 0; i < LocationArray[6].Length; i++)
                LocationArray[6][i] = new GamePosition();
            LocationArray[7] = new GamePosition[10]; 
            for (int i = 0; i < LocationArray[7].Length; i++)
                LocationArray[7][i] = new GamePosition();
            LocationArray[8] = new GamePosition[9];
            for (int i = 0; i < LocationArray[8].Length; i++)
                LocationArray[8][i] = new GamePosition();
            LocationArray[9] = new GamePosition[10];
            for (int i = 0; i < LocationArray[9].Length; i++)
                LocationArray[9][i] = new GamePosition();
            LocationArray[10] = new GamePosition[11];
            for (int i = 0; i < LocationArray[10].Length; i++)
                LocationArray[10][i] = new GamePosition();
            LocationArray[11] = new GamePosition[12];
            for (int i = 0; i < LocationArray[11].Length; i++)
                LocationArray[11][i] = new GamePosition();
            LocationArray[12] = new GamePosition[13];
            for (int i = 0; i < LocationArray[12].Length; i++)
                LocationArray[12][i] = new GamePosition();
            LocationArray[13] = new GamePosition[4];
            for (int i = 0; i < LocationArray[13].Length; i++)
                LocationArray[13][i] = new GamePosition();
            LocationArray[14] = new GamePosition[3];
            for (int i = 0; i < LocationArray[14].Length; i++)
                LocationArray[14][i] = new GamePosition();
            LocationArray[15] = new GamePosition[2];
            for (int i = 0; i < LocationArray[15].Length; i++)
                LocationArray[15][i] = new GamePosition();
            LocationArray[16] = new GamePosition[1];
            for (int i = 0; i < LocationArray[16].Length; i++)
                LocationArray[16][i] = new GamePosition();
        }
    }
}
