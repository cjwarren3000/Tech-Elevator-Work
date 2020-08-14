namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {
        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (Balance > amountToWithdraw)
            {
                Balance -= amountToWithdraw;
            }
            else if (Balance < amountToWithdraw && Balance - amountToWithdraw > -90.0M)
            {
                Balance -= amountToWithdraw + 10.00M;
            }
            else if (Balance < amountToWithdraw && Balance - amountToWithdraw < -90.0M)
            {
                return Balance;
            }
            return Balance;
        }

        public override decimal Deposit(decimal amountToDeposit)
        {
            return base.Deposit(amountToDeposit);
        }
    }
}

