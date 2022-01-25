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
    public partial class FrmProductos : FormBase
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Productos Productos = new CDo_Productos();
        CE_Productos Producto = new CE_Productos();

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dataGridView1.Columns[0].Visible = false; //id producto

            dataGridView1.Columns[1].Width = 140; //codigo producto
            dataGridView1.Columns[2].Width = 260; //nombre producto
            dataGridView1.Columns[3].Width = 300; //descripcion producto
            dataGridView1.Columns[4].Width = 150; //presentacion producto
            dataGridView1.Columns[5].Width = 140; //costo unitario
            dataGridView1.Columns[6].Width = 140; //precio venta
            dataGridView1.Columns[7].Width = 150; //tipo de cargo

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "#,##0.00";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "#,##0.00";

            Procedimientos.AlternarColorFilaDataGridView(dataGridView1);
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Productos");
            dataGridView1.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto AgregarProducto = new FrmAgregarProducto(this);
            AgregarProducto.UpdateEventHandler += AgPro_UpdateEventHandler;
            AgregarProducto.ShowDialog();
        }

        private void AgPro_UpdateEventHandler(object sender, FrmAgregarProducto.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void EdPro_UpdateEventHandler(object sender, FrmEditarProducto.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para editar", "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (dataGridView1.SelectedRows == null)
                    {
                        return;
                    }
                    else
                    {
                        FrmEditarProducto EditarProductos = new FrmEditarProducto(this);
                        EditarProductos.UpdateEventHandler += EdPro_UpdateEventHandler;
                        EditarProductos.txtIdProducto.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        EditarProductos.txtCodigo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        EditarProductos.txtNombre.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        EditarProductos.txtDescripcion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                        EditarProductos.txtPresentacion.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        EditarProductos.txtCostoUnitario.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                        EditarProductos.txtPrecioVenta.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                        EditarProductos.cboTipoCargo.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                        EditarProductos.ShowDialog();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Debe seleccionar un registro por favor","Editar Producto",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        public override void Eliminar()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para eliminar", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (dataGridView1.SelectedRows == null)
                    {
                        return;
                    }
                    else
                    {
                        DialogResult Resultados = MessageBox.Show("Está seguro que desea eliminar este registro?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Producto.Id_Producto = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Productos.EliminarProducto(Producto);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Debe seleccionar un registro para eliminar", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        public override void Buscar()
        {
            try
            {
                if (cboTipoBusqueda.Text == "Código")
                {
                    Producto.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Productos.Buscar_Producto_Codigo(Producto);
                }
                else if (cboTipoBusqueda.Text == "Nombre")
                {
                    Producto.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Productos.Buscar_Producto_Nombre(Producto);
                }
                else if (cboTipoBusqueda.Text == "Descripción")
                {
                    Producto.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Productos.Buscar_Producto_Descripcion(Producto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El producto no fue encontrado por: "+ex.Message,"Buscar producto",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
    }
}
