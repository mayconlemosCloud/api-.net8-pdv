namespace Aplicacao.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Documento { get; set; } // Pode ser CPF ou CNPJ
    }
}