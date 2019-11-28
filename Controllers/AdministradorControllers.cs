
using McBonaldsMVC.Controllers;
using McBonaldsMVC.Repositories;
using MCBONALDSMVC.Enums;
using MCBONALDSMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MCBONALDSMVC.Controllers
{
    public class AdministradorControllers : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();
        public IActionResult Dashboard()
        {
            var pedidos = pedidoRepository.ObterTodos();
            DashboardViewModels DashboardViewModel = new DashboardViewModels();

            foreach (var pedido in pedidos)
            {
                switch (pedido.Status)
                {
                    case (uint) StatusPedido.APROVADO:
                        DashboardViewModel.PedidosAprovados++;
                    break;
                    case (uint) StatusPedido.REPROVADO:
                        DashboardViewModel.PedidosReprovados++;
                    break;
                    case (uint) StatusPedido.PENDENTE:
                        DashboardViewModel.PedidosReprovados++;
                    break;
                    default:
                    DashboardViewModel.PedidosPendentes++;
                    DashboardViewModel.Pedido.Add(pedido);
                    // deixar na lista de pedido pendente
                    break;
                }
            }
            DashboardViewModel.NomeView = "Dashboard";
            DashboardViewModel.UsuarioEmail = ObterUsuarioSession();
            return View();
        }
    }
}