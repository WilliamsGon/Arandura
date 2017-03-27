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
using System.Windows.Shapes;
using System.Data;

namespace AranduraC
{
    /// <summary>
    /// Lógica de interacción para Hijo.xaml
    /// </summary>
    public partial class Hijo : Window
    {
        DataTable dtUsuarios = new DataTable();
        AranduraModel.UsuariosModel UsuariosModel = new AranduraModel.UsuariosModel(); 
        public Hijo()
        {
            InitializeComponent();

            LlenarDataGrid();
        }
        
        /// <summary>
        /// llena el datagrid con los datos
        /// </summary>
        private void LlenarDataGrid()
        {
            UsuariosModel.GetUsuarios();
            dtUsuarios = UsuariosModel.dataTable;
            dgvUsuarios.ItemsSource = dtUsuarios.DefaultView;
            DeshabilitarCampos();
        }
        private void DeshabilitarCampos()
        {
            grdCampos.IsEnabled = false;
            grdGrilla.IsEnabled = true;
        }
        private void HabilitarCampos()
        {
            grdCampos.IsEnabled = true;
            grdGrilla.IsEnabled = false;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
           // nuevo = true;
            HabilitarCampos();
            tbxNombre.Focus();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            //nuevo = false;
            HabilitarCampos();
            tbxNombre.Focus();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(dgvUsuarios.SelectedValue);
            UsuariosModel.DeleteUser(id);
            LlenarDataGrid();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            foreach(DataRow dr in dtUsuarios.Rows)
            {
                if (dr.RowState == DataRowState.Added)
                {
                    int id = UsuariosModel.InsertUser(tbxNombre.Text, tbxApellido.Text);
                    LlenarDataGrid();
                    dgvUsuarios.SelectedValue = id;
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    int id = Convert.ToInt32(dgvUsuarios.SelectedValue);
                    UsuariosModel.UpdateUser(tbxNombre.Text, tbxApellido.Text, id);
                    LlenarDataGrid();
                    dgvUsuarios.SelectedValue = id;
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DeshabilitarCampos();
        }
    }
}
