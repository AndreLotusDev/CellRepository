using AutoMapper;
using CellRepository.DepencyInjection;
using CellRepository.Infra.AwsService.Amazon;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.Mappings;
using CellRepository.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace SmartphoneApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartphoneApi", Version = "v1" });
            });

            string dbConnectionString = Configuration.GetConnectionString("SmartphoneDb");

            #region Configuring The Mapper
            var configMap = new MapperConfiguration(cfg =>
                {
                    ConfigGeneral.OnConfigure(cfg);
                });

            IMapper mapper = configMap.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            AwsService serviceCloud = new AwsService();

            var keyId = Environment.GetEnvironmentVariable("AMAZONKEYID", EnvironmentVariableTarget.User);
            var keySecret = Environment.GetEnvironmentVariable("AMAZONKEYSECRET", EnvironmentVariableTarget.User);

            serviceCloud.Start(keyId, keySecret);

            services.AddDbContext<CellRepositoryContext>(
                options => options.UseNpgsql(dbConnectionString, optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly("CellRepository.Infra.DataAcess");
                }));

            InjectionFactory.ConfigureServices(services);

            string keyCript = Configuration.GetValue<string>("PasswordKey");
            string secretKey = Configuration.GetValue<string>("SecretKey");

            ConfigJson configJson = new(keyCript, secretKey);

            services.AddSingleton(configJson);
            services.AddSingleton(typeof(ICloudImgService), serviceCloud);

            var key = Encoding.ASCII.GetBytes(configJson.SecretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartphoneApi v1"));
            }

            //Needs to be configured on the future
            app.UseCors(cfg => cfg.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
