using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string  n2str = null;
        Calculator c = new Calculator();
        public delegate bool OperationEventHandler(object source, OperationEventArgs args);
        public event OperationEventHandler EqualsOperatorButtonClicked;

        private void Firstnumber(Button button)
        {
            if (ShowInfoLabel.Text == "_")
            {
                ShowInfoLabel.Text = button.Text;
            }
            else
            {
                ShowInfoLabel.Text += button.Text;
            }
        }
        
        private void Afterop(ref string str,string op,Button number)
        {
            if(op != null)
            {
                str += number.Text;
            }
        }

       private bool ErrorState()
        {
            if((ShowInfoLabel.Text=="Syntax ERROR")||(ShowInfoLabel.Text=="Math ERROR"))
            {
                return true;
            }
            return false;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button7);
                Afterop(ref n2str, c.Op, Button7);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button8);
                Afterop(ref n2str, c.Op, Button8);
            }
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                c.ValidNumber(ShowInfoLabel.Text, ref c.n1);
                c.Op = PlusButton.Text;
                Firstnumber(PlusButton);
            }
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                c.ValidNumber(n2str, ref c.n2);
                if ((c.n1 != null) && (c.n2 != null))
                {
                    OnEqualsOperatorButtonClicked(c.n1, c.n2, c.Op);
                }
                else if (c.Op == null) { }
                else
                    ShowInfoLabel.Text = "Syntax ERROR";
                n2str = null;
                c.Op = null;
                c.n1 = null;
                c.n2 = null;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button9);
                Afterop(ref n2str, c.Op, Button9);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button4);
                Afterop(ref n2str, c.Op, Button4);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button5);
                Afterop(ref n2str, c.Op, Button5);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button6);
                Afterop(ref n2str, c.Op, Button6);
            }
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                c.ValidNumber(ShowInfoLabel.Text, ref c.n1);
                c.Op = MultiplyButton.Text;
                Firstnumber(MultiplyButton);
            }

        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                c.ValidNumber(ShowInfoLabel.Text, ref c.n1);
                c.Op = "/";
                Firstnumber(DivideButton);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button1);
                Afterop(ref n2str, c.Op, Button1);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button2);
                Afterop(ref n2str, c.Op, Button2);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button3);
                Afterop(ref n2str, c.Op, Button3);
            }
        }

        private void SubstractButton_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                c.ValidNumber(ShowInfoLabel.Text, ref c.n1);
                c.Op = SubstractButton.Text;
                Firstnumber(SubstractButton);
            }
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(Button0);
                Afterop(ref n2str, c.Op, Button0);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string lastdeleted;
            if (ErrorState()) { }
            else
            {
                try
                {
                    string lastchar = ShowInfoLabel.Text.Remove(0, ShowInfoLabel.Text.Length - 1);
                    if (c.Op != null)
                    {
                        if (lastchar.Equals(c.Op))
                        {
                            c.Op = null;
                        }
                    }
                    else if (c.n1 != null)
                    {
                        string n1val = Convert.ToString(c.n1);
                        string lastnumber = n1val.Remove(0, n1val.Length - 1);
                        if (lastchar.Equals(lastnumber))
                        {
                            c.n1 = null;
                        }
                    }
                    lastdeleted = ShowInfoLabel.Text.Remove(ShowInfoLabel.Text.Length - 1);
                    ShowInfoLabel.Text = lastdeleted;
                }
                catch (ArgumentOutOfRangeException)
                {
                    lastdeleted = "_";
                    ShowInfoLabel.Text = lastdeleted;
                }
            }
        }

        private void AllClearButton_Click(object sender, EventArgs e)
        {
            ShowInfoLabel.Text = "_";
            n2str = null;
            c.Op = null;
            c.n1 = null;
            c.n2 = null;
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                Firstnumber(DotButton);
                Afterop(ref n2str, c.Op, DotButton);
            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (ErrorState()) { }
            else
            {
                if (c.Prevanswer != null)
                    ShowInfoLabel.Text = Convert.ToString(c.Prevanswer);
                else
                    ShowInfoLabel.Text = "_";
                n2str = null;
                c.Op = null;
                c.n1 = null;
                c.n2 = null;
            }
        }

        private void OnEqualsOperatorButtonClicked(double? n1 , double? n2 , string op)
        {
            if (EqualsOperatorButtonClicked != null) 
            {
                bool valido = false;
                valido = EqualsOperatorButtonClicked(this, new OperationEventArgs() {Number1 = n1 , Number2 = n2 , op = op });
                if (valido)
                {
                    c.Prevanswer = c.Result(n1, n2, op);
                    ShowInfoLabel.Text = Convert.ToString(c.Prevanswer);
                }
                else if (!valido)
                {
                    ShowInfoLabel.Text = "Math ERROR";
                }
            }
        }
    }
}
