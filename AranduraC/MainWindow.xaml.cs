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
using MahApps.Metro.Controls;
using System.Windows.Media.Animation;

namespace AranduraC
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            MainFrame.Navigate(new Controles.pageLogin(this.MainFrame));
        }

        private void load_module(object sender, MouseButtonEventArgs e)
        {
            //load.appDT.Clear();
            //string modName = (sender as Image).Name;
            //load.modLoad(modName);
            //loadApps();
          
        }

        private void open_hijo(object sender, MouseButtonEventArgs e)
        {
            AranduraC.Hijo hijo = new AranduraC.Hijo();
            hijo.ShowDialog();
        }

        private void open_hijo2(object sender, MouseButtonEventArgs e)
        {
            AranduraC.Hijo2 hijo = new AranduraC.Hijo2();
            hijo.ShowDialog();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            AranduraC.VentanasDiseños.OrdenUsuario ordenProd = new AranduraC.VentanasDiseños.OrdenUsuario();
            ordenProd.ShowDialog();

        }

        /// <summary>
        /// Evento que ocurre al hacer clic en Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            //AranduraC.Controles.ctrlSettings ctrlSettings = new AranduraC.Controles.ctrlSettings(this.pnlControls, this.pnlVentanas);
            //pnlControls.Children.Clear();
            //pnlControls.Children.Add(ctrlSettings);

            //pnlVentanas.IsEnabled = false;
            //pnlVentanas.Opacity = 0.5;

            //AranduraC.Controles.ctrlLogin ctrlLogin = new Controles.ctrlLogin();
            MainFrame.Navigate(new Controles.pageLogin(this.MainFrame));
            
            
        }
    }
}
