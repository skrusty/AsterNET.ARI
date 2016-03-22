using System;


namespace ARICodeGen
{

    /*
     *  This project is simply here for testing the output of the codegen. 
     *  Any sample or demo application code will be moved into the AsterNET.ARI.TestApplication project.
     */
    class Program
    {
        public static void Main(string[] args)
        {

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
            if (inputType.ToLower() == "containers")
                return "Dictionary<string, string>";
            return inputType;
        }

        public static string TypeConvertTask(string inputType)
        {
            if (inputType.ToLower() == "void")
                return "Task";
            if (inputType.Contains("["))
                return $"Task<{inputType.Replace("[", "<").Replace("]", ">")}>";
            if (inputType.ToLower() == "date")
                return "Task<DateTime>";
            if (inputType.ToLower() == "boolean")
                return "Task<bool>";
            if (inputType.ToLower() == "containers")
                return "Task<Dictionary<string, string>>";
            return $"Task<{inputType}>";
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
