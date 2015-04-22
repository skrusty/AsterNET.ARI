/*
	AsterNET ARI Framework
	Automatically generated file @ 22/04/2015 09:45:42
*/

using AsterNET.ARI.Models;

namespace AsterNET.ARI.Actions
{
	public interface IAsteriskActions
	{
		/// <summary>
		///     Gets Asterisk system information..
		/// </summary>
		/// <param name="only">Filter information returned</param>
		AsteriskInfo GetInfo(string only = null);

		/// <summary>
		///     Get the value of a global variable..
		/// </summary>
		/// <param name="variable">The variable to get</param>
		Variable GetGlobalVar(string variable);

		/// <summary>
		///     Set the value of a global variable..
		/// </summary>
		/// <param name="variable">The variable to set</param>
		/// <param name="value">The value to set the variable to</param>
		void SetGlobalVar(string variable, string value = null);
	}
}