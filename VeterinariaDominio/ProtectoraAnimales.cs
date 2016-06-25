using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    // La clase Protectora de Animales hereda de Socio
   public class ProtectoraAnimales: Socio 

    {

        #region Atributos

        private string personaDeContacto;
        private static double valorDescuento = 0.05;


        #endregion

        #region Propertys

        public static double ValorDescuento
        {
            get
            {
                return valorDescuento;
            }

            set
            {
                valorDescuento = value;
            }
        }


        #endregion

        #region Constructor

        public ProtectoraAnimales(string ci, string nombre, string dir, string mail, int tel, Usuario usuario, string contacto ) : base(ci, nombre, dir, mail, tel, usuario) {

            this.personaDeContacto = contacto;

        }



        #endregion

        #region Métodos

        public override string ToString()
        {
            return base.ToString() + " - persona de contacto es: " + this.personaDeContacto + "\n";
        }


        //public override double calcularDescuento()
        //{
        //    return ValorDescuento;
        //}

        public override string calcularCuotaMensual()
        {
            double cuotaSinDescuento = MontoBase * cantidadMascotasPorSocio();
            double descuento = cuotaSinDescuento * valorDescuento;
            double cuotaMensual = cuotaSinDescuento - descuento;

            string retorno = "Cuota mensual: " + cuotaMensual;
                   
           return retorno;
            
        }

        #endregion


    }
}
