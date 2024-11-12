namespace Bemol.Core
{
    public interface IRouterConfig
    {
        /// <summary>
        /// Relative path to temlates folder
        /// </summary>
        public string TemplateFolder { get; set; }
        
        public bool IgnoreTrailingSlashes { get; set; }
    }
}