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
  public class CDo_Proveedores
    {
        CD_Proveedores ObjProveedor = new CD_Proveedores();

        //metodo que permite agregar un proveedor a la base de datos
        public void AgregarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedor.AgregarProveedor(Proveedores);
        }

        //metodo que permite editar un proveedor en la base de datos
        public void EditarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedor.EditarProveedor(Proveedores);
        }

        //metodo que permite eliminar un proveedor de la base de datos
        public void EliminarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedor.EliminarProveedor(Proveedores);
        }

        //metodo que permite buscar un proveedor por el codigo
        public DataTable Buscar_Proveedor_Codigo(CE_Proveedores Proveedores)
        {
            return ObjProveedor.Buscar_Proveedor_Codigo(Proveedores);
        }

        //metodo que permite buscar un proveedor por el nombre
        public DataTable Buscar_Proveedor_Nombre(CE_Proveedores Proveedores)
        {
            return ObjProveedor.Buscar_Proveedor_Nombre(Proveedores);
        }

        //metodo que permite buscar un proveedor por Rnc_Proveedor
        public DataTable Buscar_Proveedor_Rnc_Proveedor(CE_Proveedores Proveedores)
        {
            return ObjProveedor.Buscar_Proveedor_Rnc_Proveedor(Proveedores);
        }
    }
}
