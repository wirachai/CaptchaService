using System;
using System.Collections.Generic;

namespace CaptchaService
{
    public class Captcha
    {
        private int leftOperand;
        private int rightOperand;
        private int operatorValue;
        private Pattern pattern;

        private enum Pattern
        {
            WORD_OPERATOR_NUMBER = 1
        }

        private List<string> operands = new List<string> { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };

        public Captcha(int pattern, int leftOperand, int operatorValue, int rightOperand)
        {
            this.leftOperand = leftOperand;
            this.rightOperand = rightOperand;
            this.operatorValue = operatorValue;
            this.pattern = (Pattern)pattern;
        }

        public string Get()
        {
            return string.Format("{0} {1} {2}", GetLeftOperand(), GetOperator(), GetRightOperand());
        }

        public string GetLeftOperand()
        {
            ValidateInRangeZeroToNine(leftOperand);
            if (pattern == Pattern.WORD_OPERATOR_NUMBER)
            {
                return GetOperandWord(leftOperand);
            }
            return leftOperand.ToString();
        }

        public string GetRightOperand()
        {
            ValidateInRangeZeroToNine(rightOperand);
            if (pattern == Pattern.WORD_OPERATOR_NUMBER)
            {
                return rightOperand.ToString();
            }
            return GetOperandWord(rightOperand);
        }

        private void ValidateInRangeZeroToNine(int operand)
        {
            if (IsOperandNotInRangeZeroToNine(operand))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private bool IsOperandNotInRangeZeroToNine(int operand)
        {
            return operand < 0 || operand > 9;
        }

        private string GetOperandWord(int operand)
        {
            return operands[operand];
        }

        public string GetOperator()
        {
            switch (operatorValue)
            {
                case 1:
                    return "+";

                case 2:
                    return "*";

                case 3:
                    return "-";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}