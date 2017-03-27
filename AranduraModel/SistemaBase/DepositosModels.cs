using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel.SistemaBase
{
    public class DepositosModels
    {
        DataTable dt = new DataTable();
        public DataTable dataTable
        {
            get { return dt; }
            set { dt = value; }
        }
        /// <summary>
        ///Se obtienen todos los Depositos
        /// </summary>
        public void GetDepositos()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("select id, codigo, descripcion, direccion from depositos order by descripcion");
        }
    }
}
