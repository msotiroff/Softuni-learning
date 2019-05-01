using System.Collections.Generic;

public interface IProviderFactory
{
    Provider GenerateProvider(List<string> arguments);
}
