using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaWebApp
{
    public class Utilidades
    {

        public Utilidades (){
            

            
            }

        // Metodo que recorre los control del formulario y si es un textbox lo limpia

        public void limpiarCampos(ControlCollection controles)
        {

            foreach (Control control in controles)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
                else if (control.HasControls())
                {
                    limpiarCampos(control.Controls);
                }

            }
        }

    }
}