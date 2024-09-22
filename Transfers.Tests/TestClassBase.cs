using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Infrastructure;
using Xunit;

namespace Transfers.Tests
{
    [Collection("TransfersTests")]
    public class TestClassBase : IClassFixture<DatabaseFixture>, IDisposable
    {
        protected DatabaseFixture _fixture;
        protected TransfersDbContext _transfersDbContext;

        public TestClassBase(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _transfersDbContext = fixture.CreateDbContext();
        }

        public void Dispose()
        {
            _transfersDbContext.Dispose();
        }
    }
}
