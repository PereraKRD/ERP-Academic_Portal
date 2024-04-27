using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ERP.EvaluationManagement.DataService.Repositories;

public class FirstExaminerModuleOfferingRepository : GenericRepository<ModuleOfferingFirstExaminer> , IFirstExaminerModuleOfferingRepository
{
    public FirstExaminerModuleOfferingRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }
}