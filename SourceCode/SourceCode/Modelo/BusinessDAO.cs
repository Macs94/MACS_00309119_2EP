using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode.Modelo
{
    public class BusinessDAO
    {
        public static List<Business> getLista()
        {
            string query = "Select * from \"Business\"";

            DataTable dt = ConnectionBD.ExecuteQuery(query);

            List<Business> lista = new List<Business>();
            foreach (DataRow row in dt.Rows)
            {
                Business b = new Business();
                b.idBusiness = Convert.ToInt32(row[0].ToString());
                b.name = row[1].ToString();
                b.description = row[2].ToString();
                
                

                lista.Add(b);
            }
            return lista;
        }

        public static void addBusiness( Business b)
        {
            string act = String.Format(
                "insert into \"Business\"" + 
                "(\"name\", \"description\")" +
                "values ('{0}', '{1}');",
                b.name, b.description);
                
            ConnectionBD.ExecuteNonQuery(act);
        }
        
        public static void removeBusiness(int idBusiness)
        {
            string act = String.Format(
                "delete from \"Business\" where \"idBusiness\"={0};",
                idBusiness);
            
            ConnectionBD.ExecuteNonQuery(act);
        }
    } 
    
}
