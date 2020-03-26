using gestor_tiendas_pw.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_tiendas_pw
{
    public partial class sideEmpleado : System.Web.UI.MasterPage
    {
        Empleado em = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            em.getId = int.Parse(Request.QueryString.Get("id"));
            em.getNombre = Request.Params.Get("nombre");
            em.getuser = Request.Params.Get("user");
            em.getPass = Request.Params.Get("pass");
            em.getTienda = Request.Params.Get("tienda");
            lblUser.Text = "Empleado / " + em.getNombre;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ventasEmpleado.aspx?nombre=" + em.getNombre + "&id=" + em.getId + "&user=" + em.getuser + "&tienda=" + em.getTienda);
        }

        protected void btn_close_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx?");
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("homeEmpleado.aspx?nombre=" + em.getNombre + "&id=" + em.getId + "&user=" + em.getuser + "&tienda=" + em.getTienda);
        }
    }
}