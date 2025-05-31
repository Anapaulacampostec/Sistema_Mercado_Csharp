using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using MercadoConsole_POO.Models;

namespace MercadoConsole_POO.Services

{

    public class ProdutoService

    {

        private List<IProduto> produtos = new List<IProduto>();

        private int proximoId = 1;

        public ProdutoService()

        {

            produtos.Add(new Produto { Id = proximoId++, Nome = "Panela", Preco = 30.50m });

            produtos.Add(new ProdutoPerecivel { Id = proximoId++, Nome = "Café", Preco = 50.75m, DataValidade = DateTime.Today.AddDays(7) });

        }

        public void ListarProdutos()

        {

            Console.WriteLine("\n ----- Lista de Produtos -----");

            if (!produtos.Any())

            {

                Console.WriteLine("Nenhum produto cadastrado!");

                return;

            }

            foreach (var produto in produtos)

            {

                Console.WriteLine(produto);

            }

        }

        public void AdicionarProduto()

        {

            Console.WriteLine("\nTipo do produto: ");

            Console.WriteLine("1.Comum");

            Console.WriteLine("2.Perecível");

            Console.WriteLine("Escolha: ");

            string tipo = Console.ReadLine();

            Console.Write("Nome: ");

            string nome = Console.ReadLine();

            Console.WriteLine("Preço: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))

            {

                Console.WriteLine("Preço inválido!");

                return;

            }

            if (tipo == "1")

            {

                produtos.Add(new Produto { Id = proximoId++, Nome = nome, Preco = preco });

            }

            else if (tipo == "2")

            {

                Console.WriteLine("Data de validade (dd/mm/aaaa): ");

                if (!DateTime.TryParse(Console.ReadLine(), out DateTime validade))

                {

                    Console.WriteLine("Data inválida!");

                    return;

                }

                produtos.Add(new ProdutoPerecivel

                {

                    Id = proximoId++,

                    Nome = nome,

                    Preco = preco,

                    DataValidade = validade

                });

            }

            else

            {

                Console.WriteLine("Tipo inválido!");

                return;

            }
        }

        public void AtualizarProduto()
        {
            Console.WriteLine("\n ID do produto para atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID Invalido!");
                return;
            }
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }
            Console.WriteLine("Novo nome: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Novo preço: R$");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço Invalido! ");
                return;
            }
            produto.Preco = preco;

            if (produto is ProdutoPerecivel perecivel)
            {
                Console.Write("Nova validade (dd/mm/aaaa)");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime novaValidade))
                {
                    perecivel.DataValidade = novaValidade;
                }
                else
                {
                    Console.WriteLine("Data Invalida!");
                }
            }
            Console.WriteLine("Produto Atualizado!");
        }

        public void ExcluirProduto()
        {
            Console.WriteLine("\n ID do produto para excluir:");
            if(!int.TryParse(Console.ReadLine(),out int id))
            {
                Console.WriteLine("ID Invalido!");
                return;
            }
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado");
                return;
            }
            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");

        }

    }
}

