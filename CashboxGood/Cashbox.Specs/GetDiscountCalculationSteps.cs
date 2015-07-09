using System;
using FakeItEasy;
using TechTalk.SpecFlow;
using Cashbox.Models;
using Cashbox.DataAccess;
using Cashbox.Services;
using System.Linq;
using NUnit.Framework;

namespace Cashbox.Specs
{
    [Binding]
    public class GetDiscountCalculationSteps
    {
        private decimal _balance;
        private decimal _price;
        private decimal _result;

        [Given(@"I have create account whith balance (.*)")]
        public void GivenIHaveCreateAccountWhithBalance(decimal p0)
        {
            _balance = p0;
        }
        
        [Given(@"I have selected products in the amount of (.*)")]
        public void GivenIHaveSelectedProductsInTheAmountOf(decimal p0)
        {
            _price = p0;
        }
        
        [When(@"I ask what is account balance")]
        public void WhenIAskWhatIsAccountBalance()
        {
            // Arrange
            var product1 = new Product { Id = 1, Price = 1, Amount = 5 };
            var product2 = new Product { Id = 2, Price = 2, Amount = 10 };
            var product3 = new Product { Id = 3, Price = 3, Amount = 7 };

            var productRepository = A.Fake<IRepository<Product>>();
            A.CallTo(() => productRepository.Query()).Returns(new[] { product1, product2, product3 }.AsQueryable());

            var account = new Account { Id = 1, Balance = _balance };

            var accountRepository = A.Fake<IRepository<Account>>();
            A.CallTo(() => accountRepository.Get(A<int>._)).Returns(account);

            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.Repository<Product>()).Returns(productRepository);
            A.CallTo(() => unitOfWork.Repository<Account>()).Returns(accountRepository);

            var unitOfWorkFactory = A.Fake<IUnitOfWorkFactory>();
            A.CallTo(() => unitOfWorkFactory.Create()).Returns(unitOfWork);

            var service = new PurchaseService(unitOfWorkFactory);

            // Act
            service.Purchase(account.Id, new[] { product1.Id, product2.Id }, _price);
            _result = account.Balance;
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(decimal p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}
