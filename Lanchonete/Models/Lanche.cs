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
        public List<string> PromocoesAtivas = new List<string>();

        public decimal Valor {
            get {

                decimal valorTotalIngredientes = 0.0m;
                Ingredientes.ForEach(i => valorTotalIngredientes += i.Valor * i.Quantidade);

                return valorTotalIngredientes;
            }
        }

        public decimal ValorDesconto {
            get {
                return CalcularDesconto();
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
                PromocoesAtivas = this.PromocoesAtivas
            };
        }

        public decimal CalcularDesconto() {
            decimal desconto = 0;
            PromocoesAtivas.Clear();

            // Desconto promoção Muita Carne
            Ingredientes.ForEach(i => {
                if (i.Tipo == ETipoAlimento.Carne && i.Quantidade >= 3) {
                    desconto += i.Valor * (i.Quantidade / 3);
                    if (!PromocoesAtivas.Any(p => p == "Muita Carne")) PromocoesAtivas.Add("Muita Carne");
                }
            });

            // Desconto promoção Muito Queijo
            Ingredientes.ForEach(i => {
                if (i.Tipo == ETipoAlimento.Queijo && i.Quantidade >= 3) {
                    desconto += i.Valor * (i.Quantidade / 3);
                    if (!PromocoesAtivas.Any(p => p == "Muito Queijo")) PromocoesAtivas.Add("Muito Queijo");
                }
            });

            // Desconto promoção Light
            if (Ingredientes.Any(i => i.Nome == "Alface")
                && !Ingredientes.Any(i => i.Nome == "Bacon")) {
                desconto = Valor * 0.1m; //10% de desconto no valor total do lanche
                PromocoesAtivas.Add("Light");
            }

            return desconto;
        }
    }
}