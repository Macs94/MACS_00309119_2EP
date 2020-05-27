using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Controladores;

namespace SourceCode.Modelo
{
    public  class AppUserDAO
    {
        public static List<AppUser> getLista()
        {
            string query = "select * from AppUser";

            DataTable dt = ConnectionBD.ExecuteQuery(query);

            List<AppUser> lista = new List<AppUser>();
            foreach (DataRow row in dt.Rows)
            {
                 AppUser u = new AppUser();
                 u.admin = Convert.ToBoolean(row[0].ToString());
                 u.id_User = Convert.ToInt32(row[1].ToString());
                 u.fullname = row[2].ToString();
                 u.username = row[3].ToString();
                 u.password = row[4].ToString();
                

                lista.Add(u);
            }
            return lista;
        }

        public static void actualizarContra(string username, string newPassword)
        {
            string act = String.Format(
                "update AppUser set password='{0}' where idUser='{1}';",
                newPassword, username);
            
            ConnectionBD.ExecuteNonQuery(act);
        }

        public static void agregarUsuario( AppUser u)
        {
            u.password = Encriptador.CrearMD5(u.username);
            string act = String.Format(
                "insert into \"AppUser\"" + 
                "(\"admin\", \"fullname\", \"username\", \"password\")" +
                "values ('{0}', '{1}', '{2}', '{3}');",
                u.admin, u.fullname, u.username, u.password);
                
            ConnectionBD.ExecuteNonQuery(act);
        }
        
        public static void eliminar(string username)
        {
            string act = String.Format(
                "delete from AppUser where idUser='{0}';",
                username);
            
            ConnectionBD.ExecuteNonQuery(act);
        }
    }
    
}