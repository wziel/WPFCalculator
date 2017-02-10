using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public class ChangeSignOperation : IUnaryOperation
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ChangeSignOperation));

        public double Perform(double arg)
        {
            log.Debug("+/- " + arg.ToString());
            return -arg;
        }
    }
}
