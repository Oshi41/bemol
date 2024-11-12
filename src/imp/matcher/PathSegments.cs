using Bemol.src.core;

namespace Bemol.imp.matcher
{
    public class PathSegment : IPathSegment
    {
        public PathSegment(string pattern)
        {
            IsWildcard = pattern == "*";
            IsPattern = pattern.StartsWith(":");
            Regex = IsWildcard ? ".*?" // accept anything
                : IsPattern ? "[^/]+?" // Accepting everything except slash
                : pattern;
            
            Name = IsPattern 
                ? pattern[1..] 
                : null;
        }

        public string Regex { get; }
        public string? Name { get; }
        public bool IsPattern { get; }
        public bool IsWildcard { get; }
    }
}