﻿#pragma checksum "..\..\..\Views\TypePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C976022768369B150647E756334193DF61AC81E3AFD3C23D29689695D14B42EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Giros.Views;
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


namespace Giros.Views {
    
    
    /// <summary>
    /// TypePage
    /// </summary>
    public partial class TypePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Views\TypePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas chickenCanvas;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\TypePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas porkCanvas;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\TypePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas mixCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/Giros;component/views/typepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\TypePage.xaml"
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
            this.chickenCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 12 "..\..\..\Views\TypePage.xaml"
            this.chickenCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.selectChickenCanvas);
            
            #line default
            #line hidden
            return;
            case 2:
            this.porkCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 17 "..\..\..\Views\TypePage.xaml"
            this.porkCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.selectPorkCanvas);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mixCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 22 "..\..\..\Views\TypePage.xaml"
            this.mixCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.selectMixCanvas);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

