using System.Text.RegularExpressions;

namespace Bemol.src.core
{
    public interface IPathSegment
    {
        string Regex { get; }
        string? Name { get; }
        bool IsPattern { get; }
        bool IsWildcard { get; }
    }
}