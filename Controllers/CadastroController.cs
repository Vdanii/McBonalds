using System;
using MCBONALDSMVC.Models;
using MCBONALDSMVC.Models.Repositario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCBONALDSMVC.Controllers
{
    public class CadastroController : Controller
    {

        ClienteRepositariy clienteRepositariy = new ClienteRepositariy();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarCliente(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";
            try
            {
                Cliente cliente = new Cliente(form["nome"], form["endereco"], form["telefone"], form["senha"], form["email"], DateTime.Parse(form["data-nascimento"])); 
                clienteRepositariy.Inserir(cliente);
                return View("Sucesso");
            }
            catch(Exception e)
            {
            System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }

        }
        
    }
}
