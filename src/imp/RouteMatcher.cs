using System;
using System.Collections.Generic;
using System.Linq;
using Bemol.src.core;

namespace Bemol.src.imp
{
    public class RouteMatcher : IRouteMatcher
    {
        private readonly List<IRoutePath> _handlers = new();
        
        public void Add(IRoutePath handler)
        {
            _handlers.Add(handler);
        }

        public IEnumerable<IRoutePath> Match(string method, Uri uri)
        {
            return _handlers.Where(x => x.Method == method && x.Match(uri));
        }
    }
}