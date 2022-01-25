﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class CE_Proveedores
    {
        private int _Id_Proveedor;
        private string _Codigo;
        private string _Nombre;
        private string _Rnc_Proveedor;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Buscar;

        public int Id_Proveedor { get => _Id_Proveedor; set => _Id_Proveedor = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Rnc_Proveedor { get => _Rnc_Proveedor; set => _Rnc_Proveedor = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
    }
}
