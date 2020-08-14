using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class BankCustomer 
    {
        List<IAccountable> customerAccounts = new List<IAccountable>();
        private bool isVIP = false;


        public BankCustomer()
        {

        }

        public string Name
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public string PhoneNumber
        {
            get; set;
        }

        public bool IsVip
        {
            get
            {
               
                int balance = 0;
                for(int i = 0; i < customerAccounts.Count; i++)
                {
                    balance += customerAccounts[i].Balance;
                }
                if (balance < 25000)
                {
                    isVIP = false;
                }
                else
                {
                    isVIP = true;
                }

                return isVIP;
            }
        }



        public void AddAccount(IAccountable newAccount)
        {
            customerAccounts.Add(newAccount);
        }

        public IAccountable[] GetAccounts()
        {
            return customerAccounts.ToArray();
        }

    }
}
