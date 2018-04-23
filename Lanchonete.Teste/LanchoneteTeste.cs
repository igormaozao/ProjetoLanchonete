using Lanchonete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Lanchonete.Models.Enums;

namespace Lanchonete.Teste {

    public class LanchoneteTeste {

        [Fact]
        public void TesteValoresOriginais() {

            Lanche lanche = new Lanche() {
                Id = 1,
                Nome = "X-Bacon",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 2, Nome = "Bacon", Valor = 2.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo }
                }
            };
            Assert.True(lanche.ValorTotal == 6.50m, "O valor do lanche X-Bacon não corresponde.");

            lanche = new Lanche() {
                Id = 1,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo }
                }
            };
            Assert.True(lanche.ValorTotal == 4.50m, "O valor do lanche X-Burge não corresponde.");

            lanche = new Lanche() {
                Id = 1,
                Nome = "X-Egg",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 4, Nome = "Ovo", Valor = 0.80m, Tipo = ETipoAlimento.Outros },
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo }
                }
            };
            Assert.True(lanche.ValorTotal == 5.30m, "O valor do lanche X-Egg não corresponde.");

            lanche = new Lanche() {
                Id = 1,
                Nome = "X-Egg Bacon",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 4, Nome = "Ovo", Valor = 0.80m, Tipo = ETipoAlimento.Outros },
                    new Ingrediente() { Id = 2, Nome = "Bacon", Valor = 2.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo }
                }
            };
            Assert.True(lanche.ValorTotal == 7.30m, "O valor do lanche X-Egg Bacon não corresponde.");
        }

        [Fact]
        public void TestePromocaoLight() {
            Lanche lanche = new Lanche() {
                Id = 1,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo }
                }
            };
            Assert.True(lanche.ValorDesconto == 0.0m, "O valor do X-Burger Light não corresponde.");

            lanche = new Lanche() {
                Id = 1,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 1, Nome = "Alface", Valor = 0.40m, Tipo = ETipoAlimento.Vegetal },
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo }
                }
            };

            var valorDesconto = lanche.Ingredientes.Sum(i => i.Valor * i.Quantidade) * 0.10m;
            Assert.True(lanche.ValorDesconto == valorDesconto, "O valor do X-Burger Light não corresponde.");
            Assert.True(lanche.PromocoesAtivas.Any(p => p == "Light"), "O X-Burger não possui a promoção Light quando deveria.");
        }

        [Fact]
        public void TestePromocaoMuitaCarne() {
            Lanche lanche = new Lanche() {
                Id = 1,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne, Quantidade = 2 },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo, Quantidade = 6 }
                }
            };
            var valorDesconto = lanche.ValorDesconto;
            Assert.True(valorDesconto > 0, "O desconto do X-Burger MuitaCarne não corresponde.");
            Assert.False(lanche.PromocoesAtivas.Any(p => p == "Muita Carne"), "O X-Burger possui a promoção MuitaCarne quando não deveria.");

            lanche = new Lanche() {
                Id = 1,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne, Quantidade = 3 },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo, Quantidade = 3 }
                }
            };
            valorDesconto = lanche.ValorDesconto;
            Assert.True(valorDesconto > 0, "O desconto do X-Burger MuitaCarne não corresponde.");
            Assert.True(lanche.PromocoesAtivas.Any(p => p == "Muita Carne"), "O X-Burger não possui a promoção MuitaCarne quando deveria.");
        }

        [Fact]
        public void TestePromocaoMuitoQueijo() {
            Lanche lanche = new Lanche() {
                Id = 1,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne, Quantidade = 2 },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo, Quantidade = 2 }
                }
            };
            var valorDesconto = lanche.ValorDesconto;
            Assert.True(valorDesconto == 0, "O desconto do X-Burger MuitoQueijo não corresponde.");
            Assert.False(lanche.PromocoesAtivas.Any(p => p == "Muito Queijo"), "O X-Burger não possui a promoção MuitoQueijo quando deveria.");

            lanche = new Lanche() {
                Id = 1,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    new Ingrediente() { Id = 3, Nome = "Hamburguer de Carne", Valor = 3.00m, Tipo = ETipoAlimento.Carne, Quantidade = 6 },
                    new Ingrediente() { Id = 5, Nome = "Queijo", Valor = 1.50m, Tipo = ETipoAlimento.Queijo, Quantidade = 4 }
                }
            };
            valorDesconto = lanche.ValorDesconto;
            Assert.True(valorDesconto > 0, "O desconto do X-Burger MuitoQueijo não corresponde.");
            Assert.True(lanche.PromocoesAtivas.Any(p => p == "Muito Queijo"), "O X-Burger não possui a promoção MuitoQueijo quando deveria.");

        }
    }
}
