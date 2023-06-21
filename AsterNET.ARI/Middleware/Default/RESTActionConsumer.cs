using System;
using System.Threading.Tasks;
using RestSharp;

namespace AsterNET.ARI.Middleware.Default
{
    public class RestActionConsumer : IActionConsumer
    {
        private readonly StasisEndpoint _connectionInfo;

        public RestActionConsumer(StasisEndpoint connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public IRestCommand GetRestCommand(HttpMethod method, string path)
        {
            return new Command(_connectionInfo, path)
            {
                UniqueId = Guid.NewGuid().ToString(),
                Method = method.ToString()
            };
        }

        public IRestCommandResult<T> ProcessRestCommand<T>(IRestCommand command) where T : new()
        {
            var cmd = (Command) command;
            var result = cmd.Client.Execute<T>(cmd.Request);
            
            var rtn = new CommandResult<T> {StatusCode = result.StatusCode, Data = result.Data};
            
            return rtn;
        }

        public IRestCommandResult ProcessRestCommand(IRestCommand command)
        {
            var cmd = (Command) command;
            var result = cmd.Client.Execute(cmd.Request);
            
            var rtn = new CommandResult {StatusCode = result.StatusCode, RawData = result.RawBytes};
            
            return rtn;
        }

        public async Task<IRestCommandResult<T>> ProcessRestCommandAsync<T>(IRestCommand command) where T : new()
        {
            var cmd = (Command) command;
            var result = await cmd.Client.ExecuteAsync<T>(cmd.Request);
            var rtn = new CommandResult<T> {StatusCode = result.StatusCode, Data = result.Data};
            
            return rtn;
        }

        public async Task<IRestCommandResult> ProcessRestCommandAsync(IRestCommand command)
        {
            var cmd = (Command) command;
            var result = await cmd.Client.ExecuteAsync(cmd.Request);
            var rtn = new CommandResult {StatusCode = result.StatusCode, RawData = result.RawBytes};
            
            return rtn;
        }
    }
}