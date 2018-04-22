using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Lanchonete.Models.Enums;

namespace Lanchonete.Models {
    public class Ingrediente {

        public uint Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public ETipoAlimento Tipo { get; set; }

        public Ingrediente() { Quantidade = 1; }

        public Ingrediente Clone() {
            return new Ingrediente {
                Id = this.Id,
                Nome = this.Nome,
                Valor = this.Valor,
                Quantidade = this.Quantidade,
                Tipo = this.Tipo
            };
        }
    }
}
