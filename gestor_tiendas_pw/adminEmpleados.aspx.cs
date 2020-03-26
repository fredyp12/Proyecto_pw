using gestor_tiendas_pw.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_tiendas_pw
{
    public partial class adminEmpleados : System.Web.UI.Page
    {
        Db baseDatos = new Db();
        protected void Page_Load(object sender, EventArgs e) {}
        public void actualizar()
        {
            grid_empleado.DataBind();
        }
        public void clear()
        {
            txt_id.Text = "";
            txt_nombre.Text = "";
            txt_usuario.Text = "";
            txt_pass.Text = "";
            txt_tienda.Text = "";
        }

        protected void grid_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_id.Text = grid_empleado.SelectedRow.Cells[1].Text;
            txt_nombre.Text = grid_empleado.SelectedRow.Cells[2].Text;
            txt_usuario.Text = grid_empleado.SelectedRow.Cells[3].Text;
            txt_pass.Text = grid_empleado.SelectedRow.Cells[4].Text;
            txt_tienda.Text = grid_empleado.SelectedRow.Cells[5].Text;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = baseDatos.add_emp(txt_id.Text,txt_nombre.Text, txt_usuario.Text, txt_pass.Text, txt_tienda.Text);
            actualizar();
            clear();
        }
        

        protected void btn_update_Click(object sender, EventArgs e)
        {
            baseDatos.dtUpdate("'"+txt_nombre.Text+"'", "nombre", "empleado", txt_id.Text);
            if(baseDatos.dat_exist("SELECT * FROM empleado  WHERE pass='"+txt_pass.Text+"'")==false)
                baseDatos.dtUpdate("'"+txt_pass.Text+"'", "pass", "empleado", txt_id.Text);

            if (baseDatos.dat_exist("SELECT * FROM tienda  WHERE nombre='" + txt_tienda.Text + "'") == true)
                baseDatos.dtUpdate("'"+txt_tienda.Text+"'", "tienda", "empleado", txt_id.Text);

            grid_empleado.DataBind();
            clear();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            baseDatos.delete("empleado", txt_id.Text);
            grid_empleado.DataBind();
            clear();
        }
    }
}