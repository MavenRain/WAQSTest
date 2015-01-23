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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using WCFAsyncQueryableServices.ClientContext;
using WCFAsyncQueryableServices.ClientContext.Interfaces;
using WCFAsyncQueryableServices.ClientContext.Interfaces.Errors;
using WCFAsyncQueryableServices.ComponentModel;
using WCFAsyncQueryableServices.Entities;
using WCFAsyncQueryableServices.EntitiesTracking;

namespace WAQSTest
{
    [DataContract(IsReference = true, Namespace = "http://WAQSModel/Entities")]
    public partial class Entity1 : DynamicType, IEntityWithErrors
    {
#region DynamicType
        protected override ICustomTypeDescriptor CustomTypeDescriptor
        {
            get
            {
                return new DynamicType<Entity1>(this, CustomPropertyDescriptors);
            }
        }

        protected override IEnumerable<CustomPropertyDescriptor> CustomPropertyDescriptors
        {
            get
            {
                return DynamicType<Entity1>.CustomProperties;
            }
        }

#endregion
#region Simple Properties
        [DataMember]
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                OnIdPropertyChanging(ref value);
                if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                _id = value;
                if (!ChangeTracker.Saving)
                {
                    OnIdPropertyChanged(value);
                    OnPropertyChanged("Id");
                    ResetEntityKey();
                }
            }
        }

        private int _id;
        partial void OnIdPropertyChanging(ref int value);
        partial void OnIdPropertyChanged(int value);
        [DataMember]
        public string Size
        {
            get
            {
                return _size;
            }

            set
            {
                if (_size == value)
                {
                    if (!(IsDeserializing || ChangeTracker.Saving))
                        ValidateSizeRequired(value);
                    return;
                }

                OnSizePropertyChanging(ref value);
                if (!(IsDeserializing || ChangeTracker.Saving))
                {
                    ValidateSizeRequired(value);
                }

                _size = value;
                if (!ChangeTracker.Saving)
                {
                    OnSizePropertyChanged(value);
                    OnPropertyChanged("Size");
                }
            }
        }

        private string _size;
        partial void OnSizePropertyChanging(ref string value);
        partial void OnSizePropertyChanged(string value);
        protected virtual Error ValidateSizeRequired(string value)
        {
            var errorInfo = Validators.ValidateRequiredStringProperty(value, () => Size, DataErrorInfo);
            var error = Errors.Size.FirstOrDefault(e => e.Key == "SizeRequired");
            if (errorInfo == null)
            {
                if (error != null)
                    Errors.Size.Remove(error);
                return null;
            }

            if (error == null)
                Errors.Size.Add(error = new Error
                {
                Criticity = Criticity.Mandatory, Key = "SizeRequired", Message = errorInfo.Message, ErrorInfo = errorInfo
                }

                );
            return error;
        }

        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    if (!(IsDeserializing || ChangeTracker.Saving))
                        ValidateNameRequired(value);
                    return;
                }

                OnNamePropertyChanging(ref value);
                if (!(IsDeserializing || ChangeTracker.Saving))
                {
                    ValidateNameRequired(value);
                }

                _name = value;
                if (!ChangeTracker.Saving)
                {
                    OnNamePropertyChanged(value);
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _name;
        partial void OnNamePropertyChanging(ref string value);
        partial void OnNamePropertyChanged(string value);
        protected virtual Error ValidateNameRequired(string value)
        {
            var errorInfo = Validators.ValidateRequiredStringProperty(value, () => Name, DataErrorInfo);
            var error = Errors.Name.FirstOrDefault(e => e.Key == "NameRequired");
            if (errorInfo == null)
            {
                if (error != null)
                    Errors.Name.Remove(error);
                return null;
            }

            if (error == null)
                Errors.Name.Add(error = new Error
                {
                Criticity = Criticity.Mandatory, Key = "NameRequired", Message = errorInfo.Message, ErrorInfo = errorInfo
                }

                );
            return error;
        }

#endregion
#region Complex Properties
#endregion
#region Navigation Properties
#endregion
#region Specifications
        partial void GetCustomValidation(ref List<Error> errors);
        public virtual IEnumerable<Error> ValidateOnClient(bool force = false)
        {
            if (force || ChangeTracker.State == ObjectState.Added || ChangeTracker.State == ObjectState.Modified && ChangeTracker.ModifiedProperties.Contains("Size"))
            {
                Error error = ValidateSizeRequired(Size);
                if (error != null)
                    yield return error;
            }

            if (force || ChangeTracker.State == ObjectState.Added || ChangeTracker.State == ObjectState.Modified && ChangeTracker.ModifiedProperties.Contains("Name"))
            {
                Error error = ValidateNameRequired(Name);
                if (error != null)
                    yield return error;
            }

            List<Error> errors = null;
            GetCustomValidation(ref errors);
            if (errors != null)
                foreach (var er in errors)
                    yield return er;
        }

#endregion
#region ChangeTracking
        protected virtual void AddValidationProperty(string propertyName)
        {
            if (!ChangeTracker.ValidationProperties.Contains(propertyName))
                ChangeTracker.ValidationProperties.Add(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool isTracked = true)
        {
            if (propertyName != "Id" && isTracked && ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && (ChangeTracker.State & ObjectState.Deleted) == 0)
            {
                if (!(IsDeserializing || ChangeTracker.ModifiedProperties.Contains(propertyName)))
                    ChangeTracker.ModifiedProperties.Add(propertyName);
                ChangeTracker.State = ObjectState.Modified;
            }

            NotifyPropertyChanged.RaisePropertyChanged(propertyName);
            OnPropertyChangedExtension(propertyName);
        }

        partial void OnPropertyChangedExtension(string propertyName);
        protected virtual void OnNavigationPropertyChanged(string propertyName)
        {
            NotifyPropertyChanged.RaisePropertyChanged(propertyName);
            OnNavigationPropertyChangedExtension(propertyName);
            RaiseNavigationPropertyChanged(propertyName);
        }

        partial void OnNavigationPropertyChangedExtension(string propertyName);
        protected virtual void RaiseNavigationPropertyChanged(string propertyName)
        {
            if (NavigationPropertyChanged != null)
                NavigationPropertyChanged(this, propertyName);
        }

        public event Action<Entity1, string> NavigationPropertyChanged;
        private ObjectChangeTracker _changeTracker;
        [DataMember]
        [Display(AutoGenerateFilter = false, AutoGenerateField = false)]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanged += HandleObjectStateChanged;
                }

                return _changeTracker;
            }

            set
            {
                if (_changeTracker != null)
                    _changeTracker.ObjectStateChanged -= HandleObjectStateChanged;
                _changeTracker = value;
                if (_changeTracker != null)
                    _changeTracker.ObjectStateChanged += HandleObjectStateChanged;
            }
        }

        private void HandleObjectStateChanged(object sender, ObjectStateChangedEventArgs e)
        {
            switch (e.NewState)
            {
                case ObjectState.Deleted:
                case ObjectState.CascadeDeleted:
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        IsDeleting = true;
                        ClearNavigationProperties();
                        IsDeleting = false;
                    }

                    break;
                case ObjectState.Detached:
                    ClearNavigationProperties();
                    break;
            }

            OnStateChanged(e.NewState);
        }

        protected virtual void OnStateChanged(ObjectState state)
        {
            if (StateChanged != null)
                StateChanged(this, state);
        }

        public event Action<IObjectWithChangeTracker, ObjectState> StateChanged;
        private bool _isDeserializing;
        [Display(AutoGenerateFilter = false, AutoGenerateField = false)]
        public bool IsDeserializing
        {
            get
            {
                return _isDeserializing;
            }

            set
            {
                if (_isDeserializing == value)
                    return;
                _isDeserializing = value;
            }
        }

        [Display(AutoGenerateFilter = false, AutoGenerateField = false)]
        public bool IsInitializingRelationships
        {
            get;
            set;
        }

        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }

        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }

        public virtual void MarkAsModified()
        {
            ChangeTracker.ChangeTrackingEnabled = true;
            ChangeTracker.State = ObjectState.Modified;
            ChangeTracker.ModifiedProperties.Add("Id");
            ChangeTracker.ModifiedProperties.Add("Size");
            ChangeTracker.ModifiedProperties.Add("Name");
        }

        protected virtual void ClearNavigationProperties()
        {
            bool isInitializingRelationships = IsInitializingRelationships;
            IsInitializingRelationships = true;
            IsInitializingRelationships = isInitializingRelationships;
        }

        public bool HasTemporaryKey
        {
            get
            {
                return ChangeTracker.State == ObjectState.Added;
            }
        }

        public virtual bool HasChanges
        {
            get
            {
                return ChangeTracker.State != ObjectState.Unchanged || ChangeTracker.ObjectsRemovedFromCollectionProperties.Any() || ChangeTracker.OriginalValues.Any() || ChangeTracker.ObjectsAddedToCollectionProperties.Any();
            }
        }

