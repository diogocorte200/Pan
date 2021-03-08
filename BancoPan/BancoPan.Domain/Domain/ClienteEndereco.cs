namespace BancoPan.Domain.Domain
{
    public class ClienteEndereco
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public int IdCliente { get; set; }
    }
}
