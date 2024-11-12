using System;
using System.Collections.Generic;

namespace Bemol.src.core
{
    public interface IRouteMatcher
    {
        void Add(IRoutePath handler);
        
        IEnumerable<IRoutePath> Match(string method, Uri uri);
    }
}