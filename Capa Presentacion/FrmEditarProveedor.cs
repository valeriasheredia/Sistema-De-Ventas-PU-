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
    public partial class FrmEditarProveedor : FormBase
    {
        public FrmEditarProveedor(FrmProveedores Proveedores)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Proveedores Proveedores = new CDo_Proveedores();
        CE_Proveedores Proveedor = new CE_Proveedores();

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


        private void FrmEditarProveedor_Load(object sender, EventArgs e)
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
                    mtxtTelefono.Text == string.Empty || txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos: ", "Agregar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Proveedor.Id_Proveedor = Convert.ToInt32(txtIdProveedor.Text.Trim());
                    Proveedor.Codigo = txtCodigo.Text.Trim();
                    Proveedor.Nombre = txtNombre.Text.Trim();
                    Proveedor.Rnc_Proveedor = txtRnc.Text.Trim();
                    Proveedor.Direccion = txtDireccion.Text.Trim();
                    Proveedor.Telefono = mtxtTelefono.Text.Trim();
                    Proveedor.Email = txtEmail.Text.Trim();

                    Proveedores.EditarProveedor(Proveedor);
                    MessageBox.Show("El Proveedor fue editado correctamente", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Proveedor no fue editado por: " + ex.Message, "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
