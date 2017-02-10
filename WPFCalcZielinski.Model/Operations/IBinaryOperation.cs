using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public interface IBinaryOperation : IOperation
    {
        double Perform(double leftArg, double rightArg);
    }
}
