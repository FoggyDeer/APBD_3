namespace LegacyApp;

public interface IUserProcessor
{
    string Type { get; }
    void ProcessUser(User user, ICreditLimitService creditService);
}