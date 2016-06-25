using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class AltaCuadroClinico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Veterinario")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }
            else
            {
                txtVeterinario.Text = Session["username"].ToString();
            }

            if (!IsPostBack)
            {
                DDLSocios.DataSource = Veterinaria.Instancia.Socios;
                DDLSocios.DataTextField = "DatosSocios";
                DDLSocios.DataValueField = "CedulaSocio";
                DDLSocios.DataBind();
                /*Posible Patatologia*/
                DDLPosiblePatalogia.DataSource = Veterinaria.Instancia.Patologias;
                DDLPosiblePatalogia.DataTextField = "DatosPatologias";
                DDLPosiblePatalogia.DataValueField = "Titulo";
                DDLPosiblePatalogia.DataBind();
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

        protected void btnCuadroClinico_Click(object sender, EventArgs e)
        {
            try
            {
                string socioCI = DDLSocios.SelectedValue;
                int nroMascota = -1;
                int.TryParse(DDLMascotasSocio.SelectedValue, out nroMascota);
                DateTime fechaConsulta = txtFechaConsulta.SelectedDate;
                string motivo = txtMotivo.Text;
                string diagnostico = txtDiagnostico.Text;
                string estado = "En Curso";
                
                string posiblePatologiaValue = DDLPosiblePatalogia.SelectedValue;
                int posiblePatologia = -1;
                int.TryParse(posiblePatologiaValue.ToString(), out posiblePatologia);

                int vetNroLicencia = -1;
                int.TryParse(txtVeterinario.Text, out vetNroLicencia);

                if (Veterinaria.Instancia.altaCuadroClinico(socioCI, nroMascota, fechaConsulta, motivo, diagnostico, estado, posiblePatologia, vetNroLicencia))
                {
                    lblResultado.Text = "Se ingresó correctamente el Cuadro Clinico";
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