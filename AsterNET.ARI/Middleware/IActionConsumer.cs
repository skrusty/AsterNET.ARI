using System.Threading.Tasks;

namespace AsterNET.ARI.Middleware
{

    public enum HttpMethod
    {
        GET,
        POST,
        PUT,
        DELETE,
        HEAD,
        OPTIONS,
        PATCH,
        MERGE
    }

    public interface IActionConsumer
    {
        IRestCommand GetRestCommand(HttpMethod method, string path);
        IRestCommandResult<T> ProcessRestCommand<T>(IRestCommand command) where T : new();
        IRestCommandResult ProcessRestCommand(IRestCommand command);

        Task<IRestCommandResult<T>> ProcessRestCommandAsync<T>(IRestCommand command) where T : new();
        Task<IRestCommandResult> ProcessRestCommandAsync(IRestCommand command);
    }
}