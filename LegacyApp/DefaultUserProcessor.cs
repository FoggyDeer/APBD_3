namespace LegacyApp;

public class DefaultUserProcessor : IUserProcessor
{
    public string Type => "DefaultClient";
    public void ProcessUser(User user, ICreditLimitService creditService)
    {
        user.HasCreditLimit = true;
        user.CreditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
    }
}