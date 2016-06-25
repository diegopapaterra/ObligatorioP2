using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class AltaMascota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() != "Administrador")
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

        protected void btnEnviarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                string socioCI = DDLSocios.SelectedValue;
                string nombre = txtNombre.Text;
                string especie = txtEspecie.Text;
                string raza = txtRaza.Text;
                string sexo = txtSexo.Text;
                DateTime fechaNacimiento = txtFechaNacimiento.SelectedDate;

                if (fileUploadMascota.HasFile) {

                    fileUploadMascota.SaveAs(Server.MapPath("~/img/" + fileUploadMascota.FileName));

                }

               

               // string foto = txtFoto.Text;
                if (Veterinaria.Instancia.altaMascota(socioCI, nombre, especie, raza, sexo, fechaNacimiento, fileUploadMascota.FileName))
                {
                    resultadoMascota.Text = "Se ingresó correctamente la mascota: " + nombre;
                    resultadoMascota.CssClass = "correcto";

                    // Limpiar Campos luego del alta
                    Utilidades util = new Utilidades();
                    util.limpiarCampos(this.Controls);


                }
                else
                {
                    resultadoMascota.Text = "Los datos ingresados no son correctos";
                    resultadoMascota.CssClass = "error";
                }
            }
            catch (Exception ex) {

                resultadoMascota.Text = ex.Message;
            }
        }

    }
}