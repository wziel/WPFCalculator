using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public class NoOperation : IUnaryOperation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(NoOperation));

        public double Perform(double arg)
        {
            log.Debug("Nop " + arg.ToString());
            return arg;
        }
    }
}
