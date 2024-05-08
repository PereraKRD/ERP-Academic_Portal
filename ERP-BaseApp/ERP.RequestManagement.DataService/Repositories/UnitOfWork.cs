
using ERP.RequestManagement.DataService.Repositories.Interfaces;
using ERP.RequestManagement.DataService.Repositories.Interfaces;

using Microsoft.Extensions.Logging;

namespace ERP.RequestManagement.DataService.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ITeacherRepository Teachers { get; }
    public IStudentRepository Students { get; }
    public IBatchRepository Batches { get; }

    public UnitOfWork(AppDbContext context , ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");
        
        Teachers = new TeacherRepository(_context,logger);
        Students = new StudentRepository(_context, logger);
        Batches = new BatchRepository(_context, logger);

    }
    
    public async Task<bool> CompleteAsync()
    {
        var results = await _context.SaveChangesAsync();
        return results > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
}