namespace Arke.ARI.Middleware
{

    public enum ParameterType
    {
        Cookie,
        GetOrPost,
        UrlSegment,
        HttpHeader,
        RequestBody,
        QueryString
    }

    public interface IRestCommand
    {
        string UniqueId { get; set; }
        string Url { get; set; }
        string Method { get; set; }
        string Body { get; }

        void AddUrlSegment(string segName, string value);
        void AddParameter(string name, object value, ParameterType type);
    }
}