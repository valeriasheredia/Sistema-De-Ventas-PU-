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
    public partial class FrmProveedores : FormBase
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Proveedores Proveedores = new CDo_Proveedores();
        CE_Proveedores Proveedor = new CE_Proveedores();

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dataGridView1.Columns[0].Visible = false; //id proveedor

            dataGridView1.Columns[1].Width = 140; //codigo proveedor
            dataGridView1.Columns[2].Width = 280; //nombre proveedor
            dataGridView1.Columns[3].Width = 150; //rnc proveedor
            dataGridView1.Columns[4].Width = 350; //direccion proveedor
            dataGridView1.Columns[5].Width = 150; //telefono proveedor
            dataGridView1.Columns[6].Width = 240; //email proveedor

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            Procedimientos.AlternarColorFilaDataGridView(dataGridView1);
        }
        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Proveedores"); //nombre de la tabla
            dataGridView1.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarProveedor AgregarProveedor = new FrmAgregarProveedor(this);
            AgregarProveedor.UpdateEventHandler += AgProv_UpdateEventHandler;
            AgregarProveedor.ShowDialog();
        }

        private void AgProv_UpdateEventHandler(object sender, FrmAgregarProveedor.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void EdProv_UpdateEventHandler(object sender, FrmEditarProveedor.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para editar", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        FrmEditarProveedor EditarProveedor = new FrmEditarProveedor(this);
                        EditarProveedor.UpdateEventHandler += EdProv_UpdateEventHandler;
                        EditarProveedor.txtIdProveedor.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        EditarProveedor.txtCodigo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        EditarProveedor.txtNombre.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        EditarProveedor.txtRnc.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                        EditarProveedor.txtDireccion.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        EditarProveedor.mtxtTelefono.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                        EditarProveedor.txtEmail.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                        EditarProveedor.ShowDialog();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Debe seleccionar un registro por favor", "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("No hay registros para eliminar", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        DialogResult Resultados = MessageBox.Show("Está seguro que desea eliminar este registro?", "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Proveedor.Id_Proveedor = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Proveedores.EliminarProveedor(Proveedor);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Debe seleccionar un registro para eliminar", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                    Proveedor.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Proveedores.Buscar_Proveedor_Codigo(Proveedor);
                }
                else if (cboTipoBusqueda.Text == "Nombre")
                {
                    Proveedor.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Proveedores.Buscar_Proveedor_Nombre(Proveedor);
                }
                else if (cboTipoBusqueda.Text == "Rnc_Proveedor")
                {
                    Proveedor.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Proveedores.Buscar_Proveedor_Rnc_Proveedor(Proveedor);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("El Proveedor no fue encontrado por: " + ex.Message, "Buscar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
    }
}
