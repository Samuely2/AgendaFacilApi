using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Interface;

namespace AgendaFacil.Domain.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity

{
    protected readonly AgendaFacilDbContext DbContext;
    public BaseRepository(AgendaFacilDbContext context)
    {
        DbContext = context;
    }
    public void Create(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.Id = Guid.NewGuid();
        entity.CreatedBy = Guid.NewGuid();
        entity.CreatedDate = DateTime.UtcNow;
        DbContext.Set<TEntity>().Add(entity);
    }
    public void Delete(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }
    public void Update(TEntity entity)
    {
        entity.UpdatedBy = Guid.NewGuid();
        entity.UpdatedDate = DateTime.UtcNow;
        DbContext.Set<TEntity>().Update(entity);
    }
}