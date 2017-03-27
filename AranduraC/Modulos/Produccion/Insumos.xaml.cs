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
    /// Lógica de interacción para Insumos.xaml
    /// </summary>
    public partial class Insumos : MetroWindow
    {
        public Insumos()
        {
            InitializeComponent();
        }

        #region DataTables, Models and Variables
        DataTable dtInsumos = new DataTable();
        AranduraModel.Produccion.InsumosModel InsumosModel = new AranduraModel.Produccion.InsumosModel();
        DataTable dtCaracteristicas = new DataTable();
        AranduraModel.Produccion.CaracteristicasModel CaracteristicasModel = new AranduraModel.Produccion.CaracteristicasModel();
        DataTable dtUnidadMedidas = new DataTable();
        AranduraModel.SistemaBase.UnidadMedidaModels UnidadMedidaModels = new AranduraModel.SistemaBase.UnidadMedidaModels();
        DataTable dtInsumosCaracteristicasRel = new DataTable();
        AranduraModel.Produccion.InsumosCaracteristicasRelModels InsumosCaracteristicasRelModels = new AranduraModel.Produccion.InsumosCaracteristicasRelModels();

        Boolean is_modificar;
        int id = 0;
        ArrayList arrayInsertCarac = new ArrayList();
        ArrayList arrayDelCarac = new ArrayList();
        #endregion

        #region Load
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
            dgvInsumos.SelectedIndex = 0;
        }

        private void CargarDataGrid()
        {
            //Cargamos el DataGrid de Insumos.
            InsumosModel.getInsumos();
            dtInsumos = InsumosModel.dataTable;
            dgvInsumos.ItemsSource = dtInsumos.DefaultView;

            //ComboBox Caracteristicas
            CaracteristicasModel.getCaracteristicaComboBox();
            cbxCaracteristica.ItemsSource = CaracteristicasModel.dataTable.DefaultView;
            cbxCaracteristica.SelectedValuePath = CaracteristicasModel.dataTable.Columns[1].ToString();
            cbxCaracteristica.DisplayMemberPath = CaracteristicasModel.dataTable.Columns[2].ToString();

            //ComboBox Unidad Medidas
            UnidadMedidaModels.getUnidadMedida();
            cbxUniMedida.ItemsSource = UnidadMedidaModels.dataTable.DefaultView;
            cbxUniMedida.SelectedValuePath = UnidadMedidaModels.dataTable.Columns[1].ToString();
            cbxUniMedida.DisplayMemberPath = UnidadMedidaModels.dataTable.Columns[2].ToString();

            //Deshabilitamos los campos.
            DeshabilitarCampos();
        }

        private void DeshabilitarCampos()
        {
            gridInsumo.IsEnabled = false;
            gridCaracteristicas.IsEnabled = false;
            gridProductos.IsEnabled = false;
            gridDataGrid.IsEnabled = true;
        }

        private void HabilitarCampos()
        {
            gridInsumo.IsEnabled = true;
            gridCaracteristicas.IsEnabled = true;
            gridProductos.IsEnabled = true;
            gridDataGrid.IsEnabled = false;
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
            foreach (DataColumn column in dtInsumos.Columns)
            {
                column.AllowDBNull = true;
            }

            //Nueva fila
            DataRow RowNew = dtInsumos.NewRow();
            dtInsumos.Rows.Add(RowNew);

            //Seleccionar nueva fila agregada
            dgvInsumos.ItemsSource = dtInsumos.AsDataView();
            dgvInsumos.SelectedIndex = dgvInsumos.Items.Count - 1;

            //Definimos que no es una modificación
            is_modificar = false;
        }

        //Editar
        private void Editar(object sender)
        {
            //nuevo = false;
            HabilitarCampos();
            txbCod.Focus();
            is_modificar = true;
        }

        //Eliminar
        private void Eliminar(object sender)
        {
            if (MessageBox.Show("¿Está seguro/a que desea eliminar? ", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(dgvInsumos.SelectedValue);
                InsumosModel.Eliminar(id);
                CargarDataGrid();
            }
        }

        //Guardar
        private void Guardar(object sender)
        {
            //Insertamos o Actualizamos los Insumos
            foreach (DataRow dr in dtInsumos.Rows)
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

            //Verificamos si hay Caracteristicas para eliminar
            if (arrayDelCarac != null)
            {
                EliminarInCarRel();
            }
            is_modificar = false;
        }

        //Cancelar
        private void Cancelar(object sender)
        {
            dgvInsumos.SelectedItem = 0;
            DeshabilitarCampos();
            dtInsumos.RejectChanges();
            dgvInsumos.SelectedIndex = 0;
            //Limpiamos la lista de Caracteristicas a Eliminar
            arrayDelCarac = new ArrayList();
            cgtBar.MenuDisabled();

            is_modificar = false;
        }
        #endregion

        #region ABM Funciones
        private void Insertar()
        {
            int error = 0;
            try
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
                id = InsumosModel.Insertar(txbCod.Text, txbDesc.Text, is_active, Convert.ToInt32(txbPrecio.Text), Convert.ToInt32(txbCant.Text));

                //Insertamos las caracteristicas
                if (arrayInsertCarac != null)
                {
                    InsumosCaracteristicasRelModels.InsertarArray(arrayInsertCarac);
                }
                error = 0;
            }
            catch
            {
                if (String.IsNullOrEmpty(txbCod.Text.Trim()))
                {
                    MessageBox.Show("Defina un código ", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (String.IsNullOrEmpty(txbDesc.Text.Trim()))
                {
                    MessageBox.Show("Describa el Insumo ", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //if (String.IsNullOrEmpty(txbPrecio.Text.Trim()))
                //{
                //    MessageBox.Show("Defina el Costo ", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
                if (String.IsNullOrEmpty(txbCant.Text.Trim()))
                {
                    MessageBox.Show("Defina la cantidad ", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                error = 1;
            }
            //Valida si hubo un error en el Insert
            if(error == 1)
            {
                cgtBar.MenuEnabled();
            }
            else
            {
                CargarDataGrid();
                dgvInsumos.SelectedValue = id;
                DeshabilitarCampos();
            }
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
            int id = Convert.ToInt32(dgvInsumos.SelectedValue);
            InsumosModel.Actualizar(txbCod.Text, txbDesc.Text, is_active, Convert.ToInt32(txbPrecio.Text), Convert.ToInt32(txbCant.Text), id);
            
            CargarDataGrid();
            dgvInsumos.SelectedValue = id;
            DeshabilitarCampos();
        }

        private void EliminarInCarRel()
        {
            if (arrayDelCarac != null)
            {
                InsumosCaracteristicasRelModels.Eliminar(arrayDelCarac);
                arrayDelCarac = new ArrayList();
            }
        }
        #endregion

        #region ABM Caracteristicas
        /// <summary>
        /// Agregar una nueva Caracteristica al Insumo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCarac_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(cbxCaracteristica.Text))
            {
                MessageBox.Show("Elija una Característica ", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (String.IsNullOrEmpty(txbCaracCosto.Text))
            {
                MessageBox.Show("Defina el Costo", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //Obtenemos la Descripcion de la Caracteristica
            DataTable dtCaracteristicasAUX = new DataTable();
            CaracteristicasModel.getConsultaCaracteristica(Convert.ToInt32(cbxCaracteristica.SelectedValue));
            dtCaracteristicasAUX = CaracteristicasModel.dataTable;
            //DataRow RowCarac = dtCaracteristicasAUX.Rows[0];


            //Obtenemos la Abreviatura de la Unidad de Medida
            DataTable dtUnidadMedidaAUX = new DataTable();
            UnidadMedidaModels.getConsultaUnidadMedida(Convert.ToInt32(cbxUniMedida.SelectedValue));
            dtUnidadMedidaAUX = UnidadMedidaModels.dataTable;
            //DataRow RowUnidad = dtUnidadMedidaAUX.Rows[0];


            /// <summary> WILLIAMS
            /// La forma mas facil de Llegar a la columna de un determinado ROW es la siguiente:
            /// </summary>
            /// datatable.Rows[nFila][nColumna].ToString();
            /// 

            int id = 0;
            int id_insumo = Convert.ToInt32(dgvInsumos.SelectedValue);
            int id_caracteristica = Convert.ToInt32(cbxCaracteristica.SelectedValue);
            string desc_caracteristica = dtCaracteristicasAUX.Rows[0][2].ToString(); //RowCarac[2].ToString();
            int id_unidad_medida = Convert.ToInt32(cbxUniMedida.SelectedValue);
            string abreviatura;
            try
            {
                abreviatura = dtUnidadMedidaAUX.Rows[0][3].ToString(); //RowUnidad[3].ToString();
            } catch
            {
                abreviatura = "";
            }
            string valor = txbValor.Text;
            int costo = Convert.ToInt32(txbCaracCosto.Text);

            DataRow Row = dtInsumosCaracteristicasRel.NewRow();
            id = dtInsumosCaracteristicasRel.Rows.Count + 1;
            Row["id"] = id;
            Row["id_insumos"] = id_insumo;
            Row["id_caracteristicas"] = id_caracteristica;
            Row["desc_caracteristica"] = desc_caracteristica;
            Row["id_unidad_medida"] = id_unidad_medida;
            Row["abreviatura"] = abreviatura;
            Row["valor"] = valor;
            Row["costo"] = costo;
            dtInsumosCaracteristicasRel.Constraints.Clear();
            dtInsumosCaracteristicasRel.Rows.Add(Row);

            if (is_modificar == true)
            {
                //Insertamos en la Base de Datos directo
                InsumosCaracteristicasRelModels.Insertar(id_insumo, id_caracteristica, id_unidad_medida, valor, costo);
            }
            else
            {
                string sql = "INSERT INTO insumos_caracteristicas_rel (id_insumos, id_caracteristicas, id_unidad_medida, valor, costo, user_insert, date_insert, user_update, date_update)"
                           + "VALUES(@1," + id_caracteristica + "," + id_unidad_medida + "," + valor + "," + costo + ",@2,sysdate(),@3,sysdate())";
                arrayInsertCarac.Add(sql);
            }

            //Actualizamos el DataGrid Caracteristicas
            dgvInsumoCaracteristicaRel.ItemsSource = dtInsumosCaracteristicasRel.DefaultView;

            txbValor.Text = "";
            txbCaracCosto.Text = "";
        }

        /// <summary>
        /// Elimina el registro seleccionado de la lista de caracteristicas del Insumo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelCarac_Click(object sender, RoutedEventArgs e)
        {
            if (dgvInsumoCaracteristicaRel.SelectedItems.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("¿Está seguro/a que desea eliminar? ", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                DataRowView Row_Sel = (DataRowView)dgvInsumoCaracteristicaRel.SelectedItem;
                int id = Convert.ToInt32(Row_Sel["id"]);

                //Agregamos en un Array todas las caracteristicas a Eliminar de la DB al guardar
                arrayDelCarac.Add(id);

                foreach (DataRow Row_Caracteristicas in dtInsumosCaracteristicasRel.Select("id=" + id))
                {
                    Row_Caracteristicas.Delete();
                }
            }
        }
        #endregion

        #region Filtros
        private void FiltrarInsumo(object sender, KeyEventArgs e)
        {
            string filtro = null;
            filtro = " codigo Like '%" + tbxFiltro.Text + "%' or descripcion Like '%" + tbxFiltro.Text + "%'";
            DataView dv = (DataView)dgvInsumos.ItemsSource;
            dv.RowFilter = filtro;
        }
        #endregion

        #region ChangedListner
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvInsumos.SelectedItems.Count == 0)
            {
                return;
            }

            //Setear el Estado obtenido desde la Base de Datos
            DataRowView Row = (DataRowView)dgvInsumos.SelectedItem;
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

            //Filtramos para que nos muestre las caracteristicas solamente del Insumo Seleccionado.
            InsumosCaracteristicasRelModels.getCaracteristicaDataGrid(Convert.ToInt32(Row["id"].ToString()));
            dtInsumosCaracteristicasRel = InsumosCaracteristicasRelModels.dataTable;
            dgvInsumoCaracteristicaRel.ItemsSource = dtInsumosCaracteristicasRel.DefaultView;
        }


        private void chkEstado_Click(object sender, RoutedEventArgs e)
        {
            if (chkEstado.IsChecked == true)
            {
                DataRowView Row = (DataRowView)dgvInsumos.SelectedItem;
                Row["estado"] = "S";
                chkEstado.IsChecked = true;
            }
            else
            {
                DataRowView Row = (DataRowView)dgvInsumos.SelectedItem;
                Row["estado"] = "N";
                chkEstado.IsChecked = false;
            }
        }
        #endregion

        #region Format Number
        /// WILLIAMS
        //private void FormattedTextBox(object sender, EventArgs e)
        //{
        //    txbCaracCosto.Text = string.Format("{0:#,##0.00}", double.Parse(txbCaracCosto.Text));
        //    txbPrecio.Text = string.Format("{0:#,##0.00}", double.Parse(txbPrecio.Text));
        //}
        #endregion
        //Sirve para que el campo solo acepte valores numericos
        private void isNumeric(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}