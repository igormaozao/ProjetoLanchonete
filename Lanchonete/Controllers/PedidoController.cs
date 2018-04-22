using Lanchonete.BLL;
using Lanchonete.Models;
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

        [HttpPost]
        public JsonResult ActionCalcularDescontoLanche(Lanche lanche) {
            var lancheBLL = new LancheBLL();
            var ingredienteBLL = new IngredienteBLL();

            var novoLanche = lancheBLL.GetLanche(lanche.Nome);
            novoLanche.Ingredientes.Clear();

            // Adiciona os ingredientes de acordo com o "banco de dados" por segurança
            lanche.Ingredientes.ForEach(i => {
                var ingrediente = ingredienteBLL.GetIngrediente(i.Nome);
                ingrediente.Quantidade = i.Quantidade;
                novoLanche.Ingredientes.Add(ingrediente);
            });

            return Json(new {
                success = true,
                lanche = novoLanche
            });
        }

        public JsonResult ActionCriarPedido(List<Lanche> lanchesPedido) {

            var lancheBLL = new LancheBLL();
            var ingredienteBLL = new IngredienteBLL();

            Pedido novoPedido = new Pedido();

            foreach (var lanche in lanchesPedido) {

                var novoLanche = lancheBLL.GetLanche(lanche.Nome);
                novoLanche.Ingredientes.Clear();

                // Adiciona os ingredientes de acordo com o "banco de dados" por segurança
                lanche.Ingredientes.ForEach(i => {
                    var ingrediente = ingredienteBLL.GetIngrediente(i.Nome);
                    ingrediente.Quantidade = i.Quantidade;
                    novoLanche.Ingredientes.Add(ingrediente);
                });

                novoPedido.Lanches.Add(novoLanche);
            }

            var pedidoBLL = new PedidoBLL();
            pedidoBLL.SalvarPedido(novoPedido);

            return Json(new { success = true });
        }

    }
}
