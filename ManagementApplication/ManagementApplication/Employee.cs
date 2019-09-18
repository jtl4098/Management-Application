using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication
{
    class Employee
    {
        private string name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;

        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
            if (hours > 40)
                gross = (decimal)hours * rate * (decimal)1.5;
            else
                gross = (decimal)hours * rate;

        }

        public decimal GetGross()
        {


            return gross;
        }

        public double GetHours()
        {
            return hours;
        }

        public string GetName()
        {
            return name;
        }

        public int GetNumber()
        {
            return number;
        }

        public decimal GetRate()
        {
            return rate;
        }

        public override string ToString()
        {
            return "Name : [ " + name + " ], Number : [ " + number + " ], Pay Rate [ " + rate + " ], Hours [ " + hours +
                " ], Gross [ " + gross + " ]";
        }

        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }
    }
}
