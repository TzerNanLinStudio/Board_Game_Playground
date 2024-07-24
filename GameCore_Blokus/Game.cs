using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore_Blokus
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
        LightBlue = 400,
        LightGreen = 500,
        LightRed = 600,
        LightYellow = 700
    }

    public enum GamePiece
    {
        P5_I = 0,
        P5_L = 1,
        P5_Z = 2,
        P5_T = 3,
        P5_U = 4,
        P5_X = 5,
        P5_W = 6,
        P5_V = 7,
        P5_F = 8,
        P5_P = 9,
        P5_Y = 10,
        P5_N = 11,
        P4_I = 12,
        P4_L = 13,
        P4_Z = 14,
        P4_T = 15,
        P4_Square = 16,
        P3_Normal = 17,
        P3_Crooked = 18,
        P2_Normal = 19,
        P1_Normal = 20
    }

    public class Game
    {
        public delegate void OutputHandler(string m_Instruction);
        public event OutputHandler OutputHandleEvent;

        public Player[] GamePlayer;
        public Board GameBoard;
        public bool PieceBeClickedFlag;
        public bool PieceBeSuitedFlag;
        public bool MouseBeUppedFlag;
        public bool MouseBeMovedFlag;
        public bool MouseBeLeavedFlag;
        public GameColor CurrentColor;
        public string CurrentPieceString;
        public int CurrentPlayerInt;
        public int CurrentPieceInt;
        public int RotateTimeInt;
        public int TurnTimeInt;
        public int[] AccumulatePoint;

        public Game()
        {
            GamePlayer = new Player[4];
            GamePlayer[0] = new Player("Blue");
            GamePlayer[1] = new Player("Green");
            GamePlayer[2] = new Player("Red");
            GamePlayer[3] = new Player("Yellow");

            GameBoard = new Board();

            PieceBeClickedFlag = false;
            PieceBeSuitedFlag = false;
            MouseBeUppedFlag = false;
            MouseBeMovedFlag = false;
            MouseBeLeavedFlag = false;
            CurrentPieceString = "";
            CurrentPlayerInt = -1;
            CurrentPieceInt = -1;
            RotateTimeInt = 0;

            AccumulatePoint = new int[4];
            AccumulatePoint[0] = 0; //Blue
            AccumulatePoint[1] = 0; //Green
            AccumulatePoint[2] = 0; //Red
            AccumulatePoint[3] = 0; //Yellow
        }

        public void InputFromUI(string m_Instrustion)
        {
            try
            {
                string[] m_Array = m_Instrustion.Split(new char[1] { ',' });

                switch (m_Array[0])
                {
                    case "Board_Event":
                        {
                            switch (m_Array[1])
                            {
                                case "MouseUp":
                                    {
                                        if (PieceBeClickedFlag)
                                        {
                                            int m_X = Convert.ToInt32(m_Array[2]);
                                            int m_Y = Convert.ToInt32(m_Array[3]);

                                            MouseBeUppedFlag = true;
                                            DrawPieceOnUI(m_X, m_Y);
                                            MouseBeUppedFlag = false;
                                        }
                                    }
                                    break;

                                case "MouseMove":
                                    {
                                        if (PieceBeClickedFlag)
                                        {
                                            int m_X = Convert.ToInt32(m_Array[2]);
                                            int m_Y = Convert.ToInt32(m_Array[3]);

                                            MouseBeMovedFlag = true;
                                            DrawPieceOnUI(m_X, m_Y);
                                            MouseBeMovedFlag = false;
                                        }
                                    }
                                    break;

                                case "MouseLeave":
                                    {
                                        if (PieceBeClickedFlag)
                                        {
                                            int m_X = Convert.ToInt32(m_Array[2]);
                                            int m_Y = Convert.ToInt32(m_Array[3]);

                                            MouseBeLeavedFlag = true;
                                            DrawPieceOnUI(m_X, m_Y);
                                            MouseBeLeavedFlag = false;
                                        }
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    case "Player_Event":
                        {
                            switch (m_Array[1])
                            {
                                case "FiveBox_MouseUp":
                                    {
                                        RotateTimeInt = 0;
                                        TurnTimeInt = 0;
                                        CurrentColor = (GameColor)Enum.Parse(typeof(GameColor), m_Array[2]);
                                        CurrentPieceString = m_Array[3];
                                        PieceBeClickedFlag = true;

                                        StringFindInt();
                                    }
                                    break;

                                case "TwemtyOnePiece_TurnRight":
                                    {
                                        RotateTimeInt++;
                                        if (RotateTimeInt == 4)
                                            RotateTimeInt = 0;
                                    }
                                    break;

                                case "TwemtyOnePiece_TurnLeft":
                                    {
                                        RotateTimeInt--;
                                        if (RotateTimeInt == -1)
                                            RotateTimeInt = 3;
                                    }
                                    break;

                                case "TwemtyOnePiece_TurnUp":
                                    {
                                        TurnTimeInt++;
                                        if (TurnTimeInt == 2)
                                            TurnTimeInt = 0;
                                    }
                                    break;

                                case "TwemtyOnePiece_PassStep":
                                    {
                                        CurrentColor = (GameColor)Enum.Parse(typeof(GameColor), m_Array[2]);

                                        if (CurrentColor == GameColor.Blue)
                                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Green.ToString() + "," + CurrentPieceString + "," + "End");
                                        else if (CurrentColor == GameColor.Green)
                                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Red.ToString() + "," + CurrentPieceString + "," + "End");
                                        else if (CurrentColor == GameColor.Red)
                                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Yellow.ToString() + "," + CurrentPieceString + "," + "End");
                                        else if (CurrentColor == GameColor.Yellow)
                                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Blue.ToString() + "," + CurrentPieceString + "," + "End");
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    case "TabControl_Selected":
                        {
                            switch (m_Array[1])
                            {
                                case "ColorChange":
                                    {
                                        RotateTimeInt = 0;

                                        //Console.WriteLine("20:" + m_Instrustion + ", RotateTimeInt : " + RotateTimeInt);
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    case "Btn_Click":
                        {
                            switch (m_Array[1])
                            {
                                case "NewGame":
                                    {
                                        GameBoard.Board_Reset();

                                        for (int x = 0; x < 20; x++)
                                        {
                                            for (int y = 0; y < 20; y++)
                                            {
                                                OutputHandleEvent("Board_Event" + "," + (GameColor.Gray).ToString() + "," + (x).ToString() + "," + (y).ToString() + "," + "End");
                                            }
                                        }

                                        OutputHandleEvent("TabItem_Event" + "," + (GameColor.Blue).ToString() + "," + "End");

                                        AccumulatePoint[0] = 0; //Blue
                                        AccumulatePoint[1] = 0; //Green
                                        AccumulatePoint[2] = 0; //Red
                                        AccumulatePoint[3] = 0; //Yellow
                                    }
                                    break;

                                case "EndGame":
                                    {
                                        string m_ReturnString = "";

                                        m_ReturnString = "藍色面積 : " + AccumulatePoint[0].ToString();
                                        OutputHandleEvent("TabItem_Event" + "," + "Message" + "," + m_ReturnString + "," + "End");

                                        m_ReturnString = "綠色面積 : " + AccumulatePoint[1].ToString();
                                        OutputHandleEvent("TabItem_Event" + "," + "Message" + "," + m_ReturnString + "," + "End");

                                        m_ReturnString = "紅色面積 : " + AccumulatePoint[2].ToString();
                                        OutputHandleEvent("TabItem_Event" + "," + "Message" + "," + m_ReturnString + "," + "End");

                                        m_ReturnString = "黃色面積 : " + AccumulatePoint[3].ToString();
                                        OutputHandleEvent("TabItem_Event" + "," + "Message" + "," + m_ReturnString + "," + "End");

                                        if (AccumulatePoint[0] > AccumulatePoint[1] && AccumulatePoint[0] > AccumulatePoint[2] && AccumulatePoint[0] > AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色獲勝!";
                                        }
                                        else if (AccumulatePoint[1] > AccumulatePoint[0] && AccumulatePoint[1] > AccumulatePoint[2] && AccumulatePoint[1] > AccumulatePoint[3])
                                        {
                                            m_ReturnString = "綠色獲勝!";
                                        }
                                        else if (AccumulatePoint[2] > AccumulatePoint[0] && AccumulatePoint[2] > AccumulatePoint[1] && AccumulatePoint[2] > AccumulatePoint[3])
                                        {
                                            m_ReturnString = "紅色獲勝!";
                                        }
                                        else if (AccumulatePoint[3] > AccumulatePoint[0] && AccumulatePoint[3] > AccumulatePoint[1] && AccumulatePoint[3] > AccumulatePoint[2])
                                        {
                                            m_ReturnString = "黃色獲勝!";
                                        }// ----------
                                        else if (AccumulatePoint[0] == AccumulatePoint[1] && AccumulatePoint[0] > AccumulatePoint[2] && AccumulatePoint[0] > AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色綠色平手!";
                                        }
                                        else if (AccumulatePoint[0] > AccumulatePoint[1] && AccumulatePoint[0] == AccumulatePoint[2] && AccumulatePoint[0] > AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色紅色平手!";
                                        }
                                        else if (AccumulatePoint[0] > AccumulatePoint[1] && AccumulatePoint[0] > AccumulatePoint[2] && AccumulatePoint[0] == AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色黃色平手!";
                                        }
                                        else if (AccumulatePoint[1] > AccumulatePoint[0] && AccumulatePoint[1] == AccumulatePoint[2] && AccumulatePoint[1] > AccumulatePoint[3])
                                        {
                                            m_ReturnString = "綠色紅色平手!";
                                        }
                                        else if (AccumulatePoint[1] > AccumulatePoint[0] && AccumulatePoint[1] > AccumulatePoint[2] && AccumulatePoint[1] == AccumulatePoint[3])
                                        {
                                            m_ReturnString = "綠色黃色平手!";
                                        }
                                        else if (AccumulatePoint[2] > AccumulatePoint[0] && AccumulatePoint[2] > AccumulatePoint[1] && AccumulatePoint[2] == AccumulatePoint[3])
                                        {
                                            m_ReturnString = "紅色黃色平手!";
                                        }// ---------
                                        else if (AccumulatePoint[0] == AccumulatePoint[1] && AccumulatePoint[0] == AccumulatePoint[2] && AccumulatePoint[0] > AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色綠色紅色平手!";
                                        }
                                        else if (AccumulatePoint[0] == AccumulatePoint[1] && AccumulatePoint[0] > AccumulatePoint[2] && AccumulatePoint[0] == AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色綠色黃色平手!";
                                        }
                                        else if (AccumulatePoint[0] > AccumulatePoint[1] && AccumulatePoint[0] == AccumulatePoint[2] && AccumulatePoint[0] == AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色紅色黃色平手!";
                                        }
                                        else if (AccumulatePoint[1] > AccumulatePoint[0] && AccumulatePoint[1] == AccumulatePoint[2] && AccumulatePoint[1] == AccumulatePoint[3])
                                        {
                                            m_ReturnString = "綠色紅色黃色平手!";
                                        }// ---------
                                        else if (AccumulatePoint[0] == AccumulatePoint[1] && AccumulatePoint[0] == AccumulatePoint[2] && AccumulatePoint[0] == AccumulatePoint[3])
                                        {
                                            m_ReturnString = "藍色綠色紅色黃色平手!";   
                                        }// ---------
                                        else 
                                        {
                                            m_ReturnString = "例外狀況!";                                            
                                        }

                                        OutputHandleEvent("TabItem_Event" + "," + "Message" + "," + m_ReturnString + "," + "End");
                                    }
                                    break;

                                default:
                                    break;
                            }                     
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

        private void StringFindInt()
        {
            for (int i = 0; i < GamePlayer.Length; i++)
            {
                if (CurrentColor.ToString().CompareTo(GamePlayer[i].PlayerColor) == 0)
                {
                    CurrentPlayerInt = i;
                    break;
                }
            }

            for (int i = 0; i < GamePlayer[CurrentPlayerInt].PlayerPiece.Length; i++)
            {
                if (CurrentPieceString.CompareTo(GamePlayer[CurrentPlayerInt].PlayerPiece[i].PieceName) == 0)
                {
                    CurrentPieceInt = i;
                    break;
                }
            }
        }

        private void DrawPieceOnUI(int m_Center_X, int m_Center_Y)
        {
            try
            {
                #region "Parameter"
                GameColor m_CurrentColor = CurrentColor;
                GameColor m_OutputColor = CurrentColor;
                bool m_IsSuitable = true;
                int m_Start_X = m_Center_X - 2;
                int m_Start_Y = m_Center_Y - 2;
                int m_Output_X = -1;
                int m_Output_Y = -1;
                int m_Slope_Point = 0;
                int m_VerticalOrHorizontal_Point = 0;
                int m_Repeat_Point = 0;
                int m_Exceed_Point = 0;
                int m_Start_Point = 0;
                #endregion

                #region "Process"
                //複製陣列
                //--------------------
                int[][] m_PieceValue = new int[5][];
                for (int i = 0; i < 5; i++)
                    m_PieceValue[i] = new int[5] { 0, 0, 0, 0, 0 };

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        m_PieceValue[i][j] = GamePlayer[CurrentPlayerInt].PlayerPiece[CurrentPieceInt].PieceValue[i][j];
                    }
                }
                //Array.Copy(m_PieceValue, 0, GamePlayer[CurrentPlayerInt].PlayerPiece[CurrentPieceInt].PieceValue, 0, 25);//陣列複製測試碼
                //--------------------

                //旋轉陣列
                //--------------------
                for (int i = 0; i < RotateTimeInt; i++)
                {
                    int[][] m_TestValue = new int[5][];
                    for (int j = 0; j < 5; j++)
                        m_TestValue[j] = new int[5] { 0, 0, 0, 0, 0 };

                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            m_TestValue[4 - k][j] = m_PieceValue[j][k];
                        }
                    }

                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            m_PieceValue[j][k] = m_TestValue[j][k];
                        }
                    }
                }
                //--------------------

                //翻轉陣列
                //--------------------
                if (TurnTimeInt == 1)
                {
                    int[][] m_TestValue = new int[5][];
                    for (int j = 0; j < 5; j++)
                        m_TestValue[j] = new int[5] { 0, 0, 0, 0, 0 };

                    //0和4換 1和3換
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            m_TestValue[j][k] = m_PieceValue[4 - j][k];
                            m_TestValue[4 - j][k] = m_PieceValue[j][k];
                        }
                    }

                    //2複製
                    for (int k = 0; k < 5; k++)
                        m_TestValue[2][k] = m_PieceValue[2][k];

                    for (int j = 0; j < 5; j++)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            m_PieceValue[j][k] = m_TestValue[j][k];
                        }
                    }
                }
                //--------------------

                //檢查旗標
                //--------------------
                if (MouseBeMovedFlag)
                    m_OutputColor = (GameColor)(Convert.ToInt32(CurrentColor) * 100);

                if (MouseBeLeavedFlag)
                    m_OutputColor = GameColor.Gray;
                //--------------------

                //檢查置入是否合理
                //--------------------
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (m_PieceValue[x][y] == 1)
                        {
                            m_Output_X = m_Start_X + x;
                            m_Output_Y = m_Start_Y + y;

                            if (m_Output_X < 0 || m_Output_X >= 20 || m_Output_Y < 0 || m_Output_Y >= 20)
                            {
                                m_Exceed_Point++;
                            }
                            else
                            {
                                if (GameBoard.BoardValue[m_Output_X][m_Output_Y].BeClicked)
                                {
                                    m_Repeat_Point++;
                                }

                                if (MouseBeUppedFlag)
                                {
                                    //檢查有無起點
                                    //--------------------
                                    if (m_Output_X == 0 &&  m_Output_Y == 0)
                                        m_Start_Point++;

                                    if (m_Output_X == 0 && m_Output_Y == 19)
                                        m_Start_Point++;

                                    if (m_Output_X == 19 && m_Output_Y == 0)
                                        m_Start_Point++;

                                    if (m_Output_X == 19 && m_Output_Y == 19)
                                        m_Start_Point++;
                                    //--------------------

                                    //檢查上下左右有無相同顏色色塊
                                    //--------------------
                                    if (m_Output_X - 1 >= 0 && m_Output_X - 1 < 20 && m_Output_Y >= 0 && m_Output_Y < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X - 1][m_Output_Y].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X - 1][m_Output_Y].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_VerticalOrHorizontal_Point++;
                                            //Console.WriteLine("左面有重複!");//Debug用途
                                        }
                                    }

                                    if (m_Output_X >= 0 && m_Output_X < 20 && m_Output_Y - 1 >= 0 && m_Output_Y - 1 < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X][m_Output_Y - 1].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X][m_Output_Y - 1].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_VerticalOrHorizontal_Point++;
                                            //Console.WriteLine("上面有重複!");//Debug用途
                                        }
                                    }

                                    if (m_Output_X + 1 >= 0 && m_Output_X + 1 < 20 && m_Output_Y >= 0 && m_Output_Y < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X + 1][m_Output_Y].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X + 1][m_Output_Y].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_VerticalOrHorizontal_Point++;
                                            //Console.WriteLine("右面有重複!");//Debug用途
                                        }
                                    }

                                    if (m_Output_X >= 0 && m_Output_X < 20 && m_Output_Y + 1 >= 0 && m_Output_Y + 1 < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X][m_Output_Y + 1].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X][m_Output_Y + 1].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_VerticalOrHorizontal_Point++;
                                            //Console.WriteLine("下面有重複!");//Debug用途
                                        }
                                    }
                                    //--------------------

                                    //檢查左上左下右上右下有無相同顏色色塊
                                    //--------------------
                                    if (m_Output_X - 1 >= 0 && m_Output_X - 1 < 20 && m_Output_Y - 1 >= 0 && m_Output_Y - 1 < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X - 1][m_Output_Y - 1].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X - 1][m_Output_Y - 1].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_Slope_Point++;
                                            //Console.WriteLine("左上面有重複!");//Debug用途
                                        }
                                    }

                                    if (m_Output_X - 1 >= 0 && m_Output_X - 1 < 20 && m_Output_Y + 1 >= 0 && m_Output_Y + 1 < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X - 1][m_Output_Y + 1].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X - 1][m_Output_Y + 1].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_Slope_Point++;
                                            //Console.WriteLine("左下面有重複!");//Debug用途
                                        }
                                    }

                                    if (m_Output_X + 1 >= 0 && m_Output_X + 1 < 20 && m_Output_Y - 1 >= 0 && m_Output_Y - 1 < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X + 1][m_Output_Y - 1].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X + 1][m_Output_Y - 1].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_Slope_Point++;
                                            //Console.WriteLine("右上面有重複!");//Debug用途
                                        }
                                    }

                                    if (m_Output_X + 1 >= 0 && m_Output_X + 1 < 20 && m_Output_Y + 1 >= 0 && m_Output_Y + 1 < 20)
                                    {
                                        if (GameBoard.BoardValue[m_Output_X + 1][m_Output_Y + 1].CurrentColor.CompareTo(m_OutputColor) == 0 && GameBoard.BoardValue[m_Output_X + 1][m_Output_Y + 1].CurrentColor.CompareTo(GameColor.Gray) != 0)
                                        {
                                            m_Slope_Point++;
                                            //Console.WriteLine("右下面有重複!");//Debug用途
                                        }
                                    }
                                    //--------------------
                                }
                            }
                        }
                    }
                }

                if (m_CurrentColor == GameColor.Blue && AccumulatePoint[0] == 0 && m_Start_Point != 1)
                    m_IsSuitable = false;
                else if (m_CurrentColor == GameColor.Green && AccumulatePoint[1] == 0 && m_Start_Point != 1)
                    m_IsSuitable = false;
                else if (m_CurrentColor == GameColor.Red && AccumulatePoint[2] == 0 && m_Start_Point != 1)
                    m_IsSuitable = false;
                else if (m_CurrentColor == GameColor.Yellow && AccumulatePoint[3] == 0 && m_Start_Point != 1)
                    m_IsSuitable = false;               
                else if (m_Exceed_Point > 0 || m_Repeat_Point > 0 || m_VerticalOrHorizontal_Point > 0)
                    m_IsSuitable = false;
                else if (m_Start_Point == 0 && m_Slope_Point == 0) //有顏色開局未設起點會有Bug
                    m_IsSuitable = false;
                //--------------------

                //委派結果
                //--------------------
                if (m_IsSuitable)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (m_PieceValue[x][y] == 1)
                            {
                                m_Output_X = m_Start_X + x;
                                m_Output_Y = m_Start_Y + y;

                                if (m_Output_X >= 0 && m_Output_X <= 19 && m_Output_Y >= 0 && m_Output_Y <= 19)
                                {
                                    if (MouseBeUppedFlag)
                                    {
                                        GameBoard.BoardValue[m_Output_X][m_Output_Y].BeClicked = true;
                                        GameBoard.BoardValue[m_Output_X][m_Output_Y].CurrentColor = m_OutputColor;//2021.06.28添加，邏輯作用，測試中

                                        if (m_CurrentColor == GameColor.Blue)
                                            AccumulatePoint[0]++;
                                        else if (m_CurrentColor == GameColor.Green)
                                            AccumulatePoint[1]++;
                                        else if (m_CurrentColor == GameColor.Red)
                                            AccumulatePoint[2]++;
                                        else if (m_CurrentColor == GameColor.Yellow)
                                            AccumulatePoint[3]++;
                                    }

                                    OutputHandleEvent("Board_Event" + "," + m_OutputColor.ToString() + "," + m_Output_X.ToString() + "," + m_Output_Y.ToString() + "," + "End");
                                }
                            }
                        }
                    }

                    if (MouseBeUppedFlag)
                    {
                        PieceBeClickedFlag = false;
                        OutputHandleEvent("Player_Event" + "," + CurrentColor.ToString() + "," + CurrentPieceString + "," + "End");

                        if (CurrentColor == GameColor.Blue)
                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Green.ToString() + "," + CurrentPieceString + "," + "End");
                        else if (CurrentColor == GameColor.Green)
                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Red.ToString() + "," + CurrentPieceString + "," + "End");
                        else if (CurrentColor == GameColor.Red)
                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Yellow.ToString() + "," + CurrentPieceString + "," + "End");
                        else if (CurrentColor == GameColor.Yellow)
                            OutputHandleEvent("TabItem_Event" + "," + GameColor.Blue.ToString() + "," + CurrentPieceString + "," + "End");
                    }      
                }
                else
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (m_PieceValue[x][y] == 1)
                            {
                                m_Output_X = m_Start_X + x;
                                m_Output_Y = m_Start_Y + y;

                                if (m_Output_X >= 0 && m_Output_X <= 19 && m_Output_Y >= 0 && m_Output_Y <= 19)
                                    if (!GameBoard.BoardValue[m_Output_X][m_Output_Y].BeClicked && !MouseBeUppedFlag)//邊界似乎有Bug
                                        OutputHandleEvent("Board_Event" + "," + m_OutputColor.ToString() + "," + m_Output_X.ToString() + "," + m_Output_Y.ToString() + "," + "End");
                            }
                        }
                    }
                }
                //--------------------
                #endregion
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Function 'DrawPieceOnUI' Occurred Wrong. Error: " + Ex.Message);
            }
        }
    }
}
