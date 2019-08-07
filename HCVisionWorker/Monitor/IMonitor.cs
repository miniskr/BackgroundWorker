using System.Threading.Tasks;

namespace HCVisionWorker.Monitor
{
    public interface IMonitor
    {
        //public void Execute();
        public Task ExecuteAsync();
    }
}
