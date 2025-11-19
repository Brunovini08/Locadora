using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class ClienteController
    {

        public void AdicionarCliente(Cliente cliente)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {

                    SqlCommand command = new SqlCommand(Cliente.INSERTCLIENTE, connection, transaction);

                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

                    cliente.setClienteId(Convert.ToInt32(command.ExecuteScalar()));

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar cliente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Cliente> ListarClientes()
        {
            var connectionString = ConnectionDB.GetConnectionString();

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Cliente.SELECTALLCLIENTES, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Cliente> clientes = new List<Cliente>();
                while (reader.Read())
                {
                    var cliente = new Cliente(
                        reader["Nome"].ToString(),
                        reader["Email"].ToString(),
                        reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : null
                        );
                    cliente.setClienteId((int)reader["ClienteID"]);
                    clientes.Add(cliente);
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar os clientes" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public Cliente BuscarClienteEmail(string email)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Cliente.SELECTCLIENTEEMAIL, connection);

                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();
                Cliente cliente = null;
                if (reader.Read())
                {
                    cliente = new Cliente(
                        reader["Nome"].ToString(),
                        reader["Email"].ToString(),
                        reader["Telefone"] != DBNull.Value ?
                        reader["Telefone"].ToString() : null
                        );
                    cliente.setClienteId(Convert.ToInt32(reader["ClienteID"]));
                }
                return cliente;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar cliente por email: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar cliente por email: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AtualizarCliente(string telefone, string email)
        {

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                var clienteEncontrado = BuscarClienteEmail(email);

                if (clienteEncontrado is null)
                    throw new Exception("Cliente não encontrado");

                clienteEncontrado.setTelefone(telefone);

                try
                {
                    SqlCommand command = new SqlCommand(Cliente.UPDATELEFONECLIENTE, connection, transaction);
                    command.Parameters.AddWithValue("@Telefone", clienteEncontrado.Telefone);
                    command.Parameters.AddWithValue("@IdCliente", clienteEncontrado.ClienteID);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar telefone do cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao atualizar telefone do cliente" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }


        }

        public void DeletarCliente(string email)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                var clienteEncontrado = BuscarClienteEmail(email);

                if (clienteEncontrado is null)
                    throw new Exception("Cliente não encontrado");

                try
                {
                    SqlCommand command = new SqlCommand(Cliente.DELETECLIENTE, connection, transaction);
                    command.Parameters.AddWithValue("@IdCliente", clienteEncontrado.ClienteID);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao deletar cliente" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
