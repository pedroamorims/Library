using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infraestructure.Persistence.Configurations
{
    public class WaitListConfiguration : IEntityTypeConfiguration<WaitList>
    {
        public void Configure(EntityTypeBuilder<WaitList> builder)
        {
            builder
                 .HasKey(x => x.Id);


            builder
                .HasOne(l => l.User)
                .WithMany(u => u.WaitLists)
                .HasForeignKey(l => l.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(l => l.Book)
                .WithMany(u => u.WaitLists)
                .HasForeignKey(l => l.IdBook)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
