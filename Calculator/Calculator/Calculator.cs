using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator
{
    public class Calculator
    {
        public double? n1 = null;

        public double? n2 = null;

        public double? Prevanswer { get; set; } = null;

        public string Op { get; set; } = null;

        public void ValidNumber(string number, ref double? actualnumber )
        {
            bool valid = true;
            double n;
            if (number != null)
            {
                if (number.Contains(","))
                {
                    number = number.Replace(",", ".");
                }
            }
            try
            {
                n = Convert.ToDouble(number, CultureInfo.InvariantCulture);

            }
            catch (FormatException)
            {
                valid = false;
            }
            finally
            {
                if (valid)
                {
                    actualnumber = Convert.ToDouble(number, CultureInfo.InvariantCulture);
                }
            }
        }

        public double? Result(double? n1 , double? n2 , string op)
        {
            double? r;
            if (op == "+")// i figured that as long as the numbers are valid there are no +,- or x operations that are invalid. so no need for exception handling here
                r = n1 + n2;
            else if (op == "-")
                r = n1 - n2;
            else if (op == "x")
                r = n1 * n2;
            else {//didnt use "try" here because you can actually divide "double" numbers by 0 and it returns infinity so i had to do an "if" statement for it .
                r = n1 / n2;
                if (Double.IsPositiveInfinity(Convert.ToDouble(r)))
                {
                    r = null;
                }
                else if (Double.IsNegativeInfinity(Convert.ToDouble(r)))
                {
                    r = null;
                }
                else if (Double.IsNaN(Convert.ToDouble(r)))
                {
                    r = null;
                }
            }
            return r;
        }
    }
}
