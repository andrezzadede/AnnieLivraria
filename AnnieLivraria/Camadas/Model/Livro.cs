using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnieLivraria.Camadas.Model
{
    public class Livro
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public DateTime DataLancamento { get; set; }
        public float Valor { get; set; }
    }
}

