using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Service_Layer.Services;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var builder = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=DESKTOP-NNB1CLI\\SQLEXPRESS; Database=AMS; User=sa; Password=P@ssw0rd;MultipleActiveResultSets=true;");

            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<Persistence_Layer.Models.TransactionCode, Service_Layer.Dtos.TransactionCodeDto>();
                opts.CreateMap<Service_Layer.Dtos.TransactionCodeDto, Persistence_Layer.Models.TransactionCode>();
            });
            var mapper = config.CreateMapper();

            IUnitOfWork unitOfWork = new UnitOfWork(new DataContext(builder.Options));

            TransactionCodeService transactionCodeService = new TransactionCodeService(unitOfWork, mapper);

            var codes = transactionCodeService.Get();

            Assert.AreNotEqual(codes, null);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var builder = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=DESKTOP-NNB1CLI\\SQLEXPRESS; Database=AMS; User=sa; Password=P@ssw0rd;MultipleActiveResultSets=true;");

            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<Persistence_Layer.Models.TransactionCode, Service_Layer.Dtos.TransactionCodeDto>();
                opts.CreateMap<Service_Layer.Dtos.TransactionCodeDto, Persistence_Layer.Models.TransactionCode>();
            });
            var mapper = config.CreateMapper();

            IUnitOfWork unitOfWork = new UnitOfWork(new DataContext(builder.Options));

            TransactionCodeService transactionCodeService = new TransactionCodeService(unitOfWork, mapper);

            Service_Layer.Dtos.TransactionCodeDto code = transactionCodeService.Get(100).Result;

            Assert.AreEqual(code.TranCode, 100);
        }
    }
}
