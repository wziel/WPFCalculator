using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model.Operations;

namespace WPFCalcZielinski.Model.States
{
    public class StateParams : IStateParams
    {
        private IBinaryOperation pendingOperation;
        private double leftOperand;
        private string rightOperand;

        public StateParams(IBinaryOperation lastOperation, double leftOperand, string rightOperand)
        {
            this.pendingOperation = lastOperation;
            this.leftOperand = leftOperand;
            this.rightOperand = rightOperand;
        }

        public double RightOperandAsDouble
        {
            get
            {
                try
                {
                    return Convert.ToDouble(rightOperand);
                }
                catch (Exception)
                {
                    return 0.0;
                }
            }
        }

        public string RightOperand
        {
            get { return rightOperand ?? "0"; }
            set { rightOperand = value; }
        }

        public double LeftOperand
        {
            get { return leftOperand; }
            set { leftOperand = value; }
        }

        public IBinaryOperation PendingOperation
        {
            get { return pendingOperation; }
            set { pendingOperation = value; }
        }

        public string LeftOperandAsString { get { return leftOperand.ToString(); } }

        public void appendToRightOprand(char c) => rightOperand += c;
    }

    public interface IStateParams
    {

        double RightOperandAsDouble { get; }

        string RightOperand { get; set; }

        double LeftOperand { get; set; }

        IBinaryOperation PendingOperation { get; set; }

        string LeftOperandAsString { get; }

        void appendToRightOprand(char c);
    }
}
