//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Collections;
using System.Collections.Generic;

namespace WCFAsyncQueryableServices.EntitiesTracking
{
    [IsKnownByServer]
    public abstract partial class TrackableCollectionBase<T> : IEnumerable<T>
    {
    	public abstract bool Contains(T item);
    	public abstract IEnumerator<T> GetEnumerator();
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return GetEnumerator();
    	}
    }
}
