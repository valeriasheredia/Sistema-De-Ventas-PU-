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
    public partial class FrmAnularIngresoProducto : FormBase
    {
        public FrmAnularIngresoProducto(FrmCompras Compras)
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

        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void FrmAnularIngresoProducto_Load(object sender, EventArgs e)
        {
            MostrarDetalleIngreso();
            MejorarVista();
            
            Procedimientos.FormatoMoneda(txtTotalPagar);
        }

        private void MejorarVista()
        {
            dataGridView1.Columns[0].Visible = false;//id detalle
            dataGridView1.Columns[1].Visible = false;//id ingreso
            dataGridView1.Columns[2].Visible = false;//id producto

            dataGridView1.Columns[3].Width = 300;//nombre
            dataGridView1.Columns[4].Width = 160;//cantidad
            dataGridView1.Columns[5].Width = 160;//costo unitario
            dataGridView1.Columns[6].Width = 160;//subtotal

            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "#,##0.00";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "#,##0.00";

            Procedimientos.AlternarColorFilaDataGridView(dataGridView1);
        }

        private void MostrarDetalleIngreso()
        {
            dataGridView1.DataSource = DetalleIngresos.MostrarDetalleIngreso(Convert.ToInt32(txtIdIngreso.Text));
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Editar();
        }

        public override void Editar()
        {

            try
            {
                if (txtIdIngreso.Text == string.Empty ||
                    txtNroIngreso.Text == string.Empty ||
                    txtIdProveedor.Text == string.Empty ||
                    txtNombreProveedor.Text == string.Empty ||
                    txtComprobante.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos por favor: ", "Anular Ingreso Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                }
                else
                {
                    Ingreso.Id_Ingreso = Convert.ToInt32(txtIdIngreso.Text);
                    Ingreso.Nro_Ingreso = txtNroIngreso.Text;
                    Ingreso.Id_Proveedor = Convert.ToInt32(txtIdProveedor.Text);
                    Ingreso.Fecha_Ingreso = Convert.ToDateTime(dtpFechaIngreso.Text);
                    Ingreso.Comprobante = txtComprobante.Text;
                    Ingreso.Monto_Total = Convert.ToDecimal(txtTotalPagar.Text);
                    Ingreso.Estado = "Anulado";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DetalleIngreso.Id_Detalle = Convert.ToInt32(row.Cells[0].Value.ToString());
                        DetalleIngreso.Id_Ingreso = Convert.ToInt32(txtIdIngreso.Text);
                        DetalleIngreso.Id_Producto = Convert.ToInt32(row.Cells[2].Value.ToString());
                        DetalleIngreso.Cantidad = Convert.ToInt32(row.Cells[4].Value.ToString());
                        DetalleIngreso.Costo_Unitario = Convert.ToDecimal(row.Cells[5].Value.ToString());
                        DetalleIngreso.Sub_Total = Convert.ToDecimal(row.Cells[6].Value.ToString());

                        DetalleIngresos.AnularDetalleIngreso(DetalleIngreso);
                    }
                    Ingresos.AnularIngreso(Ingreso);

                    MessageBox.Show("Ingreso de productos anulado correctamente ", "Anular Ingreso Producto", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    this.Close();
                    Actualizar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("El ingreso del producto no fue anulado por: " + ex.Message, "Anular Ingreso Producto", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
        }
    }
}
