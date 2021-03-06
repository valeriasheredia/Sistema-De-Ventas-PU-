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
    public partial class FrmAgregarCliente : FormBase
    {
        public FrmAgregarCliente(FrmClientes Clientes)
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

        protected void Agregar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }


        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            GenerarCodigo();
        }

        private void GenerarCodigo()
        {
            txtCodigo.Text = "CLI" + Procedimientos.GenerarCodigo("Clientes");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public override bool Guardar()
        {
            try
            {
                if (txtCodigo.Text == string.Empty || txtNombre.Text == string.Empty ||
                    txtRnc.Text == string.Empty || txtDireccion.Text == string.Empty ||
                    mtxtTelefono.Text == string.Empty || txtEmail.Text == string.Empty ||
                    cboEstado.Text==string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos: ", "Agregar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    Cliente.Codigo = txtCodigo.Text.Trim();
                    Cliente.Nombre = txtNombre.Text.Trim();
                    Cliente.Rnc_Cliente = txtRnc.Text.Trim();
                    Cliente.Direccion = txtDireccion.Text.Trim();
                    Cliente.Telefono = mtxtTelefono.Text.Trim();
                    Cliente.Email = txtEmail.Text.Trim();
                    Cliente.Estado = cboEstado.Text.Trim();

                    Clientes.AgregarCliente(Cliente);
                    MessageBox.Show("El Cliente fue agregado correctamente", "Agregar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Procedimientos.LimpiarControles(this);
                    mtxtTelefono.Text = string.Empty;
                    GenerarCodigo();
                    txtNombre.Focus();
                    Agregar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Cliente no fue agregado por: " + ex.Message, "Agregar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
                btnGuardar.Focus();
                e.Handled = true;
            }
        }
    }
}
