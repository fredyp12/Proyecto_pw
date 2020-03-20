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
        public void dtUpdate(string dat, string column, string table, string id)
        {
            query = "UPDATE " + table + " SET " + column + "= '" + dat + "' WHERE id=" + id;
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
    }
}