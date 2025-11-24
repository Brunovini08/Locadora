namespace Locadora.Controller.Interfaces;

public interface ILocacaoFuncionarioController
{
    public void Adicionar(int locacaoID, int funcionarioID);
    public List<string> BuscarFuncionariosPorLocacao(int locacaoID);
}