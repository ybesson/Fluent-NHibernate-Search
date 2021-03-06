using NHibernate.Search.Store;

namespace FluentNHibernate.Search.Cfg
{
    public class FluentSearchDirectoryProviderConfiguration
    {
        private readonly FluentSearchConfiguration cfg;

        internal FluentSearchDirectoryProviderConfiguration(FluentSearchConfiguration cfg)
        {
            this.cfg = cfg;
        }

        public FluentSearchConfiguration Custom<T>() where T : IDirectoryProvider
        {
            (cfg as IFluentSearchConfiguration).Properties.Add(FluentSearchConfiguration.SearchCfgDirectoryProvider, typeof(T).AssemblyQualifiedName);
            return cfg;
        }

        /// <summary>
        /// Sets the directory provider to an FSDirectory
        /// </summary>
        /// <returns></returns>
        public FluentSearchConfiguration FSDirectory()
        {
            return Custom<FSDirectoryProvider>();
        }

        /// <summary>
        /// Sets the directory provider to a RAMDirectory
        /// </summary>
        /// <returns></returns>
        public FluentSearchConfiguration RAMDirectory()
        {
            return Custom<RAMDirectoryProvider>();
        }
    }
}