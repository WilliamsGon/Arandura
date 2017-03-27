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

namespace AranduraC.Controles
{
    /// <summary>
    /// Lógica de interacción para ctrlSettings.xaml
    /// </summary>
    public partial class ctrlSettings : UserControl
    {
        public DockPanel panel;
        public WrapPanel wrappanel;
        public ctrlSettings(DockPanel p, WrapPanel wp)
        {
            InitializeComponent();
            panel = p;
            wrappanel = wp;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Clear();
            wrappanel.Opacity = 1;
            wrappanel.IsEnabled = true;
        }
    }
}
