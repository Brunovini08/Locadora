using Locadora.Models;

namespace Locadora.Controller.Interfaces;

public interface ICategoriaController
{
    public void AdicionarCategoria(Categoria categoria);
    public List<Categoria> ListarCategorias();
    public string BuscarCategoriaPorID(int id);
    public Categoria BuscarCategoriaPorNome(string nome);
    public void AtualizarCategoria(string nome, Categoria categoria);
    public void DeletarCategoria(string nome);
    public void AdicionarCategoriaProcedure(Categoria categoria);
}