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
   public class CD_Ingreso_Productos
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;

        public void AgregarIngreso(CE_Ingreso_Productos Ingresos)
        {
            Cmd = new SqlCommand("Agregar_Ingreso_Productos", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            // Cmd.Parameters.Add(new SqlParameter("@id_ingreso", Ingresos.Id_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@nro_ingreso", Ingresos.Nro_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@id_proveedor", Ingresos.Id_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@fecha_ingreso", Ingresos.Fecha_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@comprobante", Ingresos.Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@monto_total", Ingresos.Monto_Total));
            Cmd.Parameters.Add(new SqlParameter("@estado", Ingresos.Estado));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void AnularIngreso(CE_Ingreso_Productos Ingresos)
        {
            Cmd = new SqlCommand("Anular_Ingreso_Productos", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
             Cmd.Parameters.Add(new SqlParameter("@id_ingreso", Ingresos.Id_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@nro_ingreso", Ingresos.Nro_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@id_proveedor", Ingresos.Id_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@fecha_ingreso", Ingresos.Fecha_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@comprobante", Ingresos.Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@monto_total", Ingresos.Monto_Total));
            Cmd.Parameters.Add(new SqlParameter("@estado", Ingresos.Estado));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public DataTable MostrarIngresoProductos()
        {
            DataTable Dt = new DataTable("Ingreso_Productos");
            Cmd = new SqlCommand("Mostrar_Ingreso", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Con.Cerrar();
            Dr.Close();
            return Dt;
            
        }
    }
}
