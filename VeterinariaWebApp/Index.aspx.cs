using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["permission"].ToString() == "denied")
                {
                    resultadoUsuario.Text = "Usted no tiene privilegios para ver esa información";
                    resultadoUsuario.CssClass = "error";
                }
            }
            catch (Exception ex)
            {

                resultadoUsuario.Text = ex.Message;
                resultadoUsuario.Visible = false;

            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;

            string role = Veterinaria.Instancia.autenticate(username, password);

            switch (role)
            {
                case "Administrador":
                    Session["rol"] = role;
                    Session["username"] = username;
                    Response.Redirect("AltaUsuarios.aspx");
                    break;
                case "Veterinario":
                    Session["rol"] = role;
                    Session["username"] = username;
                    Response.Redirect("AltaHistoriaClinica.aspx");
                    break;
                case "Socio":
                    Session["rol"] = role;
                    Session["username"] = username;
                    Response.Redirect("VerHistoriaClinica.aspx");
                    break;
                default:
                    Response.Redirect("Index.aspx");
                    break;
            }
        }
    }
}