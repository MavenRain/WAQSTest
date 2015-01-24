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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WCFAsyncQueryableServices.ComponentModel
{
    [DataContract(IsReference=true)]
    public abstract partial class BindableObject : IBindableObject
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    	public bool IsPropertyChangedNull
    	{
    		get { return PropertyChanged == null; }
    	}
    
    	private NotifyPropertyChanged _notifyPropertyChanged;
    	protected NotifyPropertyChanged NotifyPropertyChanged
    	{
    		get { return _notifyPropertyChanged ?? (_notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged, OnNotifyPropertyChanged)); }
    	}
    	NotifyPropertyChanged IBindableObject.NotifyPropertyChanged
    	{
    		get { return NotifyPropertyChanged; }
    	}
    	protected virtual void OnNotifyPropertyChanged(string propertyName)
    	{
    	}
    	
    	public string Error
    	{
    		get { return DataErrorInfo.Error; }
    	}
    
    	public string this[string columnName]
    	{
    		get { return DataErrorInfo[columnName]; }
    	}
    
    	private DataErrorInfo _dataErrorInfo;
    	protected DataErrorInfo DataErrorInfo
    	{
    		get { return _dataErrorInfo ?? (_dataErrorInfo = new DataErrorInfo()); }
    	}
    }
}