using Lanchonete.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index() {

            var pedidoBLL = new PedidoBLL();
            var listaPedidos = pedidoBLL.GetListaPedidos();

            return View(listaPedidos);
        }

        public IActionResult Criar() {

            var lancheBLL = new LancheBLL();
            var listaLanches = lancheBLL.GetListaLanches();

            var ingredientesBLL = new IngredienteBLL();
            ViewBag.ListaIngredientes = ingredientesBLL.GetListaIngredientes();

            return View(listaLanches);
        }

        [HttpGet]
        public JsonResult ActionGetLanche(int idLanche) {
            var lancheBLL = new LancheBLL();

            return Json(new {
                success = true,
                lanche = lancheBLL.GetLanche(idLanche)
            });
        }
    }
}
