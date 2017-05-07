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
using System.Data;
using System.Collections;
using Controls;
using AranduraModel;
using AranduraC;

namespace AranduraC.Modulos
{
    /// <summary>
    /// Lógica de interacción para pageModulos.xaml
    /// </summary>
    public partial class pageModulos : Page
    {
        DataTable dtModulos = new DataTable();
        DataTable dtVentanas = new DataTable();
        AutorizacionModel AutorizacionModel = new AranduraModel.AutorizacionModel(); 
        string usuario = "";
        string modName = "";
        public pageModulos(string user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //AutorizacionModel.getModulos();
            //dtModulos = AutorizacionModel.dataTable;
            //foreach (DataRow row in dtModulos.Rows)
            //{
            //    menuAppIcon appIcon = new menuAppIcon();
            //    appIcon.IconSource = new BitmapImage(new Uri("../Images/Menu/" + row.Field<string>("descripcion").ToString() + ".png", UriKind.Relative)).ToString();
            //    appIcon.IconColor = Brushes.Black;
            //    appIcon.Name = row.Field<string>("descripcion").ToString();

            //    appIcon.MouseUp += new MouseButtonEventHandler(this.FiltrarVentanas);
            //    this.stckModulos.Children.Add(appIcon);
            //}
        }

        private void load_module(object sender, MouseButtonEventArgs e)
        {
            AutorizacionModel.dataTable.Clear();
            modName = (sender as menuIcon).Name;
            FiltrarVentanas();
        }

        void FiltrarVentanas(/*object sender, MouseButtonEventArgs e*/) 
        {
            this.wrapVentanas.Children.Clear();
            AutorizacionModel.GetVentanas(usuario, modName.ToString());
            dtVentanas = AutorizacionModel.dataTable;
            foreach (DataRow row in dtVentanas.Rows)
            {
                menuAppIcon iconoVentana = new menuAppIcon();
                iconoVentana.IconSource = new BitmapImage(new Uri("../Images/Ventanas/" + row.Field<string>("img").ToString() + ".png", UriKind.Relative)).ToString();
                iconoVentana.IconColor = Brushes.Black;
                iconoVentana.Name = row.Field<string>("descripcion").ToString();
                iconoVentana.text = row.Field<string>("nombre").ToString().ToUpper(); ;

                iconoVentana.MouseUp += new MouseButtonEventHandler(this.LlamarVentana);
                this.wrapVentanas.Children.Add(iconoVentana);
            }
        }

        /// <summary>
        /// ACA SE HACEN LOS LLAMADOS A LAS VENTANAS, no es el mejor razonamiento, pero salva todo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         void LlamarVentana(object sender, MouseEventArgs e) 
         {
             var btn = sender as menuAppIcon;
             if (btn != null) 
             {

                //aca llamamos las ventanas dependiendo de su descripcion, esto es un ejemplo
                 if (btn.Name.ToString().ToUpper() == "PRODUCTOS")
                {
                    Produccion.Productos Productos = new Produccion.Productos();
                    Productos.ShowDialog();
                }

                 if (btn.Name.ToString().ToUpper() == "USUARIOS")
                {
                    Sistema_Base.Usuarios Usuarios = new Sistema_Base.Usuarios();
                    Usuarios.ShowDialog();
                }

                if (btn.Name.ToString().ToUpper() == "INSUMOS")
                {
                    Produccion.Insumos Insumos = new Produccion.Insumos();
                    Insumos.ShowDialog();
                }

                if (btn.Name.ToString().ToUpper() == "COMBO")
                {
                    Produccion.ComboMateriaPrima ComboMateriaPrima = new Produccion.ComboMateriaPrima();
                    ComboMateriaPrima.ShowDialog();
                }
                if (btn.Name.ToString().ToUpper() == "DEPOSITOS")
                {
                    Sistema_Base.Depositos Depositos = new Sistema_Base.Depositos();
                    Depositos.ShowDialog();
                }
                if (btn.Name.ToString().ToUpper() == "SEGUIMIENTO")
                {
                    Produccion.Seguimiento Seguimiento = new Produccion.Seguimiento();
                    Seguimiento.ShowDialog();
                }
                if (btn.Name.ToString().ToUpper() == "PEDIDOS")
                {
                    Produccion.ListaPedidos ListaPedidos = new Produccion.ListaPedidos();
                    ListaPedidos.ShowDialog();
                }
                if (btn.Name.ToString().ToUpper() == "ORDEN")
                {
                    Produccion.OrdenProduccion OrdenProduccion = new Produccion.OrdenProduccion();
                    OrdenProduccion.ShowDialog();
                }
                if (btn.Name.ToString().ToUpper() == "PRODUCTOS_COMBO")
                {
                    AranduraC.Modulos.Produccion.ComboProducto ComboProducto = new Modulos.Produccion.ComboProducto();
                    ComboProducto.ShowDialog();
                }
            }
        }
    }
}
