using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalcZielinski.Model.States
{
    public class StateFactory : IStateFactory
    {
        public IState GetInsertOperandState(IStateParams param) => new InsertOperandState(param, this);
        public IState GetShowResultState(IStateParams param) => new ShowResultState(param, this);
        public IState GetWaitForSecondOperandState(IStateParams param) => new WaitForSecondOperandState(param, this);
        public IState GetStartState() => new InsertOperandState(new StateParams(null, 0, ""), this);
    }

    public interface IStateFactory
    {
        IState GetInsertOperandState(IStateParams param);
        IState GetShowResultState(IStateParams param);
        IState GetWaitForSecondOperandState(IStateParams param);
        IState GetStartState();
    }
}
