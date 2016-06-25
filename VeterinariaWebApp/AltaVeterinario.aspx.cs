using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class AltaVeterinario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }
        }

        protected void btnAltaVeterinario_Click(object sender, EventArgs e)
        {
            try
            {
                int nroLicencia = 0;
                int.TryParse(txtLicencia.Text, out nroLicencia);
                string nombreVeterinario = txtNombreVeterinario.Text;
                DateTime fechaGraduacion = txtFechaGraduacion.SelectedDate;
                int grado = 0;
                int.TryParse(txtGrado.Text, out grado);
                if (Veterinaria.Instancia.altaVeterinario(nroLicencia, nombreVeterinario, fechaGraduacion, grado))
                {
                    lblResultadoVeterinario.Text = "El Veterinario " + nombreVeterinario + " fue dado de alta correctamente";
                    lblResultadoVeterinario.CssClass = "correcto";

                    // Limpiar Campos luego del alta
                    Utilidades util = new Utilidades();
                    util.limpiarCampos(this.Controls);


                }
                else if (nroLicencia == 0) {

                    lblResultadoVeterinario.Text = "No existe un veterinario con ese Username";
                    lblResultadoVeterinario.CssClass = "error";

                }
                else
                {
                    lblResultadoVeterinario.Text = "Los datos ingresados no son correctos";
                    lblResultadoVeterinario.CssClass = "error";
                }
            }
            catch (Exception ex)
            {

                lblResultadoVeterinario.Text = ex.Message;

            }
        }
    }
}