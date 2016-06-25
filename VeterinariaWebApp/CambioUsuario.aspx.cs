using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class CambioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }

            string username = Request.QueryString["Username"].ToString();
            txtNombreUsuario.Text = username;
            txtNombreUsuario.ReadOnly = true;
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            string username = Request.QueryString["Username"].ToString();
            string password = txtPass.Text;
           
            if (Veterinaria.Instancia.modificarUsuario(username, password))
            {
                resultadoUsuario.Text = "El Usuario " + username + " fue modificado correctamente";
                resultadoUsuario.CssClass = "correcto";
            }
            else{
                resultadoUsuario.Text = "Error";
                resultadoUsuario.CssClass = "error";
            }
        }
    }
}