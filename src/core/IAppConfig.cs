using Bemol.Core;

namespace Bemol.src_new.core
{
    public interface IAppConfig : IRouterConfig
    {
        public string StaticFolder { get; set; }
        public string ContextPath { get; set; }
        public string DefaultContentType { get; set; }
        public bool EnableCorsForAllOrigins { get; set; }
    }
}