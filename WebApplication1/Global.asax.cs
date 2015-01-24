using System;
using System.Data.Entity.Core;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using WCFAsyncQueryableServices.Common;
using WCFAsyncQueryableServices.DAL;

namespace WebApplication1
{
    public partial class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IExceptionDetailFactory, ExceptionDetailFactory<UpdateException>>(typeof (UpdateException).FullName, new InjectionConstructor(new object[]
            {
            (Func<UpdateException, IExceptionDetail>)(ue => new UpdateExceptionDetail(ue))}

            ));
            UnityServiceLocator serviceLocator = new UnityServiceLocator(unityContainer);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            Global.WAQSModelApplicationStart(unityContainer);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}