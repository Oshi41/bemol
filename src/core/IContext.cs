using System.Collections.Specialized;

namespace Bemol.src_new.core
{
    public interface IContext
    {
        /// <summary>
        /// Gets the request body
        /// </summary>
        string? Body();

        /// <summary>
        /// Maps a JSON body to a class using JsonSerializer.
        /// </summary>
        /// <typeparam name="T">Body type</typeparam>
        /// <returns>parsed body</returns>
        /// <exception cref="HttpException">Thrown when the body cannot be parsed or converted to <see cref="T"/></exception>
        T Body<T>();

        /// <summary>
        /// Gets the request content length
        /// </summary>
        long ContentLength();

        /// <summary>
        /// Gets the request content type, or null
        /// </summary>
        string ContentType();
        
        NameValueCollection Cookies { get; }
        NameValueCollection Headers { get; }
        NameValueCollection Query { get; }
    }
}