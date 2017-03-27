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
    /// Lógica de interacción para Seguimiento.xaml
    /// </summary>
    public partial class Seguimiento : Window
    {
        DataTable dtOrden = new DataTable();
        DataTable dtSeguimientos = new DataTable();
        AranduraModel.Produccion.SeguimientoModel SeguimientoModel = new AranduraModel.Produccion.SeguimientoModel();

        public Seguimiento()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SeguimientoModel.getSeguimientos();
            dtSeguimientos = SeguimientoModel.dataTable;
            dgvSeguimientos.ItemsSource = dtSeguimientos.DefaultView;

            SeguimientoModel.getOrdenes();
            dtOrden = SeguimientoModel.dataTable;
            cbxOrden.ItemsSource = dtOrden.DefaultView;
            cbxOrden.DisplayMemberPath = SeguimientoModel.dataTable.Columns[1].ToString();
            cbxOrden.SelectedValuePath = SeguimientoModel.dataTable.Columns[0].ToString();
        }


        private void toolbar_btnNew_Click(object sender)
        {
            //Permitir valores nulos
            foreach (DataColumn column in dtSeguimientos.Columns)
            {
                column.AllowDBNull = true;
            }
            dtSeguimientos.RejectChanges();

            //Nueva fila
            DataRow NewRow = dtSeguimientos.NewRow();
            dtSeguimientos.Rows.Add(NewRow);

            //Seleccionar nueva fila agregada
            dgvSeguimientos.SelectedIndex = dtOrden.Rows.Count - 1;
            tbxDescripcion.Focus();
        }

        private void toolbar_btnEdit_Click(object sender)
        {
            tbxDescripcion.Focus();

        }

        private void toolbar_btnSave_Click(object sender)
        {
            foreach (DataRow row in dtOrden.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    addSeguimiento();
                    break;
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    updSeguimiento();
                    break;
                }
            }
        }

        void addSeguimiento() 
        {
            int id_orden = Convert.ToInt32(cbxOrden.SelectedValue);
            string desc = tbxDescripcion.Text;
            int id = SeguimientoModel.addSeguimiento(id_orden, desc);
            dgvSeguimientos.SelectedValue = id;
        }

        void updSeguimiento() 
        {
            int id_orden = Convert.ToInt32(cbxOrden.SelectedValue);
            string desc = tbxDescripcion.Text;
            int id_seguimiento = Convert.ToInt32(dgvSeguimientos.SelectedValue);
            SeguimientoModel.updSeguimiento(id_seguimiento,id_orden, desc);
            dgvSeguimientos.SelectedValue = id_seguimiento;
        }

        private void toolbar_btnCancel_Click(object sender)
        {
            //limpiar
        }

        private void toolbar_btnDelete_Click(object sender)
        {
            DataRowView drv = (DataRowView)dgvSeguimientos.SelectedItem;
            int index = Convert.ToInt32(drv["id"]);
            if (index != 0)
            {
                SeguimientoModel.delSeguimiento(index);
            }
            //limpiar
        }

       
    }
}
