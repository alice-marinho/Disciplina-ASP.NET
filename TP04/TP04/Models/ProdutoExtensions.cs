using Model;

namespace TP04.Models
{
    public static class ProdutoExtensions
    {
        public static Produto ToEntity(this ProdutoViewModel vm)
        {
            return new Produto
            {
                Id = vm.Id,
                Nome = vm.Nome,
                Preco = vm.Preco,
                Categoria = vm.Categoria,
                Descricao = vm.Descricao
            };
        }

        public static ProdutoViewModel ToViewModel(this Produto entity)
        {
            return new ProdutoViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Preco = entity.Preco,
                Categoria = entity.Categoria,
                Descricao = entity.Descricao
            };
        }
    }
}
