using System;
using System.Reflection;
using System.Text;
using Easy.Core.Serializer;
using Easy.Instances.Log;
using Easy.Plugins.Contracts.Log;

namespace Easy.Core.Aspects.Log
{
    internal static class MethodCallLogger
    {
        internal static void LogInvokation(MethodInfo methodInfo, object[] parametersValue)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();
            if (logInstance.LogLevel != LogLevel.Debug && logInstance.LogLevel != LogLevel.Info)
                return;

            var sb = new StringBuilder();

            var counter = 0;
            foreach (var parameterInfo in methodInfo.GetParameters())
            {
                sb.Append(parameterInfo.Name);
                if (logInstance.LogLevel == LogLevel.Debug)
                {
                    sb.Append(" (");
                    sb.Append(JsonSerializer.Serialize(parametersValue[counter++]));
                    sb.Append(")");
                }
                sb.Append(", ");
            }

            if (counter > 0)
                sb.Length = sb.Length - 2;

            if (logInstance.LogLevel == LogLevel.Debug)
            {
                logInstance.LogDebug(string.Format("->[{0}]: {1}", methodInfo.Name, sb), null);
            }
            else
            {
                logInstance.LogInfo(string.Format("->[{0}]", methodInfo.Name), null);
            }
        }

        internal static void LogReturn(MethodInfo methodInfo, object returnValue, long elapsedMilliseconds)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();
            if (logInstance.LogLevel != LogLevel.Debug && logInstance.LogLevel != LogLevel.Info)
                return;

            if (logInstance.LogLevel == LogLevel.Debug)
            {
                logInstance.LogDebug(string.Format("<-[{0}]: ({1}) [{2}ms]", methodInfo.Name, JsonSerializer.Serialize(returnValue), elapsedMilliseconds), null);
            }
            else
            {
                logInstance.LogInfo(string.Format("<-[{0}] [{1}ms]", methodInfo.Name, elapsedMilliseconds), null);
            }
        }

        internal static void LogException(MethodInfo methodInfo, Exception ex, long elapsedMilliseconds)
        {
            var logInstance = InstanceProvider.GetInstance<Logger>();
            if (logInstance.LogLevel != LogLevel.Debug && logInstance.LogLevel != LogLevel.Info)
                return;

            if (logInstance.LogLevel == LogLevel.Debug)
                logInstance.LogDebug(string.Format("x [{0}]: {1} [{2}ms]", methodInfo.Name, ex.Message, elapsedMilliseconds), ex);

            if (logInstance.LogLevel == LogLevel.Info)
                logInstance.LogInfo(string.Format("x [{0}]: {1} [{2}ms]", methodInfo.Name, ex.Message, elapsedMilliseconds), ex);
        }
    }
}