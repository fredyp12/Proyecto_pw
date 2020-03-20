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
    public partial class adminTienda : System.Web.UI.Page
    {
        Db baseDatos = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            txt_nombre.Text = "";
            txt_direccion.Text = "";
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_nombre.Text = grid_tienda.SelectedRow.Cells[1].Text;
            txt_direccion.Text = grid_tienda.SelectedRow.Cells[2].Text;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if(txt_nombre.Text!="" && txt_direccion.Text!= "")
            {
                baseDatos.add_tienda(txt_nombre.Text, txt_direccion.Text);
                grid_tienda.DataBind();
                clear();
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "" && txt_direccion.Text != "")
            {
                DataTable tabla = new DataTable();
                tabla = baseDatos.dtTable("SELECT * FROM tienda WHERE nombre= '"+txt_nombre.Text+"'");
                if (tabla.Rows.Count > 0)
                {
                    baseDatos.dtUpdate_tienda("direccion", txt_direccion.Text, txt_nombre.Text);
                    grid_tienda.DataBind();
                    clear();
                }
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "" && txt_direccion.Text != "")
            {
                baseDatos.delete_tienda(txt_nombre.Text);
                grid_tienda.DataBind();
                clear();
            }
        }
    }
}