using Locadora.Controller.Interfaces;
using Locadora.Models;
using Locadora.Models.Enums;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller;

public class VeiculoController : IVeiculoController
{
    public void AdicionarVeiculo(Veiculo veiculo)
    {
        SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
        connection.Open();

        using (SqlTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                SqlCommand command = new SqlCommand(Veiculo.INSERTVEICULO, connection, transaction);
                command.Parameters.AddWithValue("@CategoriaID", veiculo.CategoriaID);
                command.Parameters.AddWithValue("@Placa", veiculo.Placa);
                command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                command.Parameters.AddWithValue("@Ano", veiculo.Ano);
                command.Parameters.AddWithValue("@StatusVeiculo", veiculo.StatusVeiculo);

                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar veículo no banco de dados: " + ex.Message);
            }
        }
    }
    public List<Veiculo> ListarTodosVeiculos()
    {
        var veiculos = new List<Veiculo>();
        var categoriaController = new CategoriaController();
        SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

        connection.Open();

        using (SqlCommand command = new SqlCommand(Veiculo.SELECTALLVEICULOS, connection))
        {
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Veiculo veiculo = new Veiculo(
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(5),
                            reader.GetString(6)
                        );
                        veiculo.setVeiculoID(reader.GetInt32(0));
                        veiculo.setNomeCategoria(
                                categoriaController.BuscarCategoriaNomePorID(reader.GetInt32(1))
                            );
                        veiculos.Add(veiculo);  
                    }

                    return veiculos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar veiculos: " + ex.Message);
            }
        }
    }
    public Veiculo BuscarVeiculoPlaca(string placa)
    {
        var categoriaController = new CategoriaController();
        SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

        connection.Open();

        using (SqlCommand command = new SqlCommand(Veiculo.SELECTVEICULOBYPLACA, connection))
        {
            try
            {
                Veiculo veiculo = null;
                command.Parameters.AddWithValue("@Placa", placa);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veiculo = new Veiculo(
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(5),
                            reader.GetString(6)
                        );
                        veiculo.setVeiculoID(reader.GetInt32(0));
                        veiculo.setNomeCategoria(
                            categoriaController.BuscarCategoriaNomePorID(reader.GetInt32(1))
                        );
                    }
                    return veiculo ?? throw new Exception($"Não existe veículo com a placa -> {placa}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar veiculos: " + ex.Message);
            }
        }
    }
    public void AtualizarStatusVeiculo(string placa, string statusVeiculo)
    {
        SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

        connection.Open();

        using (SqlCommand command = new SqlCommand(Veiculo.UPDATESTATUSVEICULO, connection))
        {
            Veiculo veiculo = BuscarVeiculoPlaca(placa);
            if(veiculo is null) 
                throw new Exception($"O veículo com a placa -> {placa}, não existe");
            veiculo.setStatusVeiculo(statusVeiculo.ToString());
            try
            {
                command.Parameters.AddWithValue("@StatusVeiculo", statusVeiculo);
                command.Parameters.AddWithValue("@IdVeiculo", veiculo.VeiculoID);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar veiculo: " + ex.Message);
            }
        }
    }
    public void DeletarVeiculo(string placa)
    {
        SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

        connection.Open();

        using (SqlCommand command = new SqlCommand(Veiculo.DELETEVEICULO, connection))
        {
            Veiculo veiculo = BuscarVeiculoPlaca(placa);
            if(veiculo is null) 
                throw new Exception($"O veículo com a placa -> {placa}, não existe");
            try
            {
                command.Parameters.AddWithValue("@idVeiculo", veiculo.VeiculoID);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar veiculo: " + ex.Message);
            }
        }
    }
}