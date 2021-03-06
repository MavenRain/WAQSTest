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
    public partial class MinLengthErrorInfo : ErrorInfo
    {
    	public const string MinLengthErrorCode = "MinLength";
    
    	public MinLengthErrorInfo(int maxLength)
    		: base(MinLengthErrorCode)
    	{
    		MinLength = maxLength;
    	}
    
    	public override string Message
    	{
    		get 
    		{
    			string message = string.Format("Min length error ({0})", MinLength);
    			SetMessage(ref message);
    			return message;
    		}
    	}
    	partial void SetMessage(ref string message);
    
    	public int MinLength { get; private set; }
    }
}
