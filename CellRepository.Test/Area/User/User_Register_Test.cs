using CellRepository.Domain.Entities;
using CellRepository.Infra.DataAcess.Areas.User;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces.Repositories.User;
using CellRepository.Infra.DataAcess.UnityOfWork;
using CellRepository.Services.Areas.User;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CellRepository.Test.Area.User
{
    public class Tests
    {
        private Mock<CellRepositoryContext> _db;
        private Mock<IUnityOfWork> _uof;
        private Mock<IUserLoginRepository> _ulRepo;
        private IUserLoginDomainService _userLoginService;

        [SetUp]
        public void Setup()
        {
            _db = new();
            _uof = new();
            _ulRepo = new();

            var logins = new List<UserLoginEntity>
            { 
                new UserLoginEntity { Email = "andrsoares953@yahoo.com", Password = "12345678910"},
                new UserLoginEntity { Email = "andrsoares955@yahoo.com", Password = "12345678910"},
            };

            _ulRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<UserLoginEntity, bool>>>())).ReturnsAsync(new UserLoginEntity { Email = "andrsoares955@yahoo.com", Password = "12345678910", NameInSite = "WhiteLotusZuko" });

            _uof.SetupGet(x => x.UserLoginRepository).Returns(_ulRepo.Object);

            _userLoginService = new UserLoginDomainService(_uof.Object);
        }

        /// <summary>
        /// Checks if the user cannt create a new user with the same email
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Cannot_Create_A_Two_Times_The_Same_Email()
        {
            var alreadyExist = new UserLoginEntity { Email = "andrsoares955@yahoo.com", Password = "12345678910" };
            var expectedMessageError = "This emails is already being used";

            var result = await _userLoginService.RegisterANewUserAsync(alreadyExist);

            Assert.IsFalse(result.status);
            Assert.AreSame(result.message, expectedMessageError);
        }

        /// <summary>
        /// Checks if the user cannt create a new user with the same username
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Cannot_Create_The_SameUserName()
        {
            var alreadyExist = new UserLoginEntity { Email = "andrsoares957@yahoo.com", Password = "12345678910", NameInSite = "WhiteLotusZuko" };
            var expectedMessageError = "This name of user is already being used";

            var result = await _userLoginService.RegisterANewUserAsync(alreadyExist);

            Assert.IsFalse(result.status);
            Assert.AreSame(result.message, expectedMessageError);
        }
    }
}