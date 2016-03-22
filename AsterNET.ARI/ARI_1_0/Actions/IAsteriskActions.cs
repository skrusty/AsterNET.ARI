﻿/*
	AsterNET ARI Framework
	Automatically generated file @ 3/22/2016 11:41:14 AM
*/
using System;
using System.Collections.Generic;
using AsterNET.ARI.Models;
using AsterNET.ARI;
using System.Threading.Tasks;

namespace AsterNET.ARI.Actions
{
	
	public interface IAsteriskActions
	{
		/// <summary>
		/// Retrieve a dynamic configuration object.. 
		/// </summary>
		/// <param name="configClass">The configuration class containing dynamic configuration objects.</param>
		/// <param name="objectType">The type of configuration object to retrieve.</param>
		/// <param name="id">The unique identifier of the object to retrieve.</param>
		Task<List<ConfigTuple>> GetObject(string configClass, string objectType, string id);
		/// <summary>
		/// Create or update a dynamic configuration object.. 
		/// </summary>
		/// <param name="configClass">The configuration class containing dynamic configuration objects.</param>
		/// <param name="objectType">The type of configuration object to create or update.</param>
		/// <param name="id">The unique identifier of the object to create or update.</param>
		/// <param name="fields">The body object should have a value that is a list of ConfigTuples, which provide the fields to update. Ex. [ { "attribute": "directmedia", "value": "false" } ]</param>
		Task<List<ConfigTuple>> UpdateObject(string configClass, string objectType, string id, Dictionary<string, string> fields = null);
		/// <summary>
		/// Delete a dynamic configuration object.. 
		/// </summary>
		/// <param name="configClass">The configuration class containing dynamic configuration objects.</param>
		/// <param name="objectType">The type of configuration object to delete.</param>
		/// <param name="id">The unique identifier of the object to delete.</param>
		Task DeleteObject(string configClass, string objectType, string id);
		/// <summary>
		/// Gets Asterisk system information.. 
		/// </summary>
		/// <param name="only">Filter information returned</param>
		Task<AsteriskInfo> GetInfo(string only = null);
		/// <summary>
		/// List Asterisk modules.. 
		/// </summary>
		Task<List<Module>> ListModules();
		/// <summary>
		/// Get Asterisk module information.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		Task<Module> GetModule(string moduleName);
		/// <summary>
		/// Load an Asterisk module.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		Task LoadModule(string moduleName);
		/// <summary>
		/// Unload an Asterisk module.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		Task UnloadModule(string moduleName);
		/// <summary>
		/// Reload an Asterisk module.. 
		/// </summary>
		/// <param name="moduleName">Module's name</param>
		Task ReloadModule(string moduleName);
		/// <summary>
		/// Get the value of a global variable.. 
		/// </summary>
		/// <param name="variable">The variable to get</param>
		Task<Variable> GetGlobalVar(string variable);
		/// <summary>
		/// Set the value of a global variable.. 
		/// </summary>
		/// <param name="variable">The variable to set</param>
		/// <param name="value">The value to set the variable to</param>
		Task SetGlobalVar(string variable, string value = null);
	}
}
