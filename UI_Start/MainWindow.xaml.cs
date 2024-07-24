using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Net.Sockets;
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
using UI_Blokus;
using UI_ChineseCheckers;
using UI_Debugger;
using Config_sharp;
using LogRecorder_sharp;

namespace UI_Start
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Parameter
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

        #region Event

        #endregion

        #region Method
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

                // UI Initialization Or Setting
                // --------------------------------------------------

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
        #endregion

        #region UI
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ShowWindow(Hwnd, SW_HIDE);
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.S && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                //ShowWindow(Hwnd, SW_SHOW);
                UI_Debugger.MainWindow tempWindow = new UI_Debugger.MainWindow();
                tempWindow.Show();
            }

            if (e.Key == Key.H && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                //ShowWindow(Hwnd, SW_HIDE);
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
                            UI_Blokus.MainWindow tempWindow = new UI_Blokus.MainWindow();
                            tempWindow.Show();
                        }
                        break;

                    case "Btn_ChineseCheckers":
                        {
                            UI_ChineseCheckers.MainWindow tempWindow = new UI_ChineseCheckers.MainWindow();
                            tempWindow.Show();
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

        #region Debug

        #endregion

        #region Reserve

        #endregion
    }
}
