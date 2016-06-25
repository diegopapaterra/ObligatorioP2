using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    public class Veterinaria
    {

        #region Atributos

        private static Veterinaria instancia;
        private List<Patologia> patologias = new List<Patologia>();
        private List<Socio> socios = new List<Socio>();
        private List<Veterinario> veterinarios = new List<Veterinario>();
        private List<Usuario> usuarios = new List<Usuario>();

        #endregion

        #region Propertys

        public static Veterinaria Instancia
        {
            get
            {
                if (instancia == null)
                {

                    instancia = new Veterinaria();
                }
                return instancia;
            }

            set
            {
                instancia = value;
            }
        }

        public List<Usuario> Usuarios
        {
            get { return this.usuarios; }
        }

        public List<Socio> Socios
        {
            get
            {
                return socios;
            }

        }

        public List<Veterinario> Veterinarios
        {
            get
            {
                return veterinarios;
            }

        }

        public List<Patologia> Patologias
        {
            get
            {
                return patologias;
            }
        }

        #endregion

        #region Constructor

        private Veterinaria() {
            this.cargarVeterinarios();
            this.cargarUsuarios();
            this.cargarPatologias();
        }

        #endregion

        #region Métodos

        // Requerimientos a nivel Administrador 

        // F01 Registro y modificacion de Usuarios
        // F02 Alta Patologia
        // F03 Alta veterinario
        // F04 Listado de veterinarios ordenado en forma descendente por cantidad de Cuadros Clinicos en los que participa
        // F05 Establecer el monto base de la couta mensual de todos los socios y el valor de descuentos para las protectoras
        // F06 Alta de nuevo mascota para un socio


        // ----  Requerimientos Generales ---- //

        // 1. Todos los datos deben ser validos
        // 2. Todos los datos son obligatorios
        // 3. Fechas deben ser validas y coherentes 
        // 4. Numericos positivos y dentro del rango que correpondan
        // 5. Cedulas - 8 digitos 
        // 6. Textos no pueden ser vacios


        // METODOS //

        // F01 a. Registro Usuario Regular

        public bool altaSocioRegular(string ci, string nombre, string dir, string mail, int tel, string formaPago)
        {

            bool alta = false;

            Socio nuevoSocio = this.buscarSocio(ci);

            Usuario usuarioFound = this.buscarUsuario(ci);

            if (nuevoSocio == null && usuarioFound != null && Socio.cedulaValidada(ci) && !this.esVacio(nombre) && !this.esVacio(dir) && !this.esVacio(mail) && this.esEntero(tel) && !this.esVacio(formaPago))
            {

                socios.Add(new SocioRegular(ci, nombre, dir, mail, tel, usuarioFound, formaPago));
                alta = true;

            }
            return alta;
        }

        /*Alta Socio Protectora*/

        public bool altaSocioProtectora(string ci, string nombre, string dir, string mail, int tel, string contacto)
        {

            bool alta = false;

            Socio nuevoSocio = this.buscarSocio(ci);
            Usuario usuarioFound = this.buscarUsuario(ci);

            if (nuevoSocio == null && usuarioFound!= null && Socio.cedulaValidada(ci) && !this.esVacio(nombre) && !this.esVacio(dir) && !this.esVacio(mail) && this.esEntero(tel) && !this.esVacio(contacto))
            {

                socios.Add(new ProtectoraAnimales(ci, nombre, dir, mail, tel, usuarioFound, contacto));
                alta = true;

            }
            return alta;
        }


        // Metodo que busca en la lista Socios si existe socio con el documento que se le pasa por parametros

        public Socio buscarSocio(string ci)
        {

            Socio socio = null;
            int i = 0;
            bool flag = false;

            while (i < socios.Count && !flag)
            {

                if (socios[i].CedulaSocio == ci)
                {

                    socio = socios[i];
                    flag = true;

                }
                i++;
            }
            return socio;

        }

        /*Buscar Usuario*/
        public Usuario buscarUsuario(string username)
        {

            Usuario usuario = null;
            int i = 0;
            bool flag = false;

            while (i < usuarios.Count && !flag)
            {

                if (usuarios[i].Username == username)
                {

                    usuario = usuarios[i];
                    flag = true;

                }
                i++;
            }
            return usuario;

        }

        /*Alta de Mascota*/

        public bool altaMascota(string socioCI, string nombre, string especie, string raza, string sexo, DateTime fechaNacimiento, string foto)
        {

            bool alta = false;
            Socio socio = this.buscarSocio(socioCI);
            if (socio != null && !this.esVacio(nombre) && !this.esVacio(especie) && !this.esVacio(raza) && !this.esVacio(sexo) && !this.fechaMenorActual(fechaNacimiento))
            {
                socio.altaMascota(nombre, especie, raza, sexo, fechaNacimiento, foto);
                alta = true;
            }
            
            return alta;
        }

        /*Socios por mascotas return@string*/

        public string listadoMascotasPorSocio(string socioCI)
        {

            string listado = "Vacio";
            Socio socio = this.buscarSocio(socioCI);
            listado = socio.listadoMascota();
            return listado;
        }

        /*Listado de Mascotas por Socio return@ objeto*/
        public List<Mascota> listadoMascotasPorSocioOBJ(string nroSocio)
        {
            Socio socio = this.buscarSocio(nroSocio);
            List<Mascota> listaMascotaSocio = new List<Mascota>();

            listaMascotaSocio = socio.listadoMascotaPorSocio();

            return listaMascotaSocio;
        }


        // Alta Veterinario 

        public bool altaVeterinario(int nroLicencia, string nombre, DateTime fechaG, int grado) {

            bool alta = false;

            Veterinario nuevoVeterinario = this.buscarVeterinario(nroLicencia);
            string username = nroLicencia.ToString();
            Usuario usuarioFound = this.buscarUsuario(username);

            if (nuevoVeterinario == null && usuarioFound != null && this.esEntero(nroLicencia) && !this.esVacio(nombre) && !this.fechaMenorActual(fechaG) && Veterinario.gradoValidado(grado)) { 

            veterinarios.Add(new Veterinario(nroLicencia, nombre, fechaG, grado, usuarioFound));
            alta = true;

            }

            return alta;

       }

        // Recorre la lista de veterinarios y busca uno por el nro de licencia

        public Veterinario buscarVeterinario(int nroLicencia) {

            Veterinario vet = null;
            int i = 0;
            bool flag = false;

            while (i < veterinarios.Count && !flag) {

                if (veterinarios[i].NroLicencia == nroLicencia) {

                    vet = veterinarios[i];
                    flag = true;

               }
                i++;
            }
            return vet;

        }

        // Recorre la lista de patologias y busca uno por el nro de patologia

        public Patologia buscarPatologia(int codigo)
        {

            Patologia pat = null;
            int i = 0;
            bool flag = false;

            while (i < patologias.Count && !flag)
            {

                if (patologias[i].Codigo == codigo)
                {

                    pat = patologias[i];
                    flag = true;

                }
                i++;
            }
            return pat;

        }

        /*Listado de Socios*/
        public string listadoSocios()
        {
            string listado = "";
            foreach (Socio socio in socios)
            {
                listado += socio.ToString();
            }
            return listado;
        }

        /*Listado Veterinarios*/
        public string listadoVeterinarios()
        {
            string listado = "";
            foreach (Veterinario veterinario in veterinarios)
            {
                listado += veterinario.ToString();
            }
            return listado;
        }

        // Método para cargar veterinarios

        public void cargarVeterinarios() {
            Usuario u1 = new Usuario("0001", "1", "Veterinario");
            Usuario u2 = new Usuario("0002", "1", "Veterinario");
            Usuario u3 = new Usuario("0003", "1", "Veterinario");
            Usuario u4 = new Usuario("0004", "1", "Veterinario");
            usuarios.Add(u1);
            usuarios.Add(u2);
            usuarios.Add(u3);
            usuarios.Add(u4);

            DateTime fecha1 = Convert.ToDateTime("10-04-2006");
            DateTime fecha2 = Convert.ToDateTime("07-08-2009");
            DateTime fecha3 = Convert.ToDateTime("06-12-2001");
            DateTime fecha4 = Convert.ToDateTime("04-05-2007");

            Veterinario vet1 = new Veterinario(0001, "Laura", fecha1 , 3, u1);
            Veterinario vet2 = new Veterinario(0002, "Marcos", fecha2, 1, u2);
            Veterinario vet3 = new Veterinario(0003, "Roberto", fecha3, 5, u3);
            Veterinario vet4 = new Veterinario(0004, "Florencia",fecha4, 2, u4);
            veterinarios.Add(vet1);
            veterinarios.Add(vet2);
            veterinarios.Add(vet3);
            veterinarios.Add(vet4);

        }
        /*Cargar Usuarios*/
        public void cargarUsuarios()
        {

            Usuario u1 = new Usuario("admin", "admin", "Administrador");
            Usuario u2 = new Usuario("1", "1", "Veterinario");
            Usuario u3 = new Usuario("43513050", "1", "Socio");
            Usuario u4 = new Usuario("43513051", "1", "Socio");
            Usuario u5 = new Usuario("11111111", "1", "Socio");
            Usuario u6 = new Usuario("22222222", "1", "Socio");
            Usuario u7 = new Usuario("33333333", "1", "Socio");
            Usuario u8 = new Usuario("44444444", "1", "Socio");
            usuarios.Add(u1);
            usuarios.Add(u2);
            usuarios.Add(u3);
            usuarios.Add(u4);
            usuarios.Add(u5);
            usuarios.Add(u6);
            usuarios.Add(u7);
            usuarios.Add(u8);
            this.cargarSocio(u3, u4, u5, u6, u7, u8);
        }

        /*Cargar Usuarios*/
        public void cargarSocio(Usuario usuario1, Usuario usuario2, Usuario usuario3, Usuario usuario4, Usuario usuario5, Usuario usuario6)
        {

            Socio s1 = new SocioRegular("43513050", "Diego", "Test", "mail@test.com", 55545645, usuario1, "Tarjeta");
            socios.Add(s1);
            Socio s2 = new ProtectoraAnimales("43513051", "Fernanda", "Test1", "mail2@test.com", 55545645, usuario2, "PersonaContacto");
            socios.Add(s2);

            Socio s3 = new SocioRegular("11111111", "Michel", "Reconquista 324", "mcamarotta@gmail.com", 099230816, usuario3, "Tarjeta");
            socios.Add(s3);
            Socio s4 = new ProtectoraAnimales("22222222", "Juan", "Canelones 1234", "juancho@gmail.com", 44454587, usuario4, "Marta");
            socios.Add(s4);

            Socio s5 = new SocioRegular("33333333", "Julia", "Maldonado 4321", "julita@yahoo.com", 088745478, usuario5, "Tarjeta");
            socios.Add(s5);
            Socio s6 = new ProtectoraAnimales("44444444", "Animales sin hogar", "Colonia 5544", "ash@ong.com", 028887474, usuario6, "Animales ORG");
            socios.Add(s6);

            /*Cargo Algunas Mascotas*/
            DateTime fecha1 = Convert.ToDateTime("10-04-2006");
            DateTime fecha2 = Convert.ToDateTime("07-08-2009");
            DateTime fecha3 = Convert.ToDateTime("06-12-2001");
            Mascota m1 = new Mascota("Juancho", "Lagartija", "Reptil", "Masculino", fecha1, "");
            Mascota m2 = new Mascota("Fito", "Perro", "Ovejero", "Masculino", fecha2, "");
            Mascota m3 = new Mascota("Mecha", "Gato", "Siames", "Femenino", fecha3, "");
            s3.cargarMascota(m1);
            s3.cargarMascota(m2);
            s4.cargarMascota(m3);

        }
        /*Cargar Patologias*/
        public void cargarPatologias() {
            Patologia p1 = new Patologia("Traumatismo", "Golpe y traumatismo en alguna parte");
            Patologia p2 = new Patologia("Pulgas", "Desparasitar, comunmente en Verano");
            patologias.Add(p1);
            patologias.Add(p2);
        }

        /*Validaciones*/

        // Campo vacío

        public bool esVacio(string texto){
            bool resultado = false;
            if (string.IsNullOrWhiteSpace(texto))
            {
                resultado = true;
            }
            return resultado;
        }

        
        // Fecha menor a la actual

        public bool fechaMenorActual(DateTime fecha)
        {
            bool resultado = false;
            DateTime hoy = DateTime.Now;
            if (fecha > hoy)
            {
                resultado = true;
            }
            return resultado;
        }

       
        // Es entero

        public bool esEntero(int valor)
        {
            bool resultado = false;
            if (valor > 0)
            {
                resultado = true;
            }
            return resultado;
        }

    

        /*Login Metodos*/
        public string autenticate(string username, string password)
        {
            string resultado = null;
            Usuario usuario = this.buscarUsuario(username);
            if (usuario != null)
            {
                resultado = usuario.validarPassword(password);
            }

            return resultado;
        }

        /*Alta Usuarios*/

        public bool altaUsuario(string username, string password, string tipoUser)
        {

            bool alta = false;

            Usuario nuevoUsuario = this.buscarUsuario(username);

            if (nuevoUsuario == null && !this.esVacio(username) && !this.esVacio(password) && !this.esVacio(tipoUser))
            {

                usuarios.Add(new Usuario(username, password, tipoUser));
                alta = true;

            }
            return alta;
        }

        /*Modificar Usuario*/

        public bool modificarUsuario(string username, string password)
        {

            bool alta = false;

            Usuario usuario = this.buscarUsuario(username);

        //    if (usuario != null && !this.esVacio(username) && !this.esVacio(password))

                if (!this.esVacio(password))
            {
                usuario.modificarUsuario(password);
                alta = true;

            }
            return alta;
        }

        /*Alta Patologia*/

        public bool altaPatologia(string titulo, string descripcion)
        {

            bool alta = false;

            Patologia nuevaPatologia = null;

            if (nuevaPatologia == null && !this.esVacio(titulo) && !this.esVacio(descripcion))
            {

                Patologias.Add(new Patologia(titulo, descripcion));
                alta = true;

            }
            return alta;
        }


        // Modificar el monto base de la cuota de los socios

        public bool establecerMontoBase(double valorMontoBase) {

            bool nuevoValor = false;

            if (valorMontoBase > 0) {
                
                Socio.MontoBase = valorMontoBase;
                nuevoValor = true;
            }

            return nuevoValor;
        }

        // Modificar el valor del descuento de las protectoras de Animales

        public bool establecerDescuentoProtectoras(double descuentoProtectoras) {

            bool nuevoValor = false;

            if (descuentoProtectoras > 0) {

                ProtectoraAnimales.ValorDescuento = descuentoProtectoras;
                nuevoValor = true;
            }
            return nuevoValor;
        }

        /*Alta Historia Clinica*/

        public bool altaHistoriaClinica(string ci, int mascota, DateTime fechaPrimeraRev, string revision, int veterinarioNro)
        {

            bool alta = false;

            Socio socio = this.buscarSocio(ci);

            Veterinario vet = this.buscarVeterinario(veterinarioNro);

            if (socio != null && vet != null && Socio.cedulaValidada(ci))
            {

                alta = socio.altaHistoriaClinica(mascota, fechaPrimeraRev, revision, vet);

            }
            return alta;
        }

        /*Alta Cuadro Clinico*/

        public bool altaCuadroClinico(string ci, int mascota, DateTime fechaConsulta, string motivo, string diagnostico, string estado, int posiblePatologia, int veterinarioNro)
        {

            bool alta = false;

            Socio socio = this.buscarSocio(ci);

            Veterinario vet = this.buscarVeterinario(veterinarioNro);

            Patologia patologia = this.buscarPatologia(posiblePatologia);

            if (socio != null && vet != null && Socio.cedulaValidada(ci))
            {

                alta = socio.altaCuadroClinico(mascota, fechaConsulta, motivo, diagnostico, estado, patologia, vet);

            }
            return alta;
        }

        /*Listado Cuadro Clinico*/
        public List<CuadroClinico> listadoCuadroClinicoEnCurso(string nroSocio, int nroMascota, bool todos)
        {
            List<CuadroClinico> listaCuadroClinicos = new List<CuadroClinico>();
            Socio socio = this.buscarSocio(nroSocio);

            listaCuadroClinicos = socio.listadoCuadroClinicoEnCurso(nroMascota, todos);

            return listaCuadroClinicos;
        }

        /*Alta Accion en Cuadro*/
        public bool altaAccionCuadro(string nroSocio, int nroMascota, string motivoCuadro, string accion)
        {
            bool resultado = false;
            Socio socio = this.buscarSocio(nroSocio);
            if (socio.altaAccionCuadro(nroMascota, motivoCuadro, accion))
            {
                resultado = true;
            }

            return resultado;
        }

        /*Fin Cuadro Clinico*/
        public bool finCuadroClinico(string nroSocio, int nroMascota, string motivoCuadro, string NuevoMotivo, bool checkFinalizado)
        {
            bool resultado = false;
            Socio socio = this.buscarSocio(nroSocio);
            if (socio.finCuadroClinico(nroMascota, motivoCuadro, NuevoMotivo, checkFinalizado)) {
                resultado = true;
            }

            return resultado;
        }

        /*Listado Acciones*/
        public List<string> verAcciones(string nroSocio, int nroMascota, string motivoCuadro)
        {
            List<string> listado = null;
            Socio socio = this.buscarSocio(nroSocio);
            listado = socio.verAcciones(nroMascota, motivoCuadro);
            
            return listado;
        }

        /*Listado Acciones por motivo*/
        public string verMotivo(string nroSocio, int nroMascota, string motivoCuadro)
        {
            string motivo = null;
            Socio socio = this.buscarSocio(nroSocio);
            motivo = socio.verMotivo(nroMascota, motivoCuadro);

            return motivo;
        }

        // listado de socios mas su cuota 
        public List<String> InfoCompletaSocios()
        {

            List<String> informacionCompletaSocios = new List<String>();
            string fichaSocio = "";

            foreach (Socio socio in socios)
            {
                string cuotaMensual = socio.calcularCuotaMensual();
                string mascotas = socio.listadoMascota();
                fichaSocio = socio.ToString() + cuotaMensual + mascotas;
                informacionCompletaSocios.Add(fichaSocio);
            }

            return informacionCompletaSocios;

        }

        /*Listado de Veterinarios Ordenados*/
        public List<VeterinarioCuadroListado> VeterinariosOrdenados()
        {
            List<VeterinarioCuadroListado> vetOrden = new List<VeterinarioCuadroListado>();

            foreach (Veterinario veterinario in veterinarios)
            {
                int cantidadDeCuadro = 0;
                foreach (Socio socio in socios)
                {
                    cantidadDeCuadro += socio.vetOrdenadosPorCuadro(veterinario);
                }
                /*Struct Auxiliar*/
                vetOrden.Add(new VeterinarioCuadroListado(veterinario, cantidadDeCuadro));
            }

            vetOrden.Sort();
            return vetOrden;
        }


        #endregion


    }
}
