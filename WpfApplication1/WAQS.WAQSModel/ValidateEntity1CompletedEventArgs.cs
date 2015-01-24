// Copyright (c) Matthieu MEZIL.  All rights reserved.
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WCFAsyncQueryableServices/Query", ClrNamespace = "WCFAsyncQueryableServices.ClientContext.Interfaces.Query")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WCFAsyncQueryableServices/QuerySerialization", ClrNamespace = "WCFAsyncQueryableServices.ClientContext.Interfaces.ExpressionSerialization")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WAQSModel/SerializableContext", ClrNamespace = "WpfApplication1.ClientContext.Interfaces.Serialization")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WAQSModel/Entities", ClrNamespace = "WpfApplication1")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WCFAsyncQueryableServices/EntityTracking", ClrNamespace = "WCFAsyncQueryableServices.EntitiesTracking")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WCFAsyncQueryableServices/Querying", ClrNamespace = "WCFAsyncQueryableServices.ClientContext.Interfaces.Querying")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WCFAsyncQueryableServices/QueryResult", ClrNamespace = "WCFAsyncQueryableServices.ClientContext.QueryResult")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WAQSModel/QueryResult", ClrNamespace = "WpfApplication1.ClientContext.QueryResult")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WAQSModel/Fault", ClrNamespace = "WpfApplication1.ClientContext.Fault")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WCFAsyncQueryableServices/Fault", ClrNamespace = "WCFAsyncQueryableServices.ClientContext.Fault")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://WCFAsyncQueryableServices/Errors", ClrNamespace = "WCFAsyncQueryableServices.ClientContext.Interfaces.Errors")]
// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.60310.0
// 
namespace WpfApplication1.ClientContext.ServiceReference
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ValidateEntity1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        private object[] results;
        public ValidateEntity1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState): base (exception, cancelled, userState)
        {
            this.results = results;
        }

        public WCFAsyncQueryableServices.ClientContext.Interfaces.Errors.Error[] Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return ((WCFAsyncQueryableServices.ClientContext.Interfaces.Errors.Error[])(this.results[0]));
            }
        }
    }
}
