//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VeterinariaDominio;

//namespace VeterinariaWeb
//{

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            bool exit = false;
//            while (!exit)
//            {
//                // Menu //
//                Console.WriteLine("--------------------------------------------------");
//                Console.WriteLine("~~ Menu Principal ~~");
//                Console.WriteLine("1. Alta de Socio Regular");
//                Console.WriteLine("2. Alta de Socio Protectora de Animales");
//                Console.WriteLine("3. Alta de Mascota");
//                Console.WriteLine("4. Alta de Veterinario");
//                Console.WriteLine("5. Listado de Socios y Mascotas");
//                Console.WriteLine("6. Listado de Veterinarios");
//                Console.WriteLine("7. Salir");

//                Console.WriteLine("Seleccione una opcion");
//                int opcion = 0;
//                int.TryParse(Console.ReadLine(), out opcion);

//                switch (opcion) // Segun el valor de opcion se ejecuta determinado metodo
//                {

//                    case 1:

//                        Console.WriteLine(altaSocioRegular());

//                        break;

//                    case 2:
//                        Console.WriteLine(altaSocioProtectora());
//                        break;

//                    case 3:
//                        Console.WriteLine(altaDeMascota());
//                        break;

//                    case 4:
//                        Console.WriteLine(altaVeterinario());
//                        break;

//                    case 5:
//                        obtenerListadoDeSociosYmascotas();
//                        break;

//                    case 6:
//                        listadoVeterinarios();
//                        break;

//                    case 7:
//                        salir();
//                        exit = true;
//                        break;

//                }
//            }
//        }

//        private static void salir()
//        {
//            Console.Clear();
//        }

//        // Alta Socio Regular

//        private static Resultados altaSocioRegular()
//        {

//            Console.WriteLine("** Alta de Socio Regular **");
//            Console.WriteLine("Ingrese cedula de identidad");
//            string ci = Console.ReadLine();

//            Console.WriteLine("Ingrese el nombre de usuario");
//            string nombre = Console.ReadLine();

//            Console.WriteLine("Ingrese una direccion");
//            string dir = Console.ReadLine();

//            Console.WriteLine("Ingrese una direccion de mail");
//            string mail = Console.ReadLine();

//            Console.WriteLine("Ingrese un numero de telefono");
//            int tel = 0;
//            int.TryParse(Console.ReadLine(), out tel);

//            Console.WriteLine("Ingrese una forma de pago (Efectivo o Tarjeta)");
//            string formaPago = Console.ReadLine();

//            if (cedulaValidada(ci) && !esVacio(nombre) && !esVacio(dir) && !esVacio(mail) && esEntero(tel) && !esVacio(formaPago))
//            {
//                if (Veterinaria.Instancia.altaSocioRegular(ci, nombre, dir, mail, tel, formaPago))
//                {

//                    return Resultados.ElSocioSeHaDadoDeAltaCorrectamente;
//                }
//                else
//                {

//                    return Resultados.DatosInvalidos;

//                }
//            }
//            else
//            {
//                return Resultados.DatosInvalidos;
//            }

//        }

//        /*Alta Socio Protectora*/
//        private static Resultados altaSocioProtectora()
//        {

//            Console.WriteLine("** Alta de Socio Protectora **");
//            Console.WriteLine("Ingrese cedula de identidad");
//            string ci = Console.ReadLine();

//            Console.WriteLine("Ingrese el nombre de usuario");
//            string nombre = Console.ReadLine();

//            Console.WriteLine("Ingrese una direccion");
//            string dir = Console.ReadLine();

//            Console.WriteLine("Ingrese una direccion de mail");
//            string mail = Console.ReadLine();

//            Console.WriteLine("Ingrese un numero de telefono");
//            int tel = 0;
//            int.TryParse(Console.ReadLine(), out tel);

//            Console.WriteLine("Ingrese persona de Contacto");
//            string contacto = Console.ReadLine();

//            if (cedulaValidada(ci) && !esVacio(nombre) && !esVacio(dir) && !esVacio(mail) && esEntero(tel) && !esVacio(contacto))
//            {
//                if (Veterinaria.Instancia.altaSocioProtectora(ci, nombre, dir, mail, tel, contacto))
//                {

//                    return Resultados.ElSocioSeHaDadoDeAltaCorrectamente;
//                }
//                else
//                {

