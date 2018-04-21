using Lanchonete.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.BLL {
    public abstract class DatabaseBLL {

        protected static Database Database { get; private set; }

        protected DatabaseBLL() {
            if (Database == null) {
                Database = new Database();
            }
        }
    }
}
