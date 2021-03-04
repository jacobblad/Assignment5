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
                        Price = 9.95F,
                        PageNumbers = 1488
                    },

                    new Project
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction, Business",
                        Price = 29.16F,
                        PageNumbers = 400
                    },

                    new Project
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691 ",
                        Category = "Non-Fiction, Self-Help",
                        Price = 14.99F,
                        PageNumbers = 304
                    },

                    new Project
                    {
                        Title = "Unbroken",
                        Author = "Laura HillenBrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Non-Fiction, Historical",
                        Price = 13.33F,
                        PageNumbers = 528
                    },

                    new Project
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category = "Non-Fiction, Self-Help",
                        Price = 21.66F,
                        PageNumbers = 240
                    },

                    new Project
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction, Biography",
                        Price = 14.58F,
                        PageNumbers = 944
                    },

                    new Project
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Category = "Non-Fiction, Biography",
                        Price = 21.54F,
                        PageNumbers = 832
                    },

                    new Project
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Category = "Non-Fiction, Biography",
                        Price = 11.61F,
                        PageNumbers = 864
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
