using System;
using Bemol.Core;

namespace Bemol.src.core
{
    public interface IRoutePath
    {
        public string Method { get; }
        public string Path { get; }
        public Delegate Handle { get; }
        public IRouterConfig Config { get; }

        bool Match(Uri uri);
    }
}