using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
namespace AranduraModel.Produccion
{
    public class PedidosModel
    {
        /// <summary>
        /// Obtenemos el Usuario Logueado
        /// </summary>
        string gbUser = Globales.gbUsuario;

        DataTable dt = new DataTable();
        public DataTable dataTable
        {
            get { return dt; }
            set { dt = value; }
        }

        /// <summary>
        /// Obtiene lista de todos los pedidos
        /// </summary>
        public void getPedidos() 
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT p.id, p.id_formato, p.id_cliente, p.descripcion, DATE_FORMAT(p.fecha_entrega,'%d/%m/%y') fecha_entrega, p.presupuesto, p.codigo, DATE_FORMAT(p.fecha_registro,'%d/%m/%y') fecha_registro, p.user_insert, f.descripcion FROM pedidos p, formato f where f.id = p.id_formato");
        }

        /// <summary>
        /// Obtiene la lista de todos los atributos
        /// </summary>
        public void getAtributosAll() 
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, descripcion, costo FROM atributos");
        }

        /// <summary>
        /// Obtiene lista de atributos filtrado por el formato
        /// </summary>
        public void getAtributosxFormato(int id_formato) 
        {
            ArrayList array = new ArrayList();
            array.Add(id_formato);
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            string sql = "SELECT r.id, a.id id_atributo, a.descripcion, r.cantidad, r.costo FROM formato_atributos_rel r, atributos a where r.id_atributos = a.id and r.id_formato = @1 ";
            dt = get_DT.loadDataTable(sql, array);
        }

        public void deletePedido(int id_pedido)
        {
            ArrayList array = new ArrayList();
            array.Add(id_pedido);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM pedidos p WHERE p.id=@1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public int addFormato(string descripcion, int costo)
        {
            ArrayList array = new ArrayList();
            array.Add(descripcion);
            array.Add(costo);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = " INSERT INTO formato(`descripcion`,`costo`,`user_insert`,`date_insert`,`user_update`,`date_update`) VALUES(@1,@2,@3,sysdate(),@3,sysdate()); SELECT id FROM formato WHERE id=Last_Insert_ID()";
            
            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;

        }

        public void delFormato(int id_formato)
        {
            ArrayList array = new ArrayList();
            array.Add(id_formato);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM formato WHERE id=@1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void updFormato(int id_formato, string descripcion, int costo)
        {
            //Agregamos en la Lista los parametros
            ArrayList array = new ArrayList();
            array.Add(id_formato);
            array.Add(descripcion);
            array.Add(costo);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE formato SET `descripcion` =@2, `costo` = @3 ,`user_insert` = @4 ,`date_insert` =sysdate(),`user_update` = @4,`date_update` = sysdate() WHERE `id` = @1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void AsignarAtributosFormato(int id_formato, int id_atributos, string cantidad, int costo)
        {
            ArrayList array= new ArrayList();
            array.Add(id_formato);
            array.Add(id_atributos);
            array.Add(cantidad);
            array.Add(costo);
            array.Add(gbUser);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO formato_atributos_rel (`id_formato`,`id_atributos`,`cantidad`,`costo`,`user_insert`,`date_insert`,user_update`,`date_update`)VALUES(@1,@2,@3,@4,@5,sysdate(),@5,sysdate())";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        
        }

        public void ActualizarAtributosFormato(int id_formato, int id_atributos, string cantidad, int costo) 
        {
            ArrayList array = new ArrayList();
            array.Add(id_formato);
            array.Add(id_atributos);
            array.Add(cantidad);
            array.Add(costo);
            array.Add(gbUser);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE formato_atributos_rel SET `id_atributos` = @2,`cantidad` = @3,`costo` = @4, `user_update` = @5,`date_update` = sysdate() WHERE `id_formato` = @1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void EliminarAtributosFormatoxID(int id) 
        {
            ArrayList array = new ArrayList();
            array.Add(id);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM formato_atributos_rel where id = @1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void EliminarAtributosxFormato(int id_formato) 
        {
            ArrayList array = new ArrayList();
            array.Add(id_formato);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM formato_atributos_rel WHERE id_formato = @1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public int addPedido(int id_formato, string codigo, string descripcion, string cliente, string fechaRegistro, string fechaVence, string presupuesto)
        {
            ArrayList array = new ArrayList();
            array.Add(id_formato);
            array.Add(cliente);
            array.Add(codigo);
            array.Add(descripcion);
            array.Add(fechaVence);
            array.Add(fechaRegistro);
            array.Add(presupuesto);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO pedidos(id_formato, id_cliente, codigo, descripcion, fecha_entrega, fecha_registro, presupuesto, user_insert, date_insert, user_update, date_update)"+
                         "VALUES(@1,@2,@3,@4,DATE_FORMAT(@5,'%y/%m/%d'),DATE_FORMAT(@6,'%y/%m/%d'),@7,@8,sysdate(),@8,sysdate()); SELECT id_user FROM pedidos WHERE id=Last_Insert_ID()";

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;

        }

        public void updPedido(int id_pedido, int id_formato, string codigo, string descripcion, string cliente, string fechaRegistro, string fechaVence, int presupuesto) 
        {
            ArrayList array = new ArrayList();
            array.Add(id_pedido);
            array.Add(id_formato);
            array.Add(cliente);
            array.Add(descripcion);
            array.Add(codigo);
            array.Add(fechaRegistro);
            array.Add(fechaVence);
            array.Add(presupuesto);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE pedidos SET `id_formato` = @2,`id_cliente` =@3,`descripcion` = @4,`codigo` = @5,`fecha_registro` = DATE_FORMAT(@6,'%y/%m/%d'),`fecha_entrega` = DATE_FORMAT(@7,'%y/%m/%d'),`presupuesto` = @8,`user_insert` = @9,`date_insert` = sysdate(),`user_update` = @9,`date_update` = sysdate() WHERE `id` = @1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

    }
}
