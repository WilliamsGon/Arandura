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
using System.Data;

namespace AranduraC.Controles.Sistema_Base
{
    /// <summary>
    /// Lógica de interacción para ctrlPersonas.xaml
    /// </summary>
    public partial class ctrlPersonas : MetroWindow
    {
        DataTable dtPersonas = new DataTable();
        AranduraModel.SistemaBase.PersonasModel PersonasModel = new AranduraModel.SistemaBase.PersonasModel();
        public ctrlPersonas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Al momento de Cargar la ventana este consulta la BD y trae la lista de Peronas
        /// completando así la grilla
        /// </summary>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PersonasModel.GetPersonas();
            dtPersonas = PersonasModel.dataTable;
            dgvPersonas.ItemsSource = dtPersonas.DefaultView;
        }
        /// <summary>
        /// Este metodo retorna la persona seleccionada de la lista.
        /// </summary>
        private void dgvPersonas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int codigo = Convert.ToInt32(dgvPersonas.SelectedValue);
            var Usuarios = Application.Current.Windows[1] as AranduraC.Modulos.Sistema_Base.Usuarios;
            if (Usuarios != null)
            {
                //Usuarios.codigo = codigo.ToString();
                Usuarios.txbIdPersona.Text = codigo.ToString();
                this.Close();
            }
        }
    }
}
