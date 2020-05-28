namespace SourceCode.Modelo
{
    public class Address
    {
        public  int idAddress { get; set; }
        public  int idUser { get; set; }
        public  string address { get; set; }

        public Address()
        {
        }

        public Address(int idAddress, int idUser, string address)
        {
            this.idAddress = idAddress;
            this.idUser = idUser;
            this.address = address;
        }
    }
}