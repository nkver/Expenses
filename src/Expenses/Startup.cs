using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Expenses.Areas.Identity;
using Expenses.Infrastructure.Data;
using Expenses.Infrastructure.Logic;
using Tewr.Blazor.FileReader;
using Expenses.Domain.Interfaces;
using Expenses.Infrastructure.Services;
using Expenses.Domain.Services;

namespace Expenses
{
    public class Startup
    {

        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExpensesContext>(options =>
                options.UseSqlite(
                    _config.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ExpensesContext>();

            services.AddRazorPages( o => o.RootDirectory = "/Pages");
            services.AddServerSideBlazor().AddHubOptions( o =>
            {
                o.MaximumReceiveMessageSize = _config.GetValue<long>("FileSizeLimit") * 1024 * 1024;
            });

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<ReadCsvService>();
            services.AddScoped<IAccountDataService, AccountDataService>();
            services.AddTransient<ITransactionDataService, TransactionDataService>();
            services.AddScoped<ICategoryDataService, CategoryDataService>();
            services.AddScoped<IFixedTransactionDataService, FixedTransactionDataService>();
            services.AddScoped<IIntervalService, IntervalService>();
            services.AddScoped<IOverviewService, OverviewService>();
            services.AddFileReaderService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ExpensesContext>();
                db.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
