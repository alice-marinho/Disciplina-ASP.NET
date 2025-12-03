
namespace DAL.Produtos
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        void Incluir(params TEntity[] obj);
        void Alterar(params TEntity[] obj);
        void Excluir(params TEntity[] obj);
        TEntity Find(int id);
    }
}
