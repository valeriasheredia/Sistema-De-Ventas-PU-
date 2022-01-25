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
    public class CDo_Empresa
    {
        CD_Empresa ObjEmpresa = new CD_Empresa();

        //metodo que permite agregar una empresa a la base de datos
        public void AgregarEmpresa(CE_Empresa Empresas)
        {
            ObjEmpresa.AgregarEmpresa(Empresas);
        }

        //metodo que permite editar una empresa en la base de datos
        public void EditarEmpresa(CE_Empresa Empresas)
        {
            ObjEmpresa.EditarEmpresa(Empresas);
        }

        //metodo que permite eliminar una empresa de la base de datos
        public void EliminarEmpresa(CE_Empresa Empresas)
        {
            ObjEmpresa.EliminarEmpresa(Empresas);
        }

       
    }
}
