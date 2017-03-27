using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AranduraModel.Produccion
{
    public class InsumosCaracteristicasRelModels
    {
        /// <summary>
        /// Obtenemos el Usuario Logueado
        /// </summary>
        string gbUser = Globales.gbUsuario;
        int idAUX = Globales.gbID;

        DataTable dt = new DataTable();
        public DataTable dataTable
        {
            get { return dt; }
            set { dt = value; }
        }

        /// <summary>
        /// Obtiene la lista completa de todas las Caracteristicas de los Insumos.
        /// </summary>
        public void getInsumosCaracteristicasRel()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, id_insumos, id_caracteristicas, id_unidad_medida, valor, costo, user_insert, date_insert, user_update, date_update "
                                    + "FROM insumos_caracteristicas_rel");
        }
        
        /// <summary>
        /// Obtiene la lista completa de las Caracteristicas relacionadas con los Insumos.
        /// </summary>
        public void getCaracteristicaDataGrid(int id_insumo)
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT r.id, r.id_insumos, r.id_caracteristicas, c.descripcion desc_caracteristica, r.valor, r.id_unidad_medida, initcap(u.abreviatura) abreviatura, r.costo "
                                    + "FROM insumos i "
                                    + "   , caracteristicas c "
                                    + "   , insumos_caracteristicas_rel r "
                                    + "   , unidad_medidas u "
                                    + "WHERE i.id = r.id_insumos "
                                    + "  and c.id = r.id_caracteristicas "
                                    + "  and r.id_unidad_medida = u.id "
                                    + "  and r.id_insumos = " + id_insumo);
        }

        #region ABM
        /// <summary>
        /// Procedimiento para Insertar una nueva Relacion entre Insumos y Caracteristicas
        /// </summary>
        /// <param name="id_insumos"></param>
        /// <param name="id_caracteristicas"></param>
        /// <param name="id_unidad_medida"></param>
        /// <param name="valor"></param>
        /// <param name="costo"></param>
        /// <returns></returns>
        public int Insertar(int id_insumos, int id_caracteristicas, int id_unidad_medida, string valor, int costo)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO insumos_caracteristicas_rel (id_insumos, id_caracteristicas, id_unidad_medida, valor, costo, user_insert, date_insert, user_update, date_update)"
                       + "VALUES(@1,@2,@3,@4,@5,@6,sysdate(),@7,sysdate()); SELECT id FROM insumos_caracteristicas_rel WHERE id=Last_Insert_ID()";

            //Agregamos en la Lista los parametros
            array.Add(id_insumos);          //@1
            array.Add(id_caracteristicas);  //@2
            array.Add(id_unidad_medida);    //@3
            array.Add(valor);               //@4
            array.Add(costo);               //@5
            array.Add(gbUser);              //@6
            array.Add(gbUser);              //@7

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;
        }

        /// <summary>
        /// Esta inserción es provisoria, se puede hacer mejor
        /// </summary>
        /// <param name="arrayInsert"></param>
        public void InsertarArray(ArrayList arrayInsert)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();

            //Agregamos en la Lista los parametros
            array.Add(Globales.gbID);       //@1
            array.Add(gbUser);              //@2
            array.Add(gbUser);              //@3

            foreach (string sql in arrayInsert)
            {
                exeSQLQuery.SQLQueryParameter_Execute(array, sql);
            }
        }

        public void Actualizar(int id_insumos, int id_caracteristicas, int id_unidad_medida, string valor, int costo, int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE insumos_caracteristicas_rel SET id_insumos=@1, id_caracteristicas=@2, id_unidad_medida=@3, valor=@4, costo=@5, user_insert=@6, date_update=sysdate() WHERE id=@7";

            //Agregamos en la Lista los parametros
            array.Add(id_insumos);          //@1
            array.Add(id_caracteristicas);  //@2
            array.Add(id_unidad_medida);    //@3
            array.Add(valor);               //@4
            array.Add(costo);               //@5
            array.Add(gbUser);              //@6
            array.Add(id);                  //@7

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        public void Eliminar(ArrayList list)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql;
            foreach (int id in list)
            {
                sql = "DELETE FROM insumos_caracteristicas_rel WHERE id=@1";
                
                //Agregamos en la Lista los parametros
                array.Add(id);

                exeSQLQuery.SQLQueryParameter_Execute(array, sql);
            }
        }
        #endregion
    }
}
