﻿#pragma checksum "..\..\..\GiaoDien\TheDocGiaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DDFB2BBEC6DB345B7AA742A2952414661015DB59"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuanLyThuVien.GiaoDien;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace QuanLyThuVien.GiaoDien {
    
    
    /// <summary>
    /// TheDocGiaWindow
    /// </summary>
    public partial class TheDocGiaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpngaytao;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpngayhethan;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txttendocgia;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpnamsinh;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtmatkdocgia;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbmataikhoanthuthu;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btntaotaikhoan;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThuVien;component/giaodien/thedocgiawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
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
            
            #line 9 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
            ((QuanLyThuVien.GiaoDien.TheDocGiaWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dtpngaytao = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.dtpngayhethan = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.txttendocgia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.dpnamsinh = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txtmatkdocgia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cmbmataikhoanthuthu = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btntaotaikhoan = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\GiaoDien\TheDocGiaWindow.xaml"
            this.btntaotaikhoan.Click += new System.Windows.RoutedEventHandler(this.Btntaotaikhoan_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

