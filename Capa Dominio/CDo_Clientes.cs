using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
using System.Data;

namespace Capa_Dominio
{
   public class CDo_Clientes
    {
        CD_Clientes ObjCliente = new CD_Clientes();

        //metodo que permite agregar un Cliente a la base de datos
        public void AgregarCliente(CE_Clientes Clientes)
        {
            ObjCliente.AgregarCliente(Clientes);
        }

        //metodo que permite editar un Cliente en la base de datos
        public void EditarCliente(CE_Clientes Clientes)
        {
            ObjCliente.EditarCliente(Clientes);
        }

        //metodo que permite eliminar un Cliente de la base de datos
        public void EliminarCliente(CE_Clientes Clientes)
        {
            ObjCliente.EliminarCliente(Clientes);
        }

        //metodo que permite buscar un Cliente por el codigo
        public DataTable Buscar_Cliente_Codigo(CE_Clientes Clientes)
        {
            return ObjCliente.Buscar_Cliente_Codigo(Clientes);
        }

        //metodo que permite buscar un Cliente por el nombre
        public DataTable Buscar_Cliente_Nombre(CE_Clientes Clientes)
        {
            return ObjCliente.Buscar_Cliente_Nombre(Clientes);
        }

        //metodo que permite buscar un Cliente por Rnc_Cliente
        public DataTable Buscar_Cliente_Rnc_Cliente(CE_Clientes Clientes)
        {
            return ObjCliente.Buscar_Cliente_Rnc_Cliente(Clientes);
        }
    }
}
