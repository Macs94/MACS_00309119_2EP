namespace SourceCode.Modelo
{
    public class AppUser
    {
        public int id_User { get; set; }
        
        public string fullname { get; set; }

        public string username { get; set; }
                
        public string password { get; set; }
        
        public bool admin { get; set; }

        public AppUser(int idUser, string fullname, string username, string password, bool admin)
        {
            id_User = idUser;
            this.fullname = fullname;
            this.username = username;
            this.password = password;
            this.admin = admin;
        }


        public AppUser()
        {
        }
    }
}