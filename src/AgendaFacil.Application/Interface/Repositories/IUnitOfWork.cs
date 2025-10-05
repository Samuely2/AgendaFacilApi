namespace AgendaFacil.Application.Interface.Repositories;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
