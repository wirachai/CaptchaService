using System;

namespace CaptchaService
{
    public class RandomNumber : IRandomNumber
    {
        public int GetPattern()
        {
            return Random(1, 2);
        }

        public int GetOperand()
        {
            return Random(1, 9);
        }

        public int GetOperator()
        {
            return Random(1, 3);
        }

        private int Random(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }
    }
}