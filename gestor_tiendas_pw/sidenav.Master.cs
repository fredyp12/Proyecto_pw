using gestor_tiendas_pw.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_tiendas_pw
{
    public partial class sidenav : System.Web.UI.MasterPage
    {
        Admin ad = new Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            ad.getId = int.Parse(Request.QueryString.Get("id"));
            ad.getNombre = Request.Params.Get("nombre");
            ad.getuser = Request.Params.Get("user");
            ad.getPass = Request.Params.Get("pass");
            lblUser.Text = "Admin / " + ad.getNombre;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx?");
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            ad = Update_datos();
            Response.Redirect("homeAdmin.aspx?nombre=" + ad.getNombre + "&id=" + ""+ad.getId + "&user=" + ad.getuser + "&pass=" + ad.getPass);
        }

        protected void btn_empleado_Click(object sender, EventArgs e)
        {
            ad = Update_datos();
            Response.Redirect("adminEmpleados.aspx?nombre=" + ad.getNombre + "&id=" + ad.getId + "&user=" + ad.getuser + "&pass=" + ad.getPass);
        }

        protected void btn_tienda_Click(object sender, EventArgs e)
        {
            ad = Update_datos();
            Response.Redirect("adminTienda.aspx?nombre=" + ad.getNombre + "&id=" + ad.getId + "&user=" + ad.getuser + "&pass=" + ad.getPass);
        }
        protected void btn_inventario_Click(object sender, EventArgs e)
        {
            ad = Update_datos();
            Response.Redirect("adminInventario.aspx?nombre=" + ad.getNombre + "&id=" + ad.getId + "&user=" + ad.getuser + "&pass=" + ad.getPass);
        }
        public Admin Update_datos()
        {
            Admin aux = new Admin();
            Db baseDato = new Db();
            DataTable tabla = new DataTable();
            tabla = baseDato.dtTable("SELECT * FROM administrador WHERE \"id\"='" + ad.getId + "'");
            DataRow row = tabla.Rows[0];
            string id;
            aux.getPass = Convert.ToString(row["pass"]);
            aux.getNombre = Convert.ToString(row["nombre"]);
            id = Convert.ToString(row["id"]);
            aux.getId = int.Parse(id);
            aux.getuser = Convert.ToString(row["user"]);
            return aux;
        }
    }
}