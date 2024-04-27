using ERP.EvaluationManagement.Core.Entity;
using ERP.EvaluationManagement.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ERP.EvaluationManagement.DataService.Repositories;

public class SecondExaminerModuleOfferingRepository : GenericRepository<ModuleOfferingSecondExaminer> , ISecondExaminerModuleOfferingRepository
{
    public SecondExaminerModuleOfferingRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }
}