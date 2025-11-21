using Locadora.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {

        public int VeiculoID { get; private set; }
        public int CategoriaID { get; private set; }
        public string NomeCategoria { get; private set; }   
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public int Ano { get; private set; }
        public string StatusVeiculo { get; private set; }

        public readonly static string INSERTVEICULO = @"INSERT INTO tblVeiculos (CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo)
            VALUES (@CategoriaID, @Placa, @Marca, @Modelo, @Ano, @StatusVeiculo);
";

        public readonly static string DELETEVEICULO = @"DELETE FROM tblVeiculos WHERE  VeiculoID = @IdVeiculo";
        
        public readonly static string SELECTALLVEICULOS =
            @"SELECT VeiculoID, CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo FROM tblVeiculos";

        public readonly static string SELECTVEICULOBYPLACA =
            @"SELECT VeiculoID, CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo FROM tblVeiculos WHERE Placa = @Placa";
        
        public readonly static string UPDATESTATUSVEICULO =
            @"UPDATE tblVeiculos SET StatusVeiculo = @StatusVeiculo WHERE VeiculoID = @IdVeiculo";

        public readonly static string DELETESTATUSVEICULO = @"DELETE FROM tblVeiculos WHERE VeiculoID = @IdVeiculo";
        public Veiculo(int categoriaID, string marca, string modelo, string placa, int ano, string statusVeiculo)
        {
            CategoriaID = categoriaID;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Ano = ano;
            StatusVeiculo = statusVeiculo;
        }
       
        
        public void setVeiculoID(int id)
        {
            VeiculoID = id;
        }

        public void setNomeCategoria(string nome)
        {
            NomeCategoria = nome;
        }
        
        public void setStatusVeiculo(string statusVeiculo)
        {
            StatusVeiculo = statusVeiculo;
        }


        public override string ToString()
        {
            return
                $"\n" +
                $"ID: {VeiculoID}\n" +
                $"Marca: {Marca}\n" +
                $"Modelo: {Modelo}\n" +
                $"Placa: {Placa}\n" +
                $"Ano: {Ano}\n" +
                $"Categoria: {NomeCategoria}\n" +
                $"Status: {StatusVeiculo}";
        }
    }
}
