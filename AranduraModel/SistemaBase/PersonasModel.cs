using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel.SistemaBase
{
    public class PersonasModel
    {
        DataTable dt = new DataTable();
        public DataTable dataTable
        {
            get { return dt; }
            set { dt = value; }
        }

        public DataTable tableWhere
        {
            get { return dt; }
            set { dt = value; }
        }
        /// <summary>
        ///Se obtienen todos los usuarios 
        /// </summary>
        public void GetPersonas()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("select id, apellido, nombre from personas order by nombre");
        }

        /// <summary>
        /// Se obtiene la descripcion de la persona
        /// </summary>
        /// <param name="id_persona"></param>
        public void GetPersona_Nombre(string id_persona)
        {
            ArrayList array = new ArrayList();
            array.Add(id_persona);
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            string sql = "Select concat(apellido,', ',nombre) apellido_nombre From personas Where id =@1";
            dt = get_DT.loadDataTable(sql, array);
        }
    }
}
