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
   public class CDo_Detalle_Ingreso
    {
        CD_Detalle_Ingresos ObjDetalleIngreso = new CD_Detalle_Ingresos();

        public void AgregarDetalleIngreso(CE_Detalle_Ingresos Detalles)
        {
            ObjDetalleIngreso.AgregarDetalleIngreso(Detalles);
        }

        public void AnularDetalleIngreso(CE_Detalle_Ingresos Detalles)
        {
            ObjDetalleIngreso.AnularDetalleIngreso(Detalles);
        }

        public DataTable MostrarDetalleIngreso(int id_ingreso)
        {
           
            return ObjDetalleIngreso.MostrarDetalleIngreso(id_ingreso);
        }
    }
}
