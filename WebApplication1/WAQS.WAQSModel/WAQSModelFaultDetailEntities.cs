//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WCFAsyncQueryableServices.WCFService.Contract;

namespace WebApplication1.WCFService.Contract
{
    [DataContract(Namespace = "http://WAQSModel/Fault")]
    [KnownType("GetKnownTypes")]
    public partial class WAQSModelFaultDetailEntities : FaultDetail
    {
    	[DataMember]
    	public List<object> Entities { get; set; }
    
    	public static IEnumerable<Type> GetKnownTypes()
    	{
    		var value = new List<Type>();
    		value.Add(typeof(WebApplication1.Entity1));
    		AddKnownTypes(value);
    		return value;
    	}
    	static partial void AddKnownTypes(List<Type> types);
    }
}
