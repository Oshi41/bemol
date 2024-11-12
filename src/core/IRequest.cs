using System.Collections.Specialized;
using System.IO;

namespace Bemol.src_new.interfaces
{
    public class IRequest
    {
        Stream InputStream { get; }
        long ContentLength { get; }
        string? ContentType { get; }
        NameValueCollection Cookies { get; }
        NameValueCollection Headers { get; }
        string Ip { get; }
        string Method { get; }
        string Path { get; }
        string Query { get; }
        string UserAgent { get; }
    }
}