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
using System.Linq;

namespace WCFAsyncQueryableServices.Specifications
{
    public static class PropertyDependence
    {
    	public static void DefinePropertyDependences<T>(Func<T, object> definePropertyDependences)
    	{
    	}
    
    	public static T DefinePropertyDependences<T>(this T source, Func<T, object> definePropertyDependences)
    	{
    		return source;
    	}
    
    	public static IEnumerable<T> DefinePropertyDependences<T>(this IEnumerable<T> source, Func<T, object> definePropertyDependences)
    	{
    		return source;
    	}
    
    	public static T DefinePropertyDependences<T, T2>(this T source, Func<T2, object> definePropertyDependences)
    		where T2 : T
    	{
    		return source;
    	}
    
    	public static IEnumerable<T> DefinePropertyDependences<T, T2>(this IEnumerable<T> source, Func<T2, object> definePropertyDependences)
    		where T2 : T
    	{
    		return source;
    	}
    }
}