﻿#pragma checksum "..\..\SettingUI.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "07BABCACEBC333EA75FD4301B19F575698BFF7AAE26525E96C4B0CE5008690F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

using AOI_UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AOI_UI {
    
    
    /// <summary>
    /// SettingUI
    /// </summary>
    public partial class SettingUI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_StationNo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_DeviceNo;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.NumericUpDown NumericUpDown_Exposure;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.NumericUpDown NumericUpDown_Gain;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBox_Trigger;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Config;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_ROI;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\SettingUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Close;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AOI_UI;component/settingui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingUI.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Label_StationNo = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Label_DeviceNo = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.NumericUpDown_Exposure = ((System.Windows.Forms.NumericUpDown)(target));
            
            #line 43 "..\..\SettingUI.xaml"
            this.NumericUpDown_Exposure.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NumericUpDown_Gain = ((System.Windows.Forms.NumericUpDown)(target));
            
            #line 46 "..\..\SettingUI.xaml"
            this.NumericUpDown_Gain.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CheckBox_Trigger = ((System.Windows.Controls.CheckBox)(target));
            
            #line 48 "..\..\SettingUI.xaml"
            this.CheckBox_Trigger.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 48 "..\..\SettingUI.xaml"
            this.CheckBox_Trigger.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Btn_Config = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\SettingUI.xaml"
            this.Btn_Config.Click += new System.Windows.RoutedEventHandler(this.Btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Btn_ROI = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\SettingUI.xaml"
            this.Btn_ROI.Click += new System.Windows.RoutedEventHandler(this.Btn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Btn_Close = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\SettingUI.xaml"
            this.Btn_Close.Click += new System.Windows.RoutedEventHandler(this.Btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

