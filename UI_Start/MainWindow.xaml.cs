﻿using System;
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

        private void UdpServer(string title)
        {
            string ip4 = "";

            Dispatcher.Invoke(() => Window_Start.Title = title);
            Dispatcher.Invoke(() => ip4 = TextBox_IP.Text);

            if (false)
            {
                int recv;
                byte[] data = new byte[1024];

                //得到本機IP，設定TCP埠號         
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 8001);
                Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //繫結網路地址
                newsock.Bind(ip);

                Console.WriteLine("This is a Server, host name is {0}", Dns.GetHostName());

                //等待客戶機連線
                Console.WriteLine("Waiting for a client");

                //得到客戶機IP
                IPEndPoint _sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(_sender);
                recv = newsock.ReceiveFrom(data, ref Remote);
                Console.WriteLine("Message received from {0}: ", Remote.ToString());
                Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));

                //客戶機連線成功後，傳送資訊
                string welcome = "你好 ! ";

                //字串與位元組陣列相互轉換
                data = Encoding.UTF8.GetBytes(welcome);

                //傳送資訊
                newsock.SendTo(data, data.Length, SocketFlags.None, Remote);
                while (true)
                {
                    data = new byte[1024];
                    //接收資訊
                    recv = newsock.ReceiveFrom(data, ref Remote);
                    Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));
                    //newsock.SendTo(data, recv, SocketFlags.None, Remote);
                }
            }

            if (true)
            {
                byte[] data = new byte[1024];

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipAddr = IPAddress.Parse(ip4);
                IPEndPoint endpoint = new IPEndPoint(ipAddr, 8866);
                server.Bind(endpoint);
                server.Listen(10);

                Console.WriteLine("Wait");
                Socket client = server.Accept();
                Console.WriteLine("Connect");

                int length = client.Receive(data);
                string message = Encoding.ASCII.GetString(data, 0, length);
                Console.WriteLine("Message：{0}", message);

                client.Shutdown(SocketShutdown.Both);
                client.Close();
                server.Close();
            }
            
        }

        private void UdpClient(string title)
        {
            string ip4 = "";

            Dispatcher.Invoke(() => Window_Start.Title = title);
            Dispatcher.Invoke(() => ip4 = TextBox_IP.Text);

            if (false)
            {
                byte[] data = new byte[1024];
                string input, stringData;

                //構建TCP 伺服器
                Console.WriteLine("This is a Client, host name is {0}", Dns.GetHostName());

                //設定服務IP（這個IP地址是伺服器的IP），設定TCP埠號
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.147.1"), 8001);

                //定義網路型別，資料連線型別和網路協定UDP
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                string welcome = "你好! ";
                data = Encoding.UTF8.GetBytes(welcome);
                server.SendTo(data, data.Length, SocketFlags.None, ip);
                IPEndPoint _sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)_sender;

                data = new byte[1024];
                //對於不存在的IP地址，加入此行程式碼後，可以在指定時間內解除阻塞模式限制
                int recv = server.ReceiveFrom(data, ref Remote);
                Console.WriteLine("Message received from {0}: ", Remote.ToString());
                Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));
                int i = 0;
                while (true)
                {
                    string s = "hello cqjtu!重交物聯2018級" + i;
                    Console.WriteLine(s);
                    server.SendTo(Encoding.UTF8.GetBytes(s), Remote);
                    if (i == 50)
                    {
                        break;
                    }
                    i++;
                }
                Console.WriteLine("Stopping Client.");
                server.Close();
            }

            if (true)
            {
                byte[] data = Encoding.ASCII.GetBytes("happy");

                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipAddr = IPAddress.Parse(ip4);
                IPEndPoint endpoint = new IPEndPoint(ipAddr, 8866);
                client.Connect(endpoint);

                if (client.Connected)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("NG");
                }

                client.Send(data);

                client.Shutdown(SocketShutdown.Both);
                client.Close();

                Console.WriteLine("End");
            }
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
                            UI_Blokus.MainWindow A = new UI_Blokus.MainWindow();
                            A.Show();
                        }
                        break;

                    case "Btn_ChineseCheckers":
                        {
                            UI_ChineseCheckers.MainWindow B = new UI_ChineseCheckers.MainWindow();
                            B.Show();
                        }
                        break;

                    case "Btn_TcpServer":
                        {
                            Thread vocaburarytestthread = new Thread(() => UdpServer("Server"));
                            vocaburarytestthread.Start();
                        }
                        break;

                    case "Btn_TcpClient":
                        {
                            Thread vocaburarytestthread = new Thread(() => UdpClient("Client"));
                            vocaburarytestthread.Start();
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
