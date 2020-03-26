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
    public partial class homeEmpleado : System.Web.UI.Page
    {
        Empleado em = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            em.getId = int.Parse(Request.QueryString.Get("id"));
            em.getNombre = Request.Params.Get("nombre");
            em.getuser = Request.Params.Get("user");
            em.getPass = Request.Params.Get("pass");
            em.getTienda = Request.Params.Get("tienda");
            lblBienvenido.Text = em.getNombre;
            lbl_id.Text = em.getId + "";
            lbl_name.Text = em.getNombre;
            lbl_user.Text = em.getuser;
            Db dataBase = new Db();
            DataTable tabla = new DataTable();
            tabla=dataBase.dtTable("SELECT * FROM tienda WHERE id=" + em.getId);
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                lbl_tienda.Text = Convert.ToString(row["nombre"]);
            }
        }

        protected void btn_mostrar_Click(object sender, EventArgs e)
        {
            txt_nombre.Style.Add("display", "block");
            txt_pass.Style.Add("display", "block");
            txt_passCopy.Style.Add("display", "block");
            lbl_nombreU.Style.Add("display", "block");
            lbl_passU.Style.Add("display", "block");
            lbl_passCopyU.Style.Add("display", "block");
            btn_update.Style.Add("display", "block");
            txt_nombre.Text = em.getNombre;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            Db dataBase = new Db();
            if (txt_nombre.Text != em.getNombre)
            {
                dataBase.dtUpdate("'"+txt_nombre.Text+"'", "nombre", "empleado", Convert.ToString(em.getId));
                if(dataBase.dat_exist("select * from venta where empleado= '" + em.getNombre + "'") == true)
                {
                    dataBase.dtUpdate_dat("'" + txt_nombre.Text + "'", "empleado", "venta", "empleado='" + em.getNombre+"'");
                }
                em.getNombre = txt_nombre.Text;
                lbl_name.Text = em.getNombre;
                lblBienvenido.Text = em.getNombre;
            }
            if (txt_pass.Text != "")
            {
                if (txt_pass.Text == txt_passCopy.Text)
                    dataBase.dtUpdate("'"+txt_pass.Text+"'", "pass", "empleado", Convert.ToString(em.getId));
            }
            txt_pass.Text = "";
            txt_passCopy.Text = "";
        }
    }
}