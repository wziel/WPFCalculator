using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public class SqrtOperation : IUnaryOperation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SqrtOperation));

        public double Perform(double arg)
        {
            log.Debug("Sqrt " + arg.ToString());
            if(arg < 0)
            {
                throw new ArithmeticException("Sqrt from negative number exception");
            }
            return Math.Sqrt(arg);
        }
    }
}
