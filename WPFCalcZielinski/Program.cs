using log4net;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalcZielinski.Model;
using WPFCalcZielinski.Model.Operations;
using WPFCalcZielinski.Model.States;
using WPFCalcZielinski.View;
using WPFCalcZielinski.ViewModel;

namespace WPFCalcZielinski
{
    static class Program
    {
        private static ILog log;

        [STAThread]
        static void Main()
        {
            log4net.Config.BasicConfigurator.Configure();
            log = LogManager.GetLogger(typeof(AddOperation));
            var container = GetContainer();
            RunApplication(container);
        }

        private static Container GetContainer()
        {
            var container = new Container();
            container.Register<IStateResolver, StateResolver>(Lifestyle.Singleton);
            container.Register<IStateFactory, StateFactory>(Lifestyle.Singleton);
            container.Register<IOperationsFactory, OperationsFactory>(Lifestyle.Singleton);
            container.Register<ICalculator, Calculator>();
            container.Register<MainWindow>();
            container.Register<MainViewModel>();
            container.Verify();
            return container;
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }
    }
}
