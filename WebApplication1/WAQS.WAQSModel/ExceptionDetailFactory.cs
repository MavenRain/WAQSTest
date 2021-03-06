//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;

namespace WCFAsyncQueryableServices.Common
{
    public class ExceptionDetailFactory<T> : IExceptionDetailFactory
        where T : Exception
    {
        private Func<T, IExceptionDetail> _factory;
        public ExceptionDetailFactory(Func<T, IExceptionDetail> factory)
        {
            _factory = factory;
        }
    
        public Type Type { get { return typeof(T); } }
        public IExceptionDetail Create(T exception)
        {
            if (_factory == null)
                return new ExceptionDetail<T>(exception);
            return _factory(exception);
        }
    
        IExceptionDetail IExceptionDetailFactory.Create(Exception exception)
        {
            return Create((T)exception);
        }
    }
}
