using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveAll
{
    public class MainDbContex : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<JobTitle> jobTitles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=. ; Initial catalog=Exc_8_RemoveAll ; Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People123", "schema_test");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasMany(t => t.jobTitles).WithOne(x => x.person ).HasForeignKey(s => s.PersonId);


        }




    }
}
