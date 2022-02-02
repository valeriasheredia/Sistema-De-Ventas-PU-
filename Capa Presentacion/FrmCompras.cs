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
    public partial class FrmCompras : FormBase
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_IngresoProductos IngresoProductos = new CDo_IngresoProductos();
        CE_Ingreso_Productos IngresoProducto = new CE_Ingreso_Productos();


        private void FrmCompras_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;//id ingreso

            dataGridView1.Columns[1].Width = 160;//nro de ingreso
            dataGridView1.Columns[2].Width = 370;//nombre proveedor
            dataGridView1.Columns[3].Width = 180; //fecha
            dataGridView1.Columns[4].Width = 200;//comprobante
            dataGridView1.Columns[5].Width = 180;//monto total
            dataGridView1.Columns[6].Width = 180;//estado

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "#,##0.00";

            Procedimientos.AlternarColorFilaDataGridView(dataGridView1);
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = IngresoProductos.MostrarIngresoProductos();
            dataGridView1.ClearSelection();
        }

        private void AgIn_UpdateEventHandler(object sender, FrmAgregarIngresoProducto.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarIngresoProducto AgregarProducto = new FrmAgregarIngresoProducto(this);
            AgregarProducto.UpdateEventHandler += AgIn_UpdateEventHandler;
            AgregarProducto.ShowDialog();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            FrmAnularIngresoProducto AnularProducto = new FrmAnularIngresoProducto(this);
            AnularProducto.UpdateEventHandler += AnIn_UpdateEventHandler;
            AnularProducto.txtIdIngreso.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            AnularProducto.txtIdProveedor.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            AnularProducto.txtNroIngreso.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            AnularProducto.txtNombreProveedor.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            AnularProducto.dtpFechaIngreso.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            AnularProducto.txtComprobante.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            AnularProducto.txtTotalPagar.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            AnularProducto.ShowDialog();
        }

        private void AnIn_UpdateEventHandler(object sender, FrmAnularIngresoProducto.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    Informes.FrmMostrar_Ingreso_Productos Mostrar = new Informes.FrmMostrar_Ingreso_Productos();
                    Mostrar.Id_ingreso = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_ingreso"].Value.ToString());
                    Mostrar.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un registro por favor", "Ingreso Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
