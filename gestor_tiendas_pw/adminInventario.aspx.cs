using gestor_tiendas_pw.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_tiendas_pw
{
    public partial class adminInventario : System.Web.UI.Page
    {
        Db baseDatos = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grid_inventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_producto.Text = grid_inventario.SelectedRow.Cells[2].Text;
            txt_cantidad.Text = grid_inventario.SelectedRow.Cells[4].Text;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if(txt_producto.Text!="" && txt_cantidad.Text != "")
            {
                if(baseDatos.dat_exist("SELECT * FROM producto where nombre= '" + txt_producto.Text + "'") == true)
                {
                    if (grid_inventario.SelectedRow != null)
                    {
                        if (grid_inventario.SelectedRow.Cells[2].Text != txt_producto.Text)
                        {
                            baseDatos.add_inventario(txt_producto.Text, drop_tienda.SelectedValue, txt_cantidad.Text);
                            grid_inventario.DataBind();
                        }
                    }
                    else
                    {
                        baseDatos.add_inventario(txt_producto.Text, drop_tienda.SelectedValue, txt_cantidad.Text);
                        grid_inventario.DataBind();
                    }
                }
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_producto.Text != "" && txt_cantidad.Text != "")
            {
                try
                {
                    baseDatos.dtUpdate("'" + txt_producto.Text + "'", "producto", "inventario", grid_inventario.SelectedRow.Cells[1].Text);
                    baseDatos.dtUpdate(txt_cantidad.Text, "cantidad", "inventario", grid_inventario.SelectedRow.Cells[1].Text);
                    grid_inventario.DataBind();
                }
                catch (Exception)
                {

                }
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_inventario.SelectedRow != null)
                {
                    baseDatos.delete("inventario", grid_inventario.SelectedRow.Cells[1].Text);
                    grid_inventario.DataBind();
                }
            }
            catch (Exception) { }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_nombre_p.Text = grid_producto.SelectedRow.Cells[2].Text;
            txt_precio.Text = grid_producto.SelectedRow.Cells[3].Text;
        }

        protected void btn_add_p_Click(object sender, EventArgs e)
        {
            if (txt_nombre_p.Text != "" && txt_precio.Text!="" ) {
                baseDatos.add_producto(txt_nombre_p.Text, txt_precio.Text,"producto");
                
                grid_producto.DataBind();
            }
        }

        protected void btn_update_p_Click(object sender, EventArgs e)
        {
            try {
                if (txt_nombre_p.Text != "") {
                    baseDatos.dtUpdate("'" + txt_nombre_p.Text + "'", "nombre", "producto", grid_producto.SelectedRow.Cells[1].Text);
                    grid_producto.DataBind();
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (txt_producto.Text != "")
                {
                    baseDatos.dtUpdate("" + txt_producto.Text + "", "precio", "producto", grid_producto.SelectedRow.Cells[1].Text);
                    grid_producto.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btn_delete_p_Click(object sender, EventArgs e)
        {
            if (txt_nombre_p.Text != "") {
                if (baseDatos.dat_exist("select * from inventario where producto= '" + txt_nombre_p.Text + "'")==false)
                {
                    try
                    {
                        baseDatos.delete("producto", grid_producto.SelectedRow.Cells[1].Text);
                        grid_producto.DataBind();
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}