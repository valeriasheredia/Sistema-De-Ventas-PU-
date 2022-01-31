using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion.Informes
{
    public partial class FrmMostrar_Ingreso_Producto : Form
    {
        public FrmMostrar_Ingreso_Producto()
        {
            InitializeComponent();
        }

        private int Id_Ingreso;

        public int Id_Ingreso1 { get => Id_Ingreso; set => Id_Ingreso = value; }

        private void FrmMostrar_Ingreso_Producto_Load(object sender, EventArgs e)
        {
            this.crystalReportViewer1.RefreshReport();
        }
    }
}
