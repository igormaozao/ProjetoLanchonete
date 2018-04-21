using Lanchonete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.BLL {
    public class PedidoBLL : DatabaseBLL {

        public PedidoBLL() : base() { }

        public List<Pedido> GetListaPedidos() {
            return Database.DBPedido.ToList();
        }
    }
}
