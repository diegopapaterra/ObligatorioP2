using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class FinCuadroClinico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Veterinario")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }

            if (!IsPostBack)
            {
                DDLSocios.DataSource = Veterinaria.Instancia.Socios;
                DDLSocios.DataTextField = "DatosSocios";
                DDLSocios.DataValueField = "CedulaSocio";
                DDLSocios.DataBind();
            }

        }

        protected void ddlSocio_SelectedIndexChangedCuadro(object sender, EventArgs e)
        {
            string socio = DDLSocios.SelectedValue;
            DDLMascotasSocio.DataSource = Veterinaria.Instancia.listadoMascotasPorSocioOBJ(socio);
            DDLMascotasSocio.DataTextField = "DatosMascota";
            DDLMascotasSocio.DataValueField = "NroMascota";
            DDLMascotasSocio.DataBind();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string nroSocio = DDLSocios.SelectedValue;
            int nroMascota = -1;
            int.TryParse(DDLMascotasSocio.SelectedValue, out nroMascota);
            bool todos = false;
            DDLlistaCuadroClinico.DataSource = Veterinaria.Instancia.listadoCuadroClinicoEnCurso(nroSocio, nroMascota, todos);
            DDLlistaCuadroClinico.DataTextField = "DatosCuadroClinico";
            DDLlistaCuadroClinico.DataValueField = "Motivo";
            DDLlistaCuadroClinico.DataBind();
        }

        protected void btnFinCuadro_Click(object sender, EventArgs e)
        {
            try
            {
                string nroSocio = DDLSocios.SelectedValue;
                int nroMascota = -1;
                int.TryParse(DDLMascotasSocio.SelectedValue, out nroMascota);
                string cuadroClinico = DDLlistaCuadroClinico.SelectedValue;
                string motivoCuadro = DDLlistaCuadroClinico.SelectedValue;
                string NuevoMotivo = txtMotivo.Text;
                bool chkFinalizado = checkFinalizado.Checked;

                if (Veterinaria.Instancia.finCuadroClinico(nroSocio, nroMascota, motivoCuadro, NuevoMotivo, chkFinalizado))
                {
                    lblResultado.Text = "Cuadro Clinico Finalizado";
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

        protected void DDLMascotasSocio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}