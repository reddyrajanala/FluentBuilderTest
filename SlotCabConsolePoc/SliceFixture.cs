using System;
using System.Threading.Tasks;

namespace GEI.GoldenEdge.WebApp.CTVS.Configuration.Tests.Builders
{
    public class SliceFixture
    {
        public static async Task InsertAsync(object foo)
        {
            await Task.FromResult(true);
        }

        public static DateTimeOffset GetSystemDateTime()
        {
            return DateTimeOffset.Now;
        }
    }
}