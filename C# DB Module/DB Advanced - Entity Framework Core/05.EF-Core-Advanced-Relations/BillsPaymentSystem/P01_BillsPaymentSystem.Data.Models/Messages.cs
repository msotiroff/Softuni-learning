namespace P01_BillsPaymentSystem.Data.Models
{
    public static class Messages
    {
        public const string InvalidLimit = "Limit can not be less than zero!";

        public const string InvalidOwedMoney = "Owed money must be less than your credit card limit!";

        public const string InvalidExpirationDate = "Expiration date must be later than current day!";

        public const string InvalidBalance = "Balance can not be less than zero!";

        public const string NotEnoughMoney = "Insufficient funds!";

        public const string InvalidDepositAmount = "Deposit amount must be more than zero!";
    }
}
