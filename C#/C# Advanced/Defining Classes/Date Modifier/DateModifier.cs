using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class DateModifier
    {
        public int Calculation(string year1, string year2) 
        {
            var date1 = DateTime.Parse(year1);
            var date2 = DateTime.Parse(year2);
            int days = (date1 - date2).Days;
            return days;
        }
    }
}
