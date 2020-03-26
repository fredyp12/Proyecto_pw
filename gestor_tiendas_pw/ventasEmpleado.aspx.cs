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
    public partial class ventasEmpleado : System.Web.UI.Page
    {
        Db baseDatos = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {            
            string nombre = Request.Params.Get("nombre");
            string tienda = Request.Params.Get("tienda");
            DataTable tabla = new DataTable();
            tabla = baseDatos.dtTable("select * from venta where empleado='"+nombre+"'");
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                grid_ventas.DataSource = tabla;
                grid_ventas.DataBind();
            }
            if (!IsPostBack)
            {
                llenarDrop("inventario",tienda, "producto", drop_inventario);
                llenarDrop("venta", tienda, "fecha", drop_date);

            }
        }

        protected void grid_ventas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void llenarDrop(string tabla, string tienda, string columna, DropDownList drop)
        {
            drop.DataSource = baseDatos.drop("select * from "+tabla+" where tienda='" + tienda + "'");
            drop.DataTextField = columna;
            drop.DataValueField = columna;
            drop.DataBind();
        }
    }
}
