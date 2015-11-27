namespace CaptchaService
{
    public interface IRandomNumber
    {
        int GetOperand();

        int GetOperator();

        int GetPattern();
    }
}