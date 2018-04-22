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
                Ingredientes.ForEach(i => valorTotalIngredientes += i.Valor * i.Quantidade);

                return valorTotalIngredientes;
            }
        }

        public decimal ValorDesconto {
            get {
                decimal desconto = 0;

                if (Promocao == ETipoPromocao.Light) {
                    if(Ingredientes.Any(i => i.Nome == "Alface") 
                        && !Ingredientes.Any(i => i.Nome == "Bacon")) {
                        desconto = Valor * 0.1m; //10% de desconto no valor total do lanche
                    }
                }
                else if (Promocao == ETipoPromocao.MuitaCarne) {
                    Ingredientes.ForEach(i => {
                        if(i.Tipo == ETipoAlimento.Carne && i.Quantidade >= 3) {
                            desconto += i.Valor * (i.Quantidade / 3);
                        }
                    });
                }
                else if (Promocao == ETipoPromocao.MuitoQueijo) {
                    Ingredientes.ForEach(i => {
                        if(i.Tipo == ETipoAlimento.Queijo && i.Quantidade >= 3) {
                            desconto += i.Valor * (i.Quantidade / 3);
                        }
                    });
                }

                return desconto;
            }
        }

        public decimal ValorTotal {
            get {
                return Valor - ValorDesconto;
            }
        }

        public Lanche Clone() {
            return new Lanche {
                Id = this.Id,
                Nome = this.Nome,
                Ingredientes = this.Ingredientes,
                Promocao = this.Promocao
            };
        }
    }
}