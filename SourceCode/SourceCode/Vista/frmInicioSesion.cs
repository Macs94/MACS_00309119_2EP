using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceCode.Controladores;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }
        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            poblarControles();
        }
        private void poblarControles()
        {
            // Actualizar ComboBox
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "password";
            cmbUsuario.DisplayMember = "username";
            cmbUsuario.DataSource = AppUserDAO.getLista();
        }

        private void btnModUsuario_Click(object sender, EventArgs e)
        {
            frmModUsuario unaVentana = new frmModUsuario();
            unaVentana.ShowDialog();
            poblarControles();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (Encriptador.CompararMD5(txtPassword.Text, cmbUsuario.SelectedValue.ToString()))
            {
                AppUser u = (AppUser) cmbUsuario.SelectedItem;
                
                MessageBox.Show("¡Bienvenido!", 
                    "HugoApp - Food delivery", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                frmPrincipal ventana = new frmPrincipal(u);
                ventana.Owner = this;
                this.Hide();
                ventana.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("¡Contraseña incorrecta!", "Error dialog", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

  
    }
}