using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalculatorController
    {
        Form1 form1;
        public CalculatorController(Form1 form1)
        {
            this.form1 = form1 as Form1;
            this.form1.EqualsOperatorButtonClicked += OnEqualsOperatorButtonClicked;
        }

        private bool OnEqualsOperatorButtonClicked(object server , OperationEventArgs e)
        {
            Calculator calculator = new Calculator();
            calculator.n1 = e.Number1;
            calculator.n2 = e.Number2;
            double? result = null;
            result = calculator.Result(calculator.n1,calculator.n2,e.op);
            if(result is null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
