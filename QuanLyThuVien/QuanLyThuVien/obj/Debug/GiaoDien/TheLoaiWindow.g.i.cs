﻿#pragma checksum "..\..\..\GiaoDien\TheLoaiWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7BCA2C2C8526CF45C9F4C6C52E97A30029445E31"
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
    /// TheLoaiWindow
    /// </summary>
    public partial class TheLoaiWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtmatheloai;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txttentheloai;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtmota;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoThem;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoSua;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoXoa;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnthuchien;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTheLoai;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThuVien;component/giaodien/theloaiwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
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
            
            #line 8 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
            ((QuanLyThuVien.GiaoDien.TheLoaiWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtmatheloai = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txttentheloai = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtmota = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.rdoThem = ((System.Windows.Controls.RadioButton)(target));
            
            #line 31 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
            this.rdoThem.Click += new System.Windows.RoutedEventHandler(this.RdoThem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rdoSua = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
            this.rdoSua.Click += new System.Windows.RoutedEventHandler(this.RdoSua_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rdoXoa = ((System.Windows.Controls.RadioButton)(target));
            
            #line 33 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
            this.rdoXoa.Click += new System.Windows.RoutedEventHandler(this.RdoXoa_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnthuchien = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
            this.btnthuchien.Click += new System.Windows.RoutedEventHandler(this.Btnthuchien_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dgTheLoai = ((System.Windows.Controls.DataGrid)(target));
            
            #line 38 "..\..\..\GiaoDien\TheLoaiWindow.xaml"
            this.dgTheLoai.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgTheLoai_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

