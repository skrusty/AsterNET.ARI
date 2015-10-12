/*
	AsterNET ARI Framework
	Automatically generated file @ 12/10/2015 12:13:33
*/
using System.Collections.Generic;
using System.Linq;
using AsterNET.ARI.Middleware;
using AsterNET.ARI.Models;
using Newtonsoft.Json;

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
			string path = "/asterisk/config/dynamic/{configClass}/{objectType}/{id}";
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
		public List<ConfigTuple> UpdateObject(string configClass, string objectType, string id, List<KeyValuePair<string, string>> fields = null)
		{
			string path = "/asterisk/config/dynamic/{configClass}/{objectType}/{id}";
			var request = GetNewRequest(path, HttpMethod.PUT);
			if(configClass != null)
				request.AddUrlSegment("configClass", configClass);
			if(objectType != null)
				request.AddUrlSegment("objectType", objectType);
			if(id != null)
				request.AddUrlSegment("id", id);
			if(fields != null)
			{
				request.AddParameter("application/json", fields, ParameterType.RequestBody);
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
			string path = "/asterisk/config/dynamic/{configClass}/{objectType}/{id}";
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
			string path = "/asterisk/info";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(only != null)
				request.AddParameter("only", only, ParameterType.QueryString);

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
			string path = "/asterisk/modules";
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
			string path = "/asterisk/modules/{moduleName}";
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
			string path = "/asterisk/modules/{moduleName}";
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
			string path = "/asterisk/modules/{moduleName}";
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
			string path = "/asterisk/modules/{moduleName}";
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
		/// Get the value of a global variable.. 
		/// </summary>
		/// <param name="variable">The variable to get</param>
		public Variable GetGlobalVar(string variable)
		{
			string path = "/asterisk/variable";
			var request = GetNewRequest(path, HttpMethod.GET);
			if(variable != null)
				request.AddParameter("variable", variable, ParameterType.QueryString);

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
			string path = "/asterisk/variable";
			var request = GetNewRequest(path, HttpMethod.POST);
			if(variable != null)
				request.AddParameter("variable", variable, ParameterType.QueryString);
			if(value != null)
				request.AddParameter("value", value, ParameterType.QueryString);
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
	}
}

