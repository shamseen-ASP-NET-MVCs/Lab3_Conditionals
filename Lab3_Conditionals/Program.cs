using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            //Income tax calculator
            Console.WriteLine("\n\n------INCOME TAX CALCULATOR-----");
            double tax = incomeTaxes();
            if (tax != 0)
                Console.WriteLine("Your tax is {0:C}", tax);

            ////Time and classifications
            //Console.WriteLine("\n-----Time and Classifications-----");
            //timeClassifications();

            
        }

        static double incomeTaxes()
        {
            //declaring variables
            double income = 0.0, tax = 0.0;
            string input = "";

            //taking input
            Console.Write("Please enter income: $");
            input = Console.ReadLine();

            //if you can't parse the string into an income, then input is not a number
            if (!Double.TryParse(input, out income))
            {
                Console.WriteLine("****ERROR: Invalid input! Try again!*****");
                return 0;
            }

            //declaring variables needed for loop
            double[] taxRates = { 0.05, 0.1, 0.2, 0.35 };
            int[] upperLimits = { 0, 20000, 50000, 75000 };  //for each bracket
            double taxableAmount = 0.0;
            int length = upperLimits.Length;
            bool stop = false;
            
            for (int i = 1; i < length; i++) //i = 1 so we skip upper limit of $0
            {
                //if the income is higher than tax bracket, add maximum tax for bracket
                if (income > upperLimits[i])
                    taxableAmount = upperLimits[i] - upperLimits[i - 1];

                else { //otherwise tax the difference between income and lower limit
                    taxableAmount = income - upperLimits[i - 1];
                    stop = true; //we've reached the bracket income falls in
                }

                tax += taxableAmount * taxRates[i - 1]; //rate is one element behind upper limit

                if (stop) //keep from running the else with negative taxableAmount
                    break; 
            }

            if (income > 75000)
                tax += (income - 75000) * taxRates[length - 1];
            
            // return tax;
             Console.WriteLine("Testing optimization: {0:C}", tax);

            ///*************sloppy first attempt, but it works so it's my control**************/
            //tax = 0.0;
            ////first tax bracket
            //if (income <= 20000)
            //{
            //    tax = income * 0.05;
            //    //Console.WriteLine("Your tax is {0:C}", tax);
            //    Console.WriteLine("Control: {0:C}", tax);
            //    return tax;
            //}
            //else
            //    tax += 20000 * 0.05;

            //while (true)
            //{
            //    //second tax bracket
            //    if (income < 50000)
            //    { //if higher, adds maximum tax for this bracket
            //        tax += (income - 20000) * 0.1;
            //        break;
            //    }
            //    else
            //        tax += (50000 - 20000) * 0.1;

            //    //third tax bracket
            //    if (income < 75000)
            //    { //if higher, adds maximum tax for this bracket
            //        tax += (income - 50000) * 0.2;
            //        break;
            //    }

            //    else
            //    {
            //        tax += (75000 - 50000) * 0.2;

            //        //fourth tax bracket
            //        tax += (income - 75000) * 0.35;

            //        break;
            //    }
            //}
            //Console.WriteLine("Control: {0:C}", tax); 
            return tax; 
        }

        static void timeClassifications()
        {
            string input = "Y"; //default so it can enter the loop

            while (input.ToUpper() != "N")
            {
                int seconds = System.DateTime.Now.Second;

                switch (seconds)
                {
                    case 0: Console.WriteLine("The new minute is starting!"); break;
                    case 15: Console.WriteLine("We're one quarter done."); break;
                    case 30: Console.WriteLine("Oooh, we're half. way. theere, OOOH LIVIN ON A PRAYER"); break;
                    case 45: Console.WriteLine("Getting close to done."); break;
                    default: Console.WriteLine(".. working on it .."); break;
                }

                //taking input to continue so i can keep testing
                Console.Write("Continue? (Y/N) ");
                input = Console.ReadLine();
            }

        }
    }
}
