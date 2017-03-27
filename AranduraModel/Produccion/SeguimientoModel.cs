using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel.Produccion
{
    public class SeguimientoModel
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

        public void getSeguimientos()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT `id`,`id_orden_de_produccion`,`descripcion`,`fecha`,`user_insert`,`date_insert`,`user_update`,DATE_FORMAT(`date_update`,'%d/%m/%y') date_update FROM `seguimientos`");
        }

        public void getOrdenes() 
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT `id`,`descripcion` FROM `orden_de_produccion` WHERE `es_activo` = 1");
        }

        public int addSeguimiento(int id_orden,string descripcion)
        {
            ArrayList array = new ArrayList();
            array.Add(id_orden);
            array.Add(descripcion);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO seguimientos(id_orden, descripcion, user_insert, date_insert, user_update, date_update)" +
                         "VALUES(@1,@2,@3,sysdate(),@3,sysdate()); SELECT id_user FROM seguimientos WHERE id=Last_Insert_ID()";

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;

        }

        public void updSeguimiento(int id_seguimiento, int id_orden, string descripcion)
        {
            ArrayList array = new ArrayList();
            array.Add(id_seguimiento);
            array.Add(id_orden);
            array.Add(descripcion);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE seguimientos SET `id_orden` = @2,`descripcion` =@3`user_update` = @4,`date_update` = sysdate() WHERE `id` = @1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void delSeguimiento(int id_seguimiento)
        {
            ArrayList array = new ArrayList();
            array.Add(id_seguimiento);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM seguimientos p WHERE p.id=@1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }
    }
}
