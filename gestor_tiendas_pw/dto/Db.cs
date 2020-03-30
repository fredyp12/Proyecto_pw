using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace gestor_tiendas_pw.dto
{
    public class Db
    {
        string conexionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Desktop\\trabajos\\programacion_web\\gestor_tiendas_pw\\gestor_tiendas_pw\\App_Data\\bdd.mdf;Integrated Security=True";
        string query = "SELECT * FROM empleado  WHERE id=";

        public Db() { }
        public DataTable dtTable(string dat)
        {
            query = dat;
            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection(conexionString);
            SqlCommand comando = new SqlCommand(query, conexion);
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(comando);
                adap.Fill(tabla);

            }
            catch (Exception ex)
            {

            }
            return tabla;
        }
        public void dtUpdate_dat(string dat, string column, string table, string dat_where)
        {
            query = "UPDATE " + table + " SET " + column + "= " + dat + " WHERE " + dat_where;
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();

        }
        public void dtUpdate(string dat, string column, string table, string id)
        {
            query = "UPDATE " + table + " SET " + column + "= " + dat + " WHERE id=" + id;
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();

        }
        public void dtUpdate_tienda(string column, string dat,   string nombre)
        {
            query = "UPDATE tienda SET " + column + "= '"+ dat +"' WHERE nombre= '"+ nombre+"'";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();

        }
        public string add_tienda(string nombre, string direccion)
        {
            string respuesta;
            DataTable tabla = new DataTable();
            tabla = dtTable("SELECT * FROM tienda WHERE nombre ='"+nombre+"'");
            if (tabla.Rows.Count > 0) return respuesta = "existe";
            else
            {
                query = "insert into tienda (nombre, direccion) values ('"+nombre+"' , '"+direccion+"')";
                SqlConnection conexion = new SqlConnection(conexionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();
                respuesta = "TIENDA CREADA";
            }
            return respuesta;
        }

        public string add_emp(string id, string nombre, string user, string pass, string tienda)
        {
            string respuesta;
            DataTable tabla = new DataTable();
            tabla = dtTable(query + id);
            if (tabla.Rows.Count > 0) return respuesta = "existe";
            else
            {
                tabla = dtTable("SELECT * FROM tienda  WHERE nombre='" + tienda + "'");
                if (tabla.Rows.Count <= 0) return respuesta = "no existe la tienda";
                else
                {
                    if (dat_exist("SELECT * FROM empleado WHERE \"user\" ='" + user + "'") == true) return respuesta = "Ya existe el usuario";
                    else
                    {
                        query = "insert into empleado (id, nombre, \"user\", pass, tienda) values (" + id + ",'" + nombre + "', '" + user + "', '" + pass + "', '" + tienda + "')";
                        SqlConnection conexion = new SqlConnection(conexionString);
                        conexion.Open();
                        SqlCommand comando = new SqlCommand(query, conexion);
                        comando.ExecuteNonQuery();
                    }

                }
            }
            return respuesta = "creado";
        }
        public void add_inventario(string nombre, string tienda, string cantidad) {
            DataTable tabla = new DataTable();
            query = "insert into inventario  values ('"+nombre+"', '"+tienda+"',"+cantidad+")";
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
        }
        public void add_producto(string nombre, string precio, string dat) {
            if(dat_exist("select * from producto where nombre= '" + nombre + "'")==false)
            {
                query = "insert into "+dat+"  values ('" + nombre + "',"+precio+")";
                SqlConnection conexion = new SqlConnection(conexionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
        }
        public void add_venta(string fecha,string producto, string empleado, string tienda, string cantidad)        {
            int cat = int.Parse(cantidad), precio=0, pre_cantidad=0, cantidad_tienda=0,total_venta=0, id_inventario=0;
            DataTable tabla = new DataTable();
            DataTable tabla2 = new DataTable();
            tabla = dtTable("select * from inventario where (producto='"+producto+"') and( tienda='"+tienda+"')");
            tabla2 = dtTable("select * from producto where nombre='" + producto + "'");
            DataRow row = tabla.Rows[0];
            DataRow row2 = tabla2.Rows[0];
            string string_cantidad = "", string_precio="", string_id="";
            string_cantidad= Convert.ToString(row["cantidad"]);
            string_precio= Convert.ToString(row2["precio"]);
            string_id = Convert.ToString(row["id"]);
            id_inventario = int.Parse(string_id);
            precio = int.Parse(string_precio);
            pre_cantidad = int.Parse(string_cantidad);
            if (cat < pre_cantidad)
            {
                cantidad_tienda = pre_cantidad - cat;
                total_venta = cat * precio;
                /*Insert*/
                query = "insert into venta values ('" + fecha + "','" + producto + "', '"+empleado+"', '"+tienda+"', "+cantidad+", "+total_venta+")";
                SqlConnection conexion = new SqlConnection(conexionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();
                /*Update*/
                dtUpdate(cantidad_tienda+"", "cantidad", "inventario",id_inventario+"");

            }

        }
        public void delete(string table, string id)
        {
            query = " DELETE FROM " + table + " WHERE " + "id= " + id;
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
        }
        public string delete_tienda(string nombre)
        {
            string respuesta="";
            DataTable tabla = new DataTable();
            tabla = dtTable("SELECT * FROM empleado WHERE tienda = '"+nombre+"'");
            if (tabla.Rows.Count > 0) return respuesta = "existe";
            else
            {
                query = " DELETE FROM tienda WHERE " + "nombre= '" + nombre + "'";
                SqlConnection conexion = new SqlConnection(conexionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();
                respuesta = "Eliminado";
            }
            return respuesta;
            
        }
        public bool dat_exist(string query)
        {
            bool dat;
            DataTable tabla = new DataTable();
            tabla = dtTable(query);
            if (tabla.Rows.Count > 0) dat = true;
            else dat = false;
            return dat;
        }

        public DataSet drop(string select)
        {
            query = select;
            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}