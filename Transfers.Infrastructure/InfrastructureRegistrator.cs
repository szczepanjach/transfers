using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Application.Data;
using Transfers.Domain.BusinessEntities;
using Transfers.Domain.Persons;
using Transfers.Domain.Transfers;
using Transfers.Domain.TransferTypes;
using Transfers.Infrastructure.Repositories;

namespace Transfers.Infrastructure
{
    public static class InfrastructureRegistrator
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration )
        {
            services.AddDbContext<TransfersDbContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("TransfersConnection")));
            services.AddTransient<DatabaseMigrator>();
            services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IBusinessEntityRepository, BusinessEntityRepository>();
            services.AddTransient<ITransferTypeRepository, TransferTypeRepository>();
            return services;
        }
    }
}
