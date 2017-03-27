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

namespace AranduraC.Modulos.Produccion
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : MetroWindow
    {
        DataTable dtProductos = new DataTable();
        AranduraModel.Produccion.ProductosModel ProductosModel = new AranduraModel.Produccion.ProductosModel();
        public Productos()
        {
            InitializeComponent();
        }

        #region Load
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
            dgvProductos.SelectedIndex = 0;
        }

        private void CargarDataGrid()
        {
            ProductosModel.getProductos();
            dtProductos = ProductosModel.dataTable;
            dgvProductos.ItemsSource = dtProductos.DefaultView;
            DeshabilitarCampos();
        }

        private void DeshabilitarCampos()
        {
            GridDatos.IsEnabled = false;
            dgProductos.IsEnabled = true;
        }

        private void HabilitarCampos()
        {
            GridDatos.IsEnabled = true;
            dgProductos.IsEnabled = false;
        }
        #endregion

        #region ABM ToolBar
        //Nuevo
        private void Nuevo(object sender)
        {
            // nuevo = true;
            HabilitarCampos();
            txbCod.Focus();

            // Permitir valores nulos
            foreach (DataColumn column in dtProductos.Columns)
            {
                column.AllowDBNull = true;
            }

            //Nueva fila
            DataRow RowNew = dtProductos.NewRow();
            dtProductos.Rows.Add(RowNew);

            //Seleccionar nueva fila agregada
            dgvProductos.ItemsSource = dtProductos.AsDataView();
            dgvProductos.SelectedIndex = dgvProductos.Items.Count - 1;
        }

        //Editar
        private void Editar(object sender)
        {
            //nuevo = false;
            HabilitarCampos();
            txbCod.Focus();
        }

        //Eliminar
        private void Eliminar(object sender)
        {
            if (MessageBox.Show("¿Está seguro/a que desea eliminar? ", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(dgvProductos.SelectedValue);
                ProductosModel.Eliminar(id);
                CargarDataGrid();
            }
        }

        //Guardar
        private void Guardar(object sender)
        {
            foreach (DataRow dr in dtProductos.Rows)
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
            DeshabilitarCampos();
        }

        //Cancelar
        private void Cancelar(object sender)
        {
            dgvProductos.SelectedItem = 0;
            DeshabilitarCampos();
        }
        #endregion

        #region ABM Funciones
        private void Insertar()
        {
            string is_active = "S";

            //Validamos si el estado está Activo o No.
            if (chkEstado.IsChecked == true)
            {
                is_active = "S";
            }
            else {
                is_active = "N";
            }

            //Llamamos a la funcion INSERTAR que guarda el nuevo Producto y retorna el nuevo ID generado.
            int id = ProductosModel.Insertar(txbCod.Text, txbDesc.Text, Convert.ToInt32(txbPrecio.Text), is_active);
            CargarDataGrid();
            dgvProductos.SelectedValue = id;
            DeshabilitarCampos();
        }

        private void Actualizar()
        {
            string is_active = "S";

            //Validamos si el estado está Activo o No.
            if (chkEstado.IsChecked == true)
            {
                is_active = "S";
            }
            else {
                is_active = "N";
            }

            //Llamamos a la funcion ACTUALIZAR que modifica el Producto.
            int id = Convert.ToInt32(dgvProductos.SelectedValue);
            ProductosModel.Actualizar(txbCod.Text, txbDesc.Text, Convert.ToInt32(txbPrecio.Text), is_active, id);
            CargarDataGrid();
            dgvProductos.SelectedValue = id;
            DeshabilitarCampos();
        }
        #endregion

        #region ChangedListner
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvProductos.SelectedItems.Count == 0)
            {
                return;
            }

            //Setear el Estado obtenido desde la Base de Datos
            DataRowView Row = (DataRowView)dgvProductos.SelectedItem;
            if (Row["estado"].ToString().Equals("S"))
            {
                chkEstado.IsChecked = true;
            }
            //En caso de que se esté creando un nuevo ROW se le settea "TRUE"
            else if (String.IsNullOrEmpty(Row["estado"].ToString()))
            {
                chkEstado.IsChecked = true;
            }
            else
            {
                chkEstado.IsChecked = false;
            }
        }


        private void chkEstado_Click(object sender, RoutedEventArgs e)
        {
            if (chkEstado.IsChecked == true)
            {
                DataRowView Row = (DataRowView)dgvProductos.SelectedItem;
                Row["estado"] = "S";
                chkEstado.IsChecked = true;
            }
            else
            {
                DataRowView Row = (DataRowView)dgvProductos.SelectedItem;
                Row["estado"] = "N";
                chkEstado.IsChecked = false;
            }
        }
        #endregion

        #region Filtros
        private void FiltrarProducto(object sender, KeyEventArgs e)
        {
            string filtro = null;
            filtro = " codigo Like '%" + tbxFiltro.Text + "%' or descripcion Like '%" + tbxFiltro.Text + "%'";
            DataView dv = (DataView)dgvProductos.ItemsSource;
            dv.RowFilter = filtro;
        }
        #endregion
    }
}