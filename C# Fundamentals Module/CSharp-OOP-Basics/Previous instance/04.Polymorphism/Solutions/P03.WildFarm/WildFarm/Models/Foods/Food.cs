namespace WildFarm.Models.Foods
{
    using System;

    public abstract class Food
    {
        private int quantity;

        public int Quantity
        {
            get => this.quantity;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative value!");
                }

                this.quantity = value;
            }
        }
    }
}
