/*
	AsterNET ARI Framework
	Automatically generated file @ 10.10.2019 19:36:54
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public class AsteriskActions : ARIBaseAction, IAsteriskActions
	{

		public AsteriskActions(IActionConsumer consumer)
			: base(consumer)
		{}

		/// <summary>
		/// Retrieve a dynamic configuration object.. 
		/// </summary>
		/// <param name="configClass">The configuration class containing dynamic configuration objects.</param>
		/// <param name="objectType">The type of configuration object to retrieve.</param>
		/// <param name="id">The unique identifier of the object to retrieve.</param>
		public List<ConfigTuple> GetObject(string configClass, string objectType, string id)
		{
			string path = "asterisk/config/dynamic/{configClass}/{objectType}/{id}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(configClass != null)
				request.AddUrlSegment("configClass", configClass);
			if(objectType != null)
				request.AddUrlSegment("objectType", objectType);
			if(id != null)
				request.AddUrlSegment("id", id);

			var response = Execute<List<ConfigTuple>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("{configClass|objectType|id} not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Create or update a dynamic configuration object.. 
		/// </summary>
		/// <param name="configClass">The configuration class containing dynamic configuration objects.</param>
		/// <param name="objectType">The type of configuration object to create or update.</param>
		/// <param name="id">The unique identifier of the object to create or update.</param>
		/// <param name="fields">The body object should have a value that is a list of ConfigTuples, which provide the fields to update. Ex. [ { "attribute": "directmedia", "value": "false" } ]</param>
		public List<ConfigTuple> UpdateObject(string configClass, string objectType, string id, List<ConfigTuple> fields = null)
		{
			string path = "asterisk/config/dynamic/{configClass}/{objectType}/{id}";
			var request = GetNewRequest(path, HttpMethod.PUT);
			if(configClass != null)
				request.AddUrlSegment("configClass", configClass);
			if(objectType != null)
				request.AddUrlSegment("objectType", objectType);
			if(id != null)
				request.AddUrlSegment("id", id);
			if(fields != null)
			{
				request.AddBody(new { fields = fields });
			}

			var response = Execute<List<ConfigTuple>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Bad request body", (int)response.StatusCode);
				case 403:
					throw new AriException("Could not create or update object", (int)response.StatusCode);
				case 404:
					throw new AriException("{configClass|objectType} not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Delete a dynamic configuration object.. 
		/// </summary>
		/// <param name="configClass">The configuration class containing dynamic configuration objects.</param>
		/// <param name="objectType">The type of configuration object to delete.</param>
		/// <param name="id">The unique identifier of the object to delete.</param>
		public void DeleteObject(string configClass, string objectType, string id)
		{
			string path = "asterisk/config/dynamic/{configClass}/{objectType}/{id}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(configClass != null)
				request.AddUrlSegment("configClass", configClass);
			if(objectType != null)
				request.AddUrlSegment("objectType", objectType);
			if(id != null)
				request.AddUrlSegment("id", id);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 403:
					throw new AriException("Could not delete object", (int)response.StatusCode);
				case 404:
					throw new AriException("{configClass|objectType|id} not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Gets Asterisk system information.. 
		/// </summary>
		/// <param name="only">Filter information returned</param>
		public AsteriskInfo GetInfo(string only = null)
		{
			string path = "asterisk/info";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(only != null)
				request.AddParameter("only", only);

			var response = Execute<AsteriskInfo>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// List Asterisk modules.. 
		/// </summary>
		public List<Module> ListModules()
		{
			string path = "asterisk/modules";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = Execute<List<Module>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get Asterisk module information.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		public Module GetModule(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);

			var response = Execute<Module>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Module could not be found in running modules.", (int)response.StatusCode);
				case 409:
					throw new AriException("Module information could not be retrieved.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Load an Asterisk module.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		public void LoadModule(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 409:
					throw new AriException("Module could not be loaded.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unload an Asterisk module.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		public void UnloadModule(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Module not found in running modules.", (int)response.StatusCode);
				case 409:
					throw new AriException("Module could not be unloaded.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Reload an Asterisk module.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		public void ReloadModule(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.PUT);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Module not found in running modules.", (int)response.StatusCode);
				case 409:
					throw new AriException("Module could not be reloaded.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Gets Asterisk log channel information.. 
		/// </summary>
		public List<LogChannel> ListLogChannels()
		{
			string path = "asterisk/logging";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = Execute<List<LogChannel>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Adds a log channel.. 
		/// </summary>
		/// <param name="logChannelName">The log channel to add</param>
		/// <param name="configuration">levels of the log channel</param>
		public void AddLog(string logChannelName, string configuration)
		{
			string path = "asterisk/logging/{logChannelName}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(logChannelName != null)
				request.AddUrlSegment("logChannelName", logChannelName);
			if(configuration != null)
				request.AddParameter("configuration", configuration);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Bad request body", (int)response.StatusCode);
				case 409:
					throw new AriException("Log channel could not be created.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Deletes a log channel.. 
		/// </summary>
		/// <param name="logChannelName">Log channels name</param>
		public void DeleteLog(string logChannelName)
		{
			string path = "asterisk/logging/{logChannelName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(logChannelName != null)
				request.AddUrlSegment("logChannelName", logChannelName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Log channel does not exist.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Rotates a log channel.. 
		/// </summary>
		/// <param name="logChannelName">Log channel's name</param>
		public void RotateLog(string logChannelName)
		{
			string path = "asterisk/logging/{logChannelName}/rotate";
			var request = GetNewRequest(path, HttpMethod.PUT);
			if(logChannelName != null)
				request.AddUrlSegment("logChannelName", logChannelName);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Log channel does not exist.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get the value of a global variable.. 
		/// </summary>
		/// <param name="variable">The variable to get</param>
		public Variable GetGlobalVar(string variable)
		{
			string path = "asterisk/variable";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(variable != null)
				request.AddParameter("variable", variable);

			var response = Execute<Variable>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Set the value of a global variable.. 
		/// </summary>
		/// <param name="variable">The variable to set</param>
		/// <param name="value">The value to set the variable to</param>
		public void SetGlobalVar(string variable, string value = null)
		{
			string path = "asterisk/variable";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(variable != null)
				request.AddParameter("variable", variable);
			if(value != null)
				request.AddParameter("value", value);
			var response = Execute(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}

		/// <summary>
		/// Retrieve a dynamic configuration object.. 
		/// </summary>
		public async Task<List<ConfigTuple>> GetObjectAsync(string configClass, string objectType, string id)
		{
			string path = "asterisk/config/dynamic/{configClass}/{objectType}/{id}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(configClass != null)
				request.AddUrlSegment("configClass", configClass);
			if(objectType != null)
				request.AddUrlSegment("objectType", objectType);
			if(id != null)
				request.AddUrlSegment("id", id);

			var response = await ExecuteTask<List<ConfigTuple>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("{configClass|objectType|id} not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Create or update a dynamic configuration object.. 
		/// </summary>
		public async Task<List<ConfigTuple>> UpdateObjectAsync(string configClass, string objectType, string id, List<ConfigTuple> fields = null)
		{
			string path = "asterisk/config/dynamic/{configClass}/{objectType}/{id}";
			var request = GetNewRequest(path, HttpMethod.PUT);
			if(configClass != null)
				request.AddUrlSegment("configClass", configClass);
			if(objectType != null)
				request.AddUrlSegment("objectType", objectType);
			if(id != null)
				request.AddUrlSegment("id", id);
			if(fields != null)
			{
				request.AddBody(new { fields = fields });
			}

			var response = await ExecuteTask<List<ConfigTuple>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Bad request body", (int)response.StatusCode);
				case 403:
					throw new AriException("Could not create or update object", (int)response.StatusCode);
				case 404:
					throw new AriException("{configClass|objectType} not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Delete a dynamic configuration object.. 
		/// </summary>
		public async Task DeleteObjectAsync(string configClass, string objectType, string id)
		{
			string path = "asterisk/config/dynamic/{configClass}/{objectType}/{id}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(configClass != null)
				request.AddUrlSegment("configClass", configClass);
			if(objectType != null)
				request.AddUrlSegment("objectType", objectType);
			if(id != null)
				request.AddUrlSegment("id", id);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 403:
					throw new AriException("Could not delete object", (int)response.StatusCode);
				case 404:
					throw new AriException("{configClass|objectType|id} not found", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Gets Asterisk system information.. 
		/// </summary>
		public async Task<AsteriskInfo> GetInfoAsync(string only = null)
		{
			string path = "asterisk/info";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(only != null)
				request.AddParameter("only", only);

			var response = await ExecuteTask<AsteriskInfo>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// List Asterisk modules.. 
		/// </summary>
		public async Task<List<Module>> ListModulesAsync()
		{
			string path = "asterisk/modules";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = await ExecuteTask<List<Module>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get Asterisk module information.. 
		/// </summary>
		public async Task<Module> GetModuleAsync(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);

			var response = await ExecuteTask<Module>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Module could not be found in running modules.", (int)response.StatusCode);
				case 409:
					throw new AriException("Module information could not be retrieved.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Load an Asterisk module.. 
		/// </summary>
		public async Task LoadModuleAsync(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 409:
					throw new AriException("Module could not be loaded.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Unload an Asterisk module.. 
		/// </summary>
		public async Task UnloadModuleAsync(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Module not found in running modules.", (int)response.StatusCode);
				case 409:
					throw new AriException("Module could not be unloaded.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Reload an Asterisk module.. 
		/// </summary>
		public async Task ReloadModuleAsync(string moduleName)
		{
			string path = "asterisk/modules/{moduleName}";
			var request = GetNewRequest(path, HttpMethod.PUT);
			if(moduleName != null)
				request.AddUrlSegment("moduleName", moduleName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Module not found in running modules.", (int)response.StatusCode);
				case 409:
					throw new AriException("Module could not be reloaded.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Gets Asterisk log channel information.. 
		/// </summary>
		public async Task<List<LogChannel>> ListLogChannelsAsync()
		{
			string path = "asterisk/logging";
			var request = GetNewRequest(path, HttpMethod.GET);

			var response = await ExecuteTask<List<LogChannel>>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Adds a log channel.. 
		/// </summary>
		public async Task AddLogAsync(string logChannelName, string configuration)
		{
			string path = "asterisk/logging/{logChannelName}";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(logChannelName != null)
				request.AddUrlSegment("logChannelName", logChannelName);
			if(configuration != null)
				request.AddParameter("configuration", configuration);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Bad request body", (int)response.StatusCode);
				case 409:
					throw new AriException("Log channel could not be created.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Deletes a log channel.. 
		/// </summary>
		public async Task DeleteLogAsync(string logChannelName)
		{
			string path = "asterisk/logging/{logChannelName}";
			var request = GetNewRequest(path, HttpMethod.DELETE);
			if(logChannelName != null)
				request.AddUrlSegment("logChannelName", logChannelName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Log channel does not exist.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Rotates a log channel.. 
		/// </summary>
		public async Task RotateLogAsync(string logChannelName)
		{
			string path = "asterisk/logging/{logChannelName}/rotate";
			var request = GetNewRequest(path, HttpMethod.PUT);
			if(logChannelName != null)
				request.AddUrlSegment("logChannelName", logChannelName);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 404:
					throw new AriException("Log channel does not exist.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Get the value of a global variable.. 
		/// </summary>
		public async Task<Variable> GetGlobalVarAsync(string variable)
		{
			string path = "asterisk/variable";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(variable != null)
				request.AddParameter("variable", variable);

			var response = await ExecuteTask<Variable>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
		/// <summary>
		/// Set the value of a global variable.. 
		/// </summary>
		public async Task SetGlobalVarAsync(string variable, string value = null)
		{
			string path = "asterisk/variable";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(variable != null)
				request.AddParameter("variable", variable);
			if(value != null)
				request.AddParameter("value", value);
			var response = await ExecuteTask(request);
			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return;
			switch((int)response.StatusCode)
            {
				case 400:
					throw new AriException("Missing variable parameter.", (int)response.StatusCode);
				default:
					// Unknown server response
					throw new AriException(string.Format("Unknown response code {0} from ARI.", response.StatusCode), (int)response.StatusCode);
            }
		}
	}
}

