﻿#pragma checksum "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0CB45B084812AA1712F36499DD776D58"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AranduraC.Modulos.Produccion;
using Controls;
using MahApps.Metro.Controls;
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


namespace AranduraC.Modulos.Produccion {
    
    
    /// <summary>
    /// OrdenProduccion
    /// </summary>
    public partial class OrdenProduccion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Controls.toolBar toolbar;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxPedido;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvOrden;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxOrden;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxEmpleado;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpInicio;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpFin;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxDescripcion;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkActivo;
        
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
            System.Uri resourceLocater = new System.Uri("/AranduraC;component/modulos/produccion/ordenproduccion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
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
            
            #line 9 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
            ((AranduraC.Modulos.Produccion.OrdenProduccion)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.toolbar = ((Controls.toolBar)(target));
            
            #line 16 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
            this.toolbar.btnNew_Click += new Controls.toolBar.btnNew_ClickedEventHandler(this.toolbar_btnNew_Click);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
            this.toolbar.btnEdit_Click += new Controls.toolBar.btnEdit_ClickedEventHandler(this.toolbar_btnEdit_Click);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
            this.toolbar.btnDelete_Click += new Controls.toolBar.btnDelete_ClickedEventHandler(this.toolbar_btnDelete_Click);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
            this.toolbar.btnSave_Click += new Controls.toolBar.btnSave_ClickedEventHandler(this.toolbar_btnSave_Click);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
            this.toolbar.btnCancel_Click += new Controls.toolBar.btnCancel_ClickedEventHandler(this.toolbar_btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbxPedido = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.dgvOrden = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\..\..\Modulos\Produccion\OrdenProduccion.xaml"
            this.dgvOrden.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgvOrden_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbxOrden = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbxEmpleado = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.dtpInicio = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.dtpFin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.tbxDescripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.chkActivo = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

