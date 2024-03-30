namespace LegacyApp;

public class DefaultUserProcessor : IUserProcessor
{
    public string Type => "DefaultClient";
    public void ProcessUser(User user, ICreditLimitService creditService)
    {
        user.HasCreditLimit = true;
        int creditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        user.CreditLimit = creditLimit;
    }
}