using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class frmPrincipal : Form
    {
        private AppUser user;
        public frmPrincipal(AppUser pUser)
        {
            InitializeComponent();
            user = pUser;
            DoubleBuffered = true;
            

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblSesión.Text =
                "Bienvenido " + user.username + " [" + (user.admin ? "Administrador" : "Usuario") + "]";
            

            
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicioSesion ventana = new frmInicioSesion();
            ventana.Owner = this;
            this.Hide();
            ventana.ShowDialog();
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Crear un cliente y llenar sus datos desde la vista
            AppUser u = new AppUser();
            u.fullname = textBox1.Text;
            u.username = textBox2.Text;
            u.admin = checkBox1.Checked;
            try
            {
                // Enviar a modelo, el se encargara de almacenarlo en la BDD
                AppUserDAO.addUser(u);

                MessageBox.Show("Usuario agregado exitosamente (contraseña provisional: 0000)", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la vista, los eventos se pueden invocar desde codigo
                btnClearUser_Click(sender, e);

                // Actualizar la vista, los ComboBox de la primer pestana
                actualizarControles();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearUser_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnEliminarUser_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void actualizarControles()
        {
            // Realizar consulta a la base de datos
            List<AppUser> listaU = AppUserDAO.getLista();

            cmbUserId.DataSource = null;
            cmbUserId.DisplayMember = "usuario";
            cmbUserId.DataSource = listaU;

            List<Address> listaI = AddressDAO.getLista();

            cmbAddressId.DataSource = null;
            cmbAddressId.DisplayMember = "idAdress";
            cmbAddressId.DataSource = listaI;

            comboBox3.DataSource = null;
            comboBox3.DisplayMember = "nombre";
            comboBox3.DataSource = listaI;

            actualizarControlesCommon();
        }
    }
}