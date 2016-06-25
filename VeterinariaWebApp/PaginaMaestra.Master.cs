using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaWebApp
{
    public partial class PaginaMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                lblUsername.Text = "Bienvenido, " + Session["username"].ToString();
            }

            try
            {
                if (Session["rol"].ToString() == "Administrador")
                {
                    MenuAdministrador.Visible = true;
                }
                else if (Session["rol"].ToString() == "Veterinario")
                {
                    MenuVeterinario.Visible = true;
                }
                if (Session["rol"].ToString() == "Socio")
                {
                    MenuSocio.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.Message;
            }
            

        }
    }
}