//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Runtime.Serialization;

namespace WebApplication1.Service.Interfaces
{
    [DataContract(Namespace = "http://WAQSModel/QueryResult")]
    public class WAQSModelQueriesResult
    {
    	[DataMember]
    	public WAQSModelQueryResult[] QueryResults { get; set; }
    }
}
