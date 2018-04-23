using Lanchonete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Lanchonete.Models.Enums;

namespace Lanchonete.BLL {
    public class LancheBLL : DatabaseBLL {

        public LancheBLL() : base() { }

        public List<Lanche> GetListaLanches() {
            return Database.DBLanche.ToList();
        }

        public Lanche GetLanche(int idLanche) {
            if (!Database.DBLanche.Any(l => l.Id == idLanche)) {
                throw new Exception("Lanche inválido");
            }

            return Database.DBLanche.First(l => l.Id == idLanche).Clone();
        }

        public Lanche GetLanche(string nomeLanche) {
            if (!Database.DBLanche.Any(l => l.Nome == nomeLanche)) {
                throw new Exception("Lanche inválido");
            }

            return Database.DBLanche.First(l => l.Nome == nomeLanche).Clone();
        }

    }
}
