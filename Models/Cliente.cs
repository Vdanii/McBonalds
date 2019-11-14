using System;
using MCBONALDSMVC.Models;
using Microsoft.Extensions.Primitives;
using MCBONALDSMVC.Controllers;

namespace MCBONALDSMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Endereço {get;set;}
        public string Telefone {get;set;}
        public string Senha {get;set;}
        public string Email {get;set;}
        public DateTime DataNascimento {get;set;}
        public string Endereco { get; set; }

        public Cliente()
        {
            
        }

        public Cliente(string nome, string endereco, string telefone, string senha, string email, DateTime DataNascimento)
        {
            this.Nome = nome;
            this.Endereço = endereco;
            this.Telefone = Telefone;
            this.Senha = senha;
            this.Email = email;
            this.DataNascimento = DataNascimento;
        }

    }
}