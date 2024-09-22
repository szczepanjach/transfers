using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Domain.BusinessEntities;
using Transfers.Domain.Persons;
using Transfers.Domain.Transfers;
using Transfers.Domain.TransferTypes;

namespace Transfers.Infrastructure
{
    public class TransfersDbContext : DbContext
    {
        public DbSet<BusinessEntity> BusinessEntitys { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferType> TransferTypes { get; set; }

        public TransfersDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
