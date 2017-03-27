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
using MahApps.Metro.Controls;
using System.Data;

namespace AranduraC.Modulos.Sistema_Base
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>s
    public partial class Usuarios : MetroWindow
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        #region Variables
        DataTable dtUsuarios = new DataTable();
        AranduraModel.SistemaBase.UsuariosModel UsuariosModel = new AranduraModel.SistemaBase.UsuariosModel();
        #endregion

        #region Load
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
            dgvUsuarios.SelectedValue = 1;
        }

        private void CargarDataGrid()
        {
            UsuariosModel.GetUsuarios();
            dtUsuarios = UsuariosModel.dataTable;
            dgvUsuarios.ItemsSource = dtUsuarios.DefaultView;
            DeshabilitarCampos();
        }

        private void DeshabilitarCampos()
        {
            GridCampos.IsEnabled = false;
            gridDataGrid.IsEnabled = true;
        }

        private void HabilitarCampos()
        {
            GridCampos.IsEnabled = true;
            gridDataGrid.IsEnabled = false;
        }
        #endregion

        #region ABM
        //Nuevo
        private void Nuevo(object sender)
        {
            // nuevo = true;
            HabilitarCampos();
            txbUser.Focus();

            // Permitir valores nulos
            foreach (DataColumn column in dtUsuarios.Columns)
            {
                column.AllowDBNull = true;
            }

            //Nueva fila
            DataRow RowNew = dtUsuarios.NewRow();
            dtUsuarios.Rows.Add(RowNew);

            //Seleccionar nueva fila agregada
            dgvUsuarios.ItemsSource = dtUsuarios.AsDataView();
            dgvUsuarios.SelectedIndex = dgvUsuarios.Items.Count - 1;
        }

        //Editar
        private void Editar(object sender)
        {
            //nuevo = false;
            HabilitarCampos();
            txbUser.Focus();
        }

        private void Eliminar(object sender)
        {
            if (MessageBox.Show("¿Está seguro/a que desea eliminar? ", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(dgvUsuarios.SelectedValue);
                UsuariosModel.DeleteUser(id);
                CargarDataGrid();
            }
        }

        //Guardar
        private void Guardar(object sender)
        {
            foreach (DataRow dr in dtUsuarios.Rows)
            {
                //Validamos que sea una Inserción.
                if (dr.RowState == DataRowState.Added)
                {
                    Insertar();
                }
                //Validamos que sea una Actualización.
                else if (dr.RowState == DataRowState.Modified)
                {
                    Actualizar();
                }
            }
        }

        //Cancelar
        private void Cancelar(object sender)
        {
            dgvUsuarios.SelectedItem = 0;
            DeshabilitarCampos();
        }
        #endregion

        #region ABM Funciones
        private void Insertar()
        {
            string is_active;
            //Validamos si el estado está Activo o No.
            if (chkEstado.IsChecked == true)
            {
                is_active = "S";
            }
            else {
                is_active = "N";
            }

            //Llamamos a la funcion INSERTUSER que guarda el nuevo Usuario y retorna el nuevo ID generado.
            int id = UsuariosModel.InsertUser(txbUser.Text, txbPass.Text, 1, Convert.ToInt32(txbIdPersona.Text), Convert.ToInt32(txbIdGrupo.Text), is_active);
            CargarDataGrid();
            dgvUsuarios.SelectedValue = id;
            DeshabilitarCampos();
        }

        private void Actualizar()
        {
            string is_active;
            //Validamos si el estado está Activo o No.
            if (chkEstado.IsChecked == true)
            {
                is_active = "S";
            }
            else {
                is_active = "N";
            }

            int id = Convert.ToInt32(dgvUsuarios.SelectedValue);
            UsuariosModel.UpdateUser(txbUser.Text, txbPass.Text, 1, Convert.ToInt32(txbIdPersona.Text), Convert.ToInt32(txbIdGrupo.Text), is_active, id);
            CargarDataGrid();
            dgvUsuarios.SelectedValue = id;
            DeshabilitarCampos();
        }
        #endregion

        #region Filtros
        private void FiltrarUsuario(object sender, KeyEventArgs e)
        {
            string filtro = null;
            filtro = " user Like '%" + tbxFiltro.Text + "%'";
            DataView dv = (DataView)dgvUsuarios.ItemsSource;
            dv.RowFilter = filtro;
        }
        #endregion

        #region Listas
        private void txbNombre_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AranduraC.Controles.Sistema_Base.ctrlPersonas ctrlPersonas = new Controles.Sistema_Base.ctrlPersonas();
            ctrlPersonas.ShowDialog();
        }
        #endregion

        #region ChangedListner
        /// <summary>
        /// Se recupera el NOMBRE de la Persona seleccionada.
        /// </summary>
        /// <param name="id_persona"></param>
        private void SeleccionarPersona(object sender, RoutedEventArgs e)
        {
            //Validamos que el campo de código no esté null, de ser así el LABEL vuelve a estar en blanco
            if (string.IsNullOrEmpty(txbIdPersona.Text))
            {
                lblNombre.Content = null;
            }
            else
            {
                AranduraModel.SistemaBase.PersonasModel PersonasModel = new AranduraModel.SistemaBase.PersonasModel();
                PersonasModel.GetPersona_Nombre(txbIdPersona.Text);
                DataTable dt = PersonasModel.dataTable;
                foreach (DataRow r in dt.Rows)
                {
                    lblNombre.Content = r[0].ToString();
                }
            }
        }

        /// <summary>
        /// Al seleccionar el usuario del DataGridView definimos el valor del Check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeleccionarUsuario(object sender, SelectionChangedEventArgs e)
        {
            if (dgvUsuarios.SelectedItems.Count == 0)
            {
                return;
            }

            //Setear el Estado obtenido desde la Base de Datos
            DataRowView Row = (DataRowView)dgvUsuarios.SelectedItem;
            if (Row["estado"].ToString().Equals("S"))
            {
                chkEstado.IsChecked = true;
            }
            else if (String.IsNullOrEmpty(Row["estado"].ToString()))
            {
                chkEstado.IsChecked = true;
            }
            else
            {
                chkEstado.IsChecked = false;
            }
        }
        #endregion

    }
}