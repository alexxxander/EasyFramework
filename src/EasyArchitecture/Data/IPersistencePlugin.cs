using System.Reflection;

namespace EasyArchitecture.Data
{
    public interface IPersistencePlugin
    {
        void Configure(string name, string connectionString, Assembly assembly);
        void BeginTransaction(object session);
        void CommitTransaction(object session);
        void RollbackTransaction(object session);
        object GetSession(string moduleName);
    }
}