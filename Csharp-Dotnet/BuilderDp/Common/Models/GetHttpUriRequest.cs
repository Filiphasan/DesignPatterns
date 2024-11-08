namespace BuilderDp.Common.Models;

public class GetHttpUriRequest
{
    public string BaseUrl { get; set; } = string.Empty;
    public string[] PathParams { get; set; } = [];
    public GetHttpUriQueryParamModel[] QueryParams { get; set; } = [];
}

public class GetHttpUriQueryParamModel
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}