using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;
using Microsoft.Data.SqlClient;
using Utils.Databases;

#region CLIENTE E DOCUMENTO

//Cliente cliente = new Cliente("Gustavo", "gustavo.dev@gmail.com");
//Documento documento = new Documento("RG", "343434343434", new DateOnly(2025, 3, 10), new DateOnly(2033, 3, 10));

//ClienteController clienteController = new ClienteController();

//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var clientes = clienteController.ListarClientes();
//    foreach (var item in clientes)
//    {
//        Console.WriteLine(item);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    clienteController.AtualizarDocumentoCliente("gustavo.dev@gmail.com", documento);
//    Console.WriteLine(clienteController.BuscarClienteEmail("gustavo.dev@gmail.com"));
//} catch(Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    clienteController.AtualizarCliente("16993559811", "brunocapita.dev@gmail.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    clienteController.DeletarCliente("brunocapita.dev@gmail.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

#region CATEGORIA E VEICULO

Categoria categoria = new Categoria("Carro de Luxo", "Carros CAROS", 100.00);
CategoriaController categoriaController = new CategoriaController();


/*try
{
    categoriaController.AdicionarCategoria(categoria);
    Console.WriteLine("Categoria adicionada com sucesso");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

//try
//{
//    var categorias = categoriaController.ListarCategorias();
//    Console.WriteLine("CATEGORIAS: ");
//    foreach (var item in categorias)
//    {
//        Console.WriteLine(item);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

/*try
{
    categoriaController.AtualizarDiariaCategoria("Carro de Luxo", 140);
    Console.WriteLine("Categoria atualizada com sucesso");
}
catch (Exception ex) { Console.WriteLine(ex.Message); }

try
{
    categoriaController.AtualizarDescricaoCategoria("Carro de Luxo", "Carros de luxo, bonitos");
    Console.WriteLine("Categoria atualizada com sucesso");
} catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}*/

//try
//{
//    categoriaController.DeletarCategoria("Carro de Luxo");
//    Console.WriteLine("Categoria deletada com sucesso");
//} catch(Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

#region Veiculo

var veiculoController = new VeiculoController();
/*
try
{
    var veiculo = new Veiculo(1, "Audi", "Q3", "123-345", 2024, EStatusVeiculo.DISPONIVEL.ToString());
    veiculoController.AdicionarVeiculo(veiculo);
    Console.WriteLine("Adicionado com sucesso");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
*/

/*try
{
    var veiculos = veiculoController.ListarTodosVeiculos();
    Console.WriteLine($"Veiculos ({veiculos.Count}): ");
    foreach (var veiculo in veiculos)
    {
        Console.WriteLine(veiculo);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

/*try
{
    Console.WriteLine(veiculoController.BuscarVeiculoPlaca("sa"));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

/*try
{
    veiculoController.DeletarVeiculo("oisudoaiud");
    Console.WriteLine("Carro deletado com sucesso");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

/*try
{
    veiculoController.AtualizarStatusVeiculo("123-345", EStatusVeiculo.DISPONIVEL.ToString());
    Console.WriteLine("Veiculo atualizado com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

#endregion

var funcionarioController = new FuncionarioController();
/*try
{
    var funcionario = new Funcionario("Bruno", "12345678910", "bruno@gmail.com", 1300.00);
    funcionarioController.AdicionarFuncionario(funcionario);
    Console.WriteLine("Funcionario adicionado com sucesso!");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

/*try
{
    var funcionarios = funcionarioController.ListarTodosFuncionarios();
    foreach (var item in funcionarios)
    {
        Console.WriteLine(item);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

/*try
{
    Console.WriteLine("Funcionario:");
    Console.WriteLine(funcionarioController.BuscarFuncionarioPorCPF("12345678910"));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/

/*try
{
    funcionarioController.AtualizarSalario("12345678910", 2000.00M);
    Console.WriteLine("Funcionário atualizado com sucesso!");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}*/

try
{
    funcionarioController.DeletarFuncionario("12345678910");
    Console.WriteLine("Deletado com sucesso");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}