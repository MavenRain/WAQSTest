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

namespace WCFAsyncQueryableServices.ClientContext.QueryResult
{
    [DataContract(Namespace = "http://WCFAsyncQueryableServices/QueryResult")]
    public class QueryResult
    {
        [DataMember]
        public List<QueryResultRecord> Records { get; set; }
    
        [DataMember]
        public QueryResultRecord Record { get; set; }
    }
}
