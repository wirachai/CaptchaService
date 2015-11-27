using Moq;
using NUnit.Framework;

namespace CaptchaService.Test
{
    [TestFixture]
    internal class CaptchaServiceTest
    {
        [Test]
        public void GetCaptcha_ShouldReturnCaptchaObject()
        {
            CaptchaService service = new CaptchaService();
            Assert.IsInstanceOf(typeof(Captcha), service.GetCaptcha());
        }

        [Test]
        public void GetCaptcha_ShouldBeONEPlus1()
        {
            var stub = new Mock<IRandomNumber>();
            stub.Setup(randomer => randomer.GetPattern()).Returns(() => 1);
            stub.Setup(randomer => randomer.GetOperator()).Returns(() => 1);
            stub.Setup(randomer => randomer.GetOperand()).Returns(() => 1);

            CaptchaService service = new CaptchaService(stub.Object);
            Assert.AreEqual("ONE + 1", service.GetCaptcha().Get());
        }

        [Test]
        public void GetCaptcha_ShouldBeTWOPlus2()
        {
            var stub = new Mock<IRandomNumber>();
            stub.Setup(randomer => randomer.GetPattern()).Returns(() => 1);
            stub.Setup(randomer => randomer.GetOperator()).Returns(() => 1);
            stub.Setup(randomer => randomer.GetOperand()).Returns(() => 2);

            CaptchaService service = new CaptchaService(stub.Object);
            Assert.AreEqual("TWO + 2", service.GetCaptcha().Get());
        }

        [Test]
        public void GetCaptcha_ShouldBe2PlusTWO()
        {
            var stub = new Mock<IRandomNumber>();
            stub.Setup(randomer => randomer.GetPattern()).Returns(() => 2);
            stub.Setup(randomer => randomer.GetOperator()).Returns(() => 1);
            stub.Setup(randomer => randomer.GetOperand()).Returns(() => 2);

            CaptchaService service = new CaptchaService(stub.Object);
            Assert.AreEqual("2 + TWO", service.GetCaptcha().Get());
        }

        [Test]
        public void GetCaptcha_ShouldBe5PlusNINE()
        {
            var stub = new Mock<IRandomNumber>();
            stub.Setup(randomer => randomer.GetPattern()).Returns(() => 2);
            stub.Setup(randomer => randomer.GetOperator()).Returns(() => 1);
            stub.SetupSequence(randomer => randomer.GetOperand())
                .Returns(5)
                .Returns(9);

            CaptchaService service = new CaptchaService(stub.Object);
            Assert.AreEqual("5 + NINE", service.GetCaptcha().Get());
        }
    }
}