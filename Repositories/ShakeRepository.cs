using System.Collections.Generic;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.Repositories
{
    public class ShakeRepository
    {
        private const string PATH = "Database/Shake.csv";

        public double ObterPrecoDe(string nomeShake)
        {
            var lista = ObterTodos();
            var preco = 0.0;
            foreach (var item in lista)
            {
                if (item.Nome.Equals(nomeShake))
                {
                    preco = item.Preco;
                    break;
                }
            }
            
            return preco;
        }
        public List<Shake> ObterTodos()
        {   
            List<Shake> shakes = new List<Shake>();

            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                Shake shake = new Shake();
                string [] dados = item.Split(";");
                shake.Nome = dados[0];
                shake.Preco = double.Parse(dados[1]);
                shakes.Add(shake);
            }

            return shakes;
        }
    }
}