using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel.Produccion
{
    public class InsumosModel
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
        /// Obtiene la lista completa de todos los Insumos.
        /// </summary>
        public void getInsumos()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, codigo, descripcion, estado, costo, cantidad "
                                    + "FROM insumos "
                                    + "ORDER BY descripcion");
        }

        #region ABM
        /// <summary>
        /// Inserta el Insumo
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="descripcion"></param>
        /// <param name="estado"></param>
        /// <param name="costo"></param>
        /// <returns></returns>
        public int Insertar(string codigo, string descripcion, string estado, int costo, int cantidad)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO insumos (codigo, descripcion, estado, costo, cantidad, user_insert, date_insert, user_update, date_update)"
                       + "VALUES(@1,@2,@3,@4,@5,@6,sysdate(),@7,sysdate()); SELECT id FROM insumos WHERE id=Last_Insert_ID()";

            //Agregamos en la Lista los parametros
            array.Add(codigo);
            array.Add(descripcion);
            array.Add(estado);
            array.Add(costo);
            array.Add(cantidad);
            array.Add(gbUser);
            array.Add(gbUser);

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            Globales.gbID = id;
            return id;
        }

        /// <summary>
        /// Actualizar el Insumo
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="descripcion"></param>
        /// <param name="costo"></param>
        /// <param name="estado"></param>
        /// <param name="id"></param>
        public void Actualizar(string codigo, string descripcion, string estado, int costo, int cantidad, int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE insumos SET codigo=@1, descripcion=@2, estado=@3, costo=@4, cantidad=@5, user_update=@6, date_update=sysdate() WHERE id=@7";

            //Agregamos en la Lista los parametros
            array.Add(codigo);
            array.Add(descripcion);
            array.Add(estado);
            array.Add(costo);
            array.Add(cantidad);
            array.Add(gbUser);
            array.Add(id);

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        /// <summary>
        /// Eliminar Insumo
        ///     ESTA FUNCION BORRA EL INSUMO JUNTO CON LAS RELACIONES DE LAS CARACTERISTICAS !!!
        /// </summary>
        /// <param name="id"></param>
        public void Eliminar(int id)
        {
            string sql;
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();

            //Primero Borramos las Relaciones
            sql = "DELETE FROM insumos_caracteristicas_rel WHERE id_insumos=@1";
            array.Add(id);
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);

            //Luego Borramos el Insumo
            sql = "DELETE FROM insumos WHERE id=@1";
            array.Add(id);
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }
        #endregion
    }
}
