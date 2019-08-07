using HCVisionWorker.Infrasturcture;
using HCVisionWorker.Models.Enum;
using HCVisionWorker.Services.IServices;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HCVisionWorker.Monitor
{
    public class ExperimentMonitor : IMonitor
    {
        private readonly IExperimentTaskService _experimentTaskService;

        public ExperimentMonitor(IExperimentTaskService experimentTaskService)
        {
            this._experimentTaskService = experimentTaskService;
        }

        public async Task ExecuteAsync()
        {
            //! 执行开始任务
            try
            {
                var executedStart = await this.ExperimentTasStartkAsync();
                LogUtil.Write($"实验任务开始执行完毕，结果:{executedStart}", "ExperimentTask");
            }
            catch (Exception ex)
            {
                LogUtil.Write(ex.StackTrace, "ExperimentTask");
            }

            //! 执行结束任务
            try
            {
                var executedEnd = await this.ExperimentTaskEndAsync();
                LogUtil.Write($"实验任务结束执行完毕，结果:{executedEnd}", "ExperimentTask");
            }
            catch (Exception ex)
            {
                LogUtil.Write(ex.StackTrace, "ExperimentTask");
            }
        }

        private async Task<bool> ExperimentTasStartkAsync()
        {
            var list = await this._experimentTaskService.GetListByLinqAsync(x => x.Status == ExperimentStatusEnum.NotStarted && x.StartTime <= DateTime.Now);
            if (list.Count() == 0)
                return true;
            var ids = list.Select(x => x.Id).ToList();
            var start = await this._experimentTaskService.UpdateStatusAsync(ids, ExperimentStatusEnum.Starting);

            return start;
        }

        private async Task<bool> ExperimentTaskEndAsync()
        {
            var list = await this._experimentTaskService.GetListByLinqAsync(x => x.Status == ExperimentStatusEnum.Starting && x.EndTime <= DateTime.Now);
            if (list.Count() == 0)
                return true;
            var ids = list.Select(x => x.Id).ToList();
            var end = await this._experimentTaskService.UpdateStatusAsync(ids, ExperimentStatusEnum.Ended);

            return end;
        }
    }
}
