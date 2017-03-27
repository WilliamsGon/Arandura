using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace AranduraModel
{
    public class AutorizacionModel
    {
        DataTable dt = new DataTable();
        public DataTable dataTable
        {
            get { return dt; }
            set { dt = value; }
        }

        public void LogIn(string user, string password)
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            ArrayList array = new ArrayList();
            array.Add(user);
            array.Add(password);
            
            // Ejecutamos la consulta
            string sql = "Select * from usuarios u where u.user=@1 and u.password =@2";
            dt = get_DT.loadDataTable(sql, array);

            // Definimos las variables Globales
            Globales.gbUsuario = user;
            //Globales.gbEmpresa = 1;
            //Globales.gbSucursal = 1;
        }


        public void getModulos()
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            string sql = "SELECT * FROM modulos m where m.activo='S'";
            dt = get_DT.loadDataTable(sql);
        }



        public void GetVentanas(string admin, string modulo)
        {
            DataAccessLayer.exeDataTable get_DT = new DataAccessLayer.exeDataTable();
            ArrayList array = new ArrayList();
            array.Add(admin);
            array.Add(modulo);
            
            string sql = "Select v.id, v.descripcion, initcap(v.nombre) nombre, v.img from  ventanas v, usuarios u, permisos p, rel_modulos_ventanas r, modulos m " +
                         "where r.id_ventanas = v.id and r.id = p.id_rel_modulos_ventanas and u.user =@1 and u.id_grupos_usuarios = p.id_grupos_usuarios and m.id = r.id_modulos and m.descripcion =@2 and p.activo = 'S'";

            dt = get_DT.loadDataTable(sql, array);
      
            //dt = get_DT.loadDataTable("Select v.descripcion from  ventanas v, usuarios u, permisos p, rel_modulos_ventanas r where r.id_ventanas = v.id and r.id = p.id_rel_modulos_ventanas and u.user ="admin "and u.id_grupos_usuarios = p.id_grupos_usuarios");
        }
    }
}
