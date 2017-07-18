using System;
using System.Threading.Tasks;

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
            result.RunSynchronously();

            var rtn = new CommandResult<T> {StatusCode = result.Result.StatusCode, Data = result.Result.Data};
            
            cmd.Client.Dispose();

            return rtn;
        }

        public IRestCommandResult ProcessRestCommand(IRestCommand command)
        {
            var cmd = (Command) command;
            var result = cmd.Client.Execute(cmd.Request);
            result.RunSynchronously();

            var rtn = new CommandResult {StatusCode = result.Result.StatusCode, RawData = result.Result.RawBytes};
            
            cmd.Client.Dispose();

            return rtn;
        }

        public async Task<IRestCommandResult<T>> ProcessRestTaskCommand<T>(IRestCommand command) where T : new()
        {
            var cmd = (Command) command;
            var result = await cmd.Client.Execute<T>(cmd.Request);
            var rtn = new CommandResult<T> {StatusCode = result.StatusCode, Data = result.Data};
            
            cmd.Client.Dispose();
            
            return rtn;
        }

        public async Task<IRestCommandResult> ProcessRestTaskCommand(IRestCommand command)
        {
            var cmd = (Command) command;
            var result = await cmd.Client.Execute(cmd.Request);
            var rtn = new CommandResult {StatusCode = result.StatusCode, RawData = result.RawBytes};
            
            cmd.Client.Dispose();
            
            return rtn;
        }
    }
}