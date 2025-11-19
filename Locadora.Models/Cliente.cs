namespace Locadora.Models
{
    public class Cliente
    {

        public int ClienteID { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; } = string.Empty;

        public readonly static string INSERTCLIENTE = "INSERT INTO tblClientes VALUES(@Nome, @Email, @Telefone);" +
            "SELECT SCOPE_IDENTITY()";

        public readonly static string SELECTALLCLIENTES = "SELECT * FROM tblClientes";
        public readonly static string UPDATELEFONECLIENTE = "UPDATE tblClientes SET Telefone = @Telefone WHERE ClienteID = @IdCliente";
        public readonly static string SELECTCLIENTEEMAIL = "SELECT * FROM tblClientes WHERE Email = @Email";
        public readonly static string DELETECLIENTE = "DELETE FROM tblClientes WHERE ClienteID = @IdCliente";
        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Cliente(string nome, string email, string? telefone): this(nome, email)
        {
            Telefone = telefone;
        }

        public void setClienteId(int id)
        {
            ClienteID = id;
        }

        public void setTelefone(string telefone)
        {
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"Cliente:\n" +
                $"Nome: {Nome}\n" +
                $"Email: {Email}\n" +
                $"Telefone: {(Telefone == string.Empty ? "Sem telefone" : Telefone)}\n";
        }

    }
}
