﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Resources;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Windows.Media.Media3D;
using System.Security.Cryptography;
using System.Speech.Synthesis; //2021.10.21新加入為測試語音 需在'參考'加入System.Speech
using Microsoft.Win32;
using Config_sharp;
using LogRecorder_sharp;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using GameCore_Blokus;

namespace UI_Blokus
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        #region "Parameter"
        // Variables For Commend Window.
        // --------------------------------------------------
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        IntPtr Hwnd = GetConsoleWindow();
        // --------------------------------------------------

        // Variables For UI.
        // --------------------------------------------------
        public TwemtyOnePiece[] GamePiece;
        public TwentyBox GameBoard;
        public bool IsInitializationFlag = false;
        // --------------------------------------------------

        // Variables For Game.
        // --------------------------------------------------
        public Game GameData;
        // --------------------------------------------------

        // Variables For Config.
        // ---------------------------------------------------------------
        public CustomConfig_UI UI_Config = new CustomConfig_UI();
        private string m_RecipeDirectoryPath = System.Environment.CurrentDirectory + @"\Appendix\Config\";
        private string m_RecipeFilename = "UI";
        private string m_RecipeSubtitle = ".dat";
        private string m_RecipeFullPath = "";
        // ---------------------------------------------------------------

        // Variables For LogRecorder. 
        // ---------------------------------------------------------------
        //public InfoMgr LogWritter;
        //bool IsLogInitSuccess = false;
        //private string m_LogFileRecipeDirectionPath = System.Environment.CurrentDirectory + @"\Appendix\Log\";
        //private string m_LogFileNameHeader = "UI";
        // ---------------------------------------------------------------

        // Variables for Debug.
        // --------------------------------------------------
        public Stopwatch[] DebugWatch = new Stopwatch[5] { new Stopwatch(), new Stopwatch(), new Stopwatch(), new Stopwatch(), new Stopwatch() };
        public Image<Bgr, byte>[] DebugBgrImage = new Image<Bgr, byte>[5] { null, null, null, null, null };
        public static Thread DebugThread;
        public bool[] DebugFlag = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        public bool[] PrintFlag = new bool[10] { false, false, false, false, false, false, false, false, false, false };
        public int[] DebugIntValue = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] DebugDoubleValue = new double[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        // --------------------------------------------------
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            InitializeAOI();
        }

        #region "Event"
        private void Board_Event(int m_X, int m_Y, GameColor m_Color, string m_Instruction)
        {
            try
            {
                GameData.InputFromUI("Board_Event" + "," + m_Instruction + "," + m_X + "," + m_Y + "," + "End");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }

        private void Player_Event(GameColor m_PieceColor, string m_PieceName, string m_Instruction)
        {
            try
            {
                GameData.InputFromUI("Player_Event" + "," + m_Instruction + "," + m_PieceColor.ToString() + "," +  m_PieceName + ","  + "End");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void Game_Event(string m_Instruction)
        {
            try
            {
                string[] m_Array = m_Instruction.Split(new char[1] { ',' });

                switch (m_Array[0])
                {
                    case "Board_Event":
                        {
                            int m_X = Convert.ToInt32(m_Array[2]);
                            int m_Y = Convert.ToInt32(m_Array[3]);

                            GameBoard.BoxColorChange(m_X, m_Y, (GameColor)Enum.Parse(typeof(GameColor), m_Array[1]));
                        }
                        break;

                    case "Player_Event":
                        {
                            switch ((GameColor)Enum.Parse(typeof(GameColor), m_Array[1]))
                            {
                                case GameColor.Blue:
                                    {
                                        GamePiece[0].FiveBox_Lock((GameColor)Enum.Parse(typeof(GameColor), m_Array[1]), m_Array[2]);
                                    }
                                    break;

                                case GameColor.Green:
                                    {
                                        GamePiece[1].FiveBox_Lock((GameColor)Enum.Parse(typeof(GameColor), m_Array[1]), m_Array[2]);
                                    }
                                    break;

                                case GameColor.Red:
                                    {
                                        GamePiece[2].FiveBox_Lock((GameColor)Enum.Parse(typeof(GameColor), m_Array[1]), m_Array[2]);
                                    }
                                    break;

                                case GameColor.Yellow:
                                    {
                                        GamePiece[3].FiveBox_Lock((GameColor)Enum.Parse(typeof(GameColor), m_Array[1]), m_Array[2]);
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    case "TabItem_Event":
                        {
                            switch (m_Array[1]) //((GameColor)Enum.Parse(typeof(GameColor), m_Array[1]))
                            {
                                case "Blue": // GameColor.Blue:
                                    {
                                        TabControl_Player.SelectedIndex = 0;
                                        (TabControl_Player.Items[0] as System.Windows.Controls.TabItem).IsEnabled = true;
                                        (TabControl_Player.Items[1] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[2] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[3] as System.Windows.Controls.TabItem).IsEnabled = false;
                                    }
                                    break;

                                case "Green": //GameColor.Green:
                                    {
                                        TabControl_Player.SelectedIndex = 1;
                                        (TabControl_Player.Items[0] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[1] as System.Windows.Controls.TabItem).IsEnabled = true;
                                        (TabControl_Player.Items[2] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[3] as System.Windows.Controls.TabItem).IsEnabled = false;
                                    }
                                    break;

                                case "Red": //GameColor.Red:
                                    {
                                        TabControl_Player.SelectedIndex = 2;
                                        (TabControl_Player.Items[0] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[1] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[2] as System.Windows.Controls.TabItem).IsEnabled = true;
                                        (TabControl_Player.Items[3] as System.Windows.Controls.TabItem).IsEnabled = false;
                                    }
                                    break;

                                case "Yellow": //GameColor.Yellow:
                                    {
                                        TabControl_Player.SelectedIndex = 3;
                                        (TabControl_Player.Items[0] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[1] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[2] as System.Windows.Controls.TabItem).IsEnabled = false;
                                        (TabControl_Player.Items[3] as System.Windows.Controls.TabItem).IsEnabled = true;
                                    }
                                    break;

                                case "Message":
                                    {
                                        WriteLogOnUI(m_Array[2]);
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
        #endregion

        #region "Function"
        private void InitializeAOI()
        {
            try
            {
                if (true)
                {
                    IsInitializationFlag = true;
                    ShowWindow(Hwnd, SW_SHOW);
                    Console.WriteLine("====================================================================================================");
                    Console.WriteLine("====================================================================================================");
                    Console.WriteLine("====================================================================================================");
                }

                // Config Initialization Or Setting
                // --------------------------------------------------
                Config_Init(true);
                // --------------------------------------------------

                // Log Initialization Or Setting
                // --------------------------------------------------
                //LogFileInit();
                // --------------------------------------------------

                // Game Initialization Or Setting
                // --------------------------------------------------
                GameData = new Game();
                GameData.OutputHandleEvent += Game_Event;
                // --------------------------------------------------

                // UI Initialization Or Setting
                // --------------------------------------------------
                TabControl_Player.SelectedIndex = 0;

                (TabControl_Player.Items[0] as System.Windows.Controls.TabItem).IsEnabled = false;
                (TabControl_Player.Items[1] as System.Windows.Controls.TabItem).IsEnabled = false;
                (TabControl_Player.Items[2] as System.Windows.Controls.TabItem).IsEnabled = false;
                (TabControl_Player.Items[3] as System.Windows.Controls.TabItem).IsEnabled = false;

                GameBoard = TwentyBox_Board;
                GameBoard.TwentyBoxHandleEvent += Board_Event;

                GamePiece = new TwemtyOnePiece[4];
                GamePiece[0] = TwemtyOnePiece_Blue;
                GamePiece[1] = TwemtyOnePiece_Green;
                GamePiece[2] = TwemtyOnePiece_Red;
                GamePiece[3] = TwemtyOnePiece_Yellow;
                for (int i = 0; i < 4; i++)
                    GamePiece[i].TwemtyOnePieceHandleEvent += Player_Event;

                PieceAssignment(0, GameColor.Blue);
                PieceAssignment(1, GameColor.Green);
                PieceAssignment(2, GameColor.Red);
                PieceAssignment(3, GameColor.Yellow);
                // --------------------------------------------------

                // Debug Code Initialization Or Setting
                // --------------------------------------------------

                // --------------------------------------------------

                if (true)
                {
                    IsInitializationFlag = false;
                    ShowWindow(Hwnd, SW_HIDE);
                    Console.WriteLine("====================================================================================================");
                    Console.WriteLine("====================================================================================================");
                    Console.WriteLine("====================================================================================================" + "\n");
                }
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX.Message);
            }
        }

        private void Restart()
        {
            Close();

            System.Threading.Thread thtmp = new System.Threading.Thread(new
            System.Threading.ParameterizedThreadStart(ReRun));

            object appName = System.Windows.Forms.Application.ExecutablePath;
            System.Threading.Thread.Sleep(5000);
            thtmp.Start(appName);
        }

        private void ReRun(Object obj)
        {
            System.Diagnostics.Process ps = new System.Diagnostics.Process();
            ps.StartInfo.FileName = obj.ToString();
            ps.Start();
        }

        public void UseTime(string title, TimeSpan ts)
        {
            if (PrintFlag[0])
            {
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                Console.WriteLine(title + elapsedTime);
            }
        }

        private string TimeFormat(int mode, DateTime datetime)
        {
            string date;
            string time;
            string str;

            switch (mode)
            {
                case 1:
                    date = datetime.ToShortDateString();
                    time = datetime.ToString("hh:mm:ss.FFF", System.Globalization.CultureInfo.InvariantCulture).PadRight(12, '0');
                    str = " [ " + date + " " + time + " ] : ";
                    return str;

                case 2:
                    str = datetime.Year.ToString() + "." + datetime.Month.ToString() + "." + datetime.Day.ToString() + "," + datetime.Hour.ToString() + "." + datetime.Minute.ToString() + "." + datetime.Second.ToString();
                    return str;

                case 3:
                    date = datetime.ToShortDateString();
                    time = datetime.ToString("hh:mm:ss.FFF", System.Globalization.CultureInfo.InvariantCulture).PadRight(12, '0');
                    str = date + " " + time;
                    return str;

                default:
                    date = datetime.ToShortDateString();
                    time = datetime.ToString("hh:mm:ss.FFF", System.Globalization.CultureInfo.InvariantCulture).PadRight(12, '0');
                    str = " [ " + date + " " + time + " ] : ";
                    return str;
            }
        }

        public void Config_Init(bool WhetherLoad)
        {
            m_RecipeFullPath = m_RecipeDirectoryPath + m_RecipeFilename + m_RecipeSubtitle;

            UI_Config = new CustomConfig_UI(m_RecipeFullPath);

            if (WhetherLoad)
                Config_Load();
        }

        public void Config_Load()
        {
            if (UI_Config.Load() == false) return;
        }

        public void Config_Save()
        {
            UI_Config.Save();
        }

        public void LogFileInit()
        {
            //string path = m_LogFileRecipeDirectionPath + m_LogFileNameHeader;

            //LogFileInitialization(path);
        }

        public void LogFileInitialization(string path)
        {
            string GenLog, WarningLog, ErrLog, DebugLog;

            try
            {
                GenLog = path + "./GeneralLog";
                WarningLog = path + "./WarningLog";
                ErrLog = path + "./ErrorLog";
                DebugLog = path + "./DebugLog";

                //LogWritter = new InfoMgr(GenLog, WarningLog, ErrLog, DebugLog);
            }
            catch (Exception ex)
            {
                WriteLogOnUI("Initialized Error In Log. Message: " + ex.Message);
            }

            //if (LogWritter != null) IsLogInitSuccess = true;
        }

        public void WriteLogOnUI(string m_Word)
        {
            string m_DateTime = TimeFormat(1, DateTime.Now);

            Dispatcher.Invoke(() => RichTextBox_SystemLog.Document.Blocks.Add(new Paragraph(new Run(m_DateTime + m_Word))));
            Dispatcher.Invoke(() => RichTextBox_SystemLog.ScrollToEnd());
        }

        public void DeleteSrcFolder(string file, bool itself)
        {
            //去除資料夾和子檔案的只讀屬性
            //去除資料夾的只讀屬性
            System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
            fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
            //去除檔案的只讀屬性
            System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
            //判斷資料夾是否還存在
            if (Directory.Exists(file))
            {
                foreach (string f in Directory.GetFileSystemEntries(file))
                {
                    if (File.Exists(f))
                    {
                        //如果有子檔案刪除檔案
                        File.Delete(f);
                    }
                    else
                    {
                        //迴圈遞迴刪除子資料夾 
                        DeleteSrcFolder(f, true);
                    }
                }
                //刪除空資料夾
                if (itself)
                    Directory.Delete(file);
            }
        }

        public void PieceAssignment(int m_Index, GameColor m_Color)
        {
            GamePiece[m_Index].TwemtyOnePiece_ColorChange(m_Color);

            for (int i = 0, j = 0, k = 0; i < 21; i++)
            {
                GamePiece[m_Index].FiveBox_ColorChange(m_Color, GameData.GamePlayer[m_Index].PlayerPiece[i].PieceName, j, k, GameData.GamePlayer[m_Index].PlayerPiece[i].PieceValue);

                if (++j > 6)
                {
                    j = 0;
                    k++;
                }
            }
        }
        #endregion

        #region "UI"
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ShowWindow(Hwnd, SW_HIDE);
        }

        private void TabControl_Selected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch ((sender as System.Windows.Controls.TabControl).Name)
                {
                    case "TabControl_Player":
                        {
                            if (!IsInitializationFlag)
                            {
                                switch ((sender as System.Windows.Controls.TabControl).SelectedIndex)
                                {
                                    case 0:
                                        {
                                            GameData.InputFromUI("TabControl_Selected" + "," + "ColorChange" + "," + "Blue" + "," + "End");
                                        }
                                        break;

                                    case 1:
                                        {
                                            GameData.InputFromUI("TabControl_Selected" + "," + "ColorChange" + "," + "Green" + "," + "End");
                                        }
                                        break;

                                    case 2:
                                        {
                                            GameData.InputFromUI("TabControl_Selected" + "," + "ColorChange" + "," + "Red" + "," + "End");
                                        }
                                        break;

                                    case 3:
                                        {
                                            GameData.InputFromUI("TabControl_Selected" + "," + "ColorChange" + "," + "Yellow" + "," + "End");
                                        }
                                        break;

                                    default:
                                        break;
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
                Console.WriteLine("Exception Occurred When TabControl Selected. Message : " + Ex.Message);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as System.Windows.Controls.Button).Name)
                {
                    case "Btn_NewGame":
                        {
                            GameData.InputFromUI("Btn_Click" + "," + "NewGame" + "," + "End");
                            GamePiece[0].FiveBox_Unlock();
                            GamePiece[1].FiveBox_Unlock();
                            GamePiece[2].FiveBox_Unlock();
                            GamePiece[3].FiveBox_Unlock();
                        }
                        break;

                    case "Btn_EndGame":
                        {
                            GameData.InputFromUI("Btn_Click" + "," + "EndGame" + "," + "End");
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

        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.S && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                ShowWindow(Hwnd, SW_SHOW);
            }

            if (e.Key == Key.H && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                ShowWindow(Hwnd, SW_HIDE);
            }
        }
        #endregion
    }
}
