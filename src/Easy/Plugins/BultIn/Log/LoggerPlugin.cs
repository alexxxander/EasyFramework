using System;
using System.IO;
using Easy.Core;
using Easy.Plugins.Contracts.Log;

namespace Easy.Plugins.BultIn.Log
{
    internal class LoggerPlugin : Plugin, ILoggerPlugin
    {
        private FileInfo _arquivo;
        private const string DefaultPath = "Log";
        private const string DefaultExtension = ".log";

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultPath);
            Directory.CreateDirectory(path);

            var logFile = Path.ChangeExtension(pluginConfiguration.ModuleName, DefaultExtension);
            logFile = Path.Combine(path, logFile);

            _arquivo = new FileInfo(logFile);

            pluginInspector.Log("Logging to {0}", _arquivo.FullName);
        }
    
        public ILogger GetInstance()
        {
            return new Logger(_arquivo);
        }
    }
}