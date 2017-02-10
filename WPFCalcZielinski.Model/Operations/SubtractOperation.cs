using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public class SubtractOperation : IBinaryOperation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SubtractOperation));

        public double Perform(double leftArg, double rightArg)
        {
            log.Debug(leftArg.ToString() + " - " + rightArg.ToString());
            return leftArg - rightArg;
        }
    }
}
