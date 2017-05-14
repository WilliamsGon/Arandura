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
using System.Data;

namespace AranduraC.Controles
{
    /// <summary>
    /// Lógica de interacción para pageLogin.xaml
    /// </summary>
    public partial class pageLogin : Page
    {
        Frame fraim = new Frame();
        DataTable dtLogin = new DataTable();
        AranduraModel.AutorizacionModel AutorizacionModel = new AranduraModel.AutorizacionModel(); 
        public pageLogin(Frame f)
        {
            InitializeComponent();
            fraim = f;
            tbxUser.Focus();

            //Seteamos el Avatar
            string source = "pack://application:,,,/AranduraC;component/Images/avatarUnknown.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(source, UriKind.Absolute);
            bitmap.EndInit();
            imgAvatar.ImageSource = bitmap;
        }
        public void btnLogIn_Click(object sender, RoutedEventArgs e) {
            AutorizacionModel.LogIn(tbxUser.Text, tbxPassword.Password);
            dtLogin = AutorizacionModel.dataTable;
            int cuentaRows = 0;
            foreach (DataRow row in dtLogin.Rows)
            {
                cuentaRows = cuentaRows + 1;
            }
            if (cuentaRows == 0)
            {
                
            }

            else
            {
                fraim.Navigate(new AranduraC.Modulos.pageModulos(tbxUser.Text));
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            btnLogIn_Click(sender,e);
        }
    }
}
