using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;


namespace VeterinariaWebApp
{
    public partial class AltaSocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }
        }


        protected void rbnRegular_CheckedChanged(object sender, EventArgs e)
        {
            PanelRegular.Visible = true;
            PanelProtectora.Visible = false;
        }

        protected void rbnProtectora_CheckedChanged(object sender, EventArgs e)
        {
            PanelRegular.Visible = false;
            PanelProtectora.Visible = true;
        }

        protected void btnEnviarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtCedulaSocio.Text;
                string nombre = txtNombreSocio.Text;
                string direccion = txtDirecSocio.Text;
                string email = txtMailSocio.Text;
                int tel = 0;
                int.TryParse(txtTelSocio.Text, out tel);
                if (PanelRegular.Visible == true)
                {
                    string formaPago = "";
                    if (rbnEfectivo.Checked)
                    {
                        formaPago = "Efectivo";
                    }
                    else if (rbnTarjeta.Checked)
                    {
                        formaPago = "Tarjeta";
                    }
                    /*Alta Socio Regular*/
                    if (Veterinaria.Instancia.altaSocioRegular(cedula, nombre, direccion, email, tel, formaPago))
                    {

                        resultadoSocio.Text = "El socio regular " + nombre + " fue dado de alta correctamente";
                        resultadoSocio.CssClass = "correcto";

                        // Limpiar Campos luego de dar un alta

                        Utilidades util = new Utilidades();
                        util.limpiarCampos(this.Controls);

                    }
                    else {
                        resultadoSocio.Text = "Error";
                        resultadoSocio.CssClass = "error";
                    }
                }
                else if (PanelProtectora.Visible == true)
                {
                    string personaContacto = txtPersonaContacto.Text;
                    /*Alta Socio Protectora*/
                    if (Veterinaria.Instancia.altaSocioProtectora(cedula, nombre, direccion, email, tel, personaContacto))
                    {
                        resultadoSocio.Text = "El Socio Protectora de Animales " + nombre + " fue dado de alta correctamente";
                        resultadoSocio.CssClass = "correcto";
                    }
                    else {
                        resultadoSocio.Text = "Error";
                        resultadoSocio.CssClass = "error";
                    }
                }
            }
            catch (Exception ex)
            {

                resultadoSocio.Text = ex.Message;

            }
        }


       

    }
}