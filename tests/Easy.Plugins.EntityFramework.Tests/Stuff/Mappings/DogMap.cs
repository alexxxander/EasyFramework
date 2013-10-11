using System.Data.Entity.ModelConfiguration;
using Easy.Plugins.Tests.Persistence.Stuff;

namespace Easy.Plugins.EntityFramework.Tests.Stuff.Mappings
{
    public class DogMapping : EntityTypeConfiguration<Dog>
    {
        public DogMapping()
        {
            ToTable("Dog");
            HasKey(x => x.Id);
            Property(x => x.Name);
            Property(x => x.Age);
        }
    }
}