namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class BankAccount
    {
        public BankAccount()
        {
        }

        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SWIFTCode = swiftCode;
        }

        public int BankAccountId { get; set; }

        private decimal balance;
        
        public string BankName { get; set; }

        public string SWIFTCode { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Messages.InvalidBalance);
                }

                this.balance = value;
            }
        }


        public void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException(Messages.NotEnoughMoney);
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(Messages.InvalidDepositAmount);
            }

            this.Balance += amount;
        }
    }
}
