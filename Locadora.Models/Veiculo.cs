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
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public int Ano { get; private set; }
        public EStatusVeiculo StatusVeiculo { get; private set; }
        public Veiculo(int categoriaID, string marca, string modelo, string placa, int ano, EStatusVeiculo statusVeiculo)
        {
            CategoriaID = categoriaID;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Ano = ano;
            StatusVeiculo = statusVeiculo;
        }

        public void setVeiculoID(int id) { VeiculoID = id; }

        public void setStatusVeiculo(EStatusVeiculo statusVeiculo)
        {
            StatusVeiculo = statusVeiculo;
        }

    }
}
