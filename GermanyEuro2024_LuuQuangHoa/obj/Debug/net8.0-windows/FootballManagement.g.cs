﻿#pragma checksum "..\..\..\FootballManagement.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33FDC524AB903B3623D103B034D0ECECFD61E341"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GermanyEuro2024_LuuQuangHoa;
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


namespace GermanyEuro2024_LuuQuangHoa {
    
    
    /// <summary>
    /// FootballManagement
    /// </summary>
    public partial class FootballManagement : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbox_playerId;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbox_playerName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_birthday;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbox_award;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbox_country;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbox_achivements;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_footballPlayerInformation;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\FootballManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbox_teamTitle;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GermanyEuro2024_LuuQuangHoa;component/footballmanagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FootballManagement.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\FootballManagement.xaml"
            ((GermanyEuro2024_LuuQuangHoa.FootballManagement)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbox_playerId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbox_playerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.date_birthday = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.tbox_award = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbox_country = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbox_achivements = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.dtg_footballPlayerInformation = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\FootballManagement.xaml"
            this.dtg_footballPlayerInformation.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dtg_footballPlayerInformation_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cbbox_teamTitle = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

