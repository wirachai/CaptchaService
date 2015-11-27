using NUnit.Framework;

namespace CaptchaService.Test
{
    [TestFixture]
    internal class RandomNumberTest
    {
        [Test]
        public void GetPattern_ShouldBeNumberInRange1To2()
        {
            RandomNumber random = new RandomNumber();
            Assert.That(random.GetPattern(), Is.InRange(1, 2));
        }

        [Test]
        public void GetOperand_ShouldBeNumberInRange1To9()
        {
            RandomNumber random = new RandomNumber();
            Assert.That(random.GetOperand(), Is.InRange(1, 9));
        }

        [Test]
        public void GetOperator_ShouldBeNumberInRange1To3()
        {
            RandomNumber random = new RandomNumber();
            Assert.That(random.GetOperator(), Is.InRange(1, 3));
        }
    }
}