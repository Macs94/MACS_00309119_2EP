using System;
using System.Collections.Generic;
using System.Data;

namespace SourceCode.Modelo
{
    public class ProductDAO
    {
        public static List<Product> getLista(int idBusiness)
        {
            string query = String.Format("Select p.\"idProduct\", p.\"name\" from \"Product\" where \"idBusiness\"={0}"
                ,idBusiness);

            DataTable dt = ConnectionBD.ExecuteQuery(query);

            List<Product> lista = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                Product p = new Product();
                p.idProduct = Convert.ToInt32(row[0].ToString());
                p.idBusiness = Convert.ToInt32(row[1].ToString());
                p.name = row[2].ToString();
                
                

                lista.Add(p);
            }
            return lista;
        }

        public static void addProduct( Product p)
        {
            string act = String.Format(
                "insert into \"Product\"" + 
                "(\"idBusiness\", \"name\")" +
                "values ({0}, '{1}');",
                p.idBusiness, p.name);
                
            ConnectionBD.ExecuteNonQuery(act);
        }
        
        public static void eliminarProducto(int idProduct)
        {
            string act = String.Format(
                "delete from \"Product\" where \"idProduct\"={0};",
                idProduct);
            
            ConnectionBD.ExecuteNonQuery(act);
        }
    } 
    
}
