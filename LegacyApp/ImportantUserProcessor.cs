namespace LegacyApp;

public class ImportantUserProcessor : IUserProcessor
{
    public string Type => "ImportantClient";
    public void ProcessUser(User user, ICreditLimitService creditService)
    {
        int creditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        creditLimit = creditLimit * 2;
        user.CreditLimit = creditLimit;
    }
}