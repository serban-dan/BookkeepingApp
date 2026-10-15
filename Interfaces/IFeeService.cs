using System;
using System.Collections.Generic;
using System.Text;

namespace BookkeepingApp.Interfaces
{
    public interface IFeeService
    {
        decimal CalculateFee(DateTime dueDate, DateTime returnDate);
        int GetOrderEtaDays(); // We'll use this later when ordering missing books
    }
}