using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCBONALDSMVC.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository clienteRepository = new ClienteRepository;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try{
                System.Console.WriteLine("===================");
                System.Console.WriteLine("email");
                System.Console.WriteLine("senha");
                System.Console.WriteLine("===================");

                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(usuario);

                return View("Sucesso");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("erro");
            }
        }
    }

}