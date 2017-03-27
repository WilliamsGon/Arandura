using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel.SistemaBase
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
            dt = get_DT.loadDataTable("select u.id, u.user, u.password, u.create_time, u.id_persona,"
                                    + "u.id_empresa, u.id_grupos_usuarios, u.estado from usuarios u");
        }
        #region ABM
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="id_empresa"></param>
        /// <param name="id_persona"></param>
        /// <param name="id_grupos_usuarios"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int InsertUser(string user, string pass, int id_empresa, int id_persona, int id_grupos_usuarios, string estado)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "INSERT INTO usuarios (user,password,create_time,id_empresa,id_persona,id_grupos_usuarios,estado)"
                       + "VALUES(@1,@2,sysdate(),@3,@4,@5,@6); SELECT id FROM usuarios WHERE id=Last_Insert_ID()";

            //Agregamos en la Lista los parametros
            array.Add(user);
            array.Add(pass);
            array.Add(id_empresa);
            array.Add(id_persona);
            array.Add(id_grupos_usuarios);
            array.Add(estado);

            int id = Convert.ToInt32(exeSQLQuery.SQLQueryParameter_ReturnScalar(array, sql));
            return id;

        }

        /// <summary>
        /// Se actualiza el usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="id_empresa"></param>
        /// <param name="id_persona"></param>
        /// <param name="id_grupos_usuarios"></param>
        /// <param name="estado"></param>
        public void UpdateUser(string user, string pass, int id_empresa, int id_persona, int id_grupos_usuarios, string estado, int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "UPDATE usuarios SET user=@1,password=@2,id_empresa=@3,id_persona=@4,id_grupos_usuarios=@5,estado=@6 WHERE id=@7";

            //Agregamos en la Lista los parametros
            array.Add(user);
            array.Add(pass);
            array.Add(id_empresa);
            array.Add(id_persona);
            array.Add(id_grupos_usuarios);
            array.Add(estado);
            array.Add(id);

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }

        /// <summary>
        /// Borramos el usuario
        /// </summary>
        /// <param name="id_user"></param>
        public void DeleteUser(int id)
        {
            ArrayList array = new ArrayList();
            DataAccessLayer.exeSQLQuery exeSQLQuery = new DataAccessLayer.exeSQLQuery();
            string sql = "DELETE FROM usuarios WHERE id=@1";
            
            //Agregamos en la Lista los parametros
            array.Add(id);

            exeSQLQuery.SQLQueryParameter_Execute(array, sql);
        }
        #endregion
    }
}
