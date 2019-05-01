using System.Collections.Generic;

namespace P08.MilitaryElite.Contracts
{
    public interface ILeutenantGeneral : IPrivate
    {
        List<IPrivate> Privates { get; }
    }
}
