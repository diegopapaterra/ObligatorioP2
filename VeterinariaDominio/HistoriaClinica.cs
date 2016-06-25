using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    public class HistoriaClinica
    {

        #region Atributos

        private DateTime fechaIngreso;
        private string primeraRevision;
        private Veterinario primerVeterinario;
        private List<CuadroClinico> posiblePatologia = new List<CuadroClinico>();

        #endregion

        #region Propertys

        #endregion

        #region Constructor

        public HistoriaClinica (DateTime fechaIngreso, string primerRev, Veterinario vet)
        {

            this.fechaIngreso = fechaIngreso;
            this.primeraRevision = primerRev;
            this.primerVeterinario = vet;
        }

        #endregion

        #region Métodos

        public bool altaCuadroClinico(DateTime fechaConsulta, string motivo, string diagnostico, string estado, Patologia patologia, Veterinario vet) {
            bool resultado = false;
            posiblePatologia.Add(new CuadroClinico(fechaConsulta, vet, motivo, diagnostico, estado, patologia));
            resultado = true;
            return resultado;
        }

        /*Listado Cuadro Clinico*/
        public List<CuadroClinico> listadoCuadroClinicoEnCurso(bool todos)
        {

            List<CuadroClinico> listaCuadroClinicos = new List<CuadroClinico>();

            foreach (CuadroClinico posiblePatologia in posiblePatologia)
            {
                if (todos)
                {
                    listaCuadroClinicos.Add(posiblePatologia);
                }
                else
                {
                    if (posiblePatologia.Estado == "En Curso")
                    {
                        listaCuadroClinicos.Add(posiblePatologia);
                    }
                }
                
            }

            return listaCuadroClinicos;
        }

        /*Alta Accion en Cuadro*/
        public bool altaAccionCuadro(string motivoCuadro, string accion)
        {
            bool resultado = false;
            foreach (CuadroClinico posiblePatologia in posiblePatologia)
            {
                if (posiblePatologia.Motivo == motivoCuadro)
                {
                    posiblePatologia.altaAccionCuadro(accion);
                    resultado = true;
                }
            }

            return resultado;
        }

        /*Fin Cuadro Clinico*/
        public bool finCuadroClinico(string motivoCuadro, string motivoFinalizado, bool checkFinalizado)
        {
            bool resultado = false;
            if (checkFinalizado)
            {
                foreach (CuadroClinico posiblePatologia in posiblePatologia)
                {
                    if (posiblePatologia.Motivo == motivoCuadro)
                    {
                        posiblePatologia.MotivoCierreCuadro = motivoFinalizado;
                        posiblePatologia.Estado = "Finalizado";
                        resultado = true;
                    }
                }
            }

            return resultado;
        }

        /*Listado Acciones*/
        public List<string> verAcciones(string motivoCuadro)
        {
            List<string> listado = null;
            foreach (CuadroClinico posiblePatologia in posiblePatologia)
            {
                if (posiblePatologia.Motivo == motivoCuadro)
                {
                    listado = posiblePatologia.verAcciones();
                }
            }
            return listado;
        }

        /*Listado Acciones por motivo*/
        public string verMotivo(string motivoCuadro)
        {
            string motivo = null;
            foreach (CuadroClinico posiblePatologia in posiblePatologia)
            {
                if (posiblePatologia.Motivo == motivoCuadro)
                {
                    motivo = posiblePatologia.verMotivo();
                }
            }
            return motivo;
        }

        /*Orden de Vet por cuadro*/
        public int vetOrdenadosPorCuadro(Veterinario vet)
        {
            int cantidad = 0;
            foreach (CuadroClinico unCuadro in posiblePatologia)
            {
                if (unCuadro.VeterinarioResponsable == vet)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        #endregion
    }
}
