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
    public class CD_Proveedores
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //metodo que me permite agregar un producto a la base de datos
        public void AgregarProveedor(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("AgregarProveedor", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@codigo", Proveedores.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@nombre", Proveedores.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@rnc_proveedor", Proveedores.Rnc_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@direccion", Proveedores.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@telefono", Proveedores.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@email", Proveedores.Email));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite editar un producto en la base de datos
        public void EditarProveedor(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("EditarProveedor", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@codigo", Proveedores.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@nombre", Proveedores.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@rnc_proveedor", Proveedores.Rnc_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@direccion", Proveedores.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@telefono", Proveedores.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@email", Proveedores.Email));
            Cmd.Parameters.Add(new SqlParameter("@id_proveedor", Proveedores.Id_Proveedor));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite Elininar un producto en la base de datos
        public void EliminarProveedor(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("EliminarProveedor", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@id_proveedor", Proveedores.Id_Proveedor));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }
        //metodo que permite Buscar un proveedor por el codigo
        public DataTable Buscar_Proveedor_Codigo(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("codigo");
            Cmd = new SqlCommand("Buscar_Proveedor_Codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
        //metodo que permite Buscar un proveedor por el nombre
        public DataTable Buscar_Proveedor_Nombre(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("nombre");
            Cmd = new SqlCommand("Buscar_Proveedor_Nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        //metodo que permite Buscar un proveedor por rnc_proveedor
        public DataTable Buscar_Proveedor_Rnc_Proveedor(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("rnc_proveedor");
            Cmd = new SqlCommand("Buscar_Proveedor_Rnc_Proveedor", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
