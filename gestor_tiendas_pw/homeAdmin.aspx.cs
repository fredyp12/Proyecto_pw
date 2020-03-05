using gestor_tiendas_pw.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_tiendas_pw
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Admin ad = new Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            ad.getId = int.Parse(Request.QueryString.Get("id"));
            ad.getNombre = Request.Params.Get("nombre");
            ad.getuser = Request.Params.Get("user");
            ad.getPass = Request.Params.Get("pass");
            lblBienvenido.Text = ad.getNombre;
            lbl_id.Text = ad.getId + "";
            lbl_name.Text = ad.getNombre;
            lbl_user.Text = ad.getuser;
        }

        protected void btn_mostrar_Click(object sender, EventArgs e)
        {
            txt_nombre.Style.Add("display", "block");
            txt_pass.Style.Add("display", "block");
            txt_passCopy.Style.Add("display", "block");
            lbl_nombreU.Style.Add("display", "block");
            lbl_passU.Style.Add("display", "block");
            lbl_passCopyU.Style.Add("display", "block");
            txt_nombre.Text = ad.getNombre;
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            Db dataBase = new Db();   
            if(txt_nombre.Text!= ad.getNombre)
            {
                dataBase.dtUpdate(txt_nombre.Text, "nombre", "administrador", Convert.ToString(ad.getId));
                ad.getNombre = txt_nombre.Text;
                lbl_name.Text = ad.getNombre;
                lblBienvenido.Text = ad.getNombre;
            }
            if (txt_pass.Text != "")
            {
                if(txt_pass.Text==txt_passCopy.Text)
                    dataBase.dtUpdate(txt_pass.Text, "pass", "administrador", Convert.ToString(ad.getId));
            }
            txt_pass.Text = "";
            txt_passCopy.Text = "";
        }
        

    }
}