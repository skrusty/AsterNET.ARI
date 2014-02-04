using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using AsterNET.ARI;
using AsterNET.ARI.Actions;
using RestSharp;

namespace ARICodeGen
{

    /*
     *  This project is simply here for testing the output of the codegen. 
     *  Any sample or demo application code will be moved into the AsterNET.ARI.TestApplication project.
     */
    class Program
    {
        public static ARIClient client;
        public static StasisEndpoint endPoint;
        static void Main(string[] args)
        {
            try
            {
                endPoint = new StasisEndpoint("192.168.1.67", 8088, "username", "test");
                client = endPoint.GetStasisClient("hello");
                

                client.Connect();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

    }

    public class SwaggerHelper
    {
        public static string TypeConvert(string inputType)
        {
            if (inputType.Contains("["))
                return inputType.Replace("[", "<").Replace("]", ">");
            if (inputType.ToLower() == "date")
                return "DateTime";
            if (inputType.ToLower() == "boolean")
                return "bool";
            return inputType;
        }

        public static string GetSafeName(string name)
        {
            return UppercaseFirst(name);
        }

        private static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }

}
