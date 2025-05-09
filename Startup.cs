using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.OpenApi.Models;
using RazorRender.Services;
using RazorRender.Services.Interfaces;
using System.Reflection;

namespace RazorRender;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
        services.AddScoped<IViewRenderService, ViewRenderService>();
        //services.AddScoped<IRazorViewEngine, RazorViewEngine>();


        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                var version = assembly
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    ?.InformationalVersion;
                var assemblyName = assembly.GetName().Name;

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = assemblyName,
                    Version = version ?? "v1"
                });

                var xmlFile = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml");
                if (File.Exists(xmlFile))
                    c.IncludeXmlComments(xmlFile, true);
            }
        });
    }

    public void Configure(IApplicationBuilder builder, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            builder.UseDeveloperExceptionPage();
            builder.UseSwagger();
            var assembly = Assembly.GetEntryAssembly();
            builder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", assembly.FullName.Split(",").First()));
        }

        //Allow all CORS
        builder.UseCors("CorsPolicy");

        builder.UseRouting();

        builder.UseAuthentication();
        builder.UseAuthorization();

        builder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}