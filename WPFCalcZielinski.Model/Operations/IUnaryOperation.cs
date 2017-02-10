using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public interface IUnaryOperation : IOperation
    {
        double Perform(double arg);
    }
}
