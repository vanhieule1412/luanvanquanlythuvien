﻿#pragma checksum "..\..\..\GiaoDien\KhuWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B18459A9735FB560151061FD84748ECA31DE66A2"
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
    /// KhuWindow
    /// </summary>
    public partial class KhuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\GiaoDien\KhuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtmakhu;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\GiaoDien\KhuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txttenkhu;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\GiaoDien\KhuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoThem;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\GiaoDien\KhuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoSua;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\GiaoDien\KhuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoXoa;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\GiaoDien\KhuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnthuchien;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\GiaoDien\KhuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgkhu;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyThuVien;component/giaodien/khuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GiaoDien\KhuWindow.xaml"
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
            
            #line 10 "..\..\..\GiaoDien\KhuWindow.xaml"
            ((QuanLyThuVien.GiaoDien.KhuWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtmakhu = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txttenkhu = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.rdoThem = ((System.Windows.Controls.RadioButton)(target));
            
            #line 36 "..\..\..\GiaoDien\KhuWindow.xaml"
            this.rdoThem.Click += new System.Windows.RoutedEventHandler(this.RdoThem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rdoSua = ((System.Windows.Controls.RadioButton)(target));
            
            #line 37 "..\..\..\GiaoDien\KhuWindow.xaml"
            this.rdoSua.Click += new System.Windows.RoutedEventHandler(this.RdoSua_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rdoXoa = ((System.Windows.Controls.RadioButton)(target));
            
            #line 38 "..\..\..\GiaoDien\KhuWindow.xaml"
            this.rdoXoa.Click += new System.Windows.RoutedEventHandler(this.RdoXoa_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnthuchien = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\GiaoDien\KhuWindow.xaml"
            this.btnthuchien.Click += new System.Windows.RoutedEventHandler(this.Btnthuchien_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgkhu = ((System.Windows.Controls.DataGrid)(target));
            
            #line 44 "..\..\..\GiaoDien\KhuWindow.xaml"
            this.dgkhu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Dgkhu_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

