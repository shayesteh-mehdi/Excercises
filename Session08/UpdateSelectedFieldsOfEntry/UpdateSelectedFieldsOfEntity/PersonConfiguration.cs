using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UpdateSelectedFieldsOfEntity
{
    internal class PersonConfiguratino : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.Property(x => x.firstName).IsRequired();
            builder.Property(x => x.lastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}