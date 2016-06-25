using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }

            if (!IsPostBack)
            {
                DDLUsuarios.DataSource = Veterinaria.Instancia.Usuarios;
                DDLUsuarios.DataTextField = "DatosUsuario";
                DDLUsuarios.DataValueField = "Username";
                DDLUsuarios.DataBind();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string usuarioModificar = DDLUsuarios.SelectedValue;
            Response.Redirect("CambioUsuario.aspx?username="+usuarioModificar);
        }
    }
}