using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AranduraModel.Produccion
{
    public class ComboMateriaPrimaModel
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
        public void getInsumosList()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, codigo, descripcion, estado, costo, cantidad "
                                    + "FROM insumos "
                                    + "ORDER BY descripcion");
        }

        public void getProductosList()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, codigo, descripcion, estado, costo, cantidad "
                                    + "FROM productos "
                                    + "ORDER BY descripcion");
        }


        public void ActualizarInsumo(decimal cantidad, int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE insumos "
                       + "SET cantidad = cantidad + @1, "
                       + "user_update=@2, "
                       + "date_update= sysdate() "
                       + "WHERE id=@3";
            //Agregamos en la Lista los parametros
            array.Add(cantidad);            //@1
            array.Add(gbUser);              //@2
            array.Add(id);                  //@3

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void ActualizarProducto(decimal cantidad, int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE productos "
                       + "SET cantidad = cantidad + @1, "
                       + "user_update=@2, "
                       + "date_update= sysdate() "
                       + "WHERE id=@3";
            //Agregamos en la Lista los parametros
            array.Add(cantidad);            //@1
            array.Add(gbUser);              //@2
            array.Add(id);                  //@3

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }
        /// <summary>
        /// Actualiza los Insumos que formaron parte de las Recetas
        /// </summary>
        /// <param name="arrayInsert"></param>
        public void ActualizarRecetas(ArrayList arrayInsert)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();

            //Agregamos en la Lista los parametros
            array.Add(gbUser);              //@1

            foreach (string sql in arrayInsert)
            {
                exeSQLQuery.SQLQueryParameter_Execute(array, sql);
            }
        }
    }
}
