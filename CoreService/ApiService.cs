using System.Threading.Tasks;
using NLog;

namespace CoreService
{
    public interface IApiService
    {
        Task<TResp> PostApi<TReq, TResp>(TReq req);
    }

    public class ApiService : IApiService
    {
        private readonly Logger _logger;

        public ApiService(Logger logger)
        {
            _logger = logger;
        }

        public async Task<TResp> PostApi<TReq, TResp>(TReq req)
        {
            return await Task.FromResult(default(TResp));
        }
    }
}