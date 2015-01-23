//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using WCFAsyncQueryableServices.ClientContext.Interfaces.Errors;

namespace WCFAsyncQueryableServices.Controls
{
    public partial class ErrorsBehaviors
    {
    	public static ObservableCollection<Error> GetErrors(DependencyObject obj)
    	{
    		return (ObservableCollection<Error>)obj.GetValue(ErrorsProperty);
    	}
    
    	public static void SetErrors(DependencyObject obj, ObservableCollection<Error> value)
    	{
    		obj.SetValue(ErrorsProperty, value);
    	}
    
    	// Using a DependencyProperty as the backing store for Errors.  This enables animation, styling, binding, etc...
    	public static readonly DependencyProperty ErrorsProperty =
    		DependencyProperty.RegisterAttached("Errors", typeof(ObservableCollection<Error>), typeof(ErrorsBehaviors), new PropertyMetadata((d, e) =>
    		{
    			var control = d as Control;
    			var errors = e.NewValue as ObservableCollection<Error>;
    			if (control == null || errors == null)
    				return;
    
    			var errorsListBox = (ListBox)XamlReader.Load(new XmlTextReader(new StringReader(string.Concat("<ListBox xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' ><ListBox.ItemTemplate><DataTemplate xmlns:errorsConveters='clr-namespace:WCFAsyncQueryableServices.Controls.Converters;assembly=", Assembly.GetExecutingAssembly().GetName().Name, "'><DataTemplate.Resources><errorsConveters:CritityConverter x:Key='CriticityConverter' /></DataTemplate.Resources><Grid><Grid.ColumnDefinitions><ColumnDefinition Width='15' /><ColumnDefinition Width='5' /><ColumnDefinition /></Grid.ColumnDefinitions><Image Source='{Binding Criticity, Converter={StaticResource CriticityConverter}}'/><TextBlock Grid.Column='2' Text='{Binding Message}' /></Grid></DataTemplate></ListBox.ItemTemplate></ListBox>"))));
    			var errorsCollectionViewSource = new CollectionViewSource { Source = errors };
    			errorsCollectionViewSource.SortDescriptions.Add(new SortDescription("Criticity", ListSortDirection.Descending));
    			errorsListBox.SetBinding(ListBox.ItemsSourceProperty, new Binding { Source = errorsCollectionViewSource });
    			var toolTip = new ToolTip { Content = errorsListBox };
    			ToolTipService.SetToolTip(control, toolTip);
    			ToolTipService.SetIsEnabled(control, false);
    
    			var oldBorderThickness = control.BorderThickness;
    			var oldBorderBrush = control.BorderBrush;
    			NotifyCollectionChangedEventHandler errorsCollectionChanged = (_, __) =>
    				{
    					var maxCriticity = errors.Select(er => er.Criticity).OrderByDescending(c => c).FirstOrDefault();
    					bool done = false;
    					SetControlStyle(control, errors, maxCriticity, ref done);
    					if (!done)
    					{
    						switch (maxCriticity)
    						{
    							case Criticity.Error:
    							case Criticity.Mandatory:
    								if (control.BorderThickness.Left == 0 && control.BorderThickness.Right == 0 && control.BorderThickness.Top == 0 && control.BorderThickness.Bottom == 0)
    									control.BorderThickness = new Thickness(3);
    								control.BorderBrush = Brushes.Red;
    								ToolTipService.SetIsEnabled(control, true);
    								break;
    							case Criticity.Warning:
    								if (control.BorderThickness.Left == 0 && control.BorderThickness.Right == 0 && control.BorderThickness.Top == 0 && control.BorderThickness.Bottom == 0)
    									control.BorderThickness = new Thickness(3);
    								control.BorderBrush = Brushes.Orange;
    								ToolTipService.SetIsEnabled(control, true);
    								break;
    							case Criticity.Information:
    								control.BorderThickness = oldBorderThickness;
    								control.BorderBrush = oldBorderBrush;
    								ToolTipService.SetIsEnabled(control, true);
    								break;
    							case Criticity.None:
    								control.BorderThickness = oldBorderThickness;
    								control.BorderBrush = oldBorderBrush;
    								ToolTipService.SetIsEnabled(control, false);
    								break;
    						}
    					}
    				};
    			errors.CollectionChanged += errorsCollectionChanged;
    			RoutedEventHandler controlUnloaded = null;
    			controlUnloaded = (_, __) =>
    				{
    					control.Unloaded -= controlUnloaded;
    					errors.CollectionChanged -= errorsCollectionChanged;
    				};
    			control.Unloaded += controlUnloaded;
    		}));
    
    	static partial void SetControlStyle(Control control, ObservableCollection<Error> errors, Criticity maxCriticity, ref bool done);
    }
}
