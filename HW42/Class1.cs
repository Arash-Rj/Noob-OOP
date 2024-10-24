using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW42
{
  public class BankAccount
    {
        private string name {  get; set; }
        private string password { get; set; }
        private int OwnerID { get; set; }
        private int AccountNumber { get; set; }
        private string phonenumber { get; set; }
        private long Cardnumber { get; set; }
        private string lastname { get; set; }
        private string Owner { get; set; }
        private long Balance { get; set; }
        private string Establishmentdate { get; set; }
        private string email { get; set; }
      
        public BankAccount( string Name, string Lastname, string Email)
        {
            name = Name;
            email = Email;
            lastname = Lastname;
            AccountNumber = Convert.ToInt32(Lastname[0]) * Convert.ToInt32(Name[0]);
            password = Convert.ToInt32(Name[0]).ToString() + AccountNumber;
            Balance = 100;
            Owner = Name + Lastname; 
        }
        public void changepassword(string pass)
        {
            if(pass.Length > 10)
            {
                Console.Write("Too long.please try again.");
            }
            else { password = pass; }
        }
        public void Deposit(long Amount)
        {
            Balance += Amount;
        }
        public void withdraw(long Amount)
        {
           if (Balance < Amount)
            {
                {
                    Console.Write("Not enough Balance.");
                }
            }
            Balance -= Amount;
        }
        public long Showbalance()
        {
            return Balance;
        }
        public bool setPhone(string PN)
        {
            bool check = PN.All(char.IsNumber);
            string PN2 = PN.Replace("+98", "0");
            bool C = false;
           switch (check)
            {
                case true:
                    if (PN2.Length > 14 && PN2.Length < 11 && PN2.Length == 12.13)
                    {
                        Console.WriteLine("incorrect phone number, please try agian.");
                       return C;
                    }
                    else if (PN2.Length == 11 && PN2.Substring(0, 2) == "09")
                    {
                        phonenumber = PN2; return !C;
                    }
                    else if (PN.Substring(0, 4) == "0098" && PN.Length == 14)
                    {
                        phonenumber = PN2; return !C;
                    }
                    else
                    {
                        Console.WriteLine("incorrect phone number, please try agian.");
                        return C;
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Incorrect characters.");
                        return C;
                    }
                    break;

            }
        }
        public string Getphonenumber() { return phonenumber; }
        public string GetEmail() { return email; }
        private string GetPass() { return password; }
        private string Getowner() { return Owner; }   

        //public void Setcardnumber() { }
       //public void setEstablishmentdate() { }
       public void AccountInfo()
        {
            Console.WriteLine("Owner: "+Getowner());
            Console.WriteLine("Email: "+GetEmail());
            Console.WriteLine("Phone number: "+Getphonenumber());
            Console.WriteLine("Balance: "+Showbalance());
            Console.WriteLine("Password: " + password);   
        }

        


    }
}
