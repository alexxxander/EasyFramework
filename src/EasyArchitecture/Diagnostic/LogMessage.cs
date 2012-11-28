using System;

namespace EasyArchitecture.Diagnostic
{
    public  class LogMessage
    {
        internal readonly Type Logger;
        internal  object _message;
        internal  Exception _exception;

        internal LogMessage(Type logger)
        {
            Logger = logger;
        }

        public LogAction Message(string message, params object[] objs)
        {
            _message = string.Format(message, objs);
            return new LogAction(this);
        }
        public LogAction Raw(object obj)
        {
            _message = obj;
            return new LogAction(this);
        }

        public LogAction Exception(Exception exception)
        {
            _exception = exception;
            return new LogAction(this);
        }
        public LogAction Exception(Exception exception, string message, params object[] objs)
        {
            _exception = exception;
            _message = string.Format(message, objs);
            return new LogAction(this);
        }
    
    }
}