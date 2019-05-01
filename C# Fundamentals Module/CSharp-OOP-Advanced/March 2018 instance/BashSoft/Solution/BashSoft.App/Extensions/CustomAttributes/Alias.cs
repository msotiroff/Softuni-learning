namespace BashSoft.App.Extensions.CustomAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class AliasAttribute : Attribute
    {
        private string[] types;

        public AliasAttribute(params string[] types)
        {
            this.Types = types;
        }

        public AliasAttribute()
        {
            this.Types = null;
        }

        public string[] Types
        {
            get => this.types;

            private set => this.types = value;
        }
    }
}
