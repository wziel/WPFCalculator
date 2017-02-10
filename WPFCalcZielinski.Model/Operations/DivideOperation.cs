using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public class DivideOperation : IBinaryOperation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DivideOperation));

        public double Perform(double leftArg, double rightArg)
        {
            log.Debug(leftArg.ToString() + " / " + rightArg.ToString());

            if(rightArg == 0)
            {
                throw new DivideByZeroException();
            }
            return leftArg / rightArg;
        }
    }
}
