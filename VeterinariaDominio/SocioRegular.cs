using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    // La clase Regular Hereda de Socio

   public class SocioRegular : Socio
    {

        #region Atributos

        private string formaDePago;

        #endregion

        #region Propertys

        #endregion

        #region Constructor

        public SocioRegular(string ci, string nombre, string dir, string mail, int tel, Usuario usuario, string formaPago): base (ci,nombre, dir, mail, tel, usuario) {

            this.formaDePago = formaPago;


        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return base.ToString() + " - forma de pago es: " + this.formaDePago + "\n";
        }

        public override string calcularCuotaMensual() {

        double desc = 0;
        double cuotaMensual;

            if (cantidadMascotasPorSocio() < 3)
            {

                desc = 0.05;

            }
            else {

                desc = 0.15;

            }

           double cuotaSinDescuento = MontoBase * cantidadMascotasPorSocio();
           double descuento = cuotaSinDescuento * desc;
           cuotaMensual = cuotaSinDescuento - descuento;
           string retorno = "Cuota mensual: " + cuotaMensual;

            return retorno;

        }




    #endregion


}
}
