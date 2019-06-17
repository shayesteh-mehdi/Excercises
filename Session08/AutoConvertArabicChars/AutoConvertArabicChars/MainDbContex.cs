using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConvertArabicChars
{

    class MainDbContex : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Initial Catalog=Exc_8_AutoConvertArabicChars;Integrated security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        public static string ConvertCharArabicToPersian(string Input)
        {
            string Output = Input.Trim().Replace(Strings.ChrW(1610), Strings.ChrW(1740));
            return Output.Replace(Strings.ChrW(1603), Strings.ChrW(1705));
        }


        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                foreach (var prop in item.Properties)
                {
                    if (prop.Metadata.ClrType == typeof(string))
                    {
                        if (prop.CurrentValue != null)
                        {
                            prop.CurrentValue = ConvertCharArabicToPersian((string)prop.CurrentValue);
                        }
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
