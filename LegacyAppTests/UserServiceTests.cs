using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Doe";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        string email = "doe";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId); 
        
        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void UserProcessor_Should_Set_HasCreditLimit_To_False_For_User()
    {
        //Arrange
        List<IUserProcessor> processors = new List<IUserProcessor>();
        processors.Add(new ImportantUserProcessor());
        processors.Add(new VeryImportantUserProcessor());
        
        UserProcessor userProcessor = new UserProcessor(processors);

        Client client = new Client();
        client.Type = "VeryImportantClient";
        var user = new User(client, new DateTime(1990, 1, 1), "poe@gmail.com", "John", "Biden");
        
        //Act
        userProcessor.ProcessUser(user, new FakeUserCreditService());
        
        //Assert
        Assert.Equal(false, user.HasCreditLimit);
    }
    
    [Fact]
    public void UserProcessor_Should_Set_CreditLimit_To_2000_For_User()
    {
        //Arrange
        List<IUserProcessor> processors = new List<IUserProcessor>();
        processors.Add(new ImportantUserProcessor());
        processors.Add(new VeryImportantUserProcessor());
        
        UserProcessor userProcessor = new UserProcessor(processors);

        Client client = new Client();
        client.Type = "ImportantClient";
        var user = new User(client, new DateTime(1990, 1, 1), "poe@gmail.com", "John", "Biden");
        
        //Act
        userProcessor.ProcessUser(user, new FakeUserCreditService());
        
        //Assert
        Assert.Equal(2000, user.CreditLimit);
    }
}