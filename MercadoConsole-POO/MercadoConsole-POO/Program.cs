using MercadoConsole_POO.Services;

ProdutoService servico = new ProdutoService();
bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE MERCADO ===");
    Console.WriteLine("1. Listar Produtos");
    Console.WriteLine("2. Adicionar Produtos");
    Console.WriteLine("3. Atualizar Produtos");
    Console.WriteLine("4. Excluir Produtos");
    Console.WriteLine("5. Sair");
    Console.WriteLine("Opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1": servico.ListarProdutos(); break;
        case "2": servico.AdicionarProduto(); break;
        case "3": servico.AtualizarProduto(); break;
        case "4": servico.ExcluirProduto(); break;
        case "5": continuar = false; break;
        default: Console.WriteLine("Opção Invalida!");break;
    }
    if (continuar)
    {
        Console.WriteLine("\n Precissione qualquer tecla para continuar");
        Console.ReadKey();
    }
    
}
