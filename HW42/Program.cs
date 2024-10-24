using HW42;
using System;

BankAccount user1 = new("Arash","Rajabi","rajabiarsh36@gmail.com");
BankAccount user2 = new("Arash","Rajabi", "rajabiarsh256@gmail.com");
BankAccount user3 = new("Ali", "mohammadi", "Alimm@gmail.com");
BankAccount[] bankAccounts = new BankAccount[1000];
bankAccounts[0] = user1;
bankAccounts[1] = user2;
bankAccounts[2] = user3;
Services accountservice = new Services(bankAccounts);
string E ="";
int option = 0;
do
{
   Console.Clear();
    Console.WriteLine("Welcome to our bank.");
    Console.WriteLine("1.Log in.");
    Console.WriteLine("2.New to our bank? Sign in.");
    Console.WriteLine("3.Exit.");
   
    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.Clear();
            Console.Write("Please enter your email: ");
           E = Console.ReadLine();
            //Console.WriteLine("Password: ");
            //string P = Console.ReadLine();
            if (accountservice.SearchEmail(E)==true)
            { 
                Gotousersmenu(); 
                
            }
            else
            {
                Console.WriteLine("No Accounts Found, try again.");
                Console.ReadKey();
            }
            break;
        case 2:
            Console.Clear();
           bool CH = Adduser();
            if (CH == true)
            {
                Console.WriteLine("Congrats! you have created an account.");
                Console.WriteLine("We recommend you to set a password and phonenumber.");
                Console.WriteLine("1.Advance to menu     2.Exit");
                int Op = 0;
                Op = int.Parse(Console.ReadLine());
                if (Op == 1)
                { Gotousersmenu(); }
                else {  }
            }
            
          break;
    }
}
while (option< 3);
   void Gotousersmenu()
{
    int option2 = 0;
    do
    {
        int index = 0;
        index = accountservice.SearchIndex(E);
        Console.Clear();
        Console.WriteLine("Please choose what you wanna do:  ");
        Console.WriteLine("1.Add new Account.");
        Console.WriteLine("2.Change Password.");
        Console.WriteLine("3.Deposit money.");
        Console.WriteLine("4.Withdraw money.");
        Console.WriteLine("5.See Account information.");
        Console.WriteLine("6.set new phone number.");
        Console.WriteLine("7.Exit.");
        option2 = int.Parse(Console.ReadLine());
        switch(option2)
        {
            case 1: 
                Adduser(); 
                break;   
            case 2:
                Console.Clear();
                Console.Write("New password: ");
                string p = Console.ReadLine();
                bankAccounts[index].changepassword(p);
                break;
            case 3:
                Console.Clear();
                Console.Write("Enter an amount: ");
                long D = Convert.ToInt64(Console.ReadLine());
                bankAccounts[index].Deposit(D);
                break;
            case 4:
                Console.Clear();
                Console.Write("Enter an amount: ");
                long W = Convert.ToInt64(Console.ReadLine());
                bankAccounts[index].withdraw(W);
                break;
            case 5:
                Console.Clear();
                bankAccounts[index].AccountInfo();
                Console.WriteLine("press any botton.");
                Console.ReadKey();
                break;
            case 6:
                Console.Clear();
                Console.Write("Enter the new number: ");
                string pn = Console.ReadLine();
                bankAccounts[index].setPhone(pn);
                break;
        }

    }
    while (option2<7);
}
bool Adduser()
{
    Console.Clear();
  
    Console.Write("Write your name: ");
       string N = Console.ReadLine();
     Console.Write("Write your lastname: ");
       string L = Console.ReadLine();
     Console.Write("Write your Email: ");
       string E1 = Console.ReadLine();
  
   BankAccount NewUser = new(N, L, E1);
    
    Console.Write("Write your phone number:");
        string Ph = Console.ReadLine();
     bool Ch = NewUser.setPhone(Ph);
    if ( Ch == true )
    { accountservice.AddAccount(NewUser); return true; }
    else
    {
       
    } 
      return false;
}