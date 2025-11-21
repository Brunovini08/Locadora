using System.Runtime.InteropServices.JavaScript;
using Locadora.Models.Enums;

namespace Locadora.Models;

public class Locacao
{
    public int LocacaoID { get; private set; }
    public int ClienteID { get; private set; }
    public int VeiculoID { get; private set; }
    public DateTime DataLocacao { get; private set; }
    public DateTime? DataDevolucaoPrevista { get; private set; }
    public DateTime? DataDevolucaoReal { get; private set; }
    public double ValorDiaria { get; private set; }
    public double ValorTotal { get; set; }
    public double Multa { get; private set; }
    public EStatusLocacao Status { get; private set; }

    public Locacao(int clienteId, int veiculoID, double valorDiaria, int diasLocacao)
    {
        ClienteID  = clienteId;
        VeiculoID = veiculoID;
        DataLocacao = DateTime.Now;
        ValorDiaria = valorDiaria;
        ValorTotal = valorDiaria *  diasLocacao;
        DataDevolucaoPrevista = DateTime.Now.AddDays(diasLocacao);
        Status = EStatusLocacao.Ativa;
    }
    
    public override string ToString()
    {
        return $"Cliente: {ClienteID}\nVeiculo: {VeiculoID}\n" +
               $"DataLocacao: {DataLocacao}\n" +
               $"DataDevolucaoPrevista: {DataDevolucaoPrevista}\n" +
               $"DataDevolucaoReal: {DataDevolucaoReal}\n" +
               $"ValorDiaria: {ValorDiaria}\nValorTotal: {ValorTotal}\n" +
               $"Multa: {Multa}\nStatus: {Status}";
    }
}