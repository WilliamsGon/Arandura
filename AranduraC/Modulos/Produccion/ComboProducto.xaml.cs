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
using System.Collections;


namespace AranduraC.Modulos.Produccion
{
    /// <summary>
    /// Lógica de interacción para ComboMateriaPrima.xaml
    /// </summary>
    public partial class ComboProducto : MetroWindow
    {
        #region Datable, Models and Variables
        DataTable dtProductos = new DataTable();
        AranduraModel.Produccion.ComboMateriaPrimaModel ComboMateriaPrimaModel = new AranduraModel.Produccion.ComboMateriaPrimaModel();

        DataTable dtReceta = new DataTable();
        ArrayList arrayReceta = new ArrayList();
        #endregion

        public ComboProducto()
        {
            InitializeComponent();
        }

        #region Load
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
            dgvInsumos.SelectedIndex = 0;
            cbxInsumo.Focus();
        }

        private void CargarDataGrid()
        {
            // Cargamos el DataGrid de Insumos Existentes
            ComboMateriaPrimaModel.getProductosList();
            dtProductos = ComboMateriaPrimaModel.dataTable;
            dgvInsumos.ItemsSource = dtProductos.DefaultView;

            // Creamos el DataTable de Recetas
            dtRecetas();

            // ComboBox Insumos
            ComboMateriaPrimaModel.getInsumosList();
            cbxInsumo.ItemsSource = ComboMateriaPrimaModel.dataTable.DefaultView;
            cbxInsumo.SelectedValuePath = ComboMateriaPrimaModel.dataTable.Columns[0].ToString();
            cbxInsumo.DisplayMemberPath = ComboMateriaPrimaModel.dataTable.Columns[2].ToString();
        }
        // Instancia el dtReceta y agrega las columnas que necesita
        private void dtRecetas()
        {
            dtReceta = new DataTable();
            dtReceta.Columns.Add("id");
            dtReceta.Columns.Add("codigo");
            dtReceta.Columns.Add("descripcion");
            dtReceta.Columns.Add("cantidad");
        }
        #endregion

        #region ChangedList
        private void dgvInsumos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Actualiza el Grid de los Campos para la Receta
            DataRowView Row = (DataRowView)dgvInsumos.SelectedItem;
            if (Row != null)
            {
                txbCodigo.Text = Row["codigo"].ToString();
                txbInsumo.Text = Row["descripcion"].ToString();
                txbCantidad.Text = Row["cantidad"].ToString();
            }
        }

        private void txbCantidad_LostFocus(object sender, RoutedEventArgs e)
        {
            DataRowView Row = (DataRowView)dgvInsumos.SelectedItem;
            decimal aux = Convert.ToDecimal(txbCantidad.Text);
            // Valida que la cantidad no supere el Stocl
            if (aux > Convert.ToDecimal(Row["cantidad"].ToString()))
            {
                MessageBox.Show("Cantidad supera stock ", "Atención", MessageBoxButton.OK);
            }
            // Valida que la cantidad no sea menor o igual a 0 (cero)
            if (aux <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0 ", "Atención", MessageBoxButton.OK);
            }
        }

        private void isNumeric(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
        #endregion

        #region ABM
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            if (dgvReceta.Items.Count != 0)
            {
                // Valida que el campo de Cantidad a crear no esté vacío.
                if (String.IsNullOrEmpty(txbCantidadAdd.Text))
                {
                    MessageBox.Show("Debe especificar la cantidad a crear ", "Atención", MessageBoxButton.OK);
                    return;
                }
                // Agregar un String con el UPDATE armado en un Array.
                foreach (DataRow dr in dtReceta.Rows)
                {
                    string sql = "UPDATE productos "
                               + "SET cantidad = cantidad - " + dr["cantidad"] + ", "
                               + "user_update=@1, "
                               + "date_update= sysdate() "
                               + "WHERE id = " + dr["id"];
                    arrayReceta.Add(sql);
                }
                // Actualizar los Insumos que cumplieron el Papel de Receta.
                ComboMateriaPrimaModel.ActualizarRecetas(arrayReceta);

                // Actualizar el Insumo creado.
                ComboMateriaPrimaModel.ActualizarProducto(Convert.ToDecimal(txbCantidadAdd.Text), Convert.ToInt32(cbxInsumo.SelectedValue.ToString()));

                // Actualizar la ventana para que contemple las Actualizaciones.
                dtReceta = new DataTable();
                CargarDataGrid();
                dgvReceta.ItemsSource = dtReceta.DefaultView;
                dgvReceta.Items.Refresh();
                arrayReceta = new ArrayList();
                txbCantidadAdd.Text = "";
                cbxInsumo.Focus();
            }
            else
            {
                MessageBox.Show("Debe cargar insumos para procesar ", "Atención", MessageBoxButton.OK);
            }
        }

        private void btnCanelar_Click(object sender, RoutedEventArgs e)
        {
            // Valida antes de eliminar el registro.
            if (MessageBox.Show("¿Está seguro/a que desea cancelar?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                dtReceta = new DataTable();
                CargarDataGrid();
                dgvReceta.ItemsSource = dtReceta.DefaultView;
                dgvReceta.Items.Refresh();
                arrayReceta = new ArrayList();
                txbCantidadAdd.Text = "";
                cbxInsumo.Focus();
            }
        }
        #endregion

        #region ABM Receta
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(dgvInsumos.SelectedValue) != 0)
            {
                // Valida que se haya elegido el Insumo a crear.
                if (cbxInsumo.SelectedValue == null)
                {
                    MessageBox.Show("Primero elija el Insumo a crear", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                // Valida que la Cantidad sea mayor a 0 (cero).
                if (Convert.ToDecimal(txbCantidad.Text) <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0 ", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                // Valida que el Insumo a agregar para Procesar no sea igual al que se desea Crear.
                if (Convert.ToInt32(cbxInsumo.SelectedValue) == Convert.ToInt32(dgvInsumos.SelectedValue))
                {
                    MessageBox.Show("No puede agregar el Insumo que desea Crear ", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                // Valida que no se agregue un Insumo repetido.
                foreach (DataRow RowAUX in dtReceta.Rows)
                {
                    if (Convert.ToInt32(RowAUX["id"]) == Convert.ToInt32(dgvInsumos.SelectedValue))
                    {
                        MessageBox.Show("El Insumo ya se agregó", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                // Agrega un nuevo Row en el dtReceta y carga las columnas con los datos del Insumo seleccionado.
                DataRow Row = dtReceta.NewRow();
                Row["id"] = Convert.ToInt32(dgvInsumos.SelectedValue);
                Row["codigo"] = txbCodigo.Text;
                Row["descripcion"] = txbInsumo.Text;
                Row["cantidad"] = Convert.ToDecimal(txbCantidad.Text);
                dtReceta.Rows.Add(Row);
                // Actualiza el dgvReceta para que tenga el nuevo Row agregado.
                dgvReceta.ItemsSource = dtReceta.DefaultView;
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            // Valida que exista registro para borrar.
            if (dgvReceta.SelectedItems.Count == 0)
            {
                return;
            }
            // Valida si se desea eliminar realmente el registro.
            if (MessageBox.Show("¿Está seguro/a que desea eliminar? ", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                DataRowView Row_Sel = (DataRowView)dgvReceta.SelectedItem;
                int id = Convert.ToInt32(Row_Sel["id"]);
                foreach (DataRow Row_Caracteristicas in dtReceta.Select("id=" + id))
                {
                    Row_Caracteristicas.Delete();
                }
            }
        }
        #endregion
    }
}
