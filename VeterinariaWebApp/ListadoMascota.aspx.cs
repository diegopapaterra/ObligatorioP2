using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeterinariaDominio;

namespace VeterinariaWebApp
{
    public partial class ListadoMascota : System.Web.UI.Page
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

        protected void btnBuscarMascota_Click(object sender, EventArgs e)
        {
            string socioCI = DDLSocios.SelectedValue;

            if (cedulaValidada(socioCI))
            {
                string resultadoString = Veterinaria.Instancia.listadoMascotasPorSocio(socioCI);
                string[] result = resultadoString.Split(new string[] { "\n" }, StringSplitOptions.None);
                listMascota.DataSource = result;
                listMascota.DataBind();
            }
            else
            {
                resultadoListMascota.Text = "Error";
                resultadoListMascota.CssClass = "error";
            }
        }

        public static bool cedulaValidada(string texto)
        {
            bool resultado = false;
            if (texto.Length > 6 && texto.Length < 9)
            {
                resultado = true;
            }
            return resultado;
        }
    }
}