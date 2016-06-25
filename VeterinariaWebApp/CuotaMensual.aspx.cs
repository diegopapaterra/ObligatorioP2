using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class CuotaMensual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
            {
                Response.Redirect("Index.aspx?permission=denied");
            }
        }

        protected void btnEnviarMontoBase_Click(object sender, EventArgs e)
        {
            try
            {
                double montoBase = 0;
                double.TryParse(txtMontoBase.Text, out montoBase);

                if (Veterinaria.Instancia.establecerMontoBase(montoBase))
                {

                    lblmensajeMonto.Text = "Se ha actualizado el monto base";
                    lblmensajeMonto.CssClass = "correcto";

                }
                else {

                    lblmensajeMonto.Text = "Debe ingresar un número mayor a 0";
                    lblmensajeMonto.CssClass = "Error";
                }
              
            }catch (Exception ex) {

                lblmensajeMonto.Text = ex.Message;
                lblmensajeMonto.CssClass = "Error";
            }
        }

        protected void btnEnviarDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                double descuentoProtectora = 0;
                double.TryParse(txtDescProtectoras.Text, out descuentoProtectora);
                if (Veterinaria.Instancia.establecerDescuentoProtectoras(descuentoProtectora)) {

                    lblMensajeDesc.Text = "Se ha actualizado el valor del descuento para las protectoras de animales";
                    lblMensajeDesc.CssClass = "correcto";

                } else
                {

                    lblMensajeDesc.Text = "Debe ingresar un valor mayor a 0";
                    lblMensajeDesc.CssClass = "Error";

                }            
               
            } catch (Exception ex) {

                lblMensajeDesc.Text = ex.Message;
                lblMensajeDesc.CssClass = "Error";
            }
        }
    }
}