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
    
    public Transaction(DateTime date, double amount)
    {
        _date = date;
        _amount = amount;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public DateTime GetDate()
    {
        return _date;
    }
}
