namespace BuilderDp.Builders;

public class HttpUriBuilder(string baseUrl)
{
    private readonly Dictionary<string, string> _queryParams = new();
    private readonly List<string> _pathParams = [];

    public HttpUriBuilder AppendPath(string path)
    {
        _pathParams.Add(path);
        return this;
    }

    public HttpUriBuilder AppendQueryParam(string key, string value)
    {
        _queryParams.Add(key, value);
        return this;
    }

    public string Build()
    {
        var path = string.Join("/", _pathParams);
        var query = _queryParams
            .Select(kvp => $"{kvp.Key}={kvp.Value}")
            .Aggregate((a, b) => $"{a}&{b}");
        return $"{baseUrl}/{path}?{query}";
    }
}