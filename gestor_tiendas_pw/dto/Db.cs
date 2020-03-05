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
        string query;

        public Db() { }
        public DataTable dtTable(string dat) {
            query = dat;
            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection(conexionString);
            SqlCommand comando = new SqlCommand(query, conexion);
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(comando);
                adap.Fill(tabla);

            }
            catch(Exception ex)
            {

            }
            return tabla;
        }
        public void dtUpdate(string dat,string column,string table,string id)
        {
            query = "UPDATE "+table+" SET "+column+"= '"+dat+"' WHERE id="+id;
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
            
        }
    }
}