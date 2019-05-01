using Emergency_Skeleton.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Emergency_Skeleton.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IEnumerable<string> arguments)
        {
            this.Arguments = arguments;
        }

        protected IEnumerable<string> Arguments { get; }

        public abstract string Execute();
    }
}
