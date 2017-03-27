using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel.Produccion
{
    public class OrdenProduccionModel
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
        public void getOrdenes()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT `id`,`id_pedidos`,`id_empleado`,`descripcion`,DATE_FORMAT(`fecha_inicio`,'%d/%m/%y'),DATE_FORMAT(`fecha_fin`,'%d/%m/%y'),`es_activo` FROM `orden_de_produccion`");
        }
        public void getPedidos()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT `id`,`descripcion` FROM `pedidos`");
        }

        #region ABM
        public int addOrden(int id_pedido, int id_empleado, string descripcion, string fecha_inicio, string fecha_fin, int es_activo)
        {
            ArrayList array = new ArrayList();
            array.Add(id_pedido);
            array.Add(id_empleado);
            array.Add(descripcion);
            array.Add(fecha_inicio);
            array.Add(fecha_fin);
            array.Add(es_activo);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO `orden_de_produccion`(`id_pedidos`,`id_empleado`,`descripcion`,DATE_FORMAT(`fecha_inicio`,'%y/%m/%d'),DATE_FORMAT(`fecha_fin`,'%y/%m/%d'),`es_activo`,`user_insert`,`date_insert`,`user_update`,`date_update`)"+
                         "VALUES(@1,@2,@3,@4,@5,@6,@7, sysdate(),@7, sysdate());; SELECT id_user FROM orden_de_produccion WHERE id=Last_Insert_ID()";

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;

        }

        public void updOrden(int id_orden, int id_pedido, int id_empleado, string descripcion, string fecha_inicio, string fecha_fin, int es_activo)
        {
            ArrayList array = new ArrayList();
            array.Add(id_orden);
            array.Add(id_pedido);
            array.Add(id_empleado);
            array.Add(descripcion);
            array.Add(fecha_inicio);
            array.Add(fecha_fin);
            array.Add(es_activo);
            array.Add(gbUser);

            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE `orden_de_produccion `SET `id_pedidos` = @2, `id_empleado` = @3, `descripcion` = @4, `fecha_inicio` = DATE_FORMAT(@5,'%y/%m/%d'), `fecha_fin` = DATE_FORMAT(@6,'%y/%m/%d'), `es_activo` = @7, `user_insert` = @8 , `date_insert` = sysdate(), `user_update` = @8, `date_update` = sysdate() WHERE `id` = @1";

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void delOrden(int id_orden)
        {
            ArrayList array = new ArrayList();
            array.Add(id_orden);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM orden_de_produccion p WHERE p.id=@1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }
        #endregion
        

    }
}
