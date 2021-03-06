//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using WCFAsyncQueryableServices.EntitiesTracking;
using WCFAsyncQueryableServices.ClientContext.Interfaces.ExpressionSerialization;
using WCFAsyncQueryableServices.ClientContext.Interfaces;

namespace WCFAsyncQueryableServices.ClientContext
{
    public abstract class ClientEntitySetBase<ClientContext> : IClientEntitySet<ClientContext>, IDisposable, INotifyCollectionChanged
        where ClientContext : class, IClientContext
    {
        public ClientEntitySetBase(string entitySetName, ClientContext context, IList entities, HashSet<IObjectWithChangeTracker> hashSet, Func<IObjectWithChangeTracker, object> getEntityKey)
        {
            EntitySetName = entitySetName;
            Context = context;
            Entities = entities;
            HashSet = hashSet;
            GetEntityKey = getEntityKey;
        }
                                            
        ~ClientEntitySetBase()
        {
            Dispose(false);
        }
            
        protected internal virtual bool EntitiesContains(IObjectWithChangeTracker entity)
        {
            return HashSet.Contains(entity);
        }
            
        protected virtual void EntitiesAdd(IObjectWithChangeTracker entity)
        {
            HashSet.Add(entity);
            Entities.Add(entity);
        }
            
        protected virtual void EntitiesRemove(IObjectWithChangeTracker entity)
        {
            HashSet.Remove(entity);
            Entities.Remove(entity);
        }
                                        
        public string EntitySetName { get; private set; }
                                        
        private SerializableExpression _expression;
        protected internal virtual SerializableExpression Expression 
        { 
            get { return _expression ?? (_expression = new SerializableEntitySetExpression(EntitySetName));}
        }
        SerializableExpression IClientEntitySet.Expression
        {
            get { return Expression; }
        }
                                        
        public ClientContext Context { get; private set; }
        IClientContext IClientEntitySet.Context
        {
            get { return Context; }
        }
        private Dictionary<object, IObjectWithChangeTracker> _entitiesDico;
        private Dictionary<object, IObjectWithChangeTracker> EntitiesDico 
        {
            get { return _entitiesDico ?? (_entitiesDico = new Dictionary<object, IObjectWithChangeTracker>()); }
        }
        protected internal IList Entities { get; private set; }
        protected internal HashSet<IObjectWithChangeTracker> HashSet { get; private set; }
        public Func<IObjectWithChangeTracker, object> GetEntityKey { get; private set; }
        
        protected virtual bool Add(IObjectWithChangeTracker entity, bool checkIfAlreadyExist = true)
        {
            entity.ChangeTracker.ChangeTrackingEnabled = true;
            entity.ChangeTracker.State = ObjectState.Added;
            return AddEntity(entity, checkIfAlreadyExist);
        }
                    
        protected virtual bool Attach(IObjectWithChangeTracker entity, bool checkIfAlreadyExist = true)
        {
            entity.ChangeTracker.AcceptChanges();
            entity.ChangeTracker.ChangeTrackingEnabled = true;
            return AddEntity(entity, checkIfAlreadyExist);
        }
                    
        protected bool AddEntity(IObjectWithChangeTracker entity, bool checkIfAlreadyExist = true)
        {
            if (checkIfAlreadyExist && EntitiesContains(entity))
                    return false;
            bool notifyCollectionChanged = false;
            int? index = 0;
            var entityKey = GetEntityKey(entity);
                                       
            IObjectWithChangeTracker entityInEntitySet;
            if (checkIfAlreadyExist && (entityInEntitySet = Entities.Cast<IObjectWithChangeTracker>().FirstOrDefault(e => e == entity || GetEntityKey(e).Equals(entityKey))) != null && (entityInEntitySet == entity || !(entity.HasTemporaryKey && entity.ChangeTracker.State == ObjectState.Added)))
            {
                if (entityInEntitySet == entity)
                        return false;
                throw new InvalidOperationException("Another entity with the same key already exists in the context");
            }
            else
            {
                EntitiesAdd(entity);
                index = GetIndex(entity);
                notifyCollectionChanged = true;
            }
            entity.StateChanged += EntityStateChanged;
            if (notifyCollectionChanged)
                    NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, entity, index.Value));
            return true;
        }
            
        protected virtual bool Replace(ref IObjectWithChangeTracker entity)
        {
            var entityKey = GetEntityKey(entity);
            var entityDeleted = Entities.Cast<IObjectWithChangeTracker>().FirstOrDefault(e => (GetEntityKey(e).Equals(entityKey)) && (e.ChangeTracker.State == ObjectState.Deleted));
            if (entityDeleted != null)
                return AttachDeletedEntity(ref entity, entityDeleted);
            return Add(entity);
        }
                
        protected virtual bool AttachDeletedEntity(ref IObjectWithChangeTracker entity, IObjectWithChangeTracker entityDeleted)
        {
            entity = entityDeleted;
            return Attach(entity, true);
        }
                            
        void EntityStateChanged(IObjectWithChangeTracker entity, ObjectState state)
        {
            switch (state)
            {
                case ObjectState.CascadeDeleted:
                    RemoveCascade(entity);
                    break;
            }
        }
                                            
        protected virtual void Remove(IObjectWithChangeTracker entity)
        {
            if (entity.ChangeTracker.State == ObjectState.Added)
                Detach(entity);
            else
                entity.ChangeTracker.State = ObjectState.Deleted;
            int? index;
            index = GetIndex(entity);
            if (index.HasValue)
                NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, entity, index.Value));
        }
                                            
        protected virtual void RemoveCascade(IObjectWithChangeTracker entity)
        {
            if (entity.ChangeTracker.State == ObjectState.Added)
                Detach(entity);
            else if (entity.ChangeTracker.State != ObjectState.CascadeDeleted)
            {
                entity.StateChanged -= EntityStateChanged;
                entity.ChangeTracker.State = ObjectState.CascadeDeleted;
                entity.StateChanged += EntityStateChanged;
            }
            int? index = GetIndex(entity);
            if (index.HasValue)
                NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, entity, index.Value));
        }
                            
        private int? GetIndex(IObjectWithChangeTracker entity)
        {
            int index = 0;
            foreach (var e in Entities.OfType<IObjectWithChangeTracker>().Where(e => (e.ChangeTracker.State & ObjectState.Deleted) == 0 || e == entity))
            {
                if (e == entity)
                    return index;
                index++;
            }
            return null;
        }
                                            
        protected virtual void Detach(IObjectWithChangeTracker entity)
        {
            entity.ChangeTracker.DetachedPreviousState = entity.ChangeTracker.State; 
            int? index;
            entity.StateChanged -= EntityStateChanged;
            index = GetIndex(entity);
            EntitiesRemove(entity);
            entity.ChangeTracker.AcceptChanges(false);
            entity.ChangeTracker.State = ObjectState.Detached;
            entity.ChangeTracker.ChangeTrackingEnabled = false;
            if (index.HasValue)
                NotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, entity, index.Value));
        }
                                            
        void IClientEntitySet<ClientContext>.Add(IObjectWithChangeTracker entity)
        {
            Add(entity);
        }
                
        public void AddWithoutCheckingIfAlreadyExist(IObjectWithChangeTracker entity)
        {
            Add(entity, false);
        }							
                    
        void IClientEntitySet<ClientContext>.Attach(IObjectWithChangeTracker entity)
        {
            Attach(entity);
        }
                    
        public void AttachWithoutCheckingIfAlreadyExist(IObjectWithChangeTracker entity)
        {
            Attach(entity, false);
        }
                                            
        void IClientEntitySet<ClientContext>.Remove(IObjectWithChangeTracker entity)
        {
            Remove(entity);
        }
                                            
        void IClientEntitySet<ClientContext>.Detach(IObjectWithChangeTracker entity)
        {
            Detach(entity);
        }
            
        void IClientEntitySet<ClientContext>.Replace(ref IObjectWithChangeTracker entity)
        {
            Replace(ref entity);
        }
                                            
        public bool AttachWithoutChangingState(IObjectWithChangeTracker entity, ObjectState? defaultState = ObjectState.Unchanged)
        {
            if (EntitiesContains(entity))
                return false;
            if (entity.ChangeTracker.State == ObjectState.Detached)
            {
                entity.ChangeTracker.ChangeTrackingEnabled = true;
                if (entity.ChangeTracker.IsAttaching)
                {
                    entity.ChangeTracker.State = ObjectState.Unchanged;
                    entity.ChangeTracker.IsAttaching = false;
                }
                else
                    entity.ChangeTracker.State = defaultState ?? ObjectState.Added;
            }
            AddEntity(entity);
            if (entity.ChangeTracker.State == ObjectState.Added)
                OnAdded(entity);
            else
                OnAttached(entity);
            return true;
        }
        protected virtual void OnAdded(IObjectWithChangeTracker entity)
        {
        }
        protected virtual void OnAttached(IObjectWithChangeTracker entity)
        {
        }
        public virtual int Count
        {
            get
            {
                var enumerator = GetEnumerable().GetEnumerator();
                int value = 0;
                while (enumerator.MoveNext()) value++;
                return value;
            }
        }
                                
        protected IEnumerable<IObjectWithChangeTracker> AllEntities
        {
            get
            {
                if (Entities == null)
                    return new IObjectWithChangeTracker[0];
                return Entities.Cast<IObjectWithChangeTracker>();
            }
        }
                                            
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerable().GetEnumerator();
        }
        protected virtual IEnumerable GetEnumerable()
        {
            return Entities.OfType<IObjectWithChangeTracker>().Where(e => (e.ChangeTracker.State & ObjectState.Deleted) == 0);
        }
        protected abstract Type GetEntityType();
                                            
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected void NotifyCollectionChanged(NotifyCollectionChangedEventArgs arg)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, arg);
        }
                                            
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
                                            
        protected internal virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var entity in AllEntities.ToList())
                {
                    entity.ChangeTracker.AcceptChanges(false); 
                    entity.ChangeTracker.ChangeTrackingEnabled = false;
                    entity.StateChanged -= EntityStateChanged;
                    entity.ChangeTracker.ClientContextDispose();
                }
                _entitiesDico = null;
                GetEntityKey = null;
            }
        }
    }
}
