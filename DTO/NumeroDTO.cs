using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quinelero.DTO
{
    class NumeroDTO
    {
        private string numero;
        private int vecesSeleccionado;

        public NumeroDTO(string numero, int vecesSeleccionado)
        {
            this.numero = numero;
            this.vecesSeleccionado = vecesSeleccionado;
        }

        public string Numero { get => numero; set => numero = value; }
        public int VecesSeleccionado { get => vecesSeleccionado; set => vecesSeleccionado = value; }
    }
}
