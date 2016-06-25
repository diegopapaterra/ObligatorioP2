using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    public class Patologia
    {

        #region Atributos

        private int codigo;
        private static int ultCodigoPatologia;
        private string titulo;
        private string descripcion;

        #endregion

        #region Propertys

        public static int UltCodigoPatologia
        {
            get
            {
                return ultCodigoPatologia;
            }

            set
            {
                ultCodigoPatologia = value;
            }
        }

        public string DatosPatologias
        {
            get
            {
                return this.Codigo + " - " + this.titulo;
            }
        }

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        #endregion

        #region Constructor

        public Patologia(string titulo, string desc) {

            this.Codigo = Patologia.UltCodigoPatologia;
            Patologia.UltCodigoPatologia++;
            this.titulo = titulo;
            this.descripcion = desc;         
        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return "El código de patologia es: " + this.Codigo + " - nombre: " + this.titulo + " - descripcion: " + this.descripcion;
        }


        #endregion


    }
}
