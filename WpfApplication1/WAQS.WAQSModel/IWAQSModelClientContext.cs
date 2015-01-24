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
using System.Threading.Tasks;
using WCFAsyncQueryableServices.ClientContext;
using WCFAsyncQueryableServices.ClientContext.Interfaces;
using WCFAsyncQueryableServices.ClientContext.Interfaces.Errors;
using WCFAsyncQueryableServices.EntitiesTracking;
using WpfApplication1.ClientContext.Interfaces.Serialization;

namespace WpfApplication1.ClientContext.Interfaces
{
    public partial interface IWAQSModelClientContext : IClientContext<IWAQSModelClientContext>
    {
        IClientEntitySet<IWAQSModelClientContext, WpfApplication1.Entity1> Entity1 { get; }
        void RefreshCurrentValues(WpfApplication1.Entity1 entityInCache, WpfApplication1.Entity1 entity);
        DateTime DbDateTime { get; }
        Task<DateTime> GetDbDateTimeAsync();
        Task<Error[]> ValidateOnServerAsync(Entity1 entity);
        new WAQSModelSerializableContext GetModifiedEntities();
        WAQSModelSerializableContext GetSerializableContext(WAQSModelSerializableContext modifiedEntities);
        Task<WAQSModelSerializableContext> TrySavingAsync(Func<Task<WAQSModelSerializableContext>> saveChangesAsync);
        void Refresh(WAQSModelSerializableContext originalSerializableContext, WAQSModelSerializableContext newSerializableContext);
    }
}
