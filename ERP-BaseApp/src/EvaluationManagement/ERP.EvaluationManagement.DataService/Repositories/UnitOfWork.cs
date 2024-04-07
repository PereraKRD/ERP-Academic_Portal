using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ERP.EvaluationManagement.DataService.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public IEvaluationRepository Evaluations { get; }
    public IModuleOfferingRepository ModuleOfferings { get; }
    public ITeacherRepository Teachers { get; }
    public IModuleRepository Modules { get; }
    public IStudentRepository Students { get; }
    public IModuleRegistrationRepository ModuleRegistrations { get; }
    public IStudentResultRepository StudentResults { get; }
    
    public UnitOfWork(AppDbContext context , ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");
        
        Evaluations = new EvaluationRepository(_context,logger);
        ModuleOfferings = new ModuleOfferingRepository(_context,logger);
        Teachers = new TeacherRepository(_context,logger);
        Modules = new ModuleRepository(_context,logger);
        Students = new StudentRepository(_context, logger);
        ModuleRegistrations = new ModuleRegistrationRepository(_context, logger);
        StudentResults = new StudentResultRepository(_context, logger);
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