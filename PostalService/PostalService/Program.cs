using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostalService.DataBase;
using PostalService.DataBase.Repositorys;
using PostalService.DataBase.Repositorys.Interfase;
using PostalService.Domain;
using System.Configuration;

namespace PostalService
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var context = services.GetRequiredService<BaseDbContext>();
                context.Database.Migrate();

                ApplicationConfiguration.Initialize();
                Application.SetCompatibleTextRenderingDefault(false);
                var mainForm = services.GetRequiredService<Form1>();
                Application.Run(mainForm);
            }
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<BaseDbContext>(options =>
                    {
                        options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=qwe123;Database=PostalService;");
                    });

                    services.AddTransient<IMemberRepository, MemberRepository>();
                    services.AddTransient<IPostalService, KitService>();
                    services.AddTransient<Form1>();
                    services.AddTransient<ViewingLetter>();
                });
        }
    }
}