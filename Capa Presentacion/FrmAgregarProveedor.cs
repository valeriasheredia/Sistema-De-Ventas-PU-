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
    public partial class FrmAgregarProveedor : FormBase
    {
        public FrmAgregarProveedor(FrmProveedores Proveedores)
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

        protected void Agregar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void FrmAgregarProveedor_Load(object sender, EventArgs e)
        {
            GenerarCodigo();
        }

        private void GenerarCodigo()
        {
            txtCodigo.Text = "PROV" + Procedimientos.GenerarCodigo("Proveedores");
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)){
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
                btnGuardar.Focus();
                e.Handled = true;
            }
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
                    mtxtTelefono.Text == string.Empty || txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos: ", "Agregar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    Proveedor.Codigo = txtCodigo.Text.Trim();
                    Proveedor.Nombre = txtNombre.Text.Trim();
                    Proveedor.Rnc_Proveedor = txtRnc.Text.Trim();
                    Proveedor.Direccion = txtDireccion.Text.Trim();
                    Proveedor.Telefono = mtxtTelefono.Text.Trim();
                    Proveedor.Email = txtEmail.Text.Trim();

                    Proveedores.AgregarProveedor(Proveedor);
                    MessageBox.Show("El Proveedor fue agregado correctamente", "Agregar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("El Proveedor no fue agregado por: " + ex.Message, "Agregar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
