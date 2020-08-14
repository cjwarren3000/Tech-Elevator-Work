using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class CreditCardAccount  : IAccountable
    {
     
        public CreditCardAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
        }
        
        public int Balance
        {
            get
            {
                return Debt * -1;
            }
        }

        public string AccountHolderName
        {
            get; set;
        }

        public string AccountNumber
        {
            get; set;
        }

        public int Debt
        {
            get; set;
        }

        public int Charge(int amountToCharge)
        {
            return Debt += amountToCharge;
        }

        public int Pay(int amountToPay)
        {
            return Debt -= amountToPay;
        }
        
    }
}
