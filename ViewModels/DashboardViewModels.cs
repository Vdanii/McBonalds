using System.Collections.Generic;
using McBonaldsMVC.Models;
using McBonaldsMVC.ViewModels;

namespace MCBONALDSMVC.ViewModels
{
    public class DashboardViewModels : BaseViewModel
    {
        public List<Pedido> Pedido {get;set;}
        public uint PedidosAprovados {get;set;}
        public uint PedidosReprovados {get;set;}
        public uint PedidosPendentes {get;set;}  

        public DashboardViewModels()
        {
            this.Pedido = new List <Pedido>();
        }

    }
}