using System;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class PedidosController : AbstractController
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();
        ShakeRepository shakeRepository = new ShakeRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        
        public IActionResult Index()
        {
            var hamburgueres = hamburguerRepository.ObterTodos();
            var shakes = shakeRepository.ObterTodos();

            PedidoViewModel pedido = new PedidoViewModel();
            ViewData["Action"] = "Pedido";
            pedido.Hamburgueres = hamburguerRepository.ObterTodos();
            pedido.Shakes = shakeRepository.ObterTodos();

            var emailCliente = ObterUsuarioSession();
            if (!string.IsNullOrEmpty(emailCliente))
            {
                pedido.Cliente = clienteRepository.ObterPor(emailCliente);
            }

            var nomeUsuario = ObterUsuarioNomeSession();
            if (!string.IsNullOrEmpty(nomeUsuario))
            {
                pedido.NomeCliente = nomeUsuario;
            }
            
            pedido.NomeView = "Pedido";
            pedido.UsuarioEmail = emailCliente;
            pedido.UsuarioNome = nomeUsuario;


            return View(pedido);
        }

 
        public IActionResult Registrar(IFormCollection form)
        {
            Pedido pedido = new Pedido();

            Shake shake = new Shake();

            shake.Nome = form["shake"];
            shake.Preco = shakeRepository.ObterPrecoDe(form["shake"]);

            pedido.Shake = shake;

            Hamburguer hamburguer = new Hamburguer()    
            {
                Nome = form["hamburguer"],
                Preco = hamburguerRepository.ObterPrecoDe(form["hamburguer"])
            };

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente();
            cliente.Nome = form["nome"];
            cliente.Endereco = form["endereco"];
            cliente.Telefone = form["telefone"];
            cliente.Email = form["email"];

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            pedido.PrecoTotal = shake.Preco + hamburguer.Preco;

            if (pedidoRepository.Inserir(pedido))
            {
                return View("Sucesso",new RespostaViewModel(){
                    NomeView = "Pedido",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            else
            {
                return View("Erro", new RespostaViewModel() {
                    NomeView = "Pedido",  
                     UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    }
}