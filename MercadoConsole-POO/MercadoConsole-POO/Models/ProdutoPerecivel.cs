namespace MercadoConsole_POO.Models
{
    public class ProdutoPerecivel : Produto
    {
        public DateTime DataValidade { get; set; }
        public override string Descricao()
        {
            return $"Produto Perecivel: {Nome} (Validade: {DataValidade: dd/MM/yyyy})";
        }
        public override string ToString()
        {
            return base.ToString() + $" Validade: {DataValidade: dd/MM/yyyy}";
        }
    }
}