using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class AltaAccionCuadroClinico : System.Web.UI.Page
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

        protected void btnAltaAccion_Click(object sender, EventArgs e)
        {
            try
            {
                string nroSocio = DDLSocios.SelectedValue;
                int nroMascota = -1;
                int.TryParse(DDLMascotasSocio.SelectedValue, out nroMascota);
                string motivoCuadro = DDLlistaCuadroClinico.SelectedValue;
                string accion = txtAccion.Text;

                if (Veterinaria.Instancia.altaAccionCuadro(nroSocio, nroMascota, motivoCuadro, accion))
                {
                    lblResultado.Text = "Se ingresó correctamente la nueva Accion al Cuadro Clinico";
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