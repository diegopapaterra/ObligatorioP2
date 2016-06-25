using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }
            listCliente.DataSource = Veterinaria.Instancia.InfoCompletaSocios();
            listCliente.DataBind();
        }

        protected void listCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}