using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Composition
{
    /// <summary>
    /// Compose application only once per initialization. Use DDD names for composition.
    /// </summary>
    public static class ComposeApplication
    {
        private static readonly Lazy<CompositionContainer> _container = new Lazy<CompositionContainer>(InitContainer);

        /// <summary>
        /// Compose application from DDD architecture
        /// </summary>
        /// <returns></returns>
        private static CompositionContainer InitContainer()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\");

            var InfrastrucureCatalog = new DirectoryCatalog(path, "Infrastrucure.dll");
            var DomainCatalog = new DirectoryCatalog(path, "Domain.dll");
            var ApplicationCatalog = new DirectoryCatalog(path, "Application.dll");
            var aggregateCatalog = new AggregateCatalog { Catalogs = { InfrastrucureCatalog, DomainCatalog, ApplicationCatalog } };
            var container = new CompositionContainer(aggregateCatalog);

            return container;
        }

        public static CompositionContainer Container { get { return _container.Value; } }
    }
}
