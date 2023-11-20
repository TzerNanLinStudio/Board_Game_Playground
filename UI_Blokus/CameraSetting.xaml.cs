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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AOI_UI
{
    /// <summary>
    /// CameraSetting.xaml 的互動邏輯
    /// </summary>
    public partial class CameraSetting : UserControl
    {
        public delegate void TextBoxHandler(uint DeviceNunber, String ParameterName, int ParameterValue);
        public event TextBoxHandler TextBoxHandlerEvent;

        public delegate void ButtonHandler(uint DeviceNunber);
        public event ButtonHandler ButtonHandlerEvent;

        public uint CameraNumber;
        public String CameraName;

        public CameraSetting()
        {
            InitializeComponent();
        }

        public void Inittialization(uint DeviceNunber, String DeviceName, double ExposureTime, double Gain, double AcquisitionFrameRate)
        {
            CameraNumber = DeviceNunber;
            CameraName = DeviceName;

            Lab_CameraExposure.Content = "攝影機曝光(" + CameraName + ") : ";
            Lab_CameraGain.Content = "攝影機增益(" + CameraName + ") : ";
            Lab_CameraFPS.Content = "攝影機幀數(" + CameraName + ") : ";
            NumericUpDown_CameraExposure.Value = Convert.ToInt32(ExposureTime);
            NumericUpDown_CameraGain.Value = Convert.ToInt32(Gain);
            NumericUpDown_CameraFPS.Value = Convert.ToInt32(AcquisitionFrameRate);
        }

        private void Btn_CameraConfig_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandlerEvent.Invoke(CameraNumber);
        }

        private void NumericUpDown_CameraParameter_ValueChanged(object sender, EventArgs e)
        {
            switch ((sender as System.Windows.Forms.NumericUpDown).AccessibleName)
            {
                //Exposure Of Camera.
                case "NumericUpDown_CameraExposure":
                    TextBoxHandlerEvent.Invoke(CameraNumber, "ExposureTime", Convert.ToInt32(NumericUpDown_CameraExposure.Value));
                    break;

                //Gain Of Camera.
                case "NumericUpDown_CameraGain":
                    TextBoxHandlerEvent.Invoke(CameraNumber, "Gain", Convert.ToInt32(NumericUpDown_CameraGain.Value));
                    break;

                //FPS Of Camera.
                case "NumericUpDown_CameraFPS":
                    TextBoxHandlerEvent.Invoke(CameraNumber, "AcquisitionFrameRate", Convert.ToInt32(NumericUpDown_CameraFPS.Value));
                    break;
                           
                default:
                    Console.WriteLine("Input Value Was Not Suitable When Camera Value Was Setting.");
                    break;
            }
        }
    }
}