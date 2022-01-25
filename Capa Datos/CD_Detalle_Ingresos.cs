using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;

namespace Capa_Datos
{
   public class CD_Detalle_Ingresos
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;

        public void AgregarDetalleIngreso(CE_Detalle_Ingresos Detalles)
        {
            Cmd = new SqlCommand("Agregar_Detalle_Ingreso", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
             Cmd.Parameters.Add(new SqlParameter("@id_ingreso", Detalles.Id_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@id_producto", Detalles.Id_Producto));
            Cmd.Parameters.Add(new SqlParameter("@cantidad", Detalles.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@costo_unitario", Detalles.Costo_Unitario));
            Cmd.Parameters.Add(new SqlParameter("@sub_total", Detalles.Sub_Total));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void AnularDetalleIngreso(CE_Detalle_Ingresos Detalles)
        {
            Cmd = new SqlCommand("Anular_Detalle_Ingreso", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@id_detalle", Detalles.Id_Detalle));
            Cmd.Parameters.Add(new SqlParameter("@id_ingreso", Detalles.Id_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@id_producto", Detalles.Id_Producto));
            Cmd.Parameters.Add(new SqlParameter("@cantidad", Detalles.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@costo_unitario", Detalles.Costo_Unitario));
            Cmd.Parameters.Add(new SqlParameter("@sub_total", Detalles.Sub_Total));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public DataTable MostrarDetalleIngreso(int id_ingreso)
        {
            DataTable Dt = new DataTable("Detalle_Ingreso");
            Cmd = new SqlCommand("MostrarDetalleIngreso", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@id_ingreso",id_ingreso));
            Cmd.ExecuteNonQuery();

            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
