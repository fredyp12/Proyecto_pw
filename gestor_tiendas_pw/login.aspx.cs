using gestor_tiendas_pw.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_tiendas_pw
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pass, radio= "";
            dto.Db baseDato = new Db();
            DataTable tabla = new DataTable();
            if (radioS.SelectedIndex == 0) radio = "administrador";
            else if (radioS.SelectedIndex == 1) radio = "empleado";
            tabla = baseDato.dtTable("SELECT * FROM "+radio+" WHERE \"user\"='" + txtUser.Text + "'");
            if(tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                pass = Convert.ToString(row["pass"]);
                if (pass == txtPass.Text)
                {
                    String nombre, id, user;
                    nombre = Convert.ToString(row["nombre"]);
                    id = Convert.ToString(row["id"]);
                    user = Convert.ToString(row["user"]);
                    Response.Redirect("homeAdmin.aspx?nombre=" + nombre + "&id=" + id + "&user=" + user + "&pass=" + pass);
                }
            }
        }
    }
}