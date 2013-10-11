using System;
using System.Collections.Generic;
using System.Reflection;
using Easy.Configuration;
using Easy.Configuration.Exceptions;
using Easy.Instances.Caching;
using Easy.Instances.IoC;
using Easy.Instances.Log;
using Easy.Instances.Persistence;
using Easy.Instances.Storage;
using Easy.Instances.Translation;
using Easy.Instances.Validation;
using Easy.Plugins;
using Easy.Plugins.Contracts.Caching;
using Easy.Plugins.Contracts.IoC;
using Easy.Plugins.Contracts.Log;
using Easy.Plugins.Contracts.Persistence;
using Easy.Plugins.Contracts.Storage;
using Easy.Plugins.Contracts.Translation;
using Easy.Plugins.Contracts.Validation;

namespace Easy.Core
{
    internal static class InstanceProvider
    {
        private static readonly Dictionary<string, List<Plugin>> PluginFactories = new Dictionary<string, List<Plugin>>();
        private static readonly Dictionary<Type, Type> Map = new Dictionary<Type, Type>();

        static InstanceProvider()
        {
            Map.Add(typeof(Persistence), typeof(IPluginFactory<IPersistence>));
            Map.Add(typeof(Container), typeof(IPluginFactory<IContainer>));
            Map.Add(typeof(Translator), typeof(IPluginFactory<ITranslator>));
            Map.Add(typeof(Validator), typeof(IPluginFactory<IValidator>));
            Map.Add(typeof(Storer), typeof(IPluginFactory<IStorage>));
            Map.Add(typeof(Cache), typeof(IPluginFactory<ICache>));
            Map.Add(typeof(Logger), typeof(IPluginFactory<ILogger>));
        }

        internal static T GetInstance<T>() where T : class
        {
            var context = ThreadContext.GetCurrent();
            if (context == null)
                throw new NotConfiguredException();

            var instance = ThreadContext.GetCurrent().GetInstance<T>();
            if (instance == null)
            {
                var moduleName = ThreadContext.GetCurrent().ConfigurationName;
                if (!PluginFactories.ContainsKey(moduleName))
                    throw new NotConfiguredException(moduleName);

                var plugins = PluginFactories[moduleName];
                var providerType = typeof(T);
                var pluginType = Map[providerType];
                var plugin = plugins.Find(pluginType.IsInstanceOfType);
                var pluginInstance = pluginType.InvokeMember("GetInstance", BindingFlags.InvokeMethod, null, plugin, null);
                instance = (T)providerType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0].Invoke(new[] { pluginInstance });
                ThreadContext.GetCurrent().SetInstance(instance);
            }

            return instance;
        }

        internal static void Configure(string moduleName, PluginSetup pluginSetup)
        {
            var pluginConfigurationData = new PluginConfiguration(
                moduleName,
                AssemblyManager.GetApplicationAssembly(moduleName),
                AssemblyManager.GetDomainAssembly(moduleName),
                AssemblyManager.GetInfrastructureAssembly(moduleName)
                );

            var pluginInformation = InitializePlugins(pluginSetup, pluginConfigurationData);

            PluginFactories[moduleName] = pluginSetup.GetPlugins();

            ThreadContext.Create(moduleName);

            GetInstance<Logger>().LogInfo(pluginInformation, null);
        }

        private static string InitializePlugins(PluginSetup pluginSetup,PluginConfiguration pluginConfigurationData)
        {
            var inspectors = new List<PluginInspector>();
            foreach (var plugin in pluginSetup.GetPlugins())
            {
                PluginInspector pluginInspector;
                plugin.Configure(pluginConfigurationData, out pluginInspector);
                inspectors.Add(pluginInspector);
            }
            return new PluginInspectorExtrator(inspectors).ToString();
        }
    }

}