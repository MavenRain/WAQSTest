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

namespace WebApplication1.WCFService.Contract
{
    [DataContract(IsReference = true, Namespace = "http://WAQSModel/SerializableContext")]
    public class WAQSModelSerializableContext
    {
    	[DataMember]
    	public List<WebApplication1.Entity1> Entity1 { get; set; }
    }
}
