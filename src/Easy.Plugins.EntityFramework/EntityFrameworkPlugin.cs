using System;
using System.Data.Entity;
using Easy.Plugins.Contracts.Persistence;

namespace Easy.Plugins.EntityFramework
{
    public class EntityFrameworkPlugin :Plugin, IPersistencePlugin
    {
        private DbContext _dbContext;
     
        public IPersistence GetInstance()
        {
            return new EntityFrameworkPersistence(_dbContext);
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var assembly = pluginConfiguration.InfrastructureAssembly;

            var dbContextType = Array.Find(assembly.GetExportedTypes(), t => t.IsSubclassOf(typeof(DbContext)));
            if (dbContextType != null)
            {
                _dbContext = (DbContext) dbContextType.Assembly.CreateInstance(dbContextType.FullName);
            }
        }
    }
  

}
