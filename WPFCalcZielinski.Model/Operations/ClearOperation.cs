using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public class ClearOperation : IUnaryOperation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ClearOperation));

        public double Perform(double arg)
        {
            log.Debug("Clear " + arg.ToString());

            return 0.0;
        }
    }
}
