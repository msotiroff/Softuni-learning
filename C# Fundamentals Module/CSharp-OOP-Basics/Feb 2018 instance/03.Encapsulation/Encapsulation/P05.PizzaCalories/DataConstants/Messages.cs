namespace P05.PizzaCalories.DataConstants
{
    internal class Messages
    {
        public static readonly string InvalidDoughType = "Invalid type of dough.";
        public static readonly string InvalidDoughWeight = "Dough weight should be in the range [{0}..{1}].";

        public static readonly string InvalidToppingType = "Cannot place {0} on top of your pizza.";
        public static readonly string InvalidToppingWeight = "{0} weight should be in the range [{1}..{2}].";

        public static readonly string InvalidPizzaName = "Pizza name should be between {0} and {1} symbols.";
        public static readonly string InvalidToppingsCount = "Number of toppings should be in range [0..{0}].";
    }
}
