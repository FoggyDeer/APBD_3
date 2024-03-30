using LegacyApp;

namespace LegacyAppTests;

public class FakeUserCreditService : ICreditLimitService
{
    public int GetCreditLimit(string lastName, DateTime birthday)
    {
        return 1000;
    }
}