using gestor_tiendas_pw.dto;
using System;
using System.Collections;
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
        static string nombre, tienda;
        protected void Page_Load(object sender, EventArgs e)
        {            
            ventasEmpleado.nombre = Request.Params.Get("nombre");
            ventasEmpleado.tienda = Request.Params.Get("tienda");
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
                int tamaño = Convert.ToInt32(drop_date.Items.Count.ToString());
                int valor = 0;
                ArrayList lista = new ArrayList();
                for(int i=0; i <= tamaño-1; i++)
                {
                    valor = 0;
                    for(int j = 0; j <= tamaño-1; j++)
                    {
                        if (drop_date.Items[i].Text== drop_date.Items[j].Text)
                        {
                            valor++;
                        }
                    }
                    if (valor == 1)
                    {
                        lista.Add(drop_date.Items[i].Text);
                    }
                    else
                    {
                        bool dat = false;
                        foreach(var t in lista)
                        {
                            if (drop_date.Items[i].Text == t+"")
                            {
                                dat = true;
                            }
                        }
                        if(dat==false) lista.Add(drop_date.Items[i].Text);
                    }
                }
                drop_date.Items.Clear();
                foreach(var lt in lista)
                {
                    drop_date.Items.Add(lt+"");
                }
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

        protected void btn_all_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = baseDatos.dtTable("select * from venta where empleado='" + nombre + "'");
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                grid_ventas.DataSource = tabla;
                grid_ventas.DataBind();
                /*Dropdown*/
                llenarDrop("venta", tienda, "fecha", drop_date);
                int tamaño = Convert.ToInt32(drop_date.Items.Count.ToString());
                int valor = 0;
                ArrayList lista = new ArrayList();
                for (int i = 0; i <= tamaño - 1; i++)
                {
                    valor = 0;
                    for (int j = 0; j <= tamaño - 1; j++)
                    {
                        if (drop_date.Items[i].Text == drop_date.Items[j].Text)
                        {
                            valor++;
                        }
                    }
                    if (valor == 1)
                    {
                        lista.Add(drop_date.Items[i].Text);
                    }
                    else
                    {
                        bool dat = false;
                        foreach (var t in lista)
                        {
                            if (drop_date.Items[i].Text == t + "")
                            {
                                dat = true;
                            }
                        }
                        if (dat == false) lista.Add(drop_date.Items[i].Text);
                    }
                }
                drop_date.Items.Clear();
                foreach (var lt in lista)
                {
                    drop_date.Items.Add(lt + "");
                }
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_cantidad.Text != "" && txt_fecha.Text!="")
            {
                baseDatos.add_venta(txt_fecha.Text, drop_inventario.SelectedValue, nombre, tienda, txt_cantidad.Text);
                grid_ventas.DataBind();
                
                
            }
        }

        protected void btn_filtro_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            string date = "",v1="",v2="",v3="";
            bool aux = false,auxV1=false,auxV2=false, aux_v2=false;
            foreach(char dat in drop_date.SelectedValue)
            {
                if (aux == false && dat != ' ')
                {
                    if (auxV1 == false)
                    {
                        if (dat != '/') v1 = v1 + dat;
                        else auxV1 = true;
                    }
                    if (auxV2==false & auxV1 == true)
                    {
                        if (dat == '/')
                        {
                            if (aux_v2 == false)
                            {
                                v2 = v2 + dat;
                                aux_v2 = true;
                            }
                            else auxV2 = true;
                        }
                        else
                        {
                            v2 = v2 + dat;
                        }
                    }
                    if (auxV2 == true && dat!='/')
                    {
                        v3 = v3 + dat;
                    }
                }
                if (dat == ' ') aux = true;
            }
            date = v3  + v2 + "/" + v1;
            tabla = baseDatos.dtTable("select * from venta where (empleado='" + ventasEmpleado.nombre + "') AND (fecha='"+date+"')");

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                grid_ventas.DataSource = tabla;
                grid_ventas.DataBind();
            }
        }
    }
}
