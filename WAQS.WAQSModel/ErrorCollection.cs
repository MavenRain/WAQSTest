//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Runtime.Serialization;
using WCFAsyncQueryableServices.ClientContext.Interfaces.Errors;

namespace WCFAsyncQueryableServices.ClientContext.Fault
{
    [DataContract(Namespace = "http://WCFAsyncQueryableServices/Fault")]
    public class ErrorCollection
    {
        [DataMember]
        public Error[] Errors { get; set; }
    }
}