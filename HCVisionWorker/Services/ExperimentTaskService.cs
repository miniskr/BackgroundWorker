using HCVisionWorker.DataBase;
using HCVisionWorker.Entities;
using HCVisionWorker.Models.Enum;
using HCVisionWorker.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HCVisionWorker.Services
{
    public class ExperimentTaskService : IExperimentTaskService
    {
        private readonly DataBaseContext _context;

        public ExperimentTaskService(DataBaseContext context)
        {
            this._context = context;
        }

        public async Task<ExperimentTaskEntity> GetEntityAsync(string id)
        {
            return await this._context.ExperimentTask.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ExperimentTaskEntity> GetEntityByLinqAsync(Expression<Func<ExperimentTaskEntity, bool>> expression)
        {
            return await this._context.ExperimentTask.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<ExperimentTaskEntity>> GetListAsync()
        {
            return await this._context.ExperimentTask.ToListAsync();
        }

        public async Task<IEnumerable<ExperimentTaskEntity>> GetListByLinqAsync(Expression<Func<ExperimentTaskEntity, bool>> expression)
        {
            return await this._context.ExperimentTask.Where(expression).ToListAsync();
        }

        public async Task<bool> UpdateStatusAsync(IEnumerable<string> ids, ExperimentStatusEnum status)
        {
            var entities = await this._context.ExperimentTask.Where(x => ids.Contains(x.Id)).ToListAsync();
            if (entities.Count == 0)
                return false;
            entities.ForEach(x => x.Status = status);

            this._context.UpdateRange(entities);
            var count = await this._context.SaveChangesAsync();
            return count > 0;
        }
    }
}
