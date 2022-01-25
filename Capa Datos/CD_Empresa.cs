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
    public class CD_Empresa
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //metodo que me permite agregar una empresa a la base de datos
        public void AgregarEmpresa(CE_Empresa Empresa)
        {
            Cmd = new SqlCommand("AgregarEmpresa", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@nombre", Empresa.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@rnc_empresa", Empresa.Rnc_Empresa));
            Cmd.Parameters.Add(new SqlParameter("@direccion", Empresa.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@telefono", Empresa.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@email", Empresa.Email));
            Cmd.Parameters.Add(new SqlParameter("@logo", Empresa.Logo));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite editar una empresa en la base de datos
        public void EditarEmpresa(CE_Empresa Empresa)
        {
            Cmd = new SqlCommand("EditarEmpresa", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@id_empresa", Empresa.Id_Empresa));
            Cmd.Parameters.Add(new SqlParameter("@nombre", Empresa.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@rnc_empresa", Empresa.Rnc_Empresa));
            Cmd.Parameters.Add(new SqlParameter("@direccion", Empresa.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@telefono", Empresa.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@email", Empresa.Email));
            Cmd.Parameters.Add(new SqlParameter("@logo", Empresa.Logo));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite Eliminar una empresa de la base de datos
        public void EliminarEmpresa(CE_Empresa Empresa)
        {
            Cmd = new SqlCommand("EliminarEmpresa", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@id_empresa", Empresa.Id_Empresa));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }
   }
}
