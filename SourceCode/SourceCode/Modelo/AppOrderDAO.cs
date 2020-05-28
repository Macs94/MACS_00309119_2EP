using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode.Modelo
{
    public class AppOrderDAO
    {
        public static List<AppOrder> getLista()
        {
            string query = $"select ao.\"idOrder\", ao.\"createDate\", pr.\"name\", au.\"fullname\", ad.\"address\""+
                           $" from \"AppOrder\" ao, \"Product\" pr, \"AppUser\" au, \"Address\" ad"+
                           $" where ao.\"idProduct\"= pr.\"idProduct\" and ao.\"idAddress\" = ad.\"idAddress\""+
                           $" and ad.\"idUser\"= au.\"idUser\"";
                

            DataTable dt = ConnectionBD.ExecuteQuery(query);

            List<AppOrder> lista = new List<AppOrder>();
            foreach (DataRow row in dt.Rows)
            {
                AppOrder o = new AppOrder();
                lista.Add(o);
            }
            return lista;
        }
        public static List<AppOrder> getListaUser(int userId)
        {
            string sql = String.Format(
                $"select ao.\"idOrder\", ao.\"createDate\", pr.\"name\", au.\"fullname\", ad.\"address\"" +
                $" from \"AppOrder\" ao, \"Product\" pr, \"AppUser\" au, \"Address\" ad" +
                $" where ao.\"idProduct\"= pr.\"idProduct\" and ao.\"idAddress\" = ad.\"idAddress\"" +
                " and ad.\"idUser\"= au.\"idUser\"and au.\"idUser\"={0};",
                userId);

            DataTable dt = ConnectionBD.ExecuteQuery(sql);

            List<AppOrder> lista = new List<AppOrder>();
            foreach (DataRow row in dt.Rows)
            {
                AppOrder o = new AppOrder();
                o.idOrder = Convert.ToInt32(row[0].ToString());
                o.createDate = DateTime.Parse(row[1].ToString());
                o.idAddress = Convert.ToInt32(row[2].ToString());
                o.idProduct = Convert.ToInt32(row[3].ToString());
                

                lista.Add(o);
            }

            return lista;
        }

        public static void addOrder( AppOrder o)
        {
            string act = String.Format(
                "insert into \"AppOrder\"" + 
                "(\"createDate\", \"idProduct\", \"idAddress\")" +
                "values ('{0}', {1}, {2});",
                o.createDate, o.idProduct, o.idAddress);
                
            ConnectionBD.ExecuteNonQuery(act);
        }
        
        public static void removeOrder(int idOrder)
        {
            string act = String.Format(
                "delete from \"AppOrder\" where \"idOrder\"={0};",
                idOrder);
            
            ConnectionBD.ExecuteNonQuery(act);
        }
    }
}