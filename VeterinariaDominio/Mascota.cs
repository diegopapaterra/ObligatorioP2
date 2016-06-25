using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    public class Mascota
    {

        #region Atributos

        private string nombre;
        private string especie;
        private string raza;
        private string sexo;
        private DateTime fechaNacimiento;
        private int nroMascota;
        private HistoriaClinica historiaClinica;
        private string foto;
        private static int ultimoNro;

        #endregion

        #region Propertys
        public static int UltimoNro
        {
            get
            {
                return ultimoNro;
            }
            set
            {
                ultimoNro = value;
            }
        }

        public int NroMascota
        {
            get
            {
                return nroMascota;
            }

            set
            {
                nroMascota = value;
            }
        }
        public string DatosMascota
        {
            get
            {
                return this.nroMascota + " - " + this.nombre + " - " + this.especie;
            }
        }
        #endregion

        #region Constructor

        public Mascota(string nombre, string especie, string raza, string sexo, DateTime fechaNac, string foto)
        {

            this.nombre = nombre;
            this.especie = especie;
            this.raza = raza;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNac;
            this.foto = foto;
            this.NroMascota = Mascota.UltimoNro;
            Mascota.UltimoNro++;


        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return "ID Mascota: " + this.NroMascota + " - nombre: " + this.nombre + " - especie: "+ this.especie + " - raza: "+ this.raza + " - sexo: " + this.sexo + " - fecha nacimiento: "+ this.fechaNacimiento +"\n";
        }

        /*Alta Historia Clinica*/
        public bool altaHistoriaClinica(DateTime fechaPrimeraRev, string revision, Veterinario vet)
        {
            bool resultado = false;
            if (this.historiaClinica == null) {
                this.historiaClinica = new HistoriaClinica(fechaPrimeraRev, revision, vet);
                resultado = true;
            }
            
            return resultado;
        }

        /*Alta Cuadro Clinico*/
        public bool altaCuadroClinico(DateTime fechaConsulta, string motivo, string diagnostico, string estado, Patologia patologia, Veterinario vet)
        {
            bool resultado = false;
            if (this.historiaClinica != null)
            {
                if (historiaClinica.altaCuadroClinico(fechaConsulta, motivo, diagnostico, estado, patologia, vet)) {
                    resultado = true;
                }                
            }

            return resultado;
        }

        /*Listado Cuadro Clinico*/
        public List<CuadroClinico> listadoCuadroClinicoEnCurso(bool todos) {

            List<CuadroClinico> listaCuadroClinicos = new List<CuadroClinico>();

            if (historiaClinica != null) {
                listaCuadroClinicos = historiaClinica.listadoCuadroClinicoEnCurso(todos);
            }

            return listaCuadroClinicos;
        }

        /*Alta Accion en Cuadro*/
        public bool altaAccionCuadro(string motivoCuadro, string accion)
        {
            bool resultado = false;
            if (historiaClinica.altaAccionCuadro(motivoCuadro, accion))
            {
                resultado = true;
            }

            return resultado;
        }

        /*Fin Cuadro Clinico*/
        public bool finCuadroClinico(string motivoCuadro, string NuevoMotivo, bool checkFinalizado)
        {
            bool resultado = false;
            if (historiaClinica.finCuadroClinico(motivoCuadro, NuevoMotivo, checkFinalizado))
            {
                resultado = true;
            }

            return resultado;
        }

        /*Listado Acciones*/
        public List<string> verAcciones(string motivoCuadro)
        {
            List<string> listado = null;
            listado = historiaClinica.verAcciones(motivoCuadro);

            return listado;
        }

        /*Listado Acciones por motivo*/
        public string verMotivo(string motivoCuadro)
        {
            string motivo = null;
            motivo = historiaClinica.verMotivo(motivoCuadro);

            return motivo;
        }

        /*Listado de Vet por Cuadro*/
        public int vetOrdenadosPorCuadro(Veterinario vet)
        {
            int cantidad = 0;
            if (historiaClinica != null)
            {
                cantidad = historiaClinica.vetOrdenadosPorCuadro(vet);
            }
            return cantidad;
        }


        #endregion
    }
}
