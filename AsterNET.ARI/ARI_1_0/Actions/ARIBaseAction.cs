using System.Threading.Tasks;
using AsterNET.ARI.Middleware;

namespace AsterNET.ARI
{
	public class ARIBaseAction
	{
		private readonly IActionConsumer _consumer;

		public ARIBaseAction(IActionConsumer consumer)
		{
			_consumer = consumer;
		}

		/// <summary>
		/// </summary>
		/// <returns></returns>
		protected IRestCommand GetNewRequest(string requestString, HttpMethod method)
		{
			return _consumer.GetRestCommand(method, requestString);
		}

		protected IRestCommandResult<T> Execute<T>(IRestCommand command) where T : new()
		{
			return _consumer.ProcessRestCommand<T>(command);
		}

		protected IRestCommandResult Execute(IRestCommand command)
		{
			return _consumer.ProcessRestCommand(command);
		}

	    protected async Task<IRestCommandResult<T>> ExecuteTask<T>(IRestCommand command) where T : new()
	    {
	        return await _consumer.ProcessRestTaskCommand<T>(command);
	    }

        protected async Task<IRestCommandResult> ExecuteTask(IRestCommand command)
        {
            return await _consumer.ProcessRestTaskCommand(command);
        }
    }
}