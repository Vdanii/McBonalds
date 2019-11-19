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

        public Cliente ObterPor (string email)
        {
            var linha = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                if(ExtraitValorDoCampo)("email",item.Equals(email))
                {
                    Cliente c = new Cliente();
                    c.Nome = ExtraitValorDoCampo("nome", item);
                    c.Email = ExtraitValorDoCampo("email", item);
                    c.DataNascimento =
                    DateTime.Parse(ExtraitValorDoCampo)("data_nascimento", item);
                    c.Endereco = ExtraitValorDoCampo("endereco", item);
                    c.Telefone = ExtraitValorDoCampo("telefone", item);
                    c.Senha = ExtraitValorDoCampo("senha", item);

                    return c;
                }
                
            }
        }

        private string ExtraitValorDoCampo(string nomeCampo, string linha)
        {
            var chave = nomeCampo;

            var indiceChave = linha.IndexOf(chave);
            var indiceTerminal = linha.IndexOf(";", indiceChave);

            var valor = "";

            if(indiceTerminal != -1)
            {
                valor = linha.Substring(indiceChave, indiceTerminal - indiceChave);
            }
            else
            {
                valor = linha.Substring(indiceChave);
            }
            System.Console.WriteLine($"Campo{nomeCampo} e o valor {valor}");
            return valor.Replace(nomeCampo + "=","");
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"nome={cliente.Nome};email={cliente.Email};senha{cliente.Senha};endereco={cliente.Endereco};telefone={cliente.Telefone};data_nascimento{cliente.DataNascimento}";
        }
    }
}