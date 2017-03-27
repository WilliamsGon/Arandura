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
    /// Lógica de interacción para Depositos.xaml
    /// </summary>
    public partial class Depositos : MetroWindow
    {
        DataTable dtDepositos = new DataTable();
        AranduraModel.SistemaBase.DepositosModels DepositosModels = new AranduraModel.SistemaBase.DepositosModels();
        public Depositos()
        {
            InitializeComponent();
        }

        #region Load
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
            dgvDepositos.SelectedIndex = 0;
        }

        private void CargarDataGrid()
        {
            DepositosModels.GetDepositos();
            dtDepositos = DepositosModels.dataTable;
            dgvDepositos.ItemsSource = dtDepositos.DefaultView;
            DeshabilitarCampos();
        }

        private void DeshabilitarCampos()
        {
            dgDepositos.IsEnabled = false;
            grdCampos.IsEnabled = true;
        }

        private void HabilitarCampos()
        {
            dgDepositos.IsEnabled = true;
            grdCampos.IsEnabled = false;
        }
        #endregion

        #region ABM ToolBar
        //Nuevo
        private void Nuevo(object sender)
        {
            // nuevo = true;
            HabilitarCampos();
            txbCodigo.Focus();

            // Permitir valores nulos
            foreach (DataColumn column in dtDepositos.Columns)
            {
                column.AllowDBNull = true;
            }

            //Nueva fila
            DataRow RowNew = dtDepositos.NewRow();
            dtDepositos.Rows.Add(RowNew);

            //Seleccionar nueva fila agregada
            dgvDepositos.ItemsSource = dtDepositos.AsDataView();
            dgvDepositos.SelectedIndex = dgvDepositos.Items.Count - 1;
        }

        //Editar
        private void Editar(object sender)
        {
            //nuevo = false;
            HabilitarCampos();
            txbCodigo.Focus();
        }

        //Eliminar
        private void Eliminar(object sender)
        {
            if (MessageBox.Show("¿Está seguro/a que desea eliminar? ", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(dgvDepositos.SelectedValue);
                //DepositosModels.Eliminar(id);
                CargarDataGrid();
            }
        }

        //Guardar
        private void Guardar(object sender)
        {
            foreach (DataRow dr in dtDepositos.Rows)
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
            dgvDepositos.SelectedItem = 0;
            DeshabilitarCampos();
        }
        #endregion

        #region ABM Funciones
        private void Insertar()
        {
            ////Validamos si el estado está Activo o No.
            //if (chkEstado.IsChecked == true)
            //{
            //    is_active = "S";
            //}
            //else {
            //    is_active = "N";
            //}

            ////Llamamos a la funcion INSERTAR que guarda el nuevo Producto y retorna el nuevo ID generado.
            //int id = ProductosModel.Insertar(txbCod.Text, txbDesc.Text, Convert.ToInt32(txbPrecio.Text), is_active);
            //CargarDataGrid();
            //dgvDepositos.SelectedValue = id;
            DeshabilitarCampos();
        }

        private void Actualizar()
        {
            ////Validamos si el estado está Activo o No.
            //if (chkEstado.IsChecked == true)
            //{
            //    is_active = "S";
            //}
            //else {
            //    is_active = "N";
            //}

            ////Llamamos a la funcion ACTUALIZAR que modifica el Producto.
            //int id = Convert.ToInt32(dgvDepositos.SelectedValue);
            //ProductosModel.Actualizar(txbCod.Text, txbDesc.Text, Convert.ToInt32(txbPrecio.Text), is_active, id);
            //CargarDataGrid();
            //dgvDepositos.SelectedValue = id;
            DeshabilitarCampos();
        }
        #endregion

        #region Filtros
        private void FiltrarDeposito(object sender, KeyEventArgs e)
        {
            string filtro = null;
            filtro = " codigo Like '%" + tbxFiltro.Text + "%' or descripcion Like '%" + tbxFiltro.Text + "%'";
            DataView dv = (DataView)dgvDepositos.ItemsSource;
            dv.RowFilter = filtro;
        }
        #endregion
    }
}
