using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class AltaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador") {
                Response.Redirect("Index.aspx?permission=denied");
            }
        }

        protected void btnEnviarUsuario_Click(object sender, EventArgs e)
        {
            /*Alta de Usuario*/
            try
            {
                string usuario = txtNombreUsuario.Text;
                string password = txtPass.Text;
                string tipoUsuario = null;
                if (rbnAdmin.Checked)
                {
                    tipoUsuario = "Administrador";
                } else if (rbnVeterinario.Checked)
                {
                    tipoUsuario = "Veterinario";

                }else if (rbnSocio.Checked)
                {
                    tipoUsuario = "Socio";
                } 

                if (Veterinaria.Instancia.altaUsuario(usuario, password, tipoUsuario))
                {
                    resultadoUsuario.Text = "El Usuario " + usuario + " fue dado de alta correctamente";
                    resultadoUsuario.CssClass = "correcto";
                }
                else
                {
                    resultadoUsuario.Text = "El usuario " + usuario + " no fue dado de alta, intente nuevamente";
                    resultadoUsuario.CssClass = "error";
                }
            }
            catch (Exception ex)
            {

                resultadoUsuario.Text = ex.Message;
                resultadoUsuario.CssClass = "error";

            }
        }
    }
}