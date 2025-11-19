using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

Cliente cliente = new Cliente("Felipe", "felipe.dev@gmail.com");
//Documento documento = new Documento(1, "CPF", "47998764813", new DateOnly(2025, 3, 10), new DateOnly(2033, 3, 10));
//Console.WriteLine(documento);

ClienteController clienteController = new ClienteController();

try
{
    clienteController.AdicionarCliente(cliente);
}
catch (Exception ex)
{
    if (ex.Message.Contains("Violation of UNIQUE KEY"))
    {
        Console.WriteLine("Não é possível adicionar um novo cliente com o mesmo email!");
    }
}

try
{
    var clientes = clienteController.ListarClientes();
    foreach (var item in clientes)
    {
        Console.WriteLine(item);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    clienteController.AtualizarCliente("16993559811", "brunocapita.dev@gmail.com");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    clienteController.DeletarCliente("brunocapita.dev@gmail.com");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}