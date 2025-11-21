using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Categoria
    {
        public int CategoriaID { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Diaria { get; private set; }

        public static string INSERTCATEGORIA = @"INSERT INTO tblCategorias VALUES (@Nome, @Descricao, @Diaria)";

        public readonly static string SELECTALLCATEGORIAS = "SELECT * FROM tblCategorias";
        public readonly static string SELECTCATEGORIANOME = @"SELECT * FROM tblCategorias WHERE Nome = @Nome";
        public readonly static string SELECCATEGORIANOMEID = @"SELECT Nome FROM tblCategorias WHERE CategoriaID = @idCategoria";

        public readonly static string UPDATEDIARIACATEGORIA = "UPDATE tblCategorias SET Diaria = @Diaria WHERE CategoriaID = @IdCategoria";
        public readonly static string UPDATEDESCRICAOCATEGORIA = "UPDATE tblCategorias SET Descricao = @Descricao WHERE CategoriaID = @IdCategoria";
        public readonly static string DELETECATEGORIA = @"DELETE FROM tblCategorias WHERE CategoriaID = @IdCategoria";

        public Categoria(string? nome, string? descricao, double diaria)
        {
            Nome = nome;
            Descricao = descricao;
            Diaria = diaria;
        }

        public void setCategoriaID(int categoriaID)
        {
            CategoriaID = categoriaID;
        }

        public void setDiaria(double diaria)
        {
            Diaria = diaria;
        }

        public void setDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public override string ToString()
        {
            return
                $"\nNome: {Nome}" +
                $"\nDescrição: {(Descricao != null ? Descricao : "Não tem descrição")}" +
                $"\nDiária: {Diaria}";
        }
    }
}
