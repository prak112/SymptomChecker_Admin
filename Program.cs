using SymptomChecker_Admin2.Components;
using SymptomChecker_Admin2.Services;
using SymptomChecker_Admin2.Services.Interfaces;

namespace SymptomChecker_Admin2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Access environment variables
            var authApiUrl = builder.Configuration["AUTH_API_URL"];
            var adminApiUrl = builder.Configuration["ADMIN_API_URL"];
            if (string.IsNullOrEmpty(authApiUrl) || string.IsNullOrEmpty(adminApiUrl))
            {
                throw new ArgumentNullException("\nAPI URLs cannot be null or empty.");
            }

            // Configure HttpClient for AuthApiService
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(authApiUrl) });
            builder.Services.AddScoped<IAuthApiService>(sp => new AuthApiService(sp.GetRequiredService<HttpClient>(), authApiUrl));

            // Configure HttpClient for AdminApiService
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(adminApiUrl) });
            builder.Services.AddScoped<IAdminApiService>(sp => new AdminApiService(sp.GetRequiredService<HttpClient>(), adminApiUrl));


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days.
                // for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
