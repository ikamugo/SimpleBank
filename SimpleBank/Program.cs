using SimpleBank.Classes;

namespace SimpleBank;

public class Program
{
    static List<Account> _accounts = new List<Account>()
    {
        new Account("Raihaan Bukenya", 2000000),
        new Account("Martha Kipwola", 2500000),
        new Account("James Semate", 1800000),

    };
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Simple Bank Limited");
        while (true)
        {
            var option = GetOption();
            switch (option)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    ListAccounts();
                    break;
                case 3:
                    MakeAccountDeposit();
                    break;
                case 4:
                    MakeAccountWithdraw();
                    break;
                case 5: 
                    PrintAccountStatement();
                    break;
                case 6:
                    PrintBankStatus();
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }






    static int GetOption()
    {
        int option = 0;
        
        while(option < 1 || option > 6)
        {
            Console.WriteLine("###############################################");
            Console.WriteLine("Select one of the options:");
            Console.WriteLine("1. Create Bank New Account");
            Console.WriteLine("2. List Bank Accounts");
            Console.WriteLine("3. Deposit on Account");
            Console.WriteLine("4. Withdraw from Account");
            Console.WriteLine("5. Print Account Statement");
            Console.WriteLine("6. Print Bank Status");
            Console.WriteLine("###############################################");

            var input = Console.ReadLine();
            int.TryParse(input, out option);

            if (option < 1 || option > 6)
                Console.WriteLine("Invalid selection!!!!");
        }

        return option;
    }

    static void CreateAccount()
    {
        Console.WriteLine("Enter the customer name: ");
        var customerName = Console.ReadLine();


        Console.WriteLine("Enter the initial Deposit: ");
        var input = Console.ReadLine();
        double.TryParse(input, out double amount);
        
        try
        {
            
            Account myAccount = new Account(customerName, amount);
            _accounts.Add(myAccount);
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error has occured.");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Account creation failed.");
        }
    }

    static void ListAccounts()
    {
        if(_accounts.Count == 0)
            Console.WriteLine("There are no accounts in the bank.");
        else
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Account Number\t\tAccount Name\t\tBalance");
            foreach (var account in _accounts)
            {
                Console.WriteLine($"{account.GetNumber()}\t\t{account.GetName()}\t\t{account.GetBalance()}");
            }
            Console.WriteLine("-------------------------------------------------------------");
        }
    }

    static void MakeAccountDeposit()
    {
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Enter the account number:");
        var accNumber = Console.ReadLine();
        var account = GetAccount(accNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return;
        }

        Console.WriteLine($"Enter Deposit Amount:");
        var input = Console.ReadLine();
        double.TryParse(input, out double depositAmount);

        try
        {
            var balance = account.Deposit(depositAmount);
            Console.WriteLine($"New Account Balance on account {account.GetNumber()} {account.GetName()} is {balance: #,###}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error has occured.");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Deposit Operation failed.");
        }
        Console.WriteLine("-------------------------------------------------------------");
    }

    static void MakeAccountWithdraw()
    {
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Enter the account number:");
        var accNumber = Console.ReadLine();
        var account = GetAccount(accNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return;
        }

        Console.WriteLine($"Enter Withdraw Amount:");
        var input = Console.ReadLine();
        double.TryParse(input, out double amount);

        try
        {
            var balance = account.Withdraw(amount);
            Console.WriteLine($"New Account Balance on account {account.GetNumber()} {account.GetName()} is {balance: #,###}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occured.");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Withdraw Operation failed.");
        }
        Console.WriteLine("-------------------------------------------------------------");
    }


    static void PrintAccountStatement()
    {
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Enter the account number:");
        var accNumber = Console.ReadLine();
        var account = GetAccount(accNumber);
        
        // check if an actual account was found
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return;
        }

        Console.WriteLine("Date \t\t Description \t\t\t\t Amount");

        foreach (var t in account.GetTransactions())
        {
            Console.WriteLine($"{t.GetDate()} \t\t {t.GetDescription()} \t\t\t\t {t.GetAmount()}");
        }
    }

    static void PrintBankStatus()
    {

    }

    static Account? GetAccount(string? accountNumber)
    {
        return _accounts.FirstOrDefault(x => x.GetNumber() == accountNumber);
    }
}