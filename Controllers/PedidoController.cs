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
        public IActionResult Index()
        {
            PedidoViewModel pvm= new PedidoViewModel();
            pvm.Hamburgueres = HamburguerRepository.ObterTodos();

            return View(pvm);
    
        }
        [HttpPost]
        public IActionResult Registrar(IFormCollection form)
        {
            Pedido pedido = new Pedido();

            Shake shake = new Shake();
            shake.Nome = form["shake"];
            shake.Preco = 0.0;

            pedido.Shake = shake;

            Hamburguer hamburguer = new Hamburguer();
            hamburguer.Nome = form["hamburguer"];
            hamburguer.Preco = 0.0;

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente();
            cliente.Nome = form["nome"];
            cliente.Endereço = form["telefone"];
            cliente.Telefone = form["telefone"];
            cliente.Email = form["email"];

            pedido.Cliente = cliente;
            pedido.DataDoPedido = DateTime.Now;
            pedido.PrecoTotal = 0.0;

            if(pedidoRepoditory.Inserir(pedido)){
                return View("Sucesso");

            }else{
                return View("Erro");
            }

        }
    }
}