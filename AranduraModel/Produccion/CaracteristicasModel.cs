using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AranduraModel.Produccion
{
    public class CaracteristicasModel
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
        /// Obtiene la lista completa de todas las Caracteristicas de los Insumos.
        /// </summary>
        public void getCaracteristicas()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, codigo, descripcion, valor "
                                    + "FROM caracteristicas "
                                    + "ORDER BY descripcion");
        }

        /// <summary>
        /// Se obtiene la lista de Caracteristicas para un ComboBox
        /// </summary>
        public void getCaracteristicaComboBox()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, codigo, descripcion "
                                    + "FROM caracteristicas "
                                    + "ORDER BY descripcion");
        }

        /// <summary>
        /// Se obtiene la lista de Caracteristicas para una Consulta
        /// </summary>
        public void getConsultaCaracteristica(int id)
        {
            ArrayList array = new ArrayList();
            array.Add(id);
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            string sql = "SELECT id, codigo, descripcion, valor "
                       + "FROM caracteristicas "
                       + "WHERE id=@1 ";
            dt = get_DT.loadDataTable(sql, array);
        }

        #region ABM
        public void Insertar()
        {
            //ArrayList array = new ArrayList();
            //DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            //string sql = "INSERT INTO productos (codigo, descripcion, costo, estado, user_insert, date_insert, user_update, date_update)"
            //           + "VALUES(@1,@2,@3,@4,@5,sysdate(),@6,sysdate()); SELECT id FROM productos WHERE id=Last_Insert_ID()";

            ////Agregamos en la Lista los parametros
            //array.Add(codigo);
            //array.Add(descripcion);
            //array.Add(costo);
            //array.Add(estado);
            //array.Add(gbUser);
            //array.Add(gbUser);

            //int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            //return id;
        }
        #endregion
    }
}
