using Easy.Core.Aspects.Context;
using Easy.Core.Aspects.Log;
using Easy.Core.Aspects.Transaction;

namespace Easy.Core.Aspects
{
    internal static class InterceptorFactory
    {
        private static  Interceptor _interceptor ;

        internal static Interceptor GetInstance()
        {
            return _interceptor ?? (_interceptor = new ContextInterceptor()
                                                       .SetSuccessor(
                                                           new LogInterceptor().SetSuccessor(
                                                               new TransactionInterceptor())));
        }
    }
}