using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model.Operations;
using WPFCalcZielinski.Model.States;

namespace WPFCalcZielinski.Model.States
{
    public class StateResolver : IStateResolver
    {
        public IState Next(IState current, IOperation operation)
        {
            if(operation is IUnaryOperation)
            {
                return current.Next((IUnaryOperation)operation);
            }
            else if(operation is IBinaryOperation)
            {
                return current.Next((IBinaryOperation)operation);
            }
            throw new InvalidOperationException("Operation type not recognized.");
        }
    }

    public interface IStateResolver
    {
        IState Next(IState current, IOperation operation);
    }
}
