using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Lanchonete.Models.Enums;

namespace Lanchonete.Models {
    public class Lanche {

        public uint Id { get; set; }
        public string Nome { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public ETipoPromocao Promocao = ETipoPromocao.Nenhuma;

        public decimal Valor {
            get {

                decimal valorTotalIngredientes = 0.0m;
                Ingredientes.ForEach(i => valorTotalIngredientes += i.Valor);

                return valorTotalIngredientes;
            }
        }

        public decimal ValorDesconto {
            get {

                return 0;
            }
        }

        public decimal ValorTotal {
            get {
                return Valor - ValorDesconto;
            }
        }
    }
}