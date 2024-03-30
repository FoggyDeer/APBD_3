using System.Collections.Generic;
using System.Linq;

namespace LegacyApp;

public class UserProcessor
{
    private readonly List<IUserProcessor> _processors;
    
    public UserProcessor(List<IUserProcessor> processors)
    {
        _processors = processors;
    }

    public void ProcessUser(User user, ICreditLimitService creditService)
    {
        var processor = _processors.FirstOrDefault(p => p.Type == ((Client)user.Client).Type) ?? new DefaultUserProcessor();
        processor.ProcessUser(user, creditService);
    }
}