using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using WpfApplication1.ClientContext;
using WCFAsyncQueryableServices.ClientContext.Interfaces.ExpressionSerialization;
using WCFAsyncQueryableServices.ComponentModel;
using WCFAsyncQueryableServices.Controls;
using WpfApplication1.ClientContext.Interfaces;
using WpfApplication1.ClientContext.ServiceReference;

namespace WpfApplication1
{
    /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
    public partial class App : Application
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
            unityContainer.Resolve<WpfApplication1.MainWindow>().Show();
        }

        private void InitWCFAsyncQueryableServicesModules(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IWAQSModelService, WAQSModelServiceClient>(new InjectionConstructor());
            unityContainer.RegisterType<IWAQSModelClientContext, WAQSModelClientContext>();
        }
    }
}