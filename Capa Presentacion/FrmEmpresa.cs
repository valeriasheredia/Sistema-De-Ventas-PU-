using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Dominio;
using Capa_Entidad;


namespace Capa_Presentacion
{
    public partial class FrmEmpresa : FormBase
    {
        public FrmEmpresa()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Empresa Empresas = new CDo_Empresa();
        CE_Empresa Empresa = new CE_Empresa();

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;//id
            dataGridView1.Columns[6].Visible = false;//logo

            dataGridView1.Columns[1].Width = 300; //nombre
            dataGridView1.Columns[2].Width = 150; //rnc
            dataGridView1.Columns[3].Width = 350; //direccion
            dataGridView1.Columns[4].Width = 150; //telefono
            dataGridView1.Columns[5].Width = 220; //email
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Empresas");
        }

        private void AgEmUpdateEventHandler(object sender, FrmAgregarEmpresa.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void EdEmUpdateEventHandler(object sender, FrmEditarEmpresa.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                ptbLogo.Image = Properties.Resources.empresa;
            }
            else
            {
                ptbLogo.BackgroundImage = null;
                byte[] i = (byte[])dataGridView1.SelectedRows[0].Cells[6].Value;
                MemoryStream ms = new MemoryStream(i);
                ptbLogo.Image = Image.FromStream(ms);
                ptbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        //en caso de haber varias empresas la imagen de cada empresa va a ir cambiando de acuerdo a cada registro
        //en el datagridview
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                ptbLogo.Image = Properties.Resources.empresa;
            }
            else
            {
                ptbLogo.BackgroundImage = null;
                byte[] i = (byte[])dataGridView1.SelectedRows[0].Cells[6].Value;
                MemoryStream ms = new MemoryStream(i);
                ptbLogo.Image = Image.FromStream(ms);
                ptbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarEmpresa AgregarEmpresa = new FrmAgregarEmpresa(this);
            AgregarEmpresa.UpdateEventHandler += AgEmUpdateEventHandler;
            AgregarEmpresa.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para editar", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        FrmEditarEmpresa EditarEmpresa = new FrmEditarEmpresa(this);
                        EditarEmpresa.UpdateEventHandler += EdEmUpdateEventHandler;
                        EditarEmpresa.txtIdEmpresa.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        EditarEmpresa.txtNombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        EditarEmpresa.txtRncEmpresa.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        EditarEmpresa.txtDireccion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                        EditarEmpresa.mtxtTelefono.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        EditarEmpresa.txtEmail.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                        ptbLogo.BackgroundImage = null;
                        byte[] i = (byte[])dataGridView1.SelectedRows[0].Cells[6].Value;
                        MemoryStream ms = new MemoryStream(i);
                        EditarEmpresa.ptbLogo.Image = Image.FromStream(ms);
                        ptbLogo.SizeMode = PictureBoxSizeMode.StretchImage;

                        EditarEmpresa.ShowDialog();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Debe seleccionar un registro por favor", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("No hay registros para eliminar", "Eliminar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        DialogResult Resultados = MessageBox.Show("Está seguro que desea eliminar este registro?", "Eliminar Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Empresa.Id_Empresa = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Empresas.EliminarEmpresa(Empresa);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe seleccionar un registro para eliminar", "Eliminar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

    }
}
