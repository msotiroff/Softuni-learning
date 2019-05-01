namespace P08.MilitaryElite.Models
{
    using Contracts;
    using System;
    using System.Linq;

    public class Mission : IMission
    {
        private readonly string[] ValidStates = { "inProgress", "Finished" };


        private string state;

        public string CodeName { get; private set; }
        
        public string State
        {
            get => this.state;
            private set
            {
                if (!this.ValidStates.Contains(value))
                {
                    throw new ArgumentException("Invalid state!");
                }

                this.state = value;
            }
        }

        public Mission(string codeName, string state)
        {
            this.State = state;
            this.CodeName = codeName;
        }

        public void CompleteMission()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.state}";
        }
    }
}
