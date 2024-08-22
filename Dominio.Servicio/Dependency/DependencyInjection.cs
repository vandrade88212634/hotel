using Common.Utils.RestServices.Interface;
using Common.Utils.RestServices;
using Common.Utils.Utils.Interface;
using Common.Utils.Utils;
using Infraestructura.Core.Context.SQLServer;
using Infraestructura.Core.Repository.Interface;
using Infraestructura.Core.Repository;
using Infraestructura.Core.UnitOfWork;
using Infraestructura.Core.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dominio.Servicio.Servicios;
using Dominio.Servicio.Servicios.Interfaces;
using Microsoft.Extensions.Caching.Memory;


namespace Dominio.Servicio.Dependency
{
    public static class DependencyInyection
    {

    
        public static IServiceCollection AddInfraestructuraServices(this IServiceCollection services,
                IConfiguration configuration)
        {






            services.AddScoped<IHotelServices, HotelServices>();
            services.AddScoped<IReservasServices, ReservasServices>();



            services.AddScoped<MemoryCache, MemoryCache>();
            services.AddScoped<Utils, Utils>();
            services.AddScoped<UnitOfWork, UnitOfWork>();
           



            // Infrastructure

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IHeaderClaims, HeaderClaims>();
            services.AddTransient<IRestService, RestService>();
            services.AddTransient<IMemoryCache, MemoryCache>();
            services.AddTransient<IUtils, Utils>();
            services.AddTransient<IAuthentication, Authentication>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBinnacle, Binnacle>();
           
            services.AddTransient<IHotelServices, HotelServices>();
            services.AddTransient<IReservasServices, ReservasServices>();


            // Common




            ////Utils
            //services.AddTransient<IUtils, Utils>();
            //services.AddTransient<IAuthentication, Authentication>();



            services.AddDbContext<Infraestructura.Core.Context.SQLServer.ContextSql>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("ConnectionStringSQLServer"),
                  providerOptions => providerOptions.EnableRetryOnFailure()));




            return services;
        }


        
        #region methods




        private static IConfigurationRoot GetConnection()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        #endregion

    }

}
