using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Program : Employee
/// @Author : Taekyung Kil
/// Date : 18/Sep/2019
/// Purpose : To set the class of Employee based on employees.csv file

namespace ManagementApplication
{
    class Employee
    {
        private string name; // set a string variable based on employees.csv file
        private int number; // set an int variable based on employees.csv file
        private decimal rate; //set a decimal variable based on employees.csv file
        private double hours; // set a double variable based on employees.csv file
        private decimal gross; // set a decimal variable


        // Employee constructor that receives four parameters
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        public decimal GetGross() // getter for gross
        {

            if (hours > 40) // set overtime rate when hours are greater than 40
            {
                decimal remain = (decimal)hours - (decimal)40;
                this.gross = ((decimal)40 * rate) + (remain * (rate * (decimal)1.5));
            }
            else
                this.gross = (decimal)hours * rate;
            return gross;
        }

        public double GetHours() //getter for hours
        {
            return hours;
        }

        public string GetName() // getter for name
        {
            return name;
        }

        public int GetNumber() // getter for number
        {
            return number;
        }

        public decimal GetRate() // getter for rate
        {
            return rate;
        }

        /// <summary>
        /// set ToString method to show the variables of Employee object
        /// </summary>
        /// <returns> variables (name, number, rate, hours, gross )</returns>
        public override string ToString()
        {
            return "Name : [ " + name + " ], Number : [ " + number + " ], Pay Rate [ " + rate + " ], Hours [ " + hours +
                " ], Gross [ " + decimal.Round(GetGross(), 2) + " ]";
        }

    }
}
