using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookStoreDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BookStoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Projects.Any())
            {
                context.Projects.AddRange(

                    new Project
                    {
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419429",
                        Category = "Fiction, Classic",
                        Price = 9.95F
                    },

                    new Project
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction, Business",
                        Price = 29.16F
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
