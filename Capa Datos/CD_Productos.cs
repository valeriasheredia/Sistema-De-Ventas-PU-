using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;
using System.Windows.Forms;

namespace Capa_Datos
{
    public class CD_Productos
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //metodo que me permite agregar un producto a la base de datos
        public void AgregarProducto(CE_Productos Productos)
        {
            Cmd = new SqlCommand("AgregarProducto", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@codigo", Productos.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@nombre", Productos.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@descripcion", Productos.Descripcion));
            Cmd.Parameters.Add(new SqlParameter("@presentacion", Productos.Presentacion));
            Cmd.Parameters.Add(new SqlParameter("@costo_unitario", Productos.Costo_unitario));
            Cmd.Parameters.Add(new SqlParameter("@precio_venta", Productos.Precio_Venta));
            Cmd.Parameters.Add(new SqlParameter("@tipo_cargo", Productos.Tipo_Cargo));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite editar un producto en la base de datos
        public void EditarProducto(CE_Productos Productos)
        {
            Cmd = new SqlCommand("EditarProducto", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@codigo", Productos.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@nombre", Productos.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@descripcion", Productos.Descripcion));
            Cmd.Parameters.Add(new SqlParameter("@presentacion", Productos.Presentacion));
            Cmd.Parameters.Add(new SqlParameter("@costo_unitario", Productos.Costo_unitario));
            Cmd.Parameters.Add(new SqlParameter("@precio_venta", Productos.Precio_Venta));
            Cmd.Parameters.Add(new SqlParameter("@tipo_cargo", Productos.Tipo_Cargo));
            Cmd.Parameters.Add(new SqlParameter("@id_producto", Productos.Id_Producto));
            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        //metodo que me permite Elininar un producto en la base de datos
        public void EliminarProducto(CE_Productos Productos)
        {
            int Existencia = 0;
            Cmd = new SqlCommand("Select cantidad From Inventario Where id_inventario= " + Productos.Id_Producto + "", Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                Existencia = Convert.ToInt32(Dr["cantidad"].ToString());
            }
            Dr.Close();
            if (Existencia != 0)
            {
                MessageBox.Show("El producto contiene existencia, no puede ser eliminado", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Cmd = new SqlCommand("EliminarProducto", Con.Abrir());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@id_producto", Productos.Id_Producto));
                Cmd.ExecuteNonQuery();
                MessageBox.Show("El producto fue eliminado correctamente", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Con.Cerrar();
            }
        }
        //metodo que permite Buscar un producto por el codigo
        public DataTable Buscar_Producto_Codigo(CE_Productos Productos)
        {
            Dt = new DataTable("codigo");
            Cmd = new SqlCommand("Buscar_Producto_Codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;          
        }
        //metodo que permite Buscar un producto por el nombre
        public DataTable Buscar_Producto_Nombre(CE_Productos Productos)
        {
            Dt = new DataTable("nombre");
            Cmd = new SqlCommand("Buscar_Producto_Nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        //metodo que permite Buscar un producto por el descripcion
        public DataTable Buscar_Producto_Descripcion(CE_Productos Productos)
        {
            Dt = new DataTable("descripcion");
            Cmd = new SqlCommand("Buscar_Producto_Descripcion", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
