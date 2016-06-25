using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class AltaPatologia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }
        }

        protected void btnEnviarPatologia_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = txtTituloPatologia.Text;
                string descripcion = txtDescripcion.Text;
                
                    /*Alta Socio Regular*/
                    if (Veterinaria.Instancia.altaPatologia(titulo, descripcion))
                    {

                        resultadoPatologia.Text = "La Patologia:  " + titulo + " fue dada de alta correctamente";
                        resultadoPatologia.CssClass = "correcto";

                        // Limpiar Campos luego de dar un alta

                        Utilidades util = new Utilidades();
                        util.limpiarCampos(this.Controls);

                    }
                    else
                    {
                        resultadoPatologia.Text = "Error";
                        resultadoPatologia.CssClass = "error";
                    }
            }
            catch (Exception ex)
            {

                resultadoPatologia.Text = ex.Message;

            }
        }
    }
}