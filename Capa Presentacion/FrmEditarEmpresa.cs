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
    public partial class FrmEditarEmpresa : FormBase
    {
        public FrmEditarEmpresa(FrmEmpresa Empresa)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Empresa Empresas = new CDo_Empresa();
        CE_Empresa Empresa = new CE_Empresa();
        OpenFileDialog examinar = new OpenFileDialog();

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

        private void FrmEditarEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarLogo_Click(object sender, EventArgs e)
        {
            examinar.Filter = "image files|*.jpg;*.png;*.gif;*.ico;.*;";
            DialogResult Dres = examinar.ShowDialog();
            if (Dres == DialogResult.Abort)
                return;
            if (Dres == DialogResult.Cancel)
                return;
            txtExaminar.Text = examinar.FileName;
            ptbLogo.Image = Image.FromFile(examinar.FileName);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtRncEmpresa.Focus();
                e.Handled = true;
            }
        }

        private void txtRncEmpresa_KeyPress(object sender, KeyPressEventArgs e)
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
                btnBuscarLogo.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarLogo_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtNombre.Text == string.Empty ||
                    txtRncEmpresa.Text == string.Empty ||
                    txtDireccion.Text == string.Empty ||
                    mtxtTelefono.Text == string.Empty ||
                    txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos: ", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    Empresa.Id_Empresa =Convert.ToInt32(txtIdEmpresa.Text.Trim());
                    Empresa.Nombre = txtNombre.Text.Trim();
                    Empresa.Rnc_Empresa = txtRncEmpresa.Text.Trim();
                    Empresa.Direccion = txtDireccion.Text.Trim();
                    Empresa.Telefono = mtxtTelefono.Text.Trim();

                    MemoryStream ms = new MemoryStream();
                    this.ptbLogo.Image.Save(ms, this.ptbLogo.Image.RawFormat);
                    Empresa.Logo = ms.GetBuffer();

                    Empresa.Email = txtEmail.Text.Trim();

                    Empresas.EditarEmpresa(Empresa);
                    MessageBox.Show("La Empresa fue editada correctamente", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualizar();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La empresa no fue editada por: " + ex.Message, "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
