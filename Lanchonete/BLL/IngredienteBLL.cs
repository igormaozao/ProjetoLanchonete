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
    }
}
