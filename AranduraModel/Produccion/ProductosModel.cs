using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel.Produccion
{
    public class ProductosModel
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
        /// Obtiene la lista completa de todos los productos.
        /// </summary>
        public void getProductos()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, codigo, descripcion, costo, estado,"
                                    + "user_insert, date_insert, user_update, date_update "
                                    + "FROM productos "
                                    + "ORDER BY descripcion");
        }

        #region ABM
        /// <summary>
        /// Inserta el Producto
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="descripcion"></param>
        /// <param name="costo"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int Insertar(string codigo, string descripcion, int costo, string estado)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO productos (codigo, descripcion, costo, estado, user_insert, date_insert, user_update, date_update)"
                       + "VALUES(@1,@2,@3,@4,@5,sysdate(),@6,sysdate()); SELECT id FROM productos WHERE id=Last_Insert_ID()";

            //Agregamos en la Lista los parametros
            array.Add(codigo);
            array.Add(descripcion);
            array.Add(costo);
            array.Add(estado);
            array.Add(gbUser);
            array.Add(gbUser);

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;
        }

        /// <summary>
        /// Actualizar el Producto
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="descripcion"></param>
        /// <param name="costo"></param>
        /// <param name="estado"></param>
        /// <param name="id"></param>
        public void Actualizar(string codigo, string descripcion, double costo, string estado, int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE productos SET codigo=@1, descripcion=@2, costo=@3, estado=@4, user_update=@5, date_update=sysdate() WHERE id=@6";

            //Agregamos en la Lista los parametros
            array.Add(codigo);
            array.Add(descripcion);
            array.Add(costo);
            array.Add(estado);
            array.Add(gbUser);
            array.Add(id);

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        /// <summary>
        /// Eliminar Producto
        /// </summary>
        /// <param name="id"></param>
        public void Eliminar(int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM productos WHERE id=@1";

            //Agregamos en la Lista los parametros
            array.Add(id);

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }
        #endregion
    }
}
