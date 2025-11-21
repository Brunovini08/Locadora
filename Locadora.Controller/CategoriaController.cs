using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;

namespace Locadora.Controller
{
    public class CategoriaController
    {
        public void AdicionarCategoria(Categoria categoria)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {

                    SqlCommand command = new SqlCommand(Categoria.INSERTCATEGORIA, connection, transaction);

                    command.Parameters.AddWithValue("@Nome", categoria.Nome);
                    command.Parameters.AddWithValue("@Descricao", categoria.Descricao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Diaria", categoria.Diaria);
                    int categoriaId = Convert.ToInt32(command.ExecuteScalar());
                    categoria.setCategoriaID(categoriaId);

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

        public List<Categoria> ListarCategorias()
        {
            var connectionString = ConnectionDB.GetConnectionString();

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Categoria.SELECTALLCATEGORIAS, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Categoria> categorias = new List<Categoria>();
                while (reader.Read())
                {
                    var categoria = new Categoria(
                        reader["Nome"].ToString(),
                        reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : null,
                        Convert.ToDouble(reader["Diaria"])
                        );

                    categoria.setCategoriaID((int)reader["CategoriaID"]);
                    categorias.Add(categoria);
                }

                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar os categorias" + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public Categoria? BuscarCategoriaNome(string nome)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Categoria.SELECTCATEGORIANOME, connection);

                command.Parameters.AddWithValue("@Nome", nome);

                SqlDataReader reader = command.ExecuteReader();
                Categoria categoria = null;
                if (reader.Read())
                {
                    categoria = new Categoria(
                        reader["Nome"].ToString(),
                        reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : null,
                        Convert.ToDouble(reader["Diaria"])
                        );
                    categoria.setCategoriaID(Convert.ToInt32(reader["CategoriaID"]));
                }
                return categoria;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar categoria por nome: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar categoria por nome: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public string BuscarCategoriaNomePorID(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Categoria.SELECCATEGORIANOMEID, connection);

                command.Parameters.AddWithValue("@idCategoria", id);

                SqlDataReader reader = command.ExecuteReader();
                string nomeCategoria = String.Empty;
                if (reader.Read())
                {
                    nomeCategoria = reader["Nome"].ToString();
                }
                return nomeCategoria;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar categoria por nome: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar categoria por nome: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AtualizarDiariaCategoria(string nome, double diaria)
        {

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                var categoriaEncontrada = BuscarCategoriaNome(nome);

                if (categoriaEncontrada is null)
                    throw new Exception("Categoria não encontrada");

                categoriaEncontrada.setDiaria(diaria);

                try
                {
                    SqlCommand command = new SqlCommand(Categoria.UPDATEDIARIACATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@Diaria", categoriaEncontrada.Diaria);
                    command.Parameters.AddWithValue("@IdCategoria", categoriaEncontrada.CategoriaID);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar diária da categoria: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao atualizar diária da categoria" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarDescricaoCategoria(string nome, string descricao)
        {

            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                var categoriaEncontrada = BuscarCategoriaNome(nome);

                if (categoriaEncontrada is null)
                    throw new Exception("Categoria não encontrada");

                categoriaEncontrada.setDescricao(descricao);

                try
                {
                    SqlCommand command = new SqlCommand(Categoria.UPDATEDESCRICAOCATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@Descricao", categoriaEncontrada.Descricao);
                    command.Parameters.AddWithValue("@IdCategoria", categoriaEncontrada.CategoriaID);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar descrição da categoria: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao atualizar descrição da categoria" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeletarCategoria(string nome)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                var categoriaEncontrada = BuscarCategoriaNome(nome);

                if (categoriaEncontrada is null)
                    throw new Exception("Categoria não encontrada");

                try
                {
                    SqlCommand command = new SqlCommand(Categoria.DELETECATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@IdCategoria", categoriaEncontrada.CategoriaID);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar categoria: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao deletar categoria" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
