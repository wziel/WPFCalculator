using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model;

namespace WPFCalcZielinski.Tests.ViewModel
{
    [TestClass]
    public class MainViewModel
    {
        [TestMethod]
        public void RelayCommandExecute_HandlesCommand()
        {
            //given
            var stubCalculator = MockRepository.GenerateStub<ICalculator>();
            var viewModel = new WPFCalcZielinski.ViewModel.MainViewModel(stubCalculator);
            var commandParam = "+";
            //when
            viewModel.RelayCommand.Execute(commandParam);
            //them
            stubCalculator.AssertWasCalled(x => x.HandleCommand(commandParam));
        }

        [TestMethod]
        public void RelayCommandExecute_TextPropertyChangedRaised()
        {
            RelayCommandExecute_PropertyChangedRaised("Text");
        }

        [TestMethod]
        public void RelayCommandExecute_DecimalPointEnabledPropertyChangedRaised()
        {
            RelayCommandExecute_PropertyChangedRaised("DecimalPointEnabled");
        }

        [TestMethod]
        public void RelayCommandExecute_ButtonsEnabledPropertyChangedRaised()
        {
            RelayCommandExecute_PropertyChangedRaised("ButtonsEnabled");
        }


        private void RelayCommandExecute_PropertyChangedRaised(string propertyName)
        {
            //given
            var stubCalculator = MockRepository.GenerateStub<ICalculator>();
            var viewModel = new WPFCalcZielinski.ViewModel.MainViewModel(stubCalculator);
            var commandParam = "+";
            var propertyChangedRaised = false;
            //when
            viewModel.PropertyChanged += (a, b) => propertyChangedRaised |= (b.PropertyName == propertyName);
            viewModel.RelayCommand.Execute(commandParam);
            //them
            Assert.IsTrue(propertyChangedRaised);
        }
    }
}
