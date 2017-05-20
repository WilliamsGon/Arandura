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
using MahApps.Metro.Controls.Dialogs;

namespace AranduraC
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool _shutdown;
        public MainWindow()
        {
            InitializeComponent();
            
            MainFrame.Navigate(new Controles.pageLogin(this.MainFrame));
        }

        /// <summary>
        /// Evento que ocurre al hacer clic en Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //AranduraC.Controles.ctrlSettings ctrlSettings = new AranduraC.Controles.ctrlSettings(this.pnlControls, this.pnlVentanas);
            //pnlControls.Children.Clear();
            //pnlControls.Children.Add(ctrlSettings);

            //pnlVentanas.IsEnabled = false;
            //pnlVentanas.Opacity = 0.5;

            //AranduraC.Controles.ctrlLogin ctrlLogin = new Controles.ctrlLogin();
            MainFrame.Navigate(new Controles.pageLogin(this.MainFrame));
        }
        //PROCESO QUE SE EJECUTA CUANDO LA HERRAMIENTA SE ESTÁ CERRANDO
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            foreach (Window win in App.Current.Windows)
            {
                if (!win.IsFocused)
                {
                    win.Close();
                }
            }
        }
        //PROCESO QUE SE EJECUTA CUANDO SE QUIERE CERRAR LA HERRAMIENTA
        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_shutdown;
            if (_shutdown) return;

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Salir",
                NegativeButtonText = "Cancelar",
                AnimateShow = true,
                AnimateHide = false
            };

            var result = await this.ShowMessageAsync("¿Salir de Arandura?",
                "¿Está seguro que desea salir de Arandura?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            _shutdown = result == MessageDialogResult.Affirmative;

            if (_shutdown)
                Application.Current.Shutdown();
        }
    }
}
