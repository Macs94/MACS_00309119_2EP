using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode.Vista
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
            if (user.admin)
            {
                actualizarControlesAdmin();
                actualizarTablasAdmin();
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[4].Parent = null;
            }
            else
            {
                actualizarControlesCommon();
                actualizarTablasCommon();
                tabControl1.TabPages[0].Parent = null;
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[2].Parent = null;
                tabControl1.TabPages[1].Parent = null;

            }
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

                MessageBox.Show($"Usuario agregado exitosamente (contraseña provisional: {u.username})", 
                    "HugoApp - Food Delivery",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la vista, los eventos se pueden invocar desde codigo
                btnClearUser_Click(sender, e);

                // Actualizar la vista, los ComboBox de la primer pestana
                actualizarControlesAdmin();
                actualizarTablasAdmin();
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
            try
            {
               
                AppUserDAO.removeUser((int) cmbUserId.SelectedValue);
                MessageBox.Show("Usuario eliminado exitosamente", "HugoApp - Food Delivery",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarControlesAdmin();
                actualizarTablasAdmin();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarControlesAdmin()
        {
            // Realizar consulta a la base de datos
            List<AppUser> listaU = AppUserDAO.getLista();

            cmbUserId.DataSource = null;
            cmbUserId.ValueMember = "id_User";
            cmbUserId.DisplayMember = "id_User";
            
            cmbUserId.DataSource = listaU;
            
            List<Business> listaB = BusinessDAO.getLista();
            cmbBusinessiD.DataSource = null;
            cmbBusinessiD.DisplayMember = "idBusiness";
            cmbBusinessiD.ValueMember = "idBusiness";
            cmbBusinessiD.DataSource = listaB;

            List<Product> listaP = ProductDAO.getLista();
            cmbProductId.DataSource = null;
            cmbProductId.DisplayMember = "idProduct";
            cmbProductId.ValueMember = "idProduct";
            cmbProductId.DataSource = listaP;
            
        }

        private void actualizarControlesCommon()
        {
            List<Address> listaA = AddressDAO.getLista(user.id_User);
            cmbAddressId.DataSource = null;
            cmbAddressId.DisplayMember = "idAddress";
            cmbAddressId.ValueMember = "idAddress";
            cmbAddressId.DataSource = listaA;

            cmbAiD.DataSource = null;
            cmbAiD.DisplayMember = "idAddress";
            cmbAiD.ValueMember = "idAddress";
            cmbAiD.DataSource = listaA;

            List < Business > listaB= BusinessDAO.getLista();
            cmbBiD2.DataSource = null;
            cmbBiD2.DisplayMember = "idBusiness";
            cmbBiD2.ValueMember = "idBusiness";
            cmbBiD2.DataSource = listaB;
            
            List<Product> listaP = ProductDAO.getLista();
            
            cmbPiD.DataSource = null;
            cmbPiD.DisplayMember = "idProduct";
            cmbPiD.ValueMember = "idProduct";
            cmbPiD.DataSource = listaP;
            
            
        }
        private void actualizarTablasAdmin()
        {
            
            dGUser.DataSource = null;
            dGUser.DataSource = AppUserDAO.getLista();

            dGBusiness.DataSource = null;
            dGBusiness.DataSource = BusinessDAO.getLista();

            dGProduct.DataSource = null;
            dGProduct.DataSource = ProductDAO.getLista();

            dGTotalOrders.DataSource = null;
            dGTotalOrders.DataSource = AppOrderDAO.getLista();


        }
        
        private void actualizarTablasCommon()
        {
            dGAdress.DataSource = null;
            dGAdress.DataSource = AddressDAO.getLista(user.id_User);

            dGUserOrders.DataSource = null;
            dGUserOrders.DataSource = AppOrderDAO.getListaUser(user.id_User);
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            
            Address a = new Address();
            a.idUser = user.id_User;
            a.address = textBox4.Text;
           
            try
            {
                AddressDAO.addAddress(a);

                MessageBox.Show($"Dirección agregada exitosamente!", 
                    "HugoApp - Food Delivery",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                btnClearAddress_Click(sender, e);

                
                actualizarControlesCommon();
                actualizarTablasCommon();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearAddress_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void btnEliminarAddress_Click(object sender, EventArgs e)
        {
            try
            {
               
                AddressDAO.removeAddress((int) cmbAddressId.SelectedValue);
                MessageBox.Show("Dirección eliminado exitosamente", "HugoApp - Food Delivery",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarControlesAdmin();
                actualizarTablasAdmin();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Business b = new Business();
            b.name = textBox3.Text;
            b.description = textBox5.Text;
            
            try
            {
                BusinessDAO.addBusiness(b);

                MessageBox.Show($"Negocio agregado exitosamente.)", 
                    "HugoApp - Food Delivery",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                btnClearBusiness_Click(sender, e);

                // Actualizar la vista, los ComboBox de la primer pestana
                actualizarControlesAdmin();
                actualizarTablasAdmin();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearBusiness_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox5.Clear();
        }

        private void btnEliminarBusiness_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}