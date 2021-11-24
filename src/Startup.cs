using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// Class for startup for the website 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Set up configuration 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// method calls configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add razorpage 
            services.AddRazorPages();

            //add servers
            services.AddServerSideBlazor();

            //add http client
            services.AddHttpClient();

            //add client 
            services.AddControllers();

            //Http context accessor 
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // connect to JsonFileProductService
            services.AddTransient<JsonFileProductService>();

            // connect to JsonFileUserService 
            services.AddTransient<JsonFileUserService>(); 

            //connect to JsonFilePollServices 
            services.AddTransient<JsonFilePollService>();
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //development
            if (env.IsDevelopment())
            {
                //use exception page
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //error 
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios,
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //redirection
            app.UseHttpsRedirection();

            //static files
            app.UseStaticFiles();

            //routing
            app.UseRouting();

            //authorization
            app.UseAuthorization();

            //endpoints
            app.UseEndpoints(endpoints =>
            {
                //razor pages 
                endpoints.MapRazorPages();

                //controllers
                endpoints.MapControllers();

                //blazor hub
                endpoints.MapBlazorHub();

            });
        }
    }
}