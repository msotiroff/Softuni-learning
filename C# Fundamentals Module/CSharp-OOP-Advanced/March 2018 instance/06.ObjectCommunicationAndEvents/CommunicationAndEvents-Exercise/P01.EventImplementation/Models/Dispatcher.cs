namespace P01.EventImplementation.Models
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    
    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;
        
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }
        
        private void OnNameChange(NameChangeEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Name))
            {
                this.NameChange(this, args);
            }
        }
    }
}
