//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Runtime.Serialization;
using System.Reflection;

namespace WCFAsyncQueryableServices.ClientContext.Interfaces.ExpressionSerialization
{
    [DataContract(Namespace = "http://WCFAsyncQueryableServices/QuerySerialization", IsReference = true)]
    [KnownType(typeof(SerializableMethodCallExpression))]
    [KnownType(typeof(SerializablePropertySetterExpression))]
    [KnownType(typeof(SerializablePropertySetterExpression))]
    public abstract class SerializableMemberExpression : SerializableExpression
    {
        public SerializableMemberExpression()
        {
        }
        public SerializableMemberExpression(SerializableExpression source, MemberInfo memberInfo)
        {
            Source = source;
            MemberDeclaringType = new SerializableType(memberInfo.DeclaringType);
            MemberName = memberInfo.Name;
        }
    
        [DataMember]
        public SerializableExpression Source { get; set; }
        [DataMember]
        public SerializableType MemberDeclaringType { get; set; }
        [DataMember]
        public string MemberName { get; set; }
    }
}
