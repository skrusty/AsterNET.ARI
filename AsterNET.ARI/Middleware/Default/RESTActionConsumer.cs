using System;

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

            var rtn = new CommandResult {StatusCode = result.StatusCode};

            return rtn;
        }
    }
}