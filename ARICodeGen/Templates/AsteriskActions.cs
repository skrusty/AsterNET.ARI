/*
	AsterNET ARI Framework
	Automatically generated file @ 27/05/2014 20:58:04
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using RestSharp;

namespace AsterNET.ARI.Actions
{
	
	public class AsteriskActions : ARIBaseAction
	{

		public AsteriskActions(StasisEndpoint endPoint)
			: base(endPoint)
		{}

		/// <summary>
		/// Gets Asterisk system information.. 
		/// </summary>
		/// <param name="only">Filter information returned</param>
		public AsteriskInfo GetInfo(string only)
		{
			string path = "/asterisk/info";
			var request = GetNewRequest(path, Method.GET);
			request.AddParameter("only", only, ParameterType.QueryString);

			var response = Client.Execute<AsteriskInfo>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Get the value of a global variable.. 
		/// </summary>
		/// <param name="variable">The variable to get</param>
		public Variable GetGlobalVar(string variable)
		{
			string path = "/asterisk/variable";
			var request = GetNewRequest(path, Method.GET);
			request.AddParameter("variable", variable, ParameterType.QueryString);

			var response = Client.Execute<Variable>(request);

			if((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
				return response.Data;

			switch((int)response.StatusCode)
            {
				case 400:
					throw new ARIException("Missing variable parameter.");
					break;
				default:
					// Unknown server response
					throw new ARIException(string.Format("Unknown response code {0} from ARI.", response.StatusCode.ToString()));
            }
		}
		/// <summary>
		/// Set the value of a global variable.. 
		/// </summary>
		/// <param name="variable">The variable to set</param>
		/// <param name="value">The value to set the variable to</param>
		public void SetGlobalVar(string variable, string value)
		{
			string path = "/asterisk/variable";
			var request = GetNewRequest(path, Method.POST);
			request.AddParameter("variable", variable, ParameterType.QueryString);
			request.AddParameter("value", value, ParameterType.QueryString);
			var response = Client.Execute(request);
		}
	}
}

