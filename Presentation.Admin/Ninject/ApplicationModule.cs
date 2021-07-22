using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellRepository.Infra.DataAcess.UnityOfWork;
using CellRepository.Infra.DataAcess.Interfaces;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces.Repositories;
using CellRepository.Infra.DataAcess;
using CellRepository.DomainServices;
using CellRepository.ApplicationService.Areas.Smartphone;
using CellRepository.Services.Areas.Smartphone;
using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.Services.Areas.User;
using CellRepository.Infra.DataAcess.Areas;
using CellRepository.ApplicationService.Areas.User;
using CellRepository.Infra.DataAcess.Areas.User;
using CellRepository.Infra.DataAcess.Interfaces.Repositories.User;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CellRepository.Infra.Mappings;
using CellRepository.Infra.AwsService.Amazon;

namespace Presentation.Admin.Ninject
{
    class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            DbContextOptionsBuilder<CellRepositoryContext> option = new();
            option.UseNpgsql("Server=localhost;Port=7272;Database=Smartphone;User Id=postgres;Password=vovodetopialandia321;Timeout=15;", 
                optionsBuilder => optionsBuilder.MigrationsAssembly("CellRepository.Infra.DataAcess"));

            CellRepositoryContext context = new(option.Options);

            var configMap = new MapperConfiguration(cfg =>
            {
                ConfigGeneral.OnConfigure(cfg);
            });
            IMapper mapper = configMap.CreateMapper();

            AwsService serviceCloud = new ();

            var keyId = Environment.GetEnvironmentVariable("AMAZONKEYID", EnvironmentVariableTarget.User);
            var keySecret = Environment.GetEnvironmentVariable("AMAZONKEYSECRET", EnvironmentVariableTarget.User);

            serviceCloud.Start(keyId, keySecret);

            Bind(typeof(IUnityOfWork)).To(typeof(UnityOfWork));
            Bind(typeof(IContext)).ToConstant(context);

            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind(typeof(IDomainServiceBase<>)).To(typeof(DomainServiceBase<>));

            Bind(typeof(ISmartphoneRepository)).To(typeof(SmartphoneRepository));
            Bind(typeof(ISmartphoneDomainService)).To(typeof(SmartphoneDomainService));
            Bind(typeof(ISmartphoneApplicationService)).To(typeof(SmartphoneApplicationService));

            Bind(typeof(IUserLoginRepository)).To(typeof(UserLoginRepository));
            Bind(typeof(IUserLoginDomainService)).To(typeof(UserLoginDomainService));
            Bind(typeof(IUserApplicationService)).To(typeof(UserLoginApplicationService));

            Bind(typeof(IMapper)).ToConstant(mapper);
            Bind(typeof(ICloudImgService)).ToConstant(serviceCloud);
        }
    }
}
