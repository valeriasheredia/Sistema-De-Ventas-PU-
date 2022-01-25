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
    public partial class FrmEditarProducto : FormBase
    {
        public FrmEditarProducto(FrmProductos Productos)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Productos Productos = new CDo_Productos();
        CE_Productos Producto = new CE_Productos();

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

        private void FrmEditarProductos_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtDescripcion.Focus();
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPresentacion.Focus();
                e.Handled = true;
            }
        }

        private void txtPresentacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCostoUnitario.Focus();
                e.Handled = true;
            }
        }

        private void txtCostoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPrecioVenta.Focus();
                e.Handled = true;
            }
        }

        private void txtCostoUnitario_Leave(object sender, EventArgs e)
        {
            Procedimientos.FormatoMoneda(txtCostoUnitario);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cboTipoCargo.Focus();
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            Procedimientos.FormatoMoneda(txtPrecioVenta);
        }

        private void cboTipoCargo_KeyPress(object sender, KeyPressEventArgs e)
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
                    txtDescripcion.Text == string.Empty || txtPresentacion.Text == string.Empty ||
                    txtCostoUnitario.Text == string.Empty || txtPrecioVenta.Text == string.Empty ||
                    cboTipoCargo.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos: ", "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    Producto.Id_Producto = Convert.ToInt32(txtIdProducto.Text.Trim());
                    Producto.Codigo = txtCodigo.Text.Trim();
                    Producto.Nombre = txtNombre.Text.Trim();
                    Producto.Descripcion = txtDescripcion.Text.Trim();
                    Producto.Presentacion = txtPresentacion.Text.Trim();
                    Producto.Costo_unitario = Convert.ToDecimal(txtCostoUnitario.Text.Trim());
                    Producto.Precio_Venta = Convert.ToDecimal(txtPrecioVenta.Text.Trim());
                    Producto.Tipo_Cargo = cboTipoCargo.Text.Trim();

                    Productos.EditarProducto(Producto);
                    MessageBox.Show("El producto fue editado correctamente", "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Producto no fue editado por: " + ex.Message, "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
