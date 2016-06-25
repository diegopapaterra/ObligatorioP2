using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class VerHistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rolID = null;
            if (Session["rol"].ToString() == "Socio")
            {
                rolID = Session["username"].ToString();
                panelSocio.Visible = true;
                lblSocio.Text = "Socio: " + rolID;
                DDLMascotasSocio.DataSource = Veterinaria.Instancia.listadoMascotasPorSocioOBJ(rolID);
                DDLMascotasSocio.DataTextField = "DatosMascota";
                DDLMascotasSocio.DataValueField = "NroMascota";
                DDLMascotasSocio.DataBind();
            }
            else if (Session["rol"].ToString() == "Veterinario" || Session["rol"].ToString() == "Administrador")
            {
                panelFull.Visible = true;
                if (!IsPostBack)
                {
                    DDLSocios.DataSource = Veterinaria.Instancia.Socios;
                    DDLSocios.DataTextField = "DatosSocios";
                    DDLSocios.DataValueField = "CedulaSocio";
                    DDLSocios.DataBind();
                }
            }
            else
            {
                Response.Redirect("Index.aspx?permission=denied");
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
            string nroSocio = null;
            if (Session["rol"].ToString() == "Socio")
            {
                nroSocio = Session["username"].ToString();
            }
            else if (Session["rol"].ToString() == "Veterinario" || Session["rol"].ToString() == "Administrador")
            {
                nroSocio = DDLSocios.SelectedValue;
            }

            int nroMascota = -1;
            int.TryParse(DDLMascotasSocio.SelectedValue, out nroMascota);
            bool todosCuadros = true;
            DDLlistaCuadroClinico.DataSource = Veterinaria.Instancia.listadoCuadroClinicoEnCurso(nroSocio, nroMascota, todosCuadros);
            DDLlistaCuadroClinico.DataTextField = "DatosCuadroClinico";
            DDLlistaCuadroClinico.DataValueField = "Motivo";
            DDLlistaCuadroClinico.DataBind();
        }

        protected void btnAcciones_Click(object sender, EventArgs e)
        {
            try
            {
                string nroSocio = null;
                if (Session["rol"].ToString() == "Socio")
                {
                    nroSocio = Session["username"].ToString();
                }
                else if (Session["rol"].ToString() == "Veterinario" || Session["rol"].ToString() == "Administrador")
                {
                    nroSocio = DDLSocios.SelectedValue;
                }
                
                int nroMascota = -1;
                int.TryParse(DDLMascotasSocio.SelectedValue, out nroMascota);
                string motivoCuadro = DDLlistaCuadroClinico.SelectedValue;

                List<string> listAcciones = Veterinaria.Instancia.verAcciones(nroSocio, nroMascota, motivoCuadro);
                txtlistAcciones.DataSource = listAcciones;
                txtlistAcciones.DataBind();

                string motivoFinalizado = Veterinaria.Instancia.verMotivo(nroSocio, nroMascota, motivoCuadro);
                if (motivoFinalizado != null)
                {
                    panelFinalizado.Visible = true;
                    txtMotivo.Text = motivoFinalizado;
                }
                else {
                    panelFinalizado.Visible = false;
                }
            }
            catch (Exception ex)
            {

                lblResultado.Text = ex.Message;
            }
        }
    }
}