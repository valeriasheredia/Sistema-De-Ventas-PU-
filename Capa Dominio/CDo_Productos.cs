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
   public class CDo_Productos
    {
        CD_Productos ObjProductos = new CD_Productos();

        //metodo que permite agregar un producto a la base de datos
        public void AgregarProducto(CE_Productos Productos)
        {
            ObjProductos.AgregarProducto(Productos);
        }

        //metodo que permite editar un producto en la base de datos
        public void EditarProducto(CE_Productos Productos)
        {
            ObjProductos.EditarProducto(Productos);
        }

        //metodo que permite eliminar un producto de la base de datos
        public void EliminarProducto(CE_Productos Productos)
        {
            ObjProductos.EliminarProducto(Productos);
        }

        //metodo que permite buscar un producto por el codigo
        public DataTable Buscar_Producto_Codigo(CE_Productos Productos)
        {
           return ObjProductos.Buscar_Producto_Codigo(Productos);
        }

        //metodo que permite buscar un producto por el nombre
        public DataTable Buscar_Producto_Nombre(CE_Productos Productos)
        {
          return  ObjProductos.Buscar_Producto_Nombre(Productos);
        }

        //metodo que permite buscar un producto por la descripcion
        public DataTable Buscar_Producto_Descripcion(CE_Productos Productos)
        {
           return ObjProductos.Buscar_Producto_Descripcion(Productos);
        }
    }
}
