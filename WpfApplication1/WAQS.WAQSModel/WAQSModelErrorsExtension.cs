//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Linq;
using WCFAsyncQueryableServices.ClientContext.Interfaces.Errors;

namespace WpfApplication1.ClientContext.Interfaces.Errors
{
    public static class WAQSModelErrorsExtension
    {
        public static WAQSModelErrorKeys GetKeyValue(this Error error)
        {
            if (error.Key == null)
                return WAQSModelErrorKeys.Unknown;
            return Enum.GetValues(typeof(WAQSModelErrorKeys)).OfType<WAQSModelErrorKeys>().FirstOrDefault(t => Enum.GetName(typeof(WAQSModelErrorKeys), t) == error.Key);
        }
    }
}
