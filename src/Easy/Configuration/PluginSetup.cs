using System;
using System.Collections.Generic;
using System.Linq;
using Easy.Plugins;
using Easy.Plugins.BultIn.Caching;
using Easy.Plugins.BultIn.IoC;
using Easy.Plugins.BultIn.Log;
using Easy.Plugins.BultIn.Persistence;
using Easy.Plugins.BultIn.Storage;
using Easy.Plugins.BultIn.Translation;
using Easy.Plugins.BultIn.Validation;
using Easy.Plugins.Contracts.Caching;
using Easy.Plugins.Contracts.IoC;
using Easy.Plugins.Contracts.Log;
using Easy.Plugins.Contracts.Persistence;
using Easy.Plugins.Contracts.Storage;
using Easy.Plugins.Contracts.Translation;
using Easy.Plugins.Contracts.Validation;

namespace Easy.Configuration
{
    internal class PluginSetup
    {
        private readonly Dictionary<Type, Plugin> _plugins;

        private PluginSetup(Dictionary<Type, Plugin> plugins)
        {
            _plugins = plugins;
        }

        internal static PluginSetup Create()
        {
            var plugins = new Dictionary<Type, Plugin>
                {
                    {typeof (IValidatorPlugin), new ValidatorPlugin()},
                    {typeof (ILoggerPlugin), new LoggerPlugin()},
                    {typeof (ITranslatorPlugin), new TranslatorPlugin()},
                    {typeof (ICachePlugin), new CachePlugin()},
                    {typeof (IStoragePlugin), new MemoryStoragePlugin()},
                    {typeof (IPersistencePlugin), new PersistencePlugin()},
                    {typeof (IContainerPlugin), new ContainerPlugin()}
                };

            return new PluginSetup(plugins);
        }

        internal void Register<T>(T plugin)
        {
            var abstractPlugin = plugin as Plugin;
            _plugins[typeof(T)] = abstractPlugin;
        }

        internal void Register<TU, T>()
        {
            var type = typeof(T);
            var plugin = type.Assembly.CreateInstance(type.FullName);
            Register((TU)plugin);
        }

        internal List<Plugin> GetPlugins()
        {
            return _plugins.Select(plugin => plugin.Value).ToList();
        }
    }

}