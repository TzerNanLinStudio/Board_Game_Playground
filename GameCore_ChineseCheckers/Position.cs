using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore_ChineseCheckers
{
    public enum GameColor
    {
        Black = 1,
        White = 2,
        Gray = 3,
        Blue = 4,
        Green = 5,
        Red = 6,
        Yellow = 7,
        Orange = 8,
        Purple = 9,
        Pink  = 10,
        LightBlue = 400,
        LightGreen = 500,
        LightRed = 600,
        LightYellow = 700
    }

    public struct GameCoordinate
    {
        double X;
        double Y;

        /// <summary>
        /// r_X是縱向；r_Y是橫向
        /// </summary>
        public GameCoordinate(double r_X, double r_Y)
        {
            X = r_X;
            Y = r_Y;
        }
    }

    public class GamePosition
    {
        #region "Parametr"
        public bool StartPointFlag;
        public int[] FrontEndLocation;
        public double[] BackEndLocation;
        public GameColor CheckerColor;

        public GameCoordinate SelfLocation; //要不要用final固定座標???
        public GameCoordinate[] SideLocation; //要不要用final固定座標???
        #endregion

        public GamePosition()
        {
            StartPointFlag = false;
            FrontEndLocation = new int[2] { -1, -1 };
            BackEndLocation = new double[2] { -1, -1 };
            CheckerColor = GameColor.White;

            SelfLocation = new GameCoordinate(0, 0);
            SideLocation = new GameCoordinate[6];
            for (int i = 0; i < 6; i++)
                SideLocation[i] = new GameCoordinate();
        }

        /// <summary>
        /// r_FrontEndLocation[2] = [縱向,橫向]；r_SideLocation[6] = [左,左上,右上,右,右下,左下]
        /// </summary>
        public GamePosition(bool r_StartPointFlag, GameColor r_CheckerColor, int[] r_FrontEndLocation, double[] r_BackEndLocation)
        {
            try
            {
                StartPointFlag = r_StartPointFlag;
                FrontEndLocation = new int[2] { r_FrontEndLocation[0], r_FrontEndLocation[1] };
                BackEndLocation = new double[2] { r_BackEndLocation[0], r_BackEndLocation[1] };
                CheckerColor = r_CheckerColor;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Message : " + Ex.Message);
            }
        }

        /// <summary>
        /// r_InterfaceSort[2] = [縱向,橫向]；r_SideLocation[6] = [左,左上,右上,右,右下,左下]
        /// </summary>
        public GamePosition(bool r_StartPointFlag, GameColor r_CheckerColor, int[] r_InterfaceSort, double[] r_SelfLocation, double[][] r_SideLocation)
        {
            try
            {
                StartPointFlag = r_StartPointFlag;
                FrontEndLocation = new int[2] { r_InterfaceSort[0], r_InterfaceSort[1] };
                CheckerColor = r_CheckerColor;
                SelfLocation = new GameCoordinate(r_SelfLocation[0], r_SelfLocation[1]);
                SideLocation = new GameCoordinate[6];
                for (int i = 0; i < 6; i++)
                    SideLocation[i] = new GameCoordinate(r_SideLocation[i][0], r_SideLocation[i][1]);
            }
            catch(Exception Ex)
            {
                Console.WriteLine("Error Message : " + Ex.Message);
            }
        }
    }
}
