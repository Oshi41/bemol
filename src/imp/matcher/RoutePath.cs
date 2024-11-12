using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Bemol.Core;
using Bemol.src.core;
using DotLiquid.Util;
using PathSegment = Bemol.imp.matcher.PathSegment;

namespace Bemol.src.imp.matcher
{
    public class RoutePath : IRoutePath
    {
        public RoutePath(string method, string path, Delegate handle, IRouterConfig config)
        {
            Method = method;
            Path = path;
            Handle = handle;
            Config = config;

            Segments = path.Split('/', '\\')
                .Where(x => x.Length > 0)
                .Select<string, IPathSegment>(x => new PathSegment(x))
                .ToList();
        }

        public string Method { get; }
        public string Path { get; }
        public Delegate Handle { get; }
        public IRouterConfig Config { get; }
        public List<IPathSegment> Segments { get; }
        

        public bool Match(Uri uri)
        {
            var regex = string.Join('/', Segments.Select(x => x.Regex));
            
            // should ignore trailing slash
            if (!Config.IgnoreTrailingSlashes && regex.EndsWith('/'))
                regex = regex[..^1];

            // set trailing slash explicitly if needed
            if (Config.IgnoreTrailingSlashes && uri.OriginalString.EndsWith('/') && !regex.EndsWith('/'))
                regex += '/';

            return new Regex(regex).IsMatch(uri.ToString());
        }
    }
}