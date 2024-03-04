using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Compose
    {
        public static void ComposeMe(object caller)
        {
            var dllCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            //var exeCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "*.exe");
            //var assCatalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            var aggregateCatalog = new AggregateCatalog { Catalogs = { dllCatalog } };
            //aggregateCatalog.Catalogs.Add(assCatalog);
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeExportedValue("AppName", Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName));
            container.ComposeParts(caller);
        }
    }
}