using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AranduraModel.SistemaBase
{
    public class UnidadMedidaModels
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
        /// Obtiene la lista completa de todas las Unidades de Medidas.
        /// </summary>
        public void getUnidadMedida()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id, codigo, descripcion, abreviatura "
                                    + "FROM unidad_medidas");
        }


        public void getConsultaUnidadMedida(int id)
        {
            ArrayList array = new ArrayList();
            array.Add(id);
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            string sql = "SELECT id, codigo, descripcion, initcap(abreviatura) abreviatura "
                       + "FROM unidad_medidas "
                       + "WHERE id=@1";
            dt = get_DT.loadDataTable(sql, array);
        }
    }
}
