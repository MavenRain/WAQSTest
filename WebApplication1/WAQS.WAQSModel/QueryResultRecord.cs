//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFAsyncQueryableServices.Service.Interfaces
{
    [DataContract(Namespace = "http://WCFAsyncQueryableServices/QueryResult")]
    public class QueryResultRecord
    {	
    	[DataMember]
    	public List<QueryResultProperty> Properties { get; set; }
    	
    	[DataMember]
    	public string SerializedValue { get; set; }
    }
}
