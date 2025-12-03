using Model;

namespace PROVA02.Models
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
                Status = vm.Status
    };
        }

        public static ProdutoViewModel ToViewModel(this Produto entity)
        {
            return new ProdutoViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Preco = entity.Preco,
                Status = entity.Status

            };
        }
    }
}
