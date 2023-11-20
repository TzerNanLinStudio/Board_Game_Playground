using System;
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
using Microsoft.Win32;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using GameCore_ChineseCheckers;
//using Config_sharp;
//using LogRecorder_sharp;

namespace UI_ChineseCheckers
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
        public bool IsInitializationFlag = false;
        // --------------------------------------------------

        // Variables For Game.
        // --------------------------------------------------
        public Game GameData;
        // --------------------------------------------------

        // Variables For Config.
        // ---------------------------------------------------------------

        // ---------------------------------------------------------------

        // Variables For LogRecorder. 
        // ---------------------------------------------------------------

        // ---------------------------------------------------------------

        // Variables for Debug.
        // --------------------------------------------------

        // --------------------------------------------------
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            InitializeDetail();
        }

        #region "Event"
        private void Intersection_Event(int r_X, int r_Y, GameColor r_Color)
        {
            try
            {
                GameData.InputFromInterface("Intersection_Event"  + "," + r_Color.ToString() + "," + r_X.ToString() + "," + r_Y.ToString() + "," + "End");
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Occurred In Intersection_Event. Message:" + Ex.Message);
            }
        }

        private void Game_Event(string r_Instruction)
        {
            try
            {
                string[] r_Array = r_Instruction.Split(new char[1] { ',' });

                switch (r_Array[0])
                {
                    case "Interface_Button_Initialization":
                        {
                            int r_X = Convert.ToInt32(r_Array[2]);
                            int r_Y = Convert.ToInt32(r_Array[3]);
                            int[] r_CoordinateValue = new int[2] { r_X, r_Y };
                            GameColor r_CurrentColor = (GameColor)Enum.Parse(typeof(GameColor), r_Array[1]);

                            ((StackPanel_Board.Children[r_X] as StackPanel).Children[r_Y] as SinglePoint).ButtonHandleEvent += Intersection_Event;
                            ((StackPanel_Board.Children[r_X] as StackPanel).Children[r_Y] as SinglePoint).InitializeDetail(r_CurrentColor, r_CoordinateValue);
                        }
                        break;

                    case "Interface_Cursor_Pattern":
                        {
                            ///Border_Board.Cursor = new System.Windows.Input.Cursor(System.Environment.CurrentDirectory + @"\Appendix\Icon\BlueMouse.cur");
                            //Border_Board.Cursor = ((TextBlock)this.Resources["BlueCursor"]).Cursor;

                            switch (r_Array[1])
                            {
                                case "Arrow":
                                    {
                                        Border_Board.Cursor = System.Windows.Input.Cursors.Arrow;
                                    }
                                    break;

                                case "Blue":
                                    {
                                        Uri uri = new Uri("pack://application:,,,/Icon/BlueMouse.ico");

                                        Stream iconstream = GetCURFromICO_E1(uri, 16, 16);

                                        Border_Board.Cursor = new System.Windows.Input.Cursor(iconstream);
                                    }
                                    break;

                                case "Green":
                                    {
                                        Uri uri = new Uri("pack://application:,,,/Icon/GreenMouse.ico");

                                        Stream iconstream = GetCURFromICO_E1(uri, 16, 16);

                                        Border_Board.Cursor = new System.Windows.Input.Cursor(iconstream);
                                    }
                                    break;

                                case "Red":
                                    {
                                        Uri uri = new Uri("pack://application:,,,/Icon/RedMouse.ico");

                                        Stream iconstream = GetCURFromICO_E1(uri, 16, 16);

                                        Border_Board.Cursor = new System.Windows.Input.Cursor(iconstream);
                                    }
                                    break;

                                case "Yellow":
                                    {
                                        Uri uri = new Uri("pack://application:,,,/Icon/YellowMouse.ico");

                                        Stream iconstream = GetCURFromICO_E1(uri, 16, 16);

                                        Border_Board.Cursor = new System.Windows.Input.Cursor(iconstream);
                                    }
                                    break;

                                case "Orange":
                                    {
                                        Uri uri = new Uri("pack://application:,,,/Icon/OrangeMouse.ico");

                                        Stream iconstream = GetCURFromICO_E1(uri, 16, 16);

                                        Border_Board.Cursor = new System.Windows.Input.Cursor(iconstream);
                                    }
                                    break;

                                case "Purple":
                                    {
                                        Uri uri = new Uri("pack://application:,,,/Icon/PurpleMouse.ico");

                                        Stream iconstream = GetCURFromICO_E1(uri, 16, 16);

                                        Border_Board.Cursor = new System.Windows.Input.Cursor(iconstream);
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
                Console.WriteLine("Error Occurred In Game_Event. Message:" + Ex.Message);
            }
        }
        #endregion

        #region "Function"
        private void InitializeDetail()
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

                //this.Cursor = new System.Windows.Input.Cursor(@"C:\Users\Ned\Desktop\Test01\UI\Icon\Cursor_01.cur");

                // Config Initialization Or Setting
                // --------------------------------------------------

                // --------------------------------------------------

                // Log Initialization Or Setting
                // --------------------------------------------------

                // --------------------------------------------------

                // Game Initialization Or Setting
                // --------------------------------------------------
                GameData = new Game();
                GameData.OutputHandleEvent += Game_Event;

                GameData.UpdateInterface("StackPanel_Board_Initialization");
                // --------------------------------------------------

                // UI Initialization Or Setting
                // --------------------------------------------------

                // --------------------------------------------------

                // Debug Initialization Or Setting
                // --------------------------------------------------

                // --------------------------------------------------

                if (true)
                {
                    IsInitializationFlag = false;
                    //ShowWindow(Hwnd, SW_HIDE);
                    Console.WriteLine("====================================================================================================");
                    Console.WriteLine("====================================================================================================");
                    Console.WriteLine("====================================================================================================" + "\n");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Occurred In InitializeDetail. Message:" + Ex.Message);
                //throw; 
                //throw Ex;
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

        public void InformationToInterface(string r_Mode, string r_Statement)
        {
            string r_DateTime = TimeFormat(1, DateTime.Now);

            switch (r_Mode)
            {
                case "System":
                    Dispatcher.Invoke(() => RichTextBox_SystemLog.Document.Blocks.Add(new Paragraph(new Run(r_DateTime + r_Statement))));
                    Dispatcher.Invoke(() => RichTextBox_SystemLog.ScrollToEnd());
                    break;

                default:
                    break;
            }
        }

        public static Stream GetCURFromICO_E1(Uri uri, byte hotspotx, byte hotspoty)
        {
            StreamResourceInfo sri = System.Windows.Application.GetResourceStream(uri);

            Stream s = sri.Stream;

            byte[] buffer = new byte[s.Length];

            s.Read(buffer, 0, (int)s.Length);

            MemoryStream ms = new MemoryStream();

            buffer[2] = 2; // change to CUR file type
            buffer[10] = hotspotx;
            buffer[12] = hotspoty;

            ms.Write(buffer, 0, (int)s.Length);

            ms.Position = 0;

            return ms;
        }

        public static Stream GetCURFromICO_E2(Uri uri, byte hotspotx, byte hotspoty)
        {
            StreamResourceInfo sri = System.Windows.Application.GetResourceStream(uri);

            Stream s = sri.Stream;

            byte[] buffer = new byte[s.Length];

            MemoryStream ms = new MemoryStream();

            ms.WriteByte(0); // always 0
            ms.WriteByte(0);
            ms.WriteByte(2); // change file type to CUR
            ms.WriteByte(0);
            ms.WriteByte(1); // 1 icon in table
            ms.WriteByte(0);

            s.Position = 6; // skip over first 6 bytes in ICO as we just wrote

            s.Read(buffer, 0, 4);
            ms.Write(buffer, 0, 4);

            ms.WriteByte(hotspotx);
            ms.WriteByte(0);

            ms.WriteByte(hotspoty);
            ms.WriteByte(0);

            s.Position += 4; // skip 4 bytes as we just wrote our own

            int remaining = (int)s.Length - 14;

            s.Read(buffer, 0, remaining);
            ms.Write(buffer, 0, remaining);

            ms.Position = 0;

            return ms;
        }
        #endregion

        #region "UI"
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ShowWindow(Hwnd, SW_HIDE);
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as System.Windows.Controls.MenuItem).Name)
                {
                    case "MenuItem_NewGame":
                        {
                            
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception Occurred When MenuItem Click. Message : " + Ex.Message);
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as System.Windows.Controls.Button).Name)
                {
                    case "Btn_Blokus":
                        {

                        }
                        break;

                    case "Btn_ChineseCheckers":
                        {

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
        #endregion

        #region "Debug"
        private void MenuItem_Test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch ((sender as System.Windows.Controls.MenuItem).Name)
                {
                    case "MenuItem_DebugFunction06":
                        {

                        }
                        break;

                    case "MenuItem_DebugFunction07":
                        {

                        }
                        break;

                    case "MenuItem_DebugFunction08":
                        {

                        }
                        break;

                    case "MenuItem_DebugFunction09":
                        {

                        }
                        break;

                    case "MenuItem_DebugFunction10":
                        {

                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Exception Occurred When MenuItem Been Clicked. Message:" + Ex.Message);
            }
        }
        #endregion

        #region "Reserve"

        #endregion
    }
}
