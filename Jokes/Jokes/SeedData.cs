using Jokes.Core.Entities;
using Jokes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jokes
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!dbContext.Jokes.Any())
                    PopulateTestData(dbContext);
            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            dbContext.Jokes.AddRange(new List<Joke>()
            {
                new Joke()
                {
                    Id = 1,
                    Punchline = "the rest is used by 'rm -f node_modules && npm install",
                    Setup = "1/3 of US bandwidth is used by Netflix..."
                },
                new Joke()
                {
                    Id = 2,
                    Punchline = "None – It’s a hardware problem",
                    Setup = "How many programmers does it take to change a light bulb?"
                },
                new Joke()
                {
                    Id = 3,
                    Punchline = "One mistake and you have to support it for the rest of your life.",
                    Setup = "Programming is like sex:"
                }
            });

            dbContext.SaveChanges();
        }

    }
}
