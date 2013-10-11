using System.Text;
using Easy.Core.Serializer;
using Easy.Instances.Log;
using Easy.Plugins.Contracts.Log;

namespace Easy.Core
{
    internal static class InstanceLogger
    {
        internal static void Log(object intance, string method, params object[] @params)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();

            if (logInstance.LogLevel != LogLevel.Debug)
                return;

            logInstance.LogDebug(string.Format("\t[{0}] {1} {2}", intance.GetType().Name, method, FormatParameters(@params)), null);
        }

        private static string FormatParameters(object[] @params)
        {
            var sb = new StringBuilder();

            foreach (var parameterInfo in @params)
            {
                sb.Append(JsonSerializer.Serialize(parameterInfo));
                sb.Append(", ");
            }

            if (@params.Length > 0)
                sb.Length = sb.Length - 2;

            return sb.ToString();
        }
    }
}
