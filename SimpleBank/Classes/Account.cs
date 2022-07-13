using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleBank.Classes;

public class Account
{
    private static long _accountSeed = 20220001;

    private string _name;
    
    private string _number;
   
    private List<Transaction> _transactions = new List<Transaction>();

    public Account(string customerName, double initialDeposit)
    {
        if(initialDeposit < 20000)
        {
            throw new Exception("Minimum Initial Deposit is 20,000");
        }

       
        var accNumber = ++_accountSeed;
        _number = accNumber.ToString();
        _name = customerName;
        _transactions.Add(new Transaction(DateTime.Now, initialDeposit, "Initial account opening deposit"));
    }

    public string GetName()
    {
        return _name;
    }

    public string GetNumber()
    {
        return _number;
    }

    public double GetBalance()
    {
        var tempBalance = 0.0;
        
        foreach(var t in _transactions)
        {
            tempBalance = tempBalance + t.GetAmount();
        }
        
        return tempBalance;
    }

    public List<Transaction> GetTransactions()
    {
        return _transactions;
    }

    public double Deposit(double amountDeposited)
    {
        if(amountDeposited <= 0)
        {
            throw new Exception("Deposit amount must be greater than zero");
        }

        _transactions.Add(new Transaction(DateTime.Now, amountDeposited, "Cash Deposit"));
        
        return GetBalance();
    }


    public double Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Withdraw amount must be greater than zero");
        }

        if (GetBalance() - amount < 20000)
        {
            throw new Exception("Insuffient balance to complete the transaction");
        }

        _transactions.Add(new Transaction(DateTime.Now, -amount, "Cash Withdraw"));

        
        return GetBalance();
    }
}
