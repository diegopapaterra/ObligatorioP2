using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
   public abstract class Socio
    {

        #region Atributos

        private string cedulaSocio;
        private string nombreSocio;
        private string direccionSocio;
        private string mailSocio;
        private int telefonoSocio;
        private List<Mascota> mascotas = new List<Mascota>();
        // Se inicializa el monto base con un valor, solamente para que no de 0 la cuota antes que se modifiquen los valores.
        private static double montoBase = 100;
        private Usuario usuario;
        
        #endregion

        #region Propertys

        public string CedulaSocio
        {
            get
            {
                return cedulaSocio;
            }

            set
            {
                cedulaSocio = value;
            }
        }

        public List<Mascota> Mascotas
        {
            get
            {
                return mascotas;
            }

            set
            {
                mascotas = value;
            }
        }

        public static double MontoBase
        {
            get
            {
                return montoBase;
            }

            set
            {
                montoBase = value;
            }
        }

        public string DatosSocios
        {
            get
            {
                return this.cedulaSocio + " - " + this.nombreSocio;
            }
        }


        #endregion

        #region Constructor

        public Socio(string ci, string nombre, string dir, string mail, int telefono, Usuario usuario) {

            this.cedulaSocio = ci;
            this.nombreSocio = nombre;
            this.direccionSocio = dir;
            this.mailSocio = mail;
            this.telefonoSocio = telefono;
            this.usuario = usuario;

}

        #endregion

        #region Métodos

        public override string ToString()
        {
            return "El documento del socio es: " + this.cedulaSocio + " - nombre: " + this.nombreSocio + " - direccion: " + this.direccionSocio+ " - mail: "+ this.mailSocio + " - telefono: " + this.telefonoSocio;
        }

        /*Alta Mascota*/
        public bool altaMascota(string nombre, string especie, string raza, string sexo, DateTime fechaNacimiento, string foto)
        {
            bool alta = false;
            Mascotas.Add(new Mascota(nombre, especie, raza, sexo, fechaNacimiento, foto));
            alta = true;
            return alta;
        }

        /*Listado Mascota*/
        public string listadoMascota()
        {
            string listado = "";
            foreach (Mascota mascota in Mascotas)
            {
                listado += mascota.ToString();
            }
            return listado;
        }

        // Validaciones propias del socio

        // Validar cedula

        public static bool cedulaValidada(string ci)
        {
            bool resultado = false;
            if (ci.Length > 6 && ci.Length < 9)
            {
                resultado = true;
            }
            return resultado;
        }

        //// El metodo que calcula el descuento es abstracto porque es diferente para cada tipo de socio

        //public abstract double calcularDescuento();

        // Cantidad de mascotas por socio

        public int cantidadMascotasPorSocio()
        {

            int cantidadMascotas = mascotas.Count();

            return cantidadMascotas;

        }


       // Calcular cuota mensual

        public abstract string calcularCuotaMensual();

        /*Alta Historia clinica*/

        public bool altaHistoriaClinica(int mascota, DateTime fechaPrimeraRev, string revision, Veterinario vet)
        {
            bool resultado = false;
            Mascota mascotaSocio = this.buscarMascota(mascota);
            if (mascotaSocio != null) {
                resultado = mascotaSocio.altaHistoriaClinica(fechaPrimeraRev, revision, vet);
            }

            return resultado;
        }

        /*Alta Cuadro clinica*/

        public bool altaCuadroClinico(int mascota, DateTime fechaConsulta, string motivo, string diagnostico, string estado, Patologia patologia, Veterinario vet)
        {
            bool resultado = false;
            Mascota mascotaSocio = this.buscarMascota(mascota);
            if (mascotaSocio != null)
            {
                resultado = mascotaSocio.altaCuadroClinico(fechaConsulta, motivo, diagnostico, estado, patologia, vet);
            }

            return resultado;
        }

        /*Buscar Mascota*/
        public Mascota buscarMascota(int nroMascota)
        {

            Mascota mascota = null;
            int i = 0;
            bool flag = false;

            while (i < mascotas.Count && !flag)
            {

                if (mascotas[i].NroMascota == nroMascota)
                {

                    mascota = mascotas[i];
                    flag = true;

                }
                i++;
            }
            return mascota;

        }

        /*Listado Cuadro Clinico*/
        public List<CuadroClinico> listadoCuadroClinicoEnCurso(int nroMascota, bool todos)
        {

            List<CuadroClinico> listaCuadroClinicos = new List<CuadroClinico>();
            Mascota mascota = this.buscarMascota(nroMascota);

            if (mascota != null)
            {
                listaCuadroClinicos = mascota.listadoCuadroClinicoEnCurso(todos);
            }
            
            return listaCuadroClinicos;
        }
        /*Listado Mascota por Socio return@objet*/
        public List<Mascota> listadoMascotaPorSocio()
        {
            List<Mascota> listaMascotaSocio = new List<Mascota>();

            foreach (Mascota mascota in mascotas)
            {

                listaMascotaSocio.Add(mascota);
                
            }

            return listaMascotaSocio;
        }

        /*Alta Accion en Cuadro*/
        public bool altaAccionCuadro(int nroMascota, string motivoCuadro, string accion)
        {
            bool resultado = false;
            Mascota mascota = this.buscarMascota(nroMascota);
            if (mascota.altaAccionCuadro(motivoCuadro, accion))
            {
                resultado = true;
            }

            return resultado;
        }
        /*Fin Cuadro Clinico*/
        public bool finCuadroClinico(int nroMascota, string motivoCuadro, string NuevoMotivo, bool checkFinalizado)
        {
            bool resultado = false;
            Mascota mascota = this.buscarMascota(nroMascota);
            if (mascota.finCuadroClinico(motivoCuadro, NuevoMotivo, checkFinalizado))
            {
                resultado = true;
            }

            return resultado;
        }

        /*Cargar Mascotas*/
        public void cargarMascota(Mascota m) {
            this.mascotas.Add(m);
        }

        /*Listado Acciones*/
        public List <string> verAcciones(int nroMascota, string motivoCuadro)
        {
            List<string> listado = null;
            Mascota mascota = this.buscarMascota(nroMascota);
            listado = mascota.verAcciones(motivoCuadro);

            return listado;
        }

        /*Listado Acciones por Motivo*/
        public string verMotivo(int nroMascota, string motivoCuadro)
        {
            string motivo = null;
            Mascota mascota = this.buscarMascota(nroMascota);
            motivo = mascota.verMotivo(motivoCuadro);

            return motivo;
        }

        /*Listado de Vet por Cuadro*/
        public int vetOrdenadosPorCuadro(Veterinario vet)
        {
            int cantidad = 0;
            foreach (Mascota mascota in mascotas)
            {
                cantidad += mascota.vetOrdenadosPorCuadro(vet);
            }

            return cantidad;
        }


        #endregion

    }
}
