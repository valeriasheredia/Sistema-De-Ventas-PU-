using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Dominio;
using Capa_Entidad;


namespace Capa_Presentacion
{
    public partial class FrmEditarCliente : FormBase
    {
        public FrmEditarCliente(FrmClientes Clientes)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Clientes Clientes = new CDo_Clientes();
        CE_Clientes Cliente = new CE_Clientes();

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void FrmEditarCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtRnc.Focus();
                e.Handled = true;
            }
        }

        private void txtRnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtDireccion.Focus();
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                mtxtTelefono.Focus();
                e.Handled = true;
            }
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtEmail.Focus();
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cboEstado.Focus();
                e.Handled = true;
            }
        }

        private void cboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnEditar.Focus();
                e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        public override void Editar()
        {
            try
            {
                if (txtCodigo.Text == string.Empty || txtNombre.Text == string.Empty ||
                    txtRnc.Text == string.Empty || txtDireccion.Text == string.Empty ||
                    mtxtTelefono.Text == string.Empty || txtEmail.Text == string.Empty ||
                    cboEstado.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos: ", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    Cliente.Id_Cliente = Convert.ToInt32(txtIdCliente.Text.Trim());
                    Cliente.Codigo = txtCodigo.Text.Trim();
                    Cliente.Nombre = txtNombre.Text.Trim();
                    Cliente.Rnc_Cliente = txtRnc.Text.Trim();
                    Cliente.Direccion = txtDireccion.Text.Trim();
                    Cliente.Telefono = mtxtTelefono.Text.Trim();
                    Cliente.Email = txtEmail.Text.Trim();
                    Cliente.Estado = cboEstado.Text.Trim();

                    Clientes.EditarCliente(Cliente);
                    MessageBox.Show("El Cliente fue editado correctamente", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Actualizar();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Cliente no fue editado por: " + ex.Message, "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
