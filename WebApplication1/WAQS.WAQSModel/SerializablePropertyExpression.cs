//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Runtime.Serialization;

namespace WCFAsyncQueryableServices.SerializableExpressions
{
    [DataContract(Namespace = "http://WCFAsyncQueryableServices/QuerySerialization", IsReference = true)]
    public class SerializablePropertyExpression
    {
        public SerializablePropertyExpression()
        {
        }
    
        [DataMember]
        public SerializableType Type { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
