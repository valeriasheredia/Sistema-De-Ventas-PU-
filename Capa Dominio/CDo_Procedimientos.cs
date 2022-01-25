using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Capa_Datos;

namespace Capa_Dominio
{
    public class CDo_Procedimientos
    {
        CD_Procedimientos ObjProcedimiento = new CD_Procedimientos();

        //metodo que me permite cargar los datos de una tabla a un datagridview
        public DataTable CargarDatos(string Tabla)
        {
            return ObjProcedimiento.CargarDatos(Tabla);
        }

        //metodo que me permite alternar los colores en las filas de un datagridview
        public void AlternarColorFilaDataGridView(DataGridView Dgv)
        {
            ObjProcedimiento.AlternarColorFilaDataGridView(Dgv);
        }

        //metodo que me permite generar codigo automaticamente
        public string GenerarCodigo(string Tabla)
        {
            return ObjProcedimiento.GenerarCodigo(Tabla);
        }

        //metodo que me permite generar id automaticamente
        public string GenerarCodigoId(string Tabla)
        {
            return ObjProcedimiento.GenerarCodigoId(Tabla);
        }

        //metodo que permite dar formato moneda a un textbox o caja de texto
        public void FormatoMoneda(TextBox xTBox)
        {
            ObjProcedimiento.FormatoMoneda(xTBox);
        }

        //metodo que permite limpiar controles
        public void LimpiarControles(Form xForm)
        {
            ObjProcedimiento.LimpiarControles(xForm);
        }

        //metodo que permite llenar combobox
        public void LlenarCombobox(string Tabla, string nombre, ComboBox xCBox)
        {
            ObjProcedimiento.LlenarCombobox(Tabla, nombre, xCBox);
        }
    }
}
