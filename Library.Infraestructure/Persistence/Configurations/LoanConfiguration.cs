using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infraestructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(l => l.Book)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.IdBook)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
