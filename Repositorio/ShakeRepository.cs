using System.Collections.Generic;
using System.IO;
using MCBONALDSMVC.Models;

namespace MCBONALDSMVC.Repositorio
{
    public class ShakeRepository
    {
        private const string PATH = "Database/Shake.csv";
        
        public double ObterPreco(string nomeShake)
        {
            var lista = ObterTodos();
            var preco = 0.0;
            foreach (var item in lista)
            {
                if(item.Nome.Equals(nomeShake))
                {
                    preco = item.Preco;
                    break;
                }
                
            }
            return preco;
        }
        public List<Shake> ObterTodos()
        {
            List<Shake> Shakes = new List<Shake>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var linha in linhas)
            {
                Shake s = new Shake();
                string [] dados = linha.Split(";");
                s.Nome = dados[0];
                s.Preco = double.Parse(dados[1]);
                Shakes.Add(s);
            }

            return Shakes;
        }
    }
}