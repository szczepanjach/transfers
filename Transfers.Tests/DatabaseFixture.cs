using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Infrastructure;

namespace Transfers.Tests
{
    public class DatabaseFixture
    {
        public TransfersDbContext CreateDbContext()
        {
            var context = new TransfersDbContext(new DbContextOptionsBuilder<TransfersDbContext>()
                .UseInMemoryDatabase("TransfersDb")
                .Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
