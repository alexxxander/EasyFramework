using Easy.Core;
using Easy.Plugins.Contracts.Caching;
using Easy.Plugins.Contracts.Log;
using Easy.Plugins.Contracts.Persistence;
using Easy.Plugins.Contracts.Storage;
using Easy.Plugins.Contracts.Translation;
using Easy.Plugins.Contracts.Validation;

namespace Easy.Configuration.Expressions
{
    public class ForExpression
    {
        private readonly string _moduleName;
        private readonly PluginSetup _pluginConfiguration;

        internal ForExpression(string moduleName)
        {
            _moduleName = moduleName;
            _pluginConfiguration = PluginSetup.Create();
        }

        public ForExpression Log(ILoggerPlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Log<T>() where T : ILoggerPlugin
        {
            _pluginConfiguration.Register<ILoggerPlugin, T>(); 
            return this;
        }

        public ForExpression Translation(ITranslatorPlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Translation<T>() where T : ITranslatorPlugin
        {
            _pluginConfiguration.Register<ITranslatorPlugin, T>();
            return this;
        }

        public ForExpression Persistence(IPersistencePlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Persistence<T>() where T : IPersistencePlugin
        {
            _pluginConfiguration.Register<IPersistencePlugin, T>();
            return this;
        }

        public ForExpression Validator(IValidatorPlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Validator<T>() where T : IValidatorPlugin
        {
            _pluginConfiguration.Register<IValidatorPlugin, T>();
            return this;
        }

        public ForExpression Cache(ICachePlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Cache<T>() where T :ICachePlugin
        {
            _pluginConfiguration.Register<ICachePlugin, T>();
            return this;
        }

        public ForExpression Storage(IStoragePlugin plugin)
        {
            _pluginConfiguration.Register(plugin);
            return this;
        }

        public ForExpression Storage<T>() where T : IStoragePlugin
        {
            _pluginConfiguration.Register<IStoragePlugin, T>();
            return this;
        }

        public ConfigObject Done()
        {
            InstanceProvider.Configure(_moduleName, _pluginConfiguration);
            return new ConfigObject(_moduleName);
        }
    }
}