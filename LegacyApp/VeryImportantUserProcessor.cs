namespace LegacyApp;

public class VeryImportantUserProcessor : IUserProcessor
{
    public string Type => "VeryImportantClient";
    public void ProcessUser(User user, ICreditLimitService creditService)
    {
        user.HasCreditLimit = false;
    }
}