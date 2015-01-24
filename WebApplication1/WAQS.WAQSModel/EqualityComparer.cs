//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Linq;

namespace WCFAsyncQueryableServices.Entities
{
    public static class EqualityComparer
    {
    	public static bool BinaryEquals(object binaryValue1, object binaryValue2)
    	{
    		if (ReferenceEquals(binaryValue1, binaryValue2))
    			return true;
    
    		var array1 = binaryValue1 as byte[];
    		var array2 = binaryValue2 as byte[];
    
    		if (array1 != null && array2 != null)
    		{
    			if (array1.Length != array2.Length)
    				return false;
    
    			return !array1.Where((t, i) => t != array2[i]).Any();
    		}
    
    		return false;
    	}
    }
}
