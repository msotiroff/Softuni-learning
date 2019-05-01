namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double DefaultWeight = 1.0;
        
        public HardDrive(double price) 
            : base(price, DefaultWeight)
        {
        }
    }
}
