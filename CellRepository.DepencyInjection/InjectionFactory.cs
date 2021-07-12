using CellRepository.ApplicationService.Areas.Smartphone;
using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.DomainServices;
using CellRepository.Infra.DataAcess;
using CellRepository.Infra.DataAcess.Areas;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces;
using CellRepository.Infra.DataAcess.Interfaces.Repositories;
using CellRepository.Infra.DataAcess.UnityOfWork;
using CellRepository.Services.Areas.Smartphone;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.DepencyInjection
{
    public static class InjectionFactory
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IContext, CellRepositoryContext>();

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddSingleton(typeof(IDomainServiceBase<>), typeof(DomainServiceBase<>));

            services.AddTransient<ISmartphoneRepository, SmartphoneRepository>();
            services.AddTransient<ISmartphoneDomainService, SmartphoneDomainService>();
            services.AddTransient<ISmartphoneApplicationService, SmartphoneApplicationService>();
        }
    }
}
