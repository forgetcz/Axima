using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration.Test
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationRepositoryExportAttributes : ExportAttribute, IAppConfigurationMefAttributes
    {
        public eApplicationConfigurationRepositoryType AppConfigType { get; }

        public eApplicationConfigurationRepositorySection AppConfigSection { get; }

        public ConfigurationRepositoryExportAttributes(eApplicationConfigurationRepositoryType appConfigType, eApplicationConfigurationRepositorySection appConfigSection)
            : base(typeof(IConfigurationRepository))
        {
            AppConfigType = appConfigType;
            AppConfigSection = appConfigSection;
        }
    }
}
