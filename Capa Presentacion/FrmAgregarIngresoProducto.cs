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
    public partial class FrmAgregarIngresoProducto : FormBase
    {
        public FrmAgregarIngresoProducto(FrmCompras Compras)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_IngresoProductos Ingresos = new CDo_IngresoProductos();
        CE_Ingreso_Productos Ingreso = new CE_Ingreso_Productos();

        CDo_Detalle_Ingreso DetalleIngresos = new CDo_Detalle_Ingreso();
        CE_Detalle_Ingresos DetalleIngreso = new CE_Detalle_Ingresos();

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

        private void FrmAgregarIngresoProducto_Load(object sender, EventArgs e)
        {
            MejorarVista();
            txtTotalPagar.Text = "0.00";
            Correlativo();
        }

        private void MejorarVista()
        {
            dataGridView1.Columns[0].Visible = false;//id producto
            dataGridView1.Columns[1].Width = 300;//nombre
            dataGridView1.Columns[2].Width = 160;//cantidad
            dataGridView1.Columns[3].Width = 160;//costo unitario
            dataGridView1.Columns[4].Width = 160;//subtotal

            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Procedimientos.AlternarColorFilaDataGridView(dataGridView1);
        }

        private void Correlativo()
        {
            txtIdIngreso.Text = Procedimientos.GenerarCodigoId("Ingreso_Productos");
            txtNroIngreso.Text = "ING" + Procedimientos.GenerarCodigo("Ingreso_Productos");
            txtIdDetalle.Text = Procedimientos.GenerarCodigoId("Detalle_Ingreso");

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedores VistaProveedor = new FrmVistaProveedores();
            VistaProveedor.ShowDialog();

            try
            {
                if(VistaProveedor.DialogResult== DialogResult.OK)
                {
                    txtIdProveedor.Text = VistaProveedor.dataGridView1.Rows[VistaProveedor.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    txtNombreProveedor.Text = VistaProveedor.dataGridView1.Rows[VistaProveedor.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    txtComprobante.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Debe seleccionar un proveedor de la lista","Seleccionar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        public static int ContFila = 0;
        public static decimal Total;

        private void AgregarDetalle()
        {
            decimal Sub_Total = 0;

            try
            {
                if (txtxIdProducto.Text == string.Empty || txtNombreProveedor.Text == string.Empty ||
               txtCantidad.Text == string.Empty || txtCostoUnitario.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos del detalle ingreso", "Agregar Detalle Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    bool Existe = false;
                    int Nro_Fila = 0;

                    if (ContFila == 0)
                    {
                        Sub_Total = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtCostoUnitario.Text);
                        dataGridView1.Rows.Add(txtxIdProducto.Text, txtProducto.Text, txtCantidad.Text, txtCostoUnitario.Text, Sub_Total.ToString("N2"));
                        dataGridView1.ClearSelection();
                        LimpiarDetalle();
                        btnAgregarProducto.Focus();

                        ContFila++;
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == txtxIdProducto.Text)
                            {
                                Existe = true;
                                Nro_Fila = row.Index;
                            }
                        }
                        if (Existe == true)
                        {
                            Sub_Total = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtCostoUnitario.Text);
                            dataGridView1.Rows[Nro_Fila].Cells[2].Value = Convert.ToDouble(txtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[Nro_Fila].Cells[2].Value.ToString());
                            dataGridView1.Rows[Nro_Fila].Cells[4].Value = (Sub_Total + Convert.ToDecimal(dataGridView1.Rows[Nro_Fila].Cells[4].Value)).ToString("N2");
                            LimpiarDetalle();
                        }
                        else
                        {
                            Sub_Total = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtCostoUnitario.Text);
                            dataGridView1.Rows.Add(txtxIdProducto.Text, txtProducto.Text, txtCantidad.Text, txtCostoUnitario.Text, Sub_Total.ToString("N2"));
                            dataGridView1.ClearSelection();
                            LimpiarDetalle();
                            btnAgregarProducto.Focus();

                            ContFila++;
                        }
                        Total = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            Total += Convert.ToDecimal(row.Cells[4].Value);
                        }
                        txtTotalPagar.Text = Total.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("El producto no fue agregado por: "+ex.Message, "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

         private void LimpiarDetalle()
        {
            txtxIdProducto.Text = string.Empty;
            txtCodigoProducto.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCostoUnitario.Text = string.Empty;
            txtCodigoProducto.Focus();
        }

        private void LimpiarCampos()
        {
            txtIdIngreso.Text = string.Empty;
            txtNroIngreso.Text = string.Empty;
            txtIdProveedor.Text = string.Empty;
            txtNombreProveedor.Text = string.Empty;
            txtComprobante.Text = string.Empty;
            dataGridView1.Rows.Clear();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmVistaProducto VistaProducto = new FrmVistaProducto();
            VistaProducto.ShowDialog();

            try
            {
                if (VistaProducto.DialogResult == DialogResult.OK)
                {
                    txtxIdProducto.Text = VistaProducto.dataGridView1.Rows[VistaProducto.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    txtCodigoProducto.Text = VistaProducto.dataGridView1.Rows[VistaProducto.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    txtProducto.Text = VistaProducto.dataGridView1.Rows[VistaProducto.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    txtCostoUnitario.Text = VistaProducto.dataGridView1.Rows[VistaProducto.dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
                    txtCantidad.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Debe seleccionar un proveedor de la lista", "Seleccionar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ContFila > 0)
                {
                    Total = Total - Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
                    txtTotalPagar.Text = Total.ToString("N2");

                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    ContFila--;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay filas para eliminar", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
        }

        private void txtComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                btnBuscarProducto.Focus();
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnAgregarProducto.Focus();
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public override bool Guardar()
        {

            try
            {
                if (txtIdIngreso.Text==string.Empty||
                    txtNroIngreso.Text == string.Empty ||
                    txtIdProveedor.Text == string.Empty ||
                    txtNombreProveedor.Text == string.Empty ||
                    txtComprobante.Text == string.Empty )
                {
                    MessageBox.Show("Debe completar todos los campos por favor: ", "Agregar Ingreso Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                }
                else
                {
                    Ingreso.Nro_Ingreso = txtNroIngreso.Text;
                    Ingreso.Id_Proveedor = Convert.ToInt32(txtIdProveedor.Text);
                    Ingreso.Fecha_Ingreso =Convert.ToDateTime( dtpFechaIngreso.Text);
                    Ingreso.Comprobante = txtComprobante.Text;
                    Ingreso.Monto_Total = Convert.ToDecimal(txtTotalPagar.Text);
                    Ingreso.Estado = "Emitido";

                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        DetalleIngreso.Id_Ingreso = Convert.ToInt32(txtIdIngreso.Text);
                        DetalleIngreso.Id_Producto = Convert.ToInt32(row.Cells[0].Value.ToString());
                        DetalleIngreso.Cantidad = Convert.ToInt32(row.Cells[2].Value.ToString());
                        DetalleIngreso.Costo_Unitario = Convert.ToDecimal(row.Cells[3].Value.ToString());
                        DetalleIngreso.Sub_Total = Convert.ToDecimal(row.Cells[4].Value.ToString());

                        DetalleIngresos.AgregarDetalleIngreso(DetalleIngreso);
                    }
                    Ingresos.AgregarIngreso(Ingreso);

                    MessageBox.Show("Ingreso de productos agregado correctamente ", "Agregar Ingreso Producto", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    Procedimientos.LimpiarControles(this);
                    txtIdDetalle.Text = string.Empty;
                    txtTotalPagar.Text = "0.00";
                    Agregar();
                    LimpiarDetalle();
                    LimpiarCampos();
                    Correlativo();
                    return true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("El ingreso del producto no fue agregado por: " + ex.Message, "Agregar Ingreso Producto", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
           
            }
            return false;
        }
    }
}
