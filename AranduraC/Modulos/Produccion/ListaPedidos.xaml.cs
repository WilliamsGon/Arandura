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
    /// Lógica de interacción para ListaPedidos.xaml
    /// </summary>
    public partial class ListaPedidos : MetroWindow
    {
        int id_formato;
        int id_pedido;
        AranduraModel.Produccion.PedidosModel PedidosModel = new AranduraModel.Produccion.PedidosModel();
        DataTable dtAtributos = new DataTable();
        DataTable dtAtributosAll = new DataTable();
        DataTable dtPedidos = new DataTable();
        public ListaPedidos()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PedidosModel.getPedidos();
            dtPedidos = PedidosModel.dataTable;
            dgvListaPedidos.ItemsSource = dtPedidos.DefaultView;
            tbcPedidos.SelectedItem = tabList;

            PedidosModel.getAtributosAll();
            dtAtributosAll = PedidosModel.dataTable;
            cbxAtributo.ItemsSource = dtAtributosAll.DefaultView;
            cbxAtributo.SelectedValuePath = PedidosModel.dataTable.Columns[0].ToString();
            cbxAtributo.DisplayMemberPath = PedidosModel.dataTable.Columns[1].ToString();
        }

        #region Handlers
        private void dgvListaPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = 0;
            foreach (DataRowView row in dgvListaPedidos.SelectedItems)
            {
                index = Convert.ToInt32(row.Row["id_formato"].ToString());
                
            }

            if (index != 0)
            {
                id_formato = index;
                PedidosModel.getAtributosxFormato(id_formato);
                dtAtributos = PedidosModel.dataTable;
                dgvAtributos.ItemsSource = dtAtributos.DefaultView;
            }
        }

        private void toolbar_btnNew_Click(object sender)
        {
            //insertamos formato y pedido con campos vacíos
            id_formato = PedidosModel.addFormato("",0);
            id_pedido = PedidosModel.addPedido(id_formato, "", "", "", "", "", "");

             //Permitir valores nulos
            foreach (DataColumn column in dtPedidos.Columns)
            {
                column.AllowDBNull = true;
            }
            dtPedidos.RejectChanges();

            //Nueva fila
            DataRow NewRow = dtPedidos.NewRow();
            dtPedidos.Rows.Add(NewRow);

            //Seleccionar nueva fila agregada
            dgvListaPedidos.SelectedIndex = dtPedidos.Rows.Count - 1;
            tbcPedidos.SelectedItem = tabDesc;
            tbxCodigo.Focus();
        }

        private void toolbar_btnEdit_Click(object sender)
        {
            tbcPedidos.SelectedItem = tabDesc;
            tbxCodigo.Focus();
        }

        private void toolbar_btnCancel_Click(object sender)
        {
            //dtPedidos.RejectChanges();
            

            PedidosModel.EliminarAtributosxFormato(id_formato);
            PedidosModel.delFormato(id_formato);
            PedidosModel.deletePedido(id_pedido);
            PedidosModel.getPedidos();
            dtPedidos = PedidosModel.dataTable;
            dgvListaPedidos.ItemsSource = dtPedidos.DefaultView;
            dgvListaPedidos.SelectedIndex = 0;
            tbcPedidos.SelectedItem = tabList;
        }

        #endregion

        #region ABM

        private void toolbar_btnDelete_Click(object sender)
        {
            DataRowView drv = (DataRowView)dgvListaPedidos.SelectedItem;
            int index = Convert.ToInt32(drv["id"]);
            if (index != 0)
            {
                id_pedido = index;
                PedidosModel.deletePedido(id_pedido);
            }
            
        }

        private void toolbar_btnSave_Click(object sender)
        {
            foreach (DataRow row in dtPedidos.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    addPedido();
                    break;
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    updatePedido();
                    break;
                }
            }
        }

        void addPedido() 
        {
            string codigo = tbxCodigo.Text;
            string descripcion = tbxDescripcion.Text;
            string cliente = tbxCliente.Text;
            string fechaRegistro = dtpFechaRegistro.Text;
            string fechaVence = dtpFechaVenc.Text;
            int presupuesto = Convert.ToInt32(tbxPresupuesto.Text);
            string formato = tbxFormato.Text;
            try
            {
                PedidosModel.updFormato(id_formato, formato, presupuesto);
                PedidosModel.updPedido(id_pedido, id_formato, codigo, descripcion, cliente, fechaRegistro, fechaVence, presupuesto);
                foreach (DataRow dr in dtAtributos.Rows)
                {
                    PedidosModel.AsignarAtributosFormato(id_formato, Convert.ToInt32(dr["id_atributo"]), dr["cantidad"].ToString(), Convert.ToInt32(dr["costo"]));
                }
               
                //limpiar campos
            }
            catch { }
        }

        void updatePedido() 
        {
            string codigo = tbxCodigo.Text;
            string descripcion = tbxDescripcion.Text;
            string cliente = tbxCliente.Text;
            string fechaRegistro = dtpFechaRegistro.Text;
            string fechaVence = dtpFechaVenc.Text;
            int presupuesto = Convert.ToInt32(tbxPresupuesto.Text);
            string formato = tbxFormato.Text;
            
            try
            {
                PedidosModel.updFormato(id_formato, formato, presupuesto);
                PedidosModel.updPedido(id_pedido, id_formato, codigo, descripcion, cliente, fechaRegistro, fechaVence, presupuesto);
                foreach (DataRow dr in dtAtributos.Rows)
                {
                    PedidosModel.ActualizarAtributosFormato(id_formato, Convert.ToInt32(dr["id_atributo"]), dr["cantidad"].ToString(), Convert.ToInt32(dr["costo"]));
                }

                //limpiar campos
            }
            catch { }
        }

        #endregion

        private void btnAddAtributo_Click(object sender, RoutedEventArgs e)
        {
            int id_atributo = Convert.ToInt32(cbxAtributo.SelectedValue);
            string descripcion = cbxAtributo.Text.ToString();
            string cantidad = tbxCantAtributo.Text;
            int costo = Convert.ToInt32(tbxCostoAtributo.Text);

            foreach (DataRow row in dtAtributos.Select("id_atributo=" + id_atributo))
            {
                MessageBox.Show("Atributo ya ingresado");
                break;
            }
            DataRow dr = dtAtributos.NewRow();
            dr["id_atributo"]= id_atributo;
            dr["descripcion"]= descripcion;
            dr["cantidad"]= cantidad;
            dr["costo"]= costo;

            dtAtributos.Rows.Add(dr);
            dgvAtributos.ItemsSource = dtAtributos.DefaultView;


            //try 
            //{
            //    PedidosModel.AsignarAtributosFormato(id_formato, id_atributo, cantidad, costo);

            //    PedidosModel.getAtributosxFormato(id_formato);
            //    dtAtributos = PedidosModel.dataTable;
            //    dgvAtributos.ItemsSource = dtAtributos.DefaultView;
            //}
            //catch { }

        }

        private void btnDelAtributo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id_atributo = Convert.ToInt32(dgvAtributos.SelectedValue);
                PedidosModel.EliminarAtributosFormatoxID(id_atributo);

                PedidosModel.getAtributosxFormato(id_formato);
                dtAtributos = PedidosModel.dataTable;
                dgvAtributos.ItemsSource = dtAtributos.DefaultView;
                if (dgvAtributos.Items.Count > 0)
                {
                    DataRowView drv = (DataRowView)dgvAtributos.SelectedItem;
                    int id = Convert.ToInt32(drv["id_atributo"]);
                    foreach (DataRow dr in dtAtributos.Select("id_atributo =" + id))
                    {
                        dr.Delete();
                    }
                }

            }
            catch { }
        }

        private void cbxAtributo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Convert.ToInt32(cbxAtributo.SelectedValue);
            //tbxCostoAtributo.Text = dtAtributosAll.Rows["COSTO"].ToString();
            foreach (DataRow row in dtAtributosAll.Rows) 
            {
                if (Convert.ToInt32(row["ID"]) == index) 
                {
                    tbxCostoAtributo.Text = row["COSTO"].ToString();
                }
            }
        }

        private void tbxCantAtributo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxCostoAtributo.Text != "") 
            {
                int costo = Convert.ToInt32(tbxCostoAtributo.Text);
                int cant = Convert.ToInt32(tbxCantAtributo.Text);
                tbxCostoAtributo.Text = (costo * cant).ToString();
            }
        }


      

      

       
    }
}
