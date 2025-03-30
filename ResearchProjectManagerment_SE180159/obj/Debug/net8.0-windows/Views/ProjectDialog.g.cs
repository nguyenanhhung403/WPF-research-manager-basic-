﻿#pragma checksum "..\..\..\..\Views\ProjectDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F705BBBDC4F17F51D8B874B482A6B2D54855331"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ResearchProjectManagerment_SE180159.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ResearchProjectManagerment_SE180159.Views {
    
    
    /// <summary>
    /// ProjectDialog
    /// </summary>
    public partial class ProjectDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProjectTitle;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtResearchField;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbLeadResearcher;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStartDate;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEndDate;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBudget;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtErrorMessage;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\Views\ProjectDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ResearchProjectManagerment_SE180159;component/views/projectdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ProjectDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtProjectTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtResearchField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cmbLeadResearcher = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.dpStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.dpEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txtBudget = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtErrorMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 147 "..\..\..\..\Views\ProjectDialog.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 155 "..\..\..\..\Views\ProjectDialog.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

