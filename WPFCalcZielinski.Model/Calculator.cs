using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model.Operations;
using WPFCalcZielinski.Model.States;

namespace WPFCalcZielinski.Model
{
    public class Calculator : ICalculator
    {
        private Dictionary<string, IOperation> operationDic;
        private IState state;
        private readonly IStateResolver stateResolver;
        private readonly IOperationsFactory operationFactory;
        private readonly IStateFactory stateFactory;

        public Calculator(IStateResolver stateResolver, IOperationsFactory operationFactory, IStateFactory stateFactory)
        {
            this.stateResolver = stateResolver;
            this.operationFactory = operationFactory;
            this.stateFactory = stateFactory;
            this.operationDic = new Dictionary<string, IOperation>()
            {
                { "+", operationFactory.GetAddOperation() },
                { "C", operationFactory.GetClearOperation() },
                { "-", operationFactory.GetSubtractOperation() },
                { "=", operationFactory.GetNoOperation() },
                { "/", operationFactory.GetDivideOperation() },
                { "+/-", operationFactory.GetChangeSignOperation() },
                { "*", operationFactory.GetMultiplyOperation() },
                { "sqrt", operationFactory.GetSqrtOperation() },
                { "%", operationFactory.GetPercentageOperation() },
            };
            Reset();
        }

        public string Text { get; private set; }
        public bool DecimalPointEnabled { get; private set; }
        public bool Error { get; private set; }

        public void HandleCommand(string commandParam)
        {
            if (Error)
            {
                Reset();
            }
            try
            {
                HandleCommandUnsafe(commandParam);
            }
            catch (Exception)
            {
                Error = true;
                Text = "Error";
                DecimalPointEnabled = false;
            }
        }

        private void Reset()
        {
            Error = false;
            DecimalPointEnabled = true;
            Text = "0";
            state = stateFactory.GetStartState();
        }

        private void HandleCommandUnsafe(string commandParam)
        {
            int commandAsInt;
            if (int.TryParse(commandParam, out commandAsInt))
            {
                state = state.append(commandParam.First());
            }
            else if (commandParam == ".")
            {
                state = state.setDecimalPoint();
                DecimalPointEnabled = false;
            }
            else
            {
                var operation = operationDic[commandParam];
                state = stateResolver.Next(state, operation);
                DecimalPointEnabled = true;
            }
            Text = state.Text;
        }
    }

    public interface ICalculator
    {
        string Text { get; }
        bool DecimalPointEnabled { get; }
        bool Error { get; }
        void HandleCommand(string commandParam);
    }
}
