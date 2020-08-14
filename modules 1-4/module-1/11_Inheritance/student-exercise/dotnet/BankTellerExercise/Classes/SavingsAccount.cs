namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {

        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if(Balance - amountToWithdraw < 150.0M && Balance - amountToWithdraw >= 2)
            {
                Balance -= amountToWithdraw + 2.0M;
                return Balance;
            }
            else if(Balance > amountToWithdraw)
            {
                Balance -= amountToWithdraw;
                return Balance;
            }
            else
            {
                return Balance;
            }
        }
    }
}
