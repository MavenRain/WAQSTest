//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WCFAsyncQueryableServices.DAL.Interfaces
{
    public interface IAsyncEnumerator : IDisposable
    {
        Task<bool> MoveNextAsync(CancellationToken cancellationToken);
    
        object Current { get; }
    }
    
    public interface IAsyncEnumerator<out T> : IAsyncEnumerator
    {
        new T Current { get; }
    }
}
