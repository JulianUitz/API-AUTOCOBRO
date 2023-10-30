using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using nuevapicobro.Domain.Entities;
using nuevapicobro;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configurar DbContext
        services.AddDbContext<DbPayUsContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbPayUsContext")));

        // Otros servicios
        services.AddControllers();
        // Agrega otros servicios necesarios, como autenticación, autorización, Swagger, etc.
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Configura el middleware y el enrutamiento
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Configura autenticación y autorización si es necesario
        // app.UseAuthentication();
        // app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        // Agrega middleware personalizado si es necesario
        // app.UseMiddleware<CustomMiddleware>();
    }
}
