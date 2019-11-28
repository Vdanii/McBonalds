using System.Collections.Generic;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.Repositories
{
    public class HamburguerRepository
    {
        private const string PATH = "Database/Hamburguer.csv";

        public double ObterPrecoDe(string nomeHamburguer)
        {
            var lista = ObterTodos();
            var preco = 0.0;
            foreach (var item in lista)
            {
                if (item.Nome.Equals(nomeHamburguer))
                {
                    preco = item.Preco;
                    break;
                }
            }
            
            return preco;
        }

        public List<Hamburguer> ObterTodos()
        {
            List<Hamburguer> hamburgueres = new List<Hamburguer>();

            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                Hamburguer hamburguer = new Hamburguer();
                string[] dados = item.Split(";");
                hamburguer.Nome = dados[0];
                hamburguer.Preco = double.Parse(dados[1]);
                hamburgueres.Add(hamburguer);
            }

            return hamburgueres;
        }
    }
}