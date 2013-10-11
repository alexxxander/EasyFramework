using System;
using Easy.Instances.Persistence;

namespace Easy.Core.Aspects.Transaction
{
    internal class TransactionInterceptor : Interceptor
    {
        internal override object Invoke(ProxyMethodCall methodCall)
        {
            object ret;
            
            InstanceProvider.GetInstance<Persistence>().BeginTransaction();
            try
            {
                ret = Next(methodCall);
            }
            catch (Exception)
            {
                InstanceProvider.GetInstance<Persistence>().RollbackTransaction();
                throw;
            }

            InstanceProvider.GetInstance<Persistence>().CommitTransaction();
            return ret;
        }
    }
}