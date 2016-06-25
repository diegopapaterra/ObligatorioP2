using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
  public class Veterinario
    {

        #region Atributos

        private int nroLicencia;
        private string nombreVeterinario;
        private DateTime fechaGraducacion;
        private int grado;
        private Usuario usuario;

        #endregion

        #region Propertys

        public string NombreVeterinario
        {
            get
            {
                return nombreVeterinario;
            }

            set
            {
                nombreVeterinario = value;
            }
        }

        public int NroLicencia
        {
            get
            {
                return nroLicencia;
            }

            set
            {
                nroLicencia = value;
            }
        }

        public DateTime FechaGraducacion
        {
            get
            {
                return fechaGraducacion;
            }

            set
            {
                fechaGraducacion = value;
            }
        }

        public int Grado
        {
            get
            {
                return grado;
            }

            set
            {
                grado = value;
            }
        }

        public string DatosVeterinario
        {
            get
            {
                return this.nroLicencia + " - " + this.nombreVeterinario;
            }
        }


        #endregion

        #region Constructor

        public Veterinario (int nroLicencia, string nombre, DateTime fechaG, int grado, Usuario usuario){

            this.NroLicencia = nroLicencia;
            this.NombreVeterinario = nombre;
            this.FechaGraducacion = fechaG;
            this.Grado = grado;
            this.usuario = usuario;


        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return "Veterinario - Numero de Licencia:" + this.nroLicencia + " - nombre del veterinario es: " + this.nombreVeterinario + " - fecha de gracuación: " + this.fechaGraducacion + " - grado: " + this.grado + "\n";
        }

        // Grado valido

        public static bool gradoValidado(int grado)
        {
            bool resultado = false;
            if (grado > 0 && grado < 6)
            {
                resultado = true;
            }
            return resultado;
        }

        #endregion

    }
}
