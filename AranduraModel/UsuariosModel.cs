using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
namespace AranduraModel
{
    public class UsuariosModel
    {
        DataTable dt = new DataTable();
        public DataTable dataTable
        {
            get { return dt; }
            set { dt = value; }
        }

        /// <summary>
        ///Se obtienen todos los usuarios 
        /// </summary>
        public void GetUsuarios()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            dt = get_DT.loadDataTable("SELECT id_user,nombre,apellido FROM usuarios");
        }

        /// <summary>
        /// se inserta un nuevo usuario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public int InsertUser(string nombre, string apellido)
        {
            ArrayList array = new ArrayList();
            array.Add(nombre);
            array.Add(apellido);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO arandura.usuarios (nombre,apellido) VALUES(@1,@2); SELECT id_user FROM arandura.usuarios WHERE id_user=Last_Insert_ID()";

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;

        }
        
        /// <summary>
        /// se Actualiza un usuario
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="id_user"></param>
        public void UpdateUser(string nombre, string apellido, int id_user)
        {
            ArrayList array = new ArrayList();
            array.Add(nombre);
            array.Add(apellido);
            array.Add(id_user);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE arandura.usuarios SET nombre=@1,apellido=@2 where id_user=@3";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        /// <summary>
        /// Borramos el usuario
        /// </summary>
        /// <param name="id_user"></param>
        public void DeleteUser(int id_user)
        {
            ArrayList array = new ArrayList();
            array.Add(id_user);
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM arandura.usuarios WHERE id_user=@1";
            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }
    }
}
