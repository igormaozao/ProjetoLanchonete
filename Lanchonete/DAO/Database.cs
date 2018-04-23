using Lanchonete.Models;
using System.Collections.Generic;
using static Lanchonete.Models.Enums;

namespace Lanchonete.DAO {
    public class Database {

        public List<Pedido> DBPedido { get; set; }
        public List<Ingrediente> DBIngrediente { get; private set; }
        public List<Lanche> DBLanche { get; private set; }

        public Database() {

            DBPedido = new List<Pedido>();

            DBIngrediente = new List<Ingrediente>();
            #region -- Criação dos objetos Ingrediente
            DBIngrediente.Add(new Ingrediente() {
                Id = 1,
                Nome = "Alface",
                Valor = 0.40m,
                Tipo = ETipoAlimento.Vegetal
            });
            DBIngrediente.Add(new Ingrediente() {
                Id = 2,
                Nome = "Bacon",
                Valor = 2.00m,
                Tipo = ETipoAlimento.Carne
            });
            DBIngrediente.Add(new Ingrediente() {
                Id = 3,
                Nome = "Hamburguer de Carne",
                Valor = 3.00m,
                Tipo = ETipoAlimento.Carne
            });
            DBIngrediente.Add(new Ingrediente() {
                Id = 4,
                Nome = "Ovo",
                Valor = 0.80m,
                Tipo = ETipoAlimento.Outros
            });
            DBIngrediente.Add(new Ingrediente() {
                Id = 5,
                Nome = "Queijo",
                Valor = 1.50m,
                Tipo = ETipoAlimento.Queijo
            });
            #endregion

            DBLanche = new List<Lanche>();
            #region -- Criação dos objetos Lanche
            // Ingredientes hardcoded, banco de dados daria esses dados melhor para nós.
            DBLanche.Add(new Lanche() {
                Id = 1,
                Nome = "X-Bacon",
                Ingredientes = new List<Ingrediente>() {
                    DBIngrediente[1], //Bacon
                    DBIngrediente[2], //Hamburguer Carne
                    DBIngrediente[4]  //Queijo
                },
                Promocao = ETipoPromocao.MuitaCarne
            });
            DBLanche.Add(new Lanche() {
                Id = 2,
                Nome = "X-Burger",
                Ingredientes = new List<Ingrediente>() {
                    DBIngrediente[2], //Hamburguer Carne
                    DBIngrediente[4]  //Queijo
                },
                Promocao = ETipoPromocao.MuitoQueijo
            });
            DBLanche.Add(new Lanche() {
                Id = 3,
                Nome = "X-Egg",
                Ingredientes = new List<Ingrediente>() {
                    DBIngrediente[3], //Ovo
                    DBIngrediente[2], //Hamburguer Carne
                    DBIngrediente[4]  //Queijo
                },
                Promocao = ETipoPromocao.Light
            });
            DBLanche.Add(new Lanche() {
                Id = 4,
                Nome = "X-Egg Bacon",
                Ingredientes = new List<Ingrediente>() {
                    DBIngrediente[3], //Ovo
                    DBIngrediente[1], //Bacon
                    DBIngrediente[2], //Hamburguer Carne
                    DBIngrediente[4]  //Queijo
                }
            });
            DBLanche.Add(new Lanche() {
                Id = 5,
                Nome = "Personalizado",
                Ingredientes = new List<Ingrediente>()
            });
            #endregion

        }
    }
}
