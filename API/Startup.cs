using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
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
            services.AddControllers();
            services.AddDbContext<DataContext>(options =>
            {
                // if (_env.IsDevelopment())
                // {
                    options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
                // }
                // else
                // {
                //     options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
                // }
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // public void ConfigureDevelopmentServices(IServiceCollection services)
        // {
        //     services.AddDbContext<DataContext>(options =>
        //     {
        //         options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
        //     });
        // }

        // public void ConfigureProductionServices(IServiceCollection services)
        // {
        //     services.AddDbContext<DataContext>(options =>
        //     {
        //         options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        //     });
        // }
    }
}