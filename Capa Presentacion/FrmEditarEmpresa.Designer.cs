
namespace Capa_Presentacion
{
    partial class FrmEditarEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtExaminar = new System.Windows.Forms.TextBox();
            this.btnBuscarLogo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.mtxtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRncEmpresa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdEmpresa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(489, 206);
            // 
            // txtExaminar
            // 
            this.txtExaminar.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExaminar.Location = new System.Drawing.Point(583, 166);
            this.txtExaminar.Multiline = true;
            this.txtExaminar.Name = "txtExaminar";
            this.txtExaminar.Size = new System.Drawing.Size(26, 25);
            this.txtExaminar.TabIndex = 48;
            this.txtExaminar.Visible = false;
            // 
            // btnBuscarLogo
            // 
            this.btnBuscarLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarLogo.BackColor = System.Drawing.Color.Azure;
            this.btnBuscarLogo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarLogo.Location = new System.Drawing.Point(511, 167);
            this.btnBuscarLogo.Name = "btnBuscarLogo";
            this.btnBuscarLogo.Size = new System.Drawing.Size(40, 24);
            this.btnBuscarLogo.TabIndex = 47;
            this.btnBuscarLogo.Text = "Logo";
            this.btnBuscarLogo.UseVisualStyleBackColor = false;
            this.btnBuscarLogo.Click += new System.EventHandler(this.btnBuscarLogo_Click);
            this.btnBuscarLogo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnBuscarLogo_KeyPress);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.BackColor = System.Drawing.Color.Azure;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(363, 206);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 30);
            this.btnEditar.TabIndex = 46;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // ptbLogo
            // 
            this.ptbLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbLogo.Image = global::Capa_Presentacion.Properties.Resources.empresa1;
            this.ptbLogo.Location = new System.Drawing.Point(451, 12);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(158, 149);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbLogo.TabIndex = 45;
            this.ptbLogo.TabStop = false;
            // 
            // mtxtTelefono
            // 
            this.mtxtTelefono.BackColor = System.Drawing.Color.PapayaWhip;
            this.mtxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtTelefono.Location = new System.Drawing.Point(21, 154);
            this.mtxtTelefono.Mask = "000-000-0000";
            this.mtxtTelefono.Name = "mtxtTelefono";
            this.mtxtTelefono.Size = new System.Drawing.Size(140, 24);
            this.mtxtTelefono.TabIndex = 44;
            this.mtxtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtTelefono_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(182, 156);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(257, 25);
            this.txtEmail.TabIndex = 43;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(179, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Teléfono";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(182, 92);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(257, 25);
            this.txtDireccion.TabIndex = 40;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(179, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Dirección";
            // 
            // txtRncEmpresa
            // 
            this.txtRncEmpresa.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtRncEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRncEmpresa.Location = new System.Drawing.Point(21, 92);
            this.txtRncEmpresa.Multiline = true;
            this.txtRncEmpresa.Name = "txtRncEmpresa";
            this.txtRncEmpresa.Size = new System.Drawing.Size(140, 25);
            this.txtRncEmpresa.TabIndex = 35;
            this.txtRncEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRncEmpresa_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Rnc";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(21, 30);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(418, 25);
            this.txtNombre.TabIndex = 37;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nombre";
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtIdEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEmpresa.Location = new System.Drawing.Point(414, 2);
            this.txtIdEmpresa.Multiline = true;
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(25, 25);
            this.txtIdEmpresa.TabIndex = 49;
            this.txtIdEmpresa.Visible = false;
            // 
            // FrmEditarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 248);
            this.Controls.Add(this.txtIdEmpresa);
            this.Controls.Add(this.txtExaminar);
            this.Controls.Add(this.btnBuscarLogo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.mtxtTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRncEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "FrmEditarEmpresa";
            this.Text = "Editar Empresa";
            this.Load += new System.EventHandler(this.FrmEditarEmpresa_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRncEmpresa, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDireccion, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.mtxtTelefono, 0);
            this.Controls.SetChildIndex(this.ptbLogo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnBuscarLogo, 0);
            this.Controls.SetChildIndex(this.txtExaminar, 0);
            this.Controls.SetChildIndex(this.txtIdEmpresa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtExaminar;
        public System.Windows.Forms.Button btnBuscarLogo;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.PictureBox ptbLogo;
        public System.Windows.Forms.MaskedTextBox mtxtTelefono;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtRncEmpresa;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtIdEmpresa;
    }
}