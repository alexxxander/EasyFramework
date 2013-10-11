using System;
using Easy.Plugins.NHibernate.Persistence;
using FluentNHibernate.Cfg.Db;

namespace Easy.Plugins.NHibernate.Tests.Stuff.Fluently
{
    public class FluentlyNHibernateConfig : INHibernateFluentlyConfig
    {
        private readonly string _dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Stuff", "dogdb.db");

        public IPersistenceConfigurer ConfigureDatabase()
        {
            return
                SQLiteConfiguration.Standard.UsingFile(_dbPath).ShowSql();
        }
    }
}
