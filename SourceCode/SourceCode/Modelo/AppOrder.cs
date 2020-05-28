using System;

namespace SourceCode.Modelo
{
    public class AppOrder
    {
        public int idOrder { get; set; }
        
        public DateTime createDate { get; set; }
        
        public int idAddress { get; set; }

        public int idProduct { get; set; }

        public AppOrder(int idOrder, DateTime date, int idAddress, int idProduct)
        {
            this.idOrder = idOrder;
            createDate = date;
            this.idAddress = idAddress;
            this.idProduct = idProduct;
        }

        public AppOrder()
        {
        }
    }
}