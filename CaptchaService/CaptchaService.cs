namespace CaptchaService
{
    public class CaptchaService
    {
        private IRandomNumber random;

        public CaptchaService()
        {
            this.random = new RandomNumber();
        }

        public CaptchaService(IRandomNumber random)
        {
            this.random = random;
        }

        public Captcha GetCaptcha()
        {
            return new Captcha(random.GetPattern(), random.GetOperand(), random.GetOperator(), random.GetOperand());
        }
    }
}