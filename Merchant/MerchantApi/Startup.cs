using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MerchantAbstraction.AutoMapper;
using MerchantData.Data;
using MerchantService.Images;
using MerchantService.Merchants;
using MerchantService.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MerchantApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>

            {
                c.SwaggerDoc(name: "V1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Merchant API", Version = "V1" });
            });


            services.AddDbContext<MerchantApiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(),typeof(Startup));

            services.AddScoped<IImagesService, ImagesService>();

            services.AddScoped<IMerchantsService, MerchantsService>();

            services.AddScoped<IProductsService, ProductsService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/V1/swagger.json", name: "Merchant API V1");
            });

            DockerMigration.Migrate(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
