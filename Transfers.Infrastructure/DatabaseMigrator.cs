using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Domain.TransferTypes;

namespace Transfers.Infrastructure
{
    public class DatabaseMigrator
    {
        private readonly TransfersDbContext _context;

        public DatabaseMigrator(TransfersDbContext context)
        {
            _context = context;
        }

        public void Migrate()
        {
            _context.Database.Migrate();
            SeedData();
        }

        private void SeedData()
        {
            if (!_context.TransferTypes.Any())
            {
                _context.TransferTypes.AddRange(
                    new TransferType("Type 1"),
                    new TransferType("Type 2"));
                _context.SaveChanges();
            }
        }
    }
}
