using System;
using System.Windows.Forms;
using SourceCode.Controladores;
using SourceCode.Modelo;

namespace SourceCode.Vista
{
    public partial class frmModUsuario : Form
    {
        public frmModUsuario()
        {
            InitializeComponent();
        }

        private void frmModUsuario_Load(object sender, EventArgs e)
        {
            // Actualizar ComboBox
            cmbUser.DataSource = null;
            cmbUser.ValueMember = "password";
            cmbUser.DisplayMember = "id_User";
            cmbUser.DataSource = AppUserDAO.getLista();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            bool actualIgual = Encriptador.CompararMD5(txtOldPass.Text, cmbUser.SelectedValue.ToString());
            bool nuevaIgual = txtNewPass.Text.Equals(txtConfirmar.Text);
            bool nuevaValida = txtNewPass.Text.Length > 0;

            if (actualIgual && nuevaIgual && nuevaValida)
            {
                try
                {
                    AppUserDAO.actualizarContra(Convert.ToInt32(cmbUser.Text), Encriptador.CrearMD5(txtNewPass.Text));

                    MessageBox.Show("¡Contraseña actualizada exitosamente!",
                        "HugoApp - Food Delivery", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Contraseña no actualizada! Favor intente mas tarde.",
                        "Error dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("¡¡Favor verifique que los datos sean correctos!",
                    "Error dialog", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
