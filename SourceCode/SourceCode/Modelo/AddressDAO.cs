using System;
using System.Collections.Generic;
using System.Data;
using SourceCode.Controladores;

namespace SourceCode.Modelo
{
    public class AddressDAO
    {

        public static List<Address> getLista(int idUser)
        {
            string query = String.Format("Select ad.\"idAddress\", ad.\"address\" from \"Address\" ad  where \"idUser\"={0}",
                idUser);
     

            DataTable dt = ConnectionBD.ExecuteQuery(query);

            List<Address> lista = new List<Address>();
            foreach (DataRow row in dt.Rows)
            {
                Address a = new Address();
                a.idAddress = Convert.ToInt32(row[0].ToString());
                a.idUser = Convert.ToInt32(row[1].ToString());
                a.address = row[2].ToString();
                
                

                lista.Add(a);
            }
            return lista;
        }

        public static void addAddress(Address a)
        {
            string act = String.Format(
                "insert into \"Address\"" + 
                "(\"idUser\", \"address\")" +
                "values ({0}, '{1}');",
                a.idUser, a.address);

            ConnectionBD.ExecuteNonQuery(act);
        }
        
        public static void removeAddress(int idAddress)
        {
            string act = String.Format(
                "delete from \"Address\" where \"idAdress\"={0};",
                idAddress);
            
            ConnectionBD.ExecuteNonQuery(act);
        }
    } 
}
