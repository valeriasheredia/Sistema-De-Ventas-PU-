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
    public partial class FrmClientes : FormBase
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Clientes Clientes = new CDo_Clientes();
        CE_Clientes Cliente = new CE_Clientes();

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dataGridView1.Columns[0].Visible = false; //id cliente

            dataGridView1.Columns[1].Width = 140; //codigo cliente
            dataGridView1.Columns[2].Width = 280; //nombre cliente
            dataGridView1.Columns[3].Width = 150; //rnc cliente
            dataGridView1.Columns[4].Width = 350; //direccion cliente
            dataGridView1.Columns[5].Width = 150; //telefono cliente
            dataGridView1.Columns[6].Width = 240; //email cliente
            dataGridView1.Columns[7].Width = 150; //estado cliente

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Procedimientos.AlternarColorFilaDataGridView(dataGridView1);
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Clientes"); //nombre de la tabla
            dataGridView1.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente AgregarCliente = new FrmAgregarCliente(this);
            AgregarCliente.UpdateEventHandler += AgCli_UpdateEventHandler;
            AgregarCliente.ShowDialog();
        }

        private void AgCli_UpdateEventHandler(object sender, FrmAgregarCliente.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void EdCli_UpdateEventHandler(object sender, FrmEditarCliente.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        public override void Eliminar()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para eliminar", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        DialogResult Resultados = MessageBox.Show("Está seguro que desea eliminar este registro?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Cliente.Id_Cliente = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Clientes.EliminarCliente(Cliente);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe seleccionar un registro para eliminar", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Cliente.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Clientes.Buscar_Cliente_Codigo(Cliente);
                }
                else if (cboTipoBusqueda.Text == "Nombre")
                {
                    Cliente.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Clientes.Buscar_Cliente_Nombre(Cliente);
                }
                else if (cboTipoBusqueda.Text == "Rnc_Cliente")
                {
                    Cliente.Buscar = txtBuscar.Text.Trim();
                    dataGridView1.DataSource = Clientes.Buscar_Cliente_Rnc_Cliente(Cliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Cliente no fue encontrado por: " + ex.Message, "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para editar", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        FrmEditarCliente EditarCliente = new FrmEditarCliente(this);
                        EditarCliente.UpdateEventHandler += EdCli_UpdateEventHandler;
                        EditarCliente.txtIdCliente.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        EditarCliente.txtCodigo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        EditarCliente.txtNombre.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        EditarCliente.txtRnc.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                        EditarCliente.txtDireccion.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        EditarCliente.mtxtTelefono.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                        EditarCliente.txtEmail.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                        EditarCliente.cboEstado.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                        EditarCliente.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe seleccionar un registro por favor", "Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

           }
}
