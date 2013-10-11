using FluentNHibernate.Cfg.Db;

namespace Easy.Plugins.NHibernate.Persistence
{
    public interface INHibernateFluentlyConfig
    {
        IPersistenceConfigurer ConfigureDatabase();
    }
}