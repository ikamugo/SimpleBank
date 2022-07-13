using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Classes;

public class Transaction
{
    private DateTime _date;
    private double _amount;
    private string _description;

    public Transaction(DateTime date, double amount, string description)
    {
        _date = date;
        _amount = amount;
        _description=description;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public string GetDescription()
    {
        return _description;
    }
}
