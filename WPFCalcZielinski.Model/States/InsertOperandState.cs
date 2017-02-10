using System;
using WPFCalcZielinski.Model.Operations;

namespace WPFCalcZielinski.Model.States
{
    public class InsertOperandState : State
    {
        internal InsertOperandState(IStateParams stateParams, IStateFactory stateFactory) : base(stateParams, stateFactory)
        {
        }

        public override string Text
        {
            get { return stateParams.RightOperand; }
        }

        public override IState append(char c)
        {
            stateParams.appendToRightOprand(c);
            return this;
        }

        public override IState Next(IBinaryOperation operation)
        {
            PerformPendingOperation();
            stateParams.PendingOperation = operation;
            return stateFactory.GetWaitForSecondOperandState(stateParams);
        }

        public override IState Next(IUnaryOperation operation)
        {
            PerformPendingOperation();
            stateParams.LeftOperand = operation.Perform(stateParams.LeftOperand);
            return stateFactory.GetShowResultState(stateParams);
        }

        private void PerformPendingOperation()
        {
            var newValue = stateParams.PendingOperation == null ? stateParams.RightOperandAsDouble
                : stateParams.PendingOperation.Perform(stateParams.LeftOperand, stateParams.RightOperandAsDouble);
            stateParams.LeftOperand = newValue;
            stateParams.RightOperand = "";
            stateParams.PendingOperation = null;
        }
    }
}