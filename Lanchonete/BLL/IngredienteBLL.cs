using Lanchonete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.BLL {
    public class IngredienteBLL : DatabaseBLL {

        public IngredienteBLL() : base() { }

        public List<Ingrediente> GetListaIngredientes() {
            return Database.DBIngrediente.ToList();
        }

        public Ingrediente GetIngrediente(string nomeIngrediente) {
            if(!Database.DBIngrediente.Any(i => i.Nome == nomeIngrediente)) {
                throw new Exception("Nome do ingrediente inválido");
            }

            return Database.DBIngrediente.First(i => i.Nome == nomeIngrediente).Clone();
        }
    }
}
