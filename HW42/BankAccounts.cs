using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HW42
{
    public class Services
    {
        private BankAccount[] accounts { get; set; } = new BankAccount[1000];
        private int numberofAccounts;
        public Services(BankAccount[] Accounts)
        {
            int counter = 0;
            foreach (BankAccount account in Accounts)
            {
                accounts[counter] = account;
                if (account != null) { counter++; }
            }
           
            numberofAccounts = counter;
        }
        public void AddAccount (BankAccount account)
        {
            if (repetitiveAccount(account.GetEmail())==true)
            {
                Console.Write("The account already exists.");
                Console.ReadKey();
            }
            else
            {
                accounts[++numberofAccounts] = account;
            }
        }
        //private void RemoveAccount(BankAccount account) { }
        private bool repetitiveAccount(string email)
        {
           if(SearchEmail(email)==true) { return true; }
           return false;
       
        }
        public bool SearchEmail(string email) 
        {
            for (int i =0; i<accounts.Length;i++)
            {
                if(accounts[i] is null) { break;}
                if (accounts[i].GetEmail().ToLower() == email.ToLower())
                { 
                    return true;
                }
            }
            return false;
        }
        public int SearchIndex(string Email)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i] is null) { break; }
                if (accounts[i].GetEmail().ToLower() == Email.ToLower())
                {
                    return i;
                }
            }
            return 2;
        }


    }
}
