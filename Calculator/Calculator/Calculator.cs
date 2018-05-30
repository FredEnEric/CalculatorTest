using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Calculator
    {
        public double Solve(string equation)
        {
            //Remove any spaces
            equation = Regex.Replace(equation, @"\s+", "");

            var operation = new Operation();
            operation.Parse(equation);

            return operation.Solve();
        }
    }
}