#endregion
#region Association Fixup
        private bool IsDeleting
        {
            get;
            set;
        }

        internal virtual void Detach()
        {
            ChangeTracker.State = ObjectState.Detached;
        }

#endregion
#region EntityKey
        private Guid? _dataTransferEntityKey;
        [DataMember]
        public virtual Guid DataTransferEntityKey
        {
            get
            {
                return _dataTransferEntityKey ?? (_dataTransferEntityKey = Guid.NewGuid()).Value;
            }

            set
            {
                _dataTransferEntityKey = value;
            }
        }

        private string _entityKey;
        public virtual string EntityKey
        {
            get
            {
                switch (ChangeTracker.State)
                {
                    case ObjectState.Added:
                        if (_entityKey == null)
                            _entityKey = "Entity1 - IdentityKey = " + Guid.NewGuid().ToString();
                        return _entityKey;
                    case ObjectState.Detached:
                        if (_entityKey != null)
                            return _entityKey;
                        if (Id == default (int))
                            goto case ObjectState.Added;
                        break;
                    case ObjectState.Unchanged:
                    case ObjectState.Modified:
                    case ObjectState.CascadeDeleted:
                    case ObjectState.Deleted:
                        _entityKey = null;
                        break;
                }

                return string.Format("Entity1 - Id={0};", Id);
            }

            set
            {
                _entityKey = value;
            }
        }

        public virtual void ResetEntityKey()
        {
            if (!IsDeserializing)
            {
                var previousEntityKey = _entityKey;
                _entityKey = null;
                OnEntityKeyChanged(previousEntityKey);
            }
        }

        protected virtual void OnEntityKeyChanged(string previousEntityKey)
        {
            if (EntityKeyChanged != null)
                EntityKeyChanged(this, previousEntityKey);
        }

        public event Action<Entity1, string> EntityKeyChanged;
        public virtual bool IsTemporaryKey
        {
            get
            {
                return _entityKey != null;
            }
        }

