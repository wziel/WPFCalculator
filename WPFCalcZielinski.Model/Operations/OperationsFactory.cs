using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.Operations
{
    public class OperationsFactory : IOperationsFactory
    {
        public IBinaryOperation GetAddOperation() => new AddOperation();
        public IUnaryOperation GetChangeSignOperation() => new ChangeSignOperation();
        public IUnaryOperation GetClearOperation() => new ClearOperation();
        public IBinaryOperation GetDivideOperation() => new DivideOperation();
        public IBinaryOperation GetMultiplyOperation() => new MultiplyOperation();
        public IUnaryOperation GetNoOperation() => new NoOperation();
        public IUnaryOperation GetPercentageOperation() => new PercentageOperation();
        public IUnaryOperation GetSqrtOperation() => new SqrtOperation();
        public IBinaryOperation GetSubtractOperation() => new SubtractOperation();
    }

    public interface IOperationsFactory
    {
        IBinaryOperation GetAddOperation();
        IUnaryOperation GetChangeSignOperation();
        IUnaryOperation GetClearOperation();
        IBinaryOperation GetDivideOperation();
        IBinaryOperation GetMultiplyOperation();
        IUnaryOperation GetNoOperation();
        IUnaryOperation GetPercentageOperation();
        IUnaryOperation GetSqrtOperation();
        IBinaryOperation GetSubtractOperation();
    }
}
