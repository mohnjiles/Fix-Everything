using System;

public class MyWebClient : WebClient
{
    Uri _responseUri;

    public Uri ResponseUri
    {
        get { return _responseUri; }
    }

    protected override WebResponse GetWebResponse(WebRequest request)
    {
        WebResponse response = base.GetWebResponse(request);
        _responseUri = response.ResponseUri;
        return response;
    }
}