//                    return Resultados.DatosInvalidos;

//                }
//            }
//            else
//            {
//                return Resultados.DatosInvalidos;
//            }



//        }

//        /*Alta de Mascota con Socio*/
//        private static Resultados altaDeMascota()
//        {

//            Console.WriteLine("Alta de Mascota");
//            Console.WriteLine(Veterinaria.Instancia.listadoSocios());
//            Console.WriteLine("Ingrese numero de socio");
//            string socioCI = Console.ReadLine();

//            Console.WriteLine("Ingrese nombre de la mascota");
//            string nombre = Console.ReadLine();

//            Console.WriteLine("Ingrese la especie");
//            string especie = Console.ReadLine();

//            Console.WriteLine("Ingrese la raza");
//            string raza = Console.ReadLine();

//            Console.WriteLine("Ingrese el sexo");
//            string sexo = Console.ReadLine();

//            Console.WriteLine("Ingrese la fecha de nacimiento");
//            DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());

//            Console.WriteLine("Ingrese foto de la mascota");
//            string foto = Console.ReadLine();


//            if (Veterinaria.Instancia.altaMascota(socioCI, nombre, especie, raza, sexo, fechaNacimiento, foto))
//            {
//                return Resultados.MascotaAsignada;
//            }
//            else
//            {
//                return Resultados.DatosInvalidos;
//            }




//        }


//        // Alta Veterinario

//        private static Resultados altaVeterinario()
//        {

//            Console.WriteLine("** Alta de Veterinario **");
//            Console.WriteLine("Ingrese el número de licencia del veterinario");
//            int nroLicencia = 0;
//            int.TryParse(Console.ReadLine(), out nroLicencia);

//            Console.WriteLine("Ingrese el nombre del veterinario");
//            string nombreVeterinario = Console.ReadLine();

//            Console.WriteLine("Ingrese la fecha de graduación");
//            DateTime fechaGraduacion = Convert.ToDateTime(Console.ReadLine());

//            Console.WriteLine("Ingrese el grado");
//            int grado = 0;
//            int.TryParse(Console.ReadLine(), out grado);


//            if (Veterinaria.Instancia.altaVeterinario(nroLicencia, nombreVeterinario, fechaGraduacion, grado))
//            {

//                return Resultados.VeterinarioSeHaDadoDeAlta;
//            }
//            else {

//                return Resultados.DatosInvalidos;
//            }



//        }

//        /*Metodo que segun un socio muestra todas sus mascotas asignadas*/

//        private static void obtenerListadoDeSociosYmascotas()
//        {
//            Console.WriteLine("** Listado de Socios **");
//            Console.WriteLine(Veterinaria.Instancia.listadoSocios());
//            Console.WriteLine("Ingrese numero de socio: ");
//            string socioCI = Console.ReadLine();

//            if (cedulaValidada(socioCI))
//            {
//                Console.WriteLine(Veterinaria.Instancia.listadoMascotasPorSocio(socioCI));
//            }
//            else
//            {
//                Console.WriteLine("DatosInvalidos");
//            }

//        }

//        /*Listado Veterinarios*/
//        private static void listadoVeterinarios()
//        {
//            Console.WriteLine(Veterinaria.Instancia.listadoVeterinarios());
//        }

//        /*Validaciones en la interfaz*/
//        public static bool esVacio(string texto)
//        {
//            bool resultado = false;
//            if (string.IsNullOrWhiteSpace(texto))
//            {
//                resultado = true;
//            }
//            return resultado;
//        }

//        public static bool fechaMenorActual(DateTime fecha)
//        {
//            bool resultado = false;
//            DateTime hoy = DateTime.Now;
//            if (fecha > hoy)
//            {
//                resultado = true;
//            }
//            return resultado;
//        }

//        public static bool cedulaValidada(string texto)
//        {
//            bool resultado = false;
//            if (texto.Length > 6 && texto.Length < 9)
//            {
//                resultado = true;
//            }
//            return resultado;
//        }

//        public static bool esEntero(int valor)
//        {
//            bool resultado = false;
//            if (valor > 0)
//            {
//                resultado = true;
//            }
//            return resultado;
//        }

//        public static bool gradoValidado(int grado)
//        {
//            bool resultado = false;
//            if (grado > 0 && grado < 6)
//            {
//                resultado = true;
//            }
//            return resultado;
//        }


//    }
//}

