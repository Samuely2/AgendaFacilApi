using AgendaFacil.Application.Interface.Repositories;

namespace AgendaFacil.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AgendaFacilDbContext _context;
    public UnitOfWork(AgendaFacilDbContext context)
    {
        _context = context;
    }
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }

}
