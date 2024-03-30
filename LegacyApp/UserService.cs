using System;
using System.Collections.Generic;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditService;

        [Obsolete]
        public UserService() : this(new ClientRepository(), new UserCreditService())
        {
        }
        
        public UserService(IClientRepository clientRepository,
            ICreditLimitService creditService)
        {
            _clientRepository = clientRepository;
            _creditService = creditService;
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!User.ValidateUserData(firstName, lastName, email, dateOfBirth))
                return false;

            var client = _clientRepository.GetById(clientId);
            var user = new User(client, dateOfBirth, email, firstName, lastName);

            UserProcessor userProcessor = new UserProcessor(new List<IUserProcessor>
            {
                new VeryImportantUserProcessor(),
                new ImportantUserProcessor()
            });
            userProcessor.ProcessUser(user, _creditService);

            if (DoesUserHaveAcceptableCreditLimit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private static bool DoesUserHaveAcceptableCreditLimit(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }
    }
}
