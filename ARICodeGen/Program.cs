using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using AsterNET.ARI;
using RestSharp;

namespace ARICodeGen
{

    /*
     *  Hierachie
     *      
     */
    class Program
    {
       
        static void Main(string[] args)
        {
            ARIClient c = new ARIClient();
            c.OnStasisStartEvent += c_OnStasisStartEvent;
            c.OnStasisEndEvent += c_OnStasisEndEvent;

            c.Connect("192.168.1.80:8088", "username", "test", "hello");

            Console.ReadKey();
        }

        static void c_OnStasisEndEvent(object sender, AsterNET.ARI.Models.StasisEndEvent e)
        {
            Console.WriteLine("Stasis Start Event: {0}, {1}", e.Application, e.Application);
        }

        static void c_OnStasisStartEvent(object sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            Console.WriteLine("Stasis End Event: {0}, {1}", e.Application, e.Application);
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
