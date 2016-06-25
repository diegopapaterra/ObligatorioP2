using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    public class CuadroClinico
    {

        #region Atributos

        private DateTime fechaPrimeraConsulta;
        private Veterinario veterinarioResponsable;
        private string motivo;
        private string motivoCierreCuadro;
        private string diagnostico;
        private string estado;
        private List<string> acciones = new List<string>();
        private Patologia posiblePatologia;

        #endregion

        #region Propertys

        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }
        public string MotivoCierreCuadro
        {
            get
            {
                return this.motivoCierreCuadro;
            }
            set
            {
                this.motivoCierreCuadro = value;
            }
        }

        public string DatosCuadroClinico
        {
            get
            {
                return this.fechaPrimeraConsulta + " - " + this.estado + " - " + this.motivo;
            }
        }
        public string Motivo
        {
            get
            {
                return this.motivo;
            }
            set
            {
                motivo = value;
            }
        }

        public Veterinario VeterinarioResponsable
        {
            get
            {
                return veterinarioResponsable;
            }

            set
            {
                veterinarioResponsable = value;
            }
        }


        #endregion

        #region Constructor

        public CuadroClinico(DateTime primerConsulta, Veterinario vetResponsable, string motivo, string diagnostico, string estado, Patologia patologia)
        {
            this.fechaPrimeraConsulta = primerConsulta;
            this.VeterinarioResponsable = vetResponsable;
            this.motivo = motivo;
            this.diagnostico = diagnostico;
            this.estado = estado;
            this.posiblePatologia = patologia;

        }

        #endregion

        #region Métodos

        /*Alta Accion en Cuadro*/
        public bool altaAccionCuadro(string accion)
        {
            this.acciones.Add(accion);
            bool resultado = true;
            return resultado;
        }

        /*Listado Acciones*/
        public List<string> verAcciones()
        {
            List<string> listado = null;
            listado = acciones;
            return listado;
        }

        /*Listado Acciones por Motivo*/
        public string verMotivo()
        {
            string motivo = null;
            motivo = this.motivoCierreCuadro;
            return motivo;
        }

        #endregion
    }
}
