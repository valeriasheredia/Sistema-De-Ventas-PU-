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
    public partial class FrmMostrar_Ingreso_Productos : Form
    {
        public FrmMostrar_Ingreso_Productos()
        {
            InitializeComponent();
        }

        public int Id_ingreso;

        private void FrmMostrar_Ingreso_Productos_Load(object sender, EventArgs e)
        {
            MostrarIngresoProducto objReporte = new MostrarIngresoProducto();
            objReporte.SetParameterValue("@id_ingreso", Id_ingreso);
            crystalReportViewer1.ReportSource = objReporte;
        }
    }
}
