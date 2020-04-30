
namespace AsterNET.ARI.Middleware
{

    public interface IRestCommand
    {
        string Url { get; set; }
        void AddUrlSegment(string segName, string value);
        void AddParameter(string name, object value);
        void AddBody(object body);
    }
}