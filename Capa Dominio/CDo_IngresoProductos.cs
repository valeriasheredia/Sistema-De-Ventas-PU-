using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Dominio
{
  public class CDo_IngresoProductos
    {
        CD_Ingreso_Productos ObjIngresoProducto = new CD_Ingreso_Productos();

        public void AgregarIngreso(CE_Ingreso_Productos Ingresos)
        {
            ObjIngresoProducto.AgregarIngreso(Ingresos);
        }

        public void AnularIngreso(CE_Ingreso_Productos Ingresos)
        {
            ObjIngresoProducto.AnularIngreso(Ingresos);
        }

        public DataTable MostrarIngresoProductos()
        {
            return ObjIngresoProducto.MostrarIngresoProductos();
        }
    }
}
