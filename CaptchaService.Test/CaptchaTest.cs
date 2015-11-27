using NUnit.Framework;
using System;

namespace CaptchaService.Test
{
    [TestFixture]
    internal class CaptchaTest
    {
        [Test]
        public void LeftOperand_ShouldBe1_WhenInputIs1()
        {
            Captcha captcha = new Captcha(2, 1, 1, 1);
            Assert.AreEqual("1", captcha.GetLeftOperand());
        }

        [Test]
        public void LeftOperand_ShouldBe2_WhenInputIs2()
        {
            Captcha captcha = new Captcha(2, 2, 1, 1);
            Assert.AreEqual("2", captcha.GetLeftOperand());
        }

        [Test]
        public void LeftOperand_ShouldBe9_WhenInputIs9()
        {
            Captcha captcha = new Captcha(2, 9, 1, 1);
            Assert.AreEqual("9", captcha.GetLeftOperand());
        }

        [Test]
        public void LeftOperand_ShouldThrowArgumentOutOfRangeException_WhenInputIsMinus1()
        {
            Captcha captcha = new Captcha(2, -1, 1, 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => captcha.GetLeftOperand());
        }

        [Test]
        public void RightOperand_ShouldBeONE_WhenInputIs1()
        {
            Captcha captcha = new Captcha(2, 1, 1, 1);
            Assert.AreEqual("ONE", captcha.GetRightOperand());
        }

        [Test]
        public void RightOperand_ShouldBeTWO_WhenInputIs2()
        {
            Captcha captcha = new Captcha(2, 1, 1, 2);
            Assert.AreEqual("TWO", captcha.GetRightOperand());
        }

        [Test]
        public void RightOperand_ShouldBeNINE_WhenInputIs9()
        {
            Captcha captcha = new Captcha(2, 1, 1, 9);
            Assert.AreEqual("NINE", captcha.GetRightOperand());
        }

        [Test]
        public void RightOperand_ShouldThrowArgumentOutOfRangeException_WhenInputIsMinus1()
        {
            Captcha captcha = new Captcha(2, 1, 1, -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => captcha.GetRightOperand());
        }

        [Test]
        public void RightOperand_ShouldThrowArgumentOutOfRangeException_WhenInputIs10()
        {
            Captcha captcha = new Captcha(2, 1, 1, 10);
            Assert.Throws<ArgumentOutOfRangeException>(() => captcha.GetRightOperand());
        }

        [Test]
        public void Operator_ShouldBePlus_WhenInputIs1()
        {
            Captcha captcha = new Captcha(pattern: 2, leftOperand: 1, operatorValue: 1, rightOperand: 1);
            Assert.AreEqual("+", captcha.GetOperator());
        }

        [Test]
        public void Operator_ShouldBeMultiply_WhenInputIs2()
        {
            Captcha captcha = new Captcha(pattern: 2, leftOperand: 1, operatorValue: 2, rightOperand: 1);
            Assert.AreEqual("*", captcha.GetOperator());
        }

        [Test]
        public void Operator_ShouldBeMinus_WhenInputIs3()
        {
            Captcha captcha = new Captcha(pattern: 2, leftOperand: 1, operatorValue: 3, rightOperand: 1);
            Assert.AreEqual("-", captcha.GetOperator());
        }

        [Test]
        public void Operator_ShouldThrowArgumentOutOfRangeException_WhenInputNotIn1To3()
        {
            Captcha captcha = new Captcha(2, 1, 0, 10);
            Assert.Throws<ArgumentOutOfRangeException>(() => captcha.GetOperator());
            captcha = new Captcha(2, 1, 4, 10);
            Assert.Throws<ArgumentOutOfRangeException>(() => captcha.GetOperator());
        }

        [Test]
        public void LeftOperand_ShouldBeTWO_WhenPatternIs1AndLeftOperandIs2()
        {
            var captcha = new Captcha(1, 2, 1, 1);
            Assert.AreEqual("TWO", captcha.GetLeftOperand());
        }

        [Test]
        public void LeftOperand_ShouldBeONE_WhenPatternIs1AndLeftOperandIs1()
        {
            Captcha captcha = new Captcha(pattern: 1, leftOperand: 1, operatorValue: 2, rightOperand: 1);
            Assert.AreEqual("ONE", captcha.GetLeftOperand());
        }

        [Test]
        public void RightOperand_ShouldBe1_WhenPatternIs1AndRightOperandIs1()
        {
            Captcha captcha = new Captcha(pattern: 1, leftOperand: 1, operatorValue: 2, rightOperand: 1);
            Assert.AreEqual("1", captcha.GetRightOperand());
        }

        [Test]
        public void RightOperand_ShouldThrowArgumentOutOfRangeException_WhenPatternIs1AndRightOperandIs10()
        {
            Captcha captcha = new Captcha(1, 1, 1, 10);
            Assert.Throws<ArgumentOutOfRangeException>(() => captcha.GetRightOperand());
        }

        [Test]
        public void Get_ShouldBeOnePlus1_WhenPatternIs1_LeftOperandIs1_OperatorIs1_RightOperandIs1()
        {
            var captcha = new Captcha(1, 1, 1, 1);
            Assert.AreEqual("ONE + 1", captcha.Get());
        }

        [Test]
        public void Get_ShouldBe1MultiplyOne_WhenPatternIs2_LeftOperandIs1_OperatorIs2_RightOperandIs1()
        {
            var captcha = new Captcha(2, 1, 2, 1);
            Assert.AreEqual("1 * ONE", captcha.Get());
        }

        [Test]
        public void Get_ShouldBeTWOMultiply2_WhenPatternIs1_LeftOperandIs2_OperatorIs2_RightOperandIs2()
        {
            var captcha = new Captcha(1, 2, 2, 2);
            Assert.AreEqual("TWO * 2", captcha.Get());
        }
    }
}