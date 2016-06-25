using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinariaDominio
{
    public struct VeterinarioCuadroListado:IComparable<VeterinarioCuadroListado>
    {
        private Veterinario veterinario;
        private int cantidadDeCuadros;

        /*Constructor*/
        public VeterinarioCuadroListado(Veterinario vet, int nrCuadros)
        {

            this.veterinario = vet;
            this.cantidadDeCuadros = nrCuadros;
        }

        public int CompareTo(VeterinarioCuadroListado a) {
            return this.cantidadDeCuadros.CompareTo(a.cantidadDeCuadros) * -1;
        }

        public override string ToString()
        {
            return veterinario.ToString();
        }
    }
}
