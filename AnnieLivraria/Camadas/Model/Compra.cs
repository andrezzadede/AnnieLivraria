using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnieLivraria.Camadas.Model
{
    public class Compra
    {
        public int id { get; set; }
        public int Livro { get; set; }
        public int Cliente { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
        
        
    }
}
