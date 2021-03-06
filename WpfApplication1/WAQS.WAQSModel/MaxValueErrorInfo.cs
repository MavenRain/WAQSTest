//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 

namespace WCFAsyncQueryableServices.ComponentModel
{
    public partial class MaxValueErrorInfo<T> : ErrorInfo
    {
    	public const string MaxValueErrorCode = "MaxValue";
    
    	public MaxValueErrorInfo(T maxValue)
    		: base(MaxValueErrorCode)
    	{
    		MaxValue = maxValue;
    	}
    
    	public override string Message
    	{
    		get 
    		{
    			string message = string.Format("Max length error ({0})", MaxValue);
    			SetMessage(ref message);
    			return message;
    		}
    	}
    	partial void SetMessage(ref string message);
    
    	public T MaxValue { get; private set; }
    }
}
