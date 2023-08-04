using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhongKham.Web.Initialize.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhongKham.Web.Initialize.SetupIdentity
{
    public class SetupIdentityDataSeeder : IHostedService
    {

        private readonly IServiceProvider _serviceProvider;
        public SetupIdentityDataSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedInitAccount>();

                await seeder.SeedAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    }
}
