using System;
using WPFCalcZielinski.Model.Operations;

namespace WPFCalcZielinski.Model.States
{
    public class ShowResultState : State
    {
        internal ShowResultState(IStateParams stateParams, IStateFactory stateFactory) : base(stateParams, stateFactory)
        {
        }

        public override string Text
        {
            get
            {
                return stateParams.LeftOperandAsString;
            }
        }

        public override IState append(char c)
        {
            stateParams.LeftOperand = 0.0;
            stateParams.RightOperand = "";
            stateParams.appendToRightOprand(c);
            return stateFactory.GetInsertOperandState(stateParams);
        }

        public override IState Next(IBinaryOperation operation)
        {
            stateParams.PendingOperation = operation;
            return stateFactory.GetInsertOperandState(stateParams);
        }

        public override IState Next(IUnaryOperation operation)
        {
            stateParams.LeftOperand = operation.Perform(stateParams.LeftOperand);
            return this;
        }
    }
}