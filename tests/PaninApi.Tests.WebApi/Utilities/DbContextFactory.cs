using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PaninApi.WebApi;

namespace PaninApi.Tests.WebApi.Utilities
{
    [ExcludeFromCodeCoverage]
    public class DbContextFactory
    {
        public PaninApiDbContext DbContext { get; }

        public DbContextOptions<PaninApiDbContext> Options { get; }

        public DbContextFactory()
        {
            var builder = new DbContextOptionsBuilder<PaninApiDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).ConfigureWarnings(configurationBuilder =>
                    configurationBuilder.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            Options = builder.Options;

            DbContext = new PaninApiDbContext(Options);
        }
    }
}