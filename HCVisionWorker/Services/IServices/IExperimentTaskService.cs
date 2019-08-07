using HCVisionWorker.Entities;
using HCVisionWorker.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HCVisionWorker.Services.IServices
{
    public interface IExperimentTaskService
    {
        Task<ExperimentTaskEntity> GetEntityAsync(string id);
        Task<ExperimentTaskEntity> GetEntityByLinqAsync(Expression<Func<ExperimentTaskEntity, bool>> expression);
        Task<IEnumerable<ExperimentTaskEntity>> GetListAsync();
        Task<IEnumerable<ExperimentTaskEntity>> GetListByLinqAsync(Expression<Func<ExperimentTaskEntity, bool>> expression);
        Task<bool> UpdateStatusAsync(IEnumerable<string> ids, ExperimentStatusEnum status);
    }
}
