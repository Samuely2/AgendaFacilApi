using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Domain.Interface;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
