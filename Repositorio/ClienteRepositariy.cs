using System.IO;

namespace MCBONALDSMVC.Models.Repositario
{
    public class ClienteRepositariy
    {
        private const string PATH = "Database/Cliente.csv";
        public ClienteRepositariy()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }

        }
        public bool Inserir(Cliente cliente)
        {
            var linha = new string[] { PrepararRegistroCSV(cliente)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"nome={cliente.Nome};email={cliente.Email};senha{cliente.Senha};endereco={cliente.Endereco};telefone={cliente.Telefone};data_nascimento{cliente.DataNascimento}";
        }
    }
}