#endregion
#region Dependences
#endregion
#region UISpecifications
        static Entity1()
        {
            DynamicType<Entity1>.AddProperty("IdIsMandatory", e => e.UISpecifications.GetIdIsMandatory(e));
            DynamicType<Entity1>.AddProperty("IdMinValue", e => e.UISpecifications.GetIdMinValue(e));
            DynamicType<Entity1>.AddProperty("IdMaxValue", e => e.UISpecifications.GetIdMaxValue(e));
            DynamicType<Entity1>.AddProperty("SizeIsMandatory", e => e.UISpecifications.GetSizeIsMandatory(e));
            DynamicType<Entity1>.AddProperty("SizeMaxLength", e => e.UISpecifications.GetSizeMaxLength(e));
            DynamicType<Entity1>.AddProperty("SizeMinLength", e => e.UISpecifications.GetSizeMinLength(e));
            DynamicType<Entity1>.AddProperty("SizePattern", e => e.UISpecifications.GetSizePattern(e));
            DynamicType<Entity1>.AddProperty("NameIsMandatory", e => e.UISpecifications.GetNameIsMandatory(e));
            DynamicType<Entity1>.AddProperty("NameMaxLength", e => e.UISpecifications.GetNameMaxLength(e));
            DynamicType<Entity1>.AddProperty("NameMinLength", e => e.UISpecifications.GetNameMinLength(e));
            DynamicType<Entity1>.AddProperty("NamePattern", e => e.UISpecifications.GetNamePattern(e));
            DynamicType<Entity1>.AddProperty("AllErrors", e => e.Errors.AllErrors);
            DynamicType<Entity1>.AddProperty("IdErrors", e => e.Errors.Id);
            DynamicType<Entity1>.AddProperty("SizeErrors", e => e.Errors.Size);
            DynamicType<Entity1>.AddProperty("NameErrors", e => e.Errors.Name);
            StaticInitializer();
        }

        static partial void StaticInitializer();
        private UISpecificationsInfo _uiSpecifications;
        private UISpecificationsInfo UISpecifications
        {
            get
            {
                return _uiSpecifications ?? (_uiSpecifications = CreateEntity1UISpecifications());
            }
        }

        protected virtual UISpecificationsInfo CreateEntity1UISpecifications()
        {
            return new UISpecificationsInfo();
        }

        public partial class UISpecificationsInfo
        {
            public virtual bool GetIdIsMandatory(Entity1 entity)
            {
                return true;
            }

            public virtual int ? GetIdMinValue(Entity1 entity)
            {
                return null;
            }

            public virtual int ? GetIdMaxValue(Entity1 entity)
            {
                return null;
            }

            public virtual bool GetSizeIsMandatory(Entity1 entity)
            {
                return true;
            }

            public virtual int ? GetSizeMaxLength(Entity1 entity)
            {
                return null;
            }

            public virtual int ? GetSizeMinLength(Entity1 entity)
            {
                return null;
            }

            public virtual string GetSizePattern(Entity1 entity)
            {
                return null;
            }

            public virtual bool GetNameIsMandatory(Entity1 entity)
            {
                return true;
            }

            public virtual int ? GetNameMaxLength(Entity1 entity)
            {
                return null;
            }

            public virtual int ? GetNameMinLength(Entity1 entity)
            {
                return null;
            }

            public virtual string GetNamePattern(Entity1 entity)
            {
                return null;
            }
        }

        private ErrorsSpecifications _errors;
        protected ErrorsSpecifications Errors
        {
            get
            {
                return _errors ?? (_errors = new ErrorsSpecifications());
            }
        }

        bool IEntityWithErrors.HasErrors
        {
            get
            {
                return Errors.AllErrors.Count != 0;
            }
        }

        event Action IEntityWithErrors.HasErrorsChanged
        {
            add
            {
                Errors.HasErrorChanged += value;
            }

            remove
            {
                Errors.HasErrorChanged += value;
            }
        }

        public partial class ErrorsSpecifications
        {
            private ObservableCollection<Error> _id;
            public ObservableCollection<Error> Id
            {
                get
                {
                    return _id ?? (_id = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _size;
            public ObservableCollection<Error> Size
            {
                get
                {
                    return _size ?? (_size = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _name;
            public ObservableCollection<Error> Name
            {
                get
                {
                    return _name ?? (_name = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _allErrors;
            public ObservableCollection<Error> AllErrors
            {
                get
                {
                    if (_allErrors == null)
                    {
                        _allErrors = new ObservableCollection<Error>();
                        NotifyCollectionChangedEventHandler errorsCollectionChanged = (_, e) =>
                        {
                            if (e.NewItems != null)
                                foreach (Error error in e.NewItems)
                                {
                                    if (!_allErrors.Any(er => er.Key == error.Key))
                                        _allErrors.Add(error);
                                }

                            if (e.OldItems != null)
                                foreach (Error error in e.OldItems)
                                    _allErrors.Remove(error);
                        }

                        ;
                        AddAllErrorsHandlers(errorsCollectionChanged);
                    }

                    return _allErrors;
                }
            }

            protected virtual void AddAllErrorsHandlers(NotifyCollectionChangedEventHandler errorsCollectionChanged)
            {
                NotifyCollectionChangedEventHandler specificErrorsCollectionChanged = (sender, e) =>
                {
                    errorsCollectionChanged(sender, e);
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            if (AllErrors.Count == e.NewItems.Count)
                                OnHasErrorChanged();
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            if (AllErrors.Count == 0)
                                OnHasErrorChanged();
                            break;
                    }
                }

                ;
                Id.CollectionChanged += specificErrorsCollectionChanged;
                Size.CollectionChanged += specificErrorsCollectionChanged;
                Name.CollectionChanged += specificErrorsCollectionChanged;
            }

            protected void OnHasErrorChanged()
            {
                if (HasErrorChanged != null)
                    OnHasErrorChanged();
            }

            public event Action HasErrorChanged;
        }
#endregion
    }
}
            