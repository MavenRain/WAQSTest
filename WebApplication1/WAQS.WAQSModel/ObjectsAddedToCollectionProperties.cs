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

namespace WCFAsyncQueryableServices.Entities
{
    [CollectionDataContract(Name = "ObjectsAddedToCollectionProperties", Namespace = "http://WCFAsyncQueryableServices/EntityTracking",
    	ItemName = "AddedObjectsForProperty", KeyName = "CollectionPropertyName", ValueName = "AddedObjects")]
    public class ObjectsAddedToCollectionProperties : Dictionary<string, ObjectList> { }
}
