
using Mc2.CrudTest.Infra.Data.Context;

using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Mc2.CrudTest.Infra.Data.UnitofWork;


public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly TaurobDBContext _context;
    private bool disposed = false;

    public UnitOfWork(TaurobDBContext context)
    {

        // Database.SetInitializer<MyDataBase>(null);
        if (context == null)
            throw new ArgumentException("DB context is null!");
        _context = context;
    }
     
    public void Dispose()
    {

        _context.Dispose();

        this.disposed = true;
        GC.SuppressFinalize(this);
    }


}
