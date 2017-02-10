using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model.Operations;
using WPFCalcZielinski.Model.States;

namespace WPFCalcZielinski.Tests.Model
{
    [TestClass]
    public class Calculator
    {
        IStateResolver stubStateResolver;
        IOperationsFactory stubOperationsFactory;
        IStateFactory stubStateFactory;
        IState stubCurrentState;
        WPFCalcZielinski.Model.Calculator calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            stubStateResolver = MockRepository.GenerateStub<IStateResolver>();
            stubOperationsFactory = MockRepository.GenerateStub<IOperationsFactory>();
            stubStateFactory = MockRepository.GenerateStub<IStateFactory>();
            stubCurrentState = MockRepository.GenerateStub<IState>();
            stubStateFactory.Stub(x => x.GetStartState()).Return(stubCurrentState);
        }

        [TestMethod]
        public void HandleCommand_AppendsCharacter()
        {
            //given
            createCalculator();
            var commandParam = "5";
            //when
            calculator.HandleCommand(commandParam);
            //then
            stubCurrentState.AssertWasCalled(x => x.append(commandParam.First()));
        }

        [TestMethod]
        public void HandleCommand_SetsDecimalPoint()
        {
            //given
            createCalculator();
            var commandParam = ".";
            //when
            calculator.HandleCommand(commandParam);
            //then
            stubCurrentState.AssertWasCalled(x => x.setDecimalPoint());
        }

        [TestMethod]
        public void HandleCommand_GetsNewState()
        {
            //given
            var stubAddOperation = MockRepository.GenerateStub<IBinaryOperation>();
            stubOperationsFactory.Stub(x => x.GetAddOperation()).Return(stubAddOperation);
            createCalculator();
            var commandParam = "+";
            //when
            calculator.HandleCommand(commandParam);
            //then
            stubStateResolver.AssertWasCalled(x => x.Next(stubCurrentState, stubAddOperation));
        }

        private void createCalculator()
        {
            calculator = new WPFCalcZielinski.Model.Calculator(stubStateResolver, stubOperationsFactory, stubStateFactory);
        }
    }
}
