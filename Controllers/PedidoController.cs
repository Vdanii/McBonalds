using System;
using MCBONALDSMVC.Models;
using MCBONALDSMVC.Repositorio;
using MCBONALDSMVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCBONALDSMVC.Controllers
{
    public class PedidoController : Controller
    {
        PedidoRepoditory pedidoRepoditory = new PedidoRepoditory();
        HamburguerRepository HamburguerRepository = new HamburguerRepository();
        ShakeRepository ShakeRepository = new ShakeRepository();
        public IActionResult Index()
        {
            PedidoViewModel pvm= new PedidoViewModel();
            pvm.Hamburgueres = HamburguerRepository.ObterTodos();
            pvm.Shakes = ShakeRepository.ObterTodos();

            return View(pvm);
    
        }
        [HttpPost]
        public IActionResult Registrar(IFormCollection form)
        {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido();

            var nomeShake = form["shake"];
            Shake shake = new Shake(nomeShake , ShakeRepository.ObterPreco(nomeShake));

            pedido.Shake = shake;


            var nomeHamburguer = form["hamburguer"];
            Hamburguer hamburguer = new Hamburguer (nomeHamburguer , HamburguerRepository.ObterPreco(nomeHamburguer));

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente();
            cliente.Nome = form["nome"];
            cliente.Endereço = form["telefone"];
            cliente.Telefone = form["telefone"];
            cliente.Email = form["email"];

            pedido.Cliente = cliente;
            pedido.DataDoPedido = DateTime.Now;
            pedido.PrecoTotal = shake.Preco + hamburguer.Preco;

            if(pedidoRepoditory.Inserir(pedido)){
                return View("Sucesso");

            }else{
                return View("Erro");
            }

        }
    }
}