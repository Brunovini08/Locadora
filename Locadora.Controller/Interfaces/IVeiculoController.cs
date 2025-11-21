using Locadora.Models;
using Locadora.Models.Enums;

namespace Locadora.Controller.Interfaces;

public interface IVeiculoController
{
    public void AdicionarVeiculo(Veiculo veiculo);
    public List<Veiculo> ListarTodosVeiculos();
    public Veiculo BuscarVeiculoPlaca(string placa);
    public void AtualizarStatusVeiculo(string placa, string statusVeiculo);
    public void DeletarVeiculo(string placa);
}