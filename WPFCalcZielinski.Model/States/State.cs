using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model.Operations;

namespace WPFCalcZielinski.Model.States
{
    public abstract class State : IState
    {
        protected readonly IStateParams stateParams;
        protected readonly IStateFactory stateFactory;

        internal State(IStateParams stateParams, IStateFactory stateFactory)
        {
            this.stateParams = stateParams;
            this.stateFactory = stateFactory;
        }

        public abstract IState append(char c);
        public abstract string Text { get; }
        public abstract IState Next(IUnaryOperation operation);
        public abstract IState Next(IBinaryOperation operation);
        public IState setDecimalPoint()
        {
            stateParams.appendToRightOprand(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.First());
            return stateFactory.GetInsertOperandState(stateParams);
        }
    }

    public interface IState
    {
        IState append(char c);
        string Text { get; }
        IState Next(IUnaryOperation operation);
        IState Next(IBinaryOperation operation);
        IState setDecimalPoint();
    }
}
