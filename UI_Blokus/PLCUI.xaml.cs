using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AOI_UI
{
    /// <summary>
    /// PLC.xaml 的互動邏輯
    /// </summary>
    public partial class PLCUI : Window
    {
        public delegate void ButtonHandler(bool WhetherOpen);
        public event ButtonHandler ButtonHandlerEvent;

        public bool PLCConnection = false;

        public PLCUI()
        {
            InitializeComponent();             
        }

        public void UpdateUI(System.String PLC_IP, int PLC_Port, bool IsConnect)
        {
            PLCConnection = IsConnect;
            TextBox_IP.Text = PLC_IP;
            TextBox_Port.Text = PLC_Port.ToString();

            if (PLCConnection)
            {
                BitmapImage CloseIcon = new BitmapImage();
                CloseIcon.BeginInit();
                CloseIcon.UriSource = new Uri(System.Environment.CurrentDirectory + "/Appendix/Icon/NetworkOff.ico", UriKind.RelativeOrAbsolute);
                CloseIcon.EndInit();
                Image_OpenOrClose.Source = CloseIcon;

                Btn_OpenOrClose.Background = Brushes.Green;
                TextBlock_OpenOrClose.Text = " 關閉PLC";
            }
            else
            {
                BitmapImage OpenIcon = new BitmapImage();
                OpenIcon.BeginInit();
                OpenIcon.UriSource = new Uri(System.Environment.CurrentDirectory + "/Appendix/Icon/NetworkOn.ico", UriKind.RelativeOrAbsolute);
                OpenIcon.EndInit();
                Image_OpenOrClose.Source = OpenIcon;

                Btn_OpenOrClose.Background = Brushes.Red;
                TextBlock_OpenOrClose.Text = " 開啟PLC";
            }
        }

        private void Btn_OpenOrClose_Click(object sender, RoutedEventArgs e)
        {
            PLCConnection = !PLCConnection;
            ButtonHandlerEvent.Invoke(PLCConnection);
        }
    }
}
