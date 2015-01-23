using System.Threading;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using WAQSTest.ClientContext;
using WCFAsyncQueryableServices.ClientContext.Interfaces.ExpressionSerialization;
using WCFAsyncQueryableServices.ComponentModel;
using WCFAsyncQueryableServices.Controls;
using WAQSTest.ClientContext.Interfaces;
using WAQSTest.ClientContext.ServiceReference;

namespace WAQSTest
{
    /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IMessageBoxService, MessageBoxService>();
            DispatcherUnhandledException += (sender, ex) =>
            {
                unityContainer.Resolve<IMessageBoxService>().ShowError(ex.Exception.Message);
                ex.Handled = true;
            }

            ;
            TaskScheduler.UnobservedTaskException += (sender, ex) =>
            {
                unityContainer.Resolve<IMessageBoxService>().ShowError(ex.Exception.InnerException.Message);
                ex.SetObserved();
            }

            ;
            InitWCFAsyncQueryableServicesModules(unityContainer);
            UIThread.Dispatcher = Application.Current.Dispatcher;
            UIThread.TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            unityContainer.Resolve<WAQSTest.MainWindow>().Show();
        }

        private void InitWCFAsyncQueryableServicesModules(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IWAQSModelService, WAQSModelServiceClient>(new InjectionConstructor());
            unityContainer.RegisterType<IWAQSModelClientContext, WAQSModelClientContext>();
        }
    }
}