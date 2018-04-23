using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Lanchonete.BLL;
using Lanchonete.Models;

namespace Lanchonete.Controllers {

    public class PromocaoController : Controller {

        public IActionResult Index() {

            var lancheBLL = new LancheBLL();
            var listaLanches = lancheBLL.GetListaLanches();

            ViewBag.PromocoesList = Enum.GetValues(typeof(Enums.ETipoPromocao)).Cast<Enums.ETipoPromocao>().ToList();
            
            return View(listaLanches);
        }

        [HttpPost]
        public JsonResult ActionAlterarPromocaoLanche(int idLanche, string nomePromocao) {

            //var lancheBLL = new LancheBLL();
            //lancheBLL.SetPromocaoLanche(idLanche, nomePromocao);

            return Json(new {
                success = true
            });
        }
    }
}
