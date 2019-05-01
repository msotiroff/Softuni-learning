namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class CreditCard
    {
        public CreditCard()
        {
        }

        public CreditCard(decimal limit, decimal moneyOwed, DateTime expDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.limitLeft = LimitLeft;
            this.ExpirationDate = expDate;
        }

        public int CreditCardId { get; set; }

        private decimal limit;

        private decimal moneyOwed;
        
        private decimal limitLeft;

        private DateTime expirationDate;

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        
        public decimal Limit
        {
            get
            {
                return this.limit;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Messages.InvalidLimit);
                }

                this.limit = value;
            }
        }

        public decimal MoneyOwed
        {
            get
            {
                return this.moneyOwed;
            }
            private set
            {
                if (value > this.Limit)
                {
                    throw new ArgumentException(Messages.InvalidOwedMoney);
                }

                this.moneyOwed = value;
            }
        }

        public decimal LimitLeft
        {
            get
            {
                return this.limitLeft;
            }
            private set
            {
                this.limitLeft = GetLimitLeft();
            }
        }

        public decimal GetLimitLeft()
        {
            return this.Limit - this.MoneyOwed;
        }

        public DateTime ExpirationDate
        {
            get
            {
                return this.expirationDate;
            }
            set
            {
                if (value <= DateTime.Now)
                {
                    throw new ArgumentException(Messages.InvalidExpirationDate);
                }

                this.expirationDate = value;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > this.LimitLeft)
            {
                throw new ArgumentException(Messages.NotEnoughMoney);
            }

            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            this.MoneyOwed -= amount;
        }
    }
}
