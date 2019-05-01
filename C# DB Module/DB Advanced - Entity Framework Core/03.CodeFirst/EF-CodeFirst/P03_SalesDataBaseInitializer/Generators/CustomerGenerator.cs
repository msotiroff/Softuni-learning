namespace P03_SalesDatabaseInitializer.Generators
{
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;

    public class CustomerGenerator
    {
        internal static void InitialCustomersSeed(SalesContext db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                db.Customers.Add(NewCustomer());
                db.SaveChanges();
            }
        }

        public static Customer NewCustomer()
        {
            string name = NameGenerator.FirstName() + " " + NameGenerator.LastName();
            string[] separatedName = name.Split(' ');
            string emailName = separatedName[0] + "." + separatedName[1];
            Customer customer = new Customer()
            {
                Name = name,
                Email = EmailGenerator.NewEmail(emailName),
                CreditCardNumber = CreditCardNumberGenerator.NewNumber()
            };

            return customer;
        }
    }
}
