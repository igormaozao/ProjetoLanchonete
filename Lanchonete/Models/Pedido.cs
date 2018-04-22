using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Models {
    public class Pedido {

        public uint Id { get; set; }
        public List<Lanche> Lanches { get; set; }

        public decimal ValorTotal {
            get {
                decimal valorTotalLanches = 0.0m;
                Lanches.ForEach(i => valorTotalLanches += i.ValorTotal);

                return valorTotalLanches;
            }
        }

        public Pedido() { Lanches = new List<Lanche>(); }
    }
}
