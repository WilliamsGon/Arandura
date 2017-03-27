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

namespace AranduraC.Modulos.Produccion
{
    /// <summary>
    /// Lógica de interacción para OrdenProduccion.xaml
    /// </summary>
    public partial class OrdenProduccion : Window
    {
        DataTable dtOrden = new DataTable();
        DataTable dtPedidos = new DataTable();
        AranduraModel.Produccion.OrdenProduccionModel OrdenProduccionModel = new AranduraModel.Produccion.OrdenProduccionModel();
        public OrdenProduccion()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrdenProduccionModel.getOrdenes();
            dtOrden = OrdenProduccionModel.dataTable;
            dgvOrden.ItemsSource = dtOrden.DefaultView;

            OrdenProduccionModel.getPedidos();
            dtPedidos = OrdenProduccionModel.dataTable;
            cbxPedido.ItemsSource = dtPedidos.DefaultView;
            cbxPedido.DisplayMemberPath = OrdenProduccionModel.dataTable.Columns[1].ToString();
            cbxPedido.SelectedValuePath = OrdenProduccionModel.dataTable.Columns[0].ToString();
        }

        private void dgvOrden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = 0;
            foreach (DataRowView row in dgvOrden.SelectedItems)
            {
                index = Convert.ToInt32(row.Row["es_activo"].ToString());
            }

            if (index != 0)
            {
                chkActivo.IsChecked = true;
            }
        }

        
        private void toolbar_btnNew_Click(object sender)
        {
            //Permitir valores nulos
            foreach (DataColumn column in dtOrden.Columns)
            {
                column.AllowDBNull = true;
            }
            dtOrden.RejectChanges();

            //Nueva fila
            DataRow NewRow = dtOrden.NewRow();
            dtOrden.Rows.Add(NewRow);

            //Seleccionar nueva fila agregada
            dgvOrden.SelectedIndex = dtOrden.Rows.Count - 1;
            tbxOrden.Focus();
            
        }

        private void toolbar_btnEdit_Click(object sender)
        {
            tbxOrden.Focus();
        }

        private void toolbar_btnDelete_Click(object sender)
        {
            DataRowView drv = (DataRowView)dgvOrden.SelectedItem;
            int index = Convert.ToInt32(drv["id"]);
            if (index != 0)
            {
                OrdenProduccionModel.delOrden(index);
            }
            //limpiar

        }

        private void toolbar_btnSave_Click(object sender)
        {
            foreach (DataRow row in dtOrden.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    addOrden();
                    break;
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    updOrden();
                    break;
                }
            }
        }

        private void toolbar_btnCancel_Click(object sender)
        {
            //limpiar
        }

        void addOrden() 
        {
            int id_pedido = Convert.ToInt32(cbxPedido.SelectedValue);
            int id_empleado = Convert.ToInt32(tbxEmpleado.Text);
            string fecha_inicio = dtpInicio.Text;
            string fecha_fin = dtpFin.Text;
            string descripcion = tbxDescripcion.Text;
            int es_activo =0;
            if (chkActivo.IsChecked == true) es_activo = 1;
            if (chkActivo.IsChecked == false) es_activo = 0;
            try 
            {
                int id_orden = OrdenProduccionModel.addOrden(id_pedido, id_empleado, descripcion, fecha_inicio, fecha_fin, es_activo);
                dgvOrden.SelectedValue = id_orden;
            }
            catch { }
            //limpiar
        }

        void updOrden() 
        {
            int id_pedido = Convert.ToInt32(cbxPedido.SelectedValue);
            int id_empleado = Convert.ToInt32(tbxEmpleado.Text);
            string fecha_inicio = dtpInicio.Text;
            string fecha_fin = dtpFin.Text;
            string descripcion = tbxDescripcion.Text;
            int es_activo = 0;
            if (chkActivo.IsChecked == true) es_activo = 1;
            if (chkActivo.IsChecked == false) es_activo = 0;
            int id_orden = Convert.ToInt32(dgvOrden.SelectedValue);
            try
            {
                OrdenProduccionModel.updOrden(id_orden, id_pedido, id_empleado, descripcion, fecha_inicio, fecha_fin, es_activo);
                dgvOrden.SelectedValue = id_orden;
            }
            catch { }
            //limpiar
        }

       
    }
}
