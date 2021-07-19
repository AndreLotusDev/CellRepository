using CellRepository.Domain.Entities;
using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.UnityOfWork;
using CellRepository.Services.Areas.Smartphone;
using CellRepository.Services.Areas.User;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Test.Area.Smartphones
{
    public class Smartphone_Adding_News
    {
        private Mock<CellRepositoryContext> _db;
        private Mock<IUnityOfWork> _uof;
        private Mock<ISmartphoneRepository> _ulRepo;
        private ISmartphoneDomainService smartphoneDomainService;

        [SetUp]
        public async Task Setup()
        {
            _db = new();
            _uof = new();
            _ulRepo = new();

            var smartphones = new List<SmartphoneEntity>
            {
               new SmartphoneEntity { OsName = "Windows 10", SmartphoneName = "BlackShark4"},
               new SmartphoneEntity { OsName = "Windows 12", SmartphoneName = "Zenfone 8"}
            };

            var _return = new SmartphoneEntity();

            _ulRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<SmartphoneEntity, bool>>>()))
                .Callback<Expression<Func<SmartphoneEntity, bool>>>(
                expression =>
                {
                    var func = expression.Compile();
                    _return = smartphones.FirstOrDefault(func);
                })
                .Returns(async () => await Task.FromResult(_return));

            _uof.SetupGet(x => x.SmartphoneRepository).Returns(_ulRepo.Object);

            smartphoneDomainService = new SmartphoneDomainService(_uof.Object);
        }

        /// <summary>
        /// Two smartphones in the DB cannt have the same name
        /// </summary>
        /// <returns></returns>
        [Test, Author("Andre SG")]
        public async Task Not_Allow_To_Create_The_Same_Name_Again()
        {
            SmartphoneEntity smartphoneEntity = new SmartphoneEntity { SmartphoneName = "blackshark4" };
            const string MESSAGE_EXPECTED = "Already exists a smartphone with this name in the database";
            const bool RESULT_EXPECTED = false;

            (var message, var status) = await smartphoneDomainService.RegisterANewSmartphoneAsync(smartphoneEntity);

            Assert.AreEqual(message, MESSAGE_EXPECTED);
            Assert.AreEqual(status, RESULT_EXPECTED);
        }

        [Test, Author("Andre SG")]
        public async Task Creating_Smartphone_With_Sucess()
        {
            SmartphoneEntity smartphoneEntity = new SmartphoneEntity { SmartphoneName = "Zenfone 7" };
            const string MESSAGE_EXPECTED = "Created with success";
            const bool RESULT_EXPECTED = true;

            (var message, var status) = await smartphoneDomainService.RegisterANewSmartphoneAsync(smartphoneEntity);

            Assert.AreEqual(message, MESSAGE_EXPECTED);
            Assert.AreEqual(status, RESULT_EXPECTED);
        }
    }
}
