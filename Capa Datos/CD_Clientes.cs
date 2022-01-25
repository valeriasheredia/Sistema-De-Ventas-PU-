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
   public class CD_Clientes
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //metodo que me permite agregar un cliente a la base de datos
        public void AgregarCliente(CE_Clientes Clientes)
        {
            Cmd = new SqlCommand("AgregarCliente", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@codigo", Clientes.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@nombre", Clientes.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@rnc_cliente", Clientes.Rnc_Cliente));
            Cmd.Parameters.Add(new SqlParameter("@direccion", Clientes.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@telefono", Clientes.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@email", Clientes.Email));
            Cmd.Parameters.Add(new SqlParameter("@estado", Clientes.Estado));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite editar un Cliente en la base de datos
        public void EditarCliente(CE_Clientes Clientes)
        {
            Cmd = new SqlCommand("EditarCliente", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@codigo", Clientes.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@nombre", Clientes.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@rnc_cliente", Clientes.Rnc_Cliente));
            Cmd.Parameters.Add(new SqlParameter("@direccion", Clientes.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@telefono", Clientes.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@email", Clientes.Email));
            Cmd.Parameters.Add(new SqlParameter("@estado", Clientes.Estado));
            Cmd.Parameters.Add(new SqlParameter("@id_cliente", Clientes.Id_Cliente));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite Elininar un Cliente en la base de datos
        public void EliminarCliente(CE_Clientes Clientes)
        {
            Cmd = new SqlCommand("EliminarCliente", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@id_cliente", Clientes.Id_Cliente));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }
        //metodo que permite Buscar un cliente por el codigo
        public DataTable Buscar_Cliente_Codigo(CE_Clientes Clientes)
        {
            Dt = new DataTable("codigo");
            Cmd = new SqlCommand("Buscar_Cliente_Codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@buscar", Clientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
        //metodo que permite Buscar un cliente por el nombre
        public DataTable Buscar_Cliente_Nombre(CE_Clientes Clientes)
        {
            Dt = new DataTable("nombre");
            Cmd = new SqlCommand("Buscar_Cliente_Nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("buscar", Clientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        //metodo que permite Buscar un proveedor por rnc_cliente
        public DataTable Buscar_Cliente_Rnc_Cliente(CE_Clientes Clientes)
        {
            Dt = new DataTable("rnc_cliente");
            Cmd = new SqlCommand("Buscar_Cliente_Rnc_Cliente", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("buscar", Clientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
