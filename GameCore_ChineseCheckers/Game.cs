using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore_ChineseCheckers
{
    public class Game
    {
        public delegate void OutputHandler(string m_Instruction);
        public event OutputHandler OutputHandleEvent;

        public GameBoard MainBoard;

        public Game()
        {
            MainBoard = new GameBoard();

            InitializeBoard();
        }

        public void InitializeBoard()
        {
            try
            {

                //MainBoard.LocationArray[0][0] = new GamePosition(true, GameColor.Blue, new int[2] { 0, 1 }, new double[2] { 1.0, 7.0 });

                //MainBoard.LocationArray[1][0] = new GamePosition(true, GameColor.Blue, new int[2] { 1, 1 }, new double[2] { 2.0, 6.5 });
                //MainBoard.LocationArray[1][1] = new GamePosition(true, GameColor.Blue, new int[2] { 1, 2 }, new double[2] { 2.0, 7.5 });

                //MainBoard.LocationArray[2][0] = new GamePosition(true, GameColor.Blue, new int[2] { 2, 1 }, new double[2] { 3.0, 6.0 });
                //MainBoard.LocationArray[2][1] = new GamePosition(true, GameColor.Yellow, new int[2] { 2, 2 }, new double[2] { 3.0, 7.0 });
                //MainBoard.LocationArray[2][2] = new GamePosition(true, GameColor.Blue, new int[2] { 2, 3 }, new double[2] { 3.0, 8.0 });

                //MainBoard.LocationArray[3][0] = new GamePosition(true, GameColor.Red, new int[2] { 3, 1 }, new double[2] { 4.0, 5.5 });
                //MainBoard.LocationArray[3][1] = new GamePosition(true, GameColor.Blue, new int[2] { 3, 2 }, new double[2] { 4.0, 6.5 });
                //MainBoard.LocationArray[3][2] = new GamePosition(true, GameColor.Green, new int[2] { 3, 3 }, new double[2] { 4.0, 7.5 });
                //MainBoard.LocationArray[3][3] = new GamePosition(true, GameColor.Blue, new int[2] { 3, 4 }, new double[2] { 4.0, 8.5 });


                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < MainBoard.LocationArray[i].Length; j++)
                        MainBoard.LocationArray[i][j] = new GamePosition(true, GameColor.Blue, new int[2] { i, j + 1 }, new double[2] { i + 1.0, 7.0 - 0.5 * i + 1.0 * j });

                for (int i = 4; i < 9; i++)
                    for (int j = 0; j < MainBoard.LocationArray[i].Length; j++)
                    {
                        int number = 8 - i;
                        bool flag;
                        GameColor color;

                        if (j < number)
                        {
                            flag = true;
                            color = GameColor.Green;
                        }
                        else if (MainBoard.LocationArray[i].Length - 1 - j < number)
                        {
                            flag = true;
                            color = GameColor.Red;
                        }   
                        else
                        {
                            flag = false;
                            color = GameColor.White;
                        }

                        MainBoard.LocationArray[i][j] = new GamePosition(flag, color, new int[2] { i, j + 1 }, new double[2] { i + 1.0, 7.0 - 0.5 * (MainBoard.LocationArray[i].Length - 1) + 1.0 * j });
                    }

                for (int i = 9; i < 13; i++)
                    for (int j = 0; j < MainBoard.LocationArray[i].Length; j++)
                    {
                        int number = i - 8;
                        bool flag;
                        GameColor color;

                        if (j < number)
                        {
                            flag = true;
                            color = GameColor.Yellow;
                        }
                        else if (MainBoard.LocationArray[i].Length - 1 - j < number)
                        {
                            flag = true;
                            color = GameColor.Orange;
                        }
                        else
                        {
                            flag = false;
                            color = GameColor.White;
                        }

                        MainBoard.LocationArray[i][j] = new GamePosition(flag, color, new int[2] { i, j + 1 }, new double[2] { i + 1.0, 7.0 - 0.5 * (MainBoard.LocationArray[i].Length - 1) + 1.0 * j });
                    }

                for (int i = 13; i < 17; i++)
                    for (int j = 0; j < MainBoard.LocationArray[i].Length; j++)
                        MainBoard.LocationArray[i][j] = new GamePosition(true, GameColor.Purple, new int[2] { i, j + 1 }, new double[2] { i + 1.0, 7.0 - 0.5 * (16 - i) + 1.0 * j });

                        
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Occurred In InitializeBoard. Message:" + Ex.Message);
            }
        }

        public void UpdateInterface(string m_Instruction)
        {
            try
            {
                switch (m_Instruction)
                {
                    case "StackPanel_Board_Initialization":
                        {
                            for (int i = 0; i < MainBoard.LocationArray.Length; i++)
                            {
                                for (int j = 0; j < MainBoard.LocationArray[i].Length; j++)
                                {
                                    if (MainBoard.LocationArray[i][j].FrontEndLocation[0] >= 0 && MainBoard.LocationArray[i][j].FrontEndLocation[0] <= 16 &&
                                        MainBoard.LocationArray[i][j].FrontEndLocation[1] >= 1 && MainBoard.LocationArray[i][j].FrontEndLocation[1] <= 13)
                                    {
                                        string r_Communication = "Interface_Button_Initialization" + "," + MainBoard.LocationArray[i][j].CheckerColor.ToString() + "," + MainBoard.LocationArray[i][j].FrontEndLocation[0].ToString() + "," + MainBoard.LocationArray[i][j].FrontEndLocation[1].ToString() + "," + "End";
                                        OutputHandleEvent(r_Communication);
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Occurred In UpdateInterface. Message:" + Ex.Message);
            }
        }

        public void InputFromInterface(string r_Instruction)
        {
            try
            {
                string[] r_Array = r_Instruction.Split(new char[1] { ',' });

                switch (r_Array[0])
                {
                    case "Intersection_Event":
                        {
                            int r_X = Convert.ToInt32(r_Array[2]);
                            int r_Y = Convert.ToInt32(r_Array[3]) - 1;

                            Console.WriteLine("01 : " + r_Instruction);
                            Console.WriteLine("02 : " + MainBoard.LocationArray[r_X][r_Y].FrontEndLocation[0] + " , " + MainBoard.LocationArray[r_X][r_Y].FrontEndLocation[1]);
                            Console.WriteLine("03 : " + MainBoard.LocationArray[r_X][r_Y].BackEndLocation[0] + " , " + MainBoard.LocationArray[r_X][r_Y].BackEndLocation[1]);

                            string r_Communication = "Interface_Cursor_Pattern" + "," + MainBoard.LocationArray[r_X][r_Y].CheckerColor.ToString() + "," + "," + "," + "End";
                            OutputHandleEvent(r_Communication);
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Occurred In InputFromInterface. Message:" + Ex.Message);
            }
        }
    }
}
