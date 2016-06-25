using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class AltaHistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Veterinario")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }
            else {
                txtPrimerVeterinario.Text = Session["username"].ToString();
            }

            if (!IsPostBack)
            {
                DDLSocios.DataSource = Veterinaria.Instancia.Socios;
                DDLSocios.DataTextField = "DatosSocios";
                DDLSocios.DataValueField = "CedulaSocio";
                DDLSocios.DataBind();
            }
        }

        protected void ddlSocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string socio = DDLSocios.SelectedValue;
            DDLMascotasSocio.DataSource = Veterinaria.Instancia.listadoMascotasPorSocioOBJ(socio);
            DDLMascotasSocio.DataTextField = "DatosMascota";
            DDLMascotasSocio.DataValueField = "NroMascota";
            DDLMascotasSocio.DataBind();

            if  (DDLMascotasSocio.DataSource == null) {

                lblResultado.Text = "El socio seleccionado no tiene mascotas";
                lblResultado.CssClass = "error";
            }
        }

        protected void ddlMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnHistoriaClinica_Click(object sender, EventArgs e)
        {
            try
            {
                string socioCI = DDLSocios.SelectedValue;
                int nroMascota = -1;
                int.TryParse(DDLMascotasSocio.SelectedValue, out nroMascota);
                DateTime fechaNacimiento = txtFechaIngreso.SelectedDate;
                string revision = txtPrimeraRevision.Text;
                int vetNroLicencia = -1;
                int.TryParse(txtPrimerVeterinario.Text, out vetNroLicencia);

                if (Veterinaria.Instancia.altaHistoriaClinica(socioCI, nroMascota, fechaNacimiento, revision, vetNroLicencia))
                {
                    lblResultado.Text = "Se ingresó correctamente la Historia Clinica";
                    lblResultado.CssClass = "correcto";

                    // Limpiar Campos luego del alta
                    Utilidades util = new Utilidades();
                    util.limpiarCampos(this.Controls);


                }
                else 
                {
                    lblResultado.Text = "Los datos ingresados no son correctos";
                    lblResultado.CssClass = "error";
                }
            }
            catch (Exception ex)
            {

                lblResultado.Text = ex.Message;
            }

        }

        
    }
}