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
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using WCFAsyncQueryableServices.Service.Interfaces;

namespace WCFAsyncQueryableServices.Service
{
    public abstract partial class ServiceBase
    {
        protected abstract Func<ISerializableExpressionProvider> SerializableExpressionProviderFactory { get; }
        
        protected static bool HasManyResult(Type type)
        {
            return type != typeof(string) && typeof(IEnumerable).IsAssignableFrom(type);
        }
        
        protected static bool IsGrouping(Type type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IGrouping<,>) || type.GetGenericTypeDefinition().GetInterfaces().Any(i => i == typeof(IGrouping<,>)));
        }
        
        protected Type GetGenericType(Type type)
        {
            if (type.IsGenericType)
                return type.GetGenericArguments()[0];
            if (type.IsArray)
                return type.GetElementType();
            throw new NotImplementedException();
        }
        
        protected bool IsNullable(Type type)
        {
            return Expression.Lambda(Expression.Default(type)).Compile().DynamicInvoke() == null;
        }
        
        protected bool IsClientKnownType(Type type)
        {
            return type.Namespace != null && type.Namespace.StartsWith("System") && type.Assembly.ManifestModule.Name == "mscorlib.dll" || type.GetCustomAttributes(typeof(DataContractAttribute), true).OfType<DataContractAttribute>().Any();
        }
        
        
        protected Expression<Func<object, QueryResultRecord>> CreateQueryResultExpression(Type type, Type originalType)
        {
            var objectParameter = Expression.Parameter(typeof(object));
            var typedObjectParameter = Expression.Convert(objectParameter, type);
            var queryResultVariable = Expression.Variable(typeof(QueryResultRecord));
            bool isNullable = IsNullable(type);
        
            Expression lambdaBody;
            if (isNullable)
                lambdaBody = Expression.IfThenElse(
                    Expression.Equal(
                        objectParameter,
                        Expression.Constant(null, typeof(object))),
                    Expression.Assign(
                        queryResultVariable,
                        Expression.Constant(null, typeof(QueryResultRecord))),
                    GetQueryResultExpression(type, originalType, typedObjectParameter, queryResultVariable));
            else
                lambdaBody = GetQueryResultExpression(type, originalType, typedObjectParameter, queryResultVariable);
        
            return Expression.Lambda<Func<object, QueryResultRecord>>(
                Expression.Block(
                    new ParameterExpression[] { queryResultVariable },
                    lambdaBody,
                    queryResultVariable),
                objectParameter);
        }
        
        protected Expression GetQueryResultExpression(Type type, Type originalType, Expression obj, ParameterExpression queryResultVariable)
        {
            bool isNullable = IsNullable(type);
            var valueVariable = Expression.Variable(originalType);
            var serializableExpressionProvider = ((Expression<Func<ISerializableExpressionProvider>>)(() => SerializableExpressionProviderFactory())).Body;
        
            Expression lambdaBody1;
            if (isNullable && !IsClientKnownType(type))
            {
                if (IsGrouping(originalType))
                    lambdaBody1 =
                        Expression.Assign(
                            queryResultVariable,
                            GetGroupingExpression(originalType, obj));
                else
                    lambdaBody1 =
                        Expression.Assign(
                            queryResultVariable,
                            Expression.MemberInit(
                                Expression.New(typeof(QueryResultRecord)),
                                Expression.Bind(
                                    typeof(QueryResultRecord).GetProperty("Properties"),
                                    GetPropertiesExpression(type, valueVariable))));
            }
            else
                lambdaBody1 =
                    Expression.Assign(
                        queryResultVariable,
                        Expression.MemberInit(
                            Expression.New(typeof(QueryResultRecord)),
                            Expression.Bind(
                                typeof(QueryResultRecord).GetProperty("SerializedValue"),
                                GetSerializedObject(type, valueVariable))));
        
            List<Expression> lambdaBodyExpressions = new List<Expression>()
                {
                    isNullable ? 
                        Expression.IfThen(
                            Expression.NotEqual(
                                valueVariable,
                                Expression.Constant(null, typeof(object))),
                            lambdaBody1) : 
                        lambdaBody1
                };
        
            if (isNullable && originalType.IsClass)
                lambdaBodyExpressions.Insert(0,
                    Expression.Assign(
                        valueVariable,
                        Expression.Convert(
                            Expression.Call(
                                serializableExpressionProvider,
                                typeof(ISerializableExpressionProvider).GetMethod("Convert", new Type[] { typeof(object) }),
                                obj),
                            originalType)));
            else
                lambdaBodyExpressions.Insert(0,
                    Expression.Assign(
                        valueVariable,
                        obj));
        
            return Expression.Block(
                new ParameterExpression[] { valueVariable },
                lambdaBodyExpressions);
        }
        
        protected ListInitExpression GetPropertiesExpression(Type type, Expression obj)
        {
            return Expression.ListInit(
                Expression.New(typeof(List<QueryResultProperty>).GetConstructor(new Type[0])),
                type.GetProperties().Select(p =>
                    Expression.ElementInit(
                        typeof(List<QueryResultProperty>).GetMethod("Add"),
                        GetPropertyExpression(
                            p,
                            obj))).ToArray());
        }
        
        protected Expression GetPropertyExpression(PropertyInfo p, Expression obj)
        {
            return GetPropertyExpression(p.Name, p.PropertyType, Expression.MakeMemberAccess(obj, p));
        }
        protected Expression GetPropertyExpression(string propertyName, Type propertyType, Expression obj)
        {
            var newQueryResultPropertyExpression = Expression.New(typeof(QueryResultProperty));
        
            if (!IsNullable(propertyType))
                return Expression.MemberInit(
                    newQueryResultPropertyExpression,
                    Expression.Bind(
                        typeof(QueryResultProperty).GetProperty("PropertyName"),
                        Expression.Constant(propertyName)),
                    Expression.Bind(
                        typeof(QueryResultProperty).GetProperty("SerializedValue"),
                        GetSerializedObject(propertyType, obj)));
        
            if (HasManyResult(propertyType))
            {
                if (IsGrouping(propertyType))
                    return Expression.MemberInit(
                        newQueryResultPropertyExpression,
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("PropertyName"),
                            Expression.Constant(propertyName)),
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("Value"),
                            GetGroupingExpression(propertyType, obj)));
                else
                {
                    var elementType = GetGenericType(propertyType);
                    var selectParameter = Expression.Parameter(elementType);
                    var valueVariable = Expression.Variable(typeof(QueryResultRecord));
                    return Expression.MemberInit(
                        newQueryResultPropertyExpression,
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("PropertyName"),
                            Expression.Constant(propertyName)),
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("Values"),
                            Expression.Call(
                                typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(typeof(QueryResultRecord)),
                                Expression.Call(
                                    typeof(Enumerable).GetMethods().First(m => m.Name == "Select" && m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 2).MakeGenericMethod(elementType, typeof(QueryResultRecord)),
                                    obj,
                                    Expression.Lambda(
                                        Expression.Block(
                                            new ParameterExpression[] { valueVariable },
                                            GetQueryResultExpression(elementType, SerializableExpressionProviderFactory().GetOriginalType(elementType), selectParameter, valueVariable),
                                            valueVariable),
                                        selectParameter)))));
                }
            }
            else
            {
                if (IsClientKnownType(propertyType))
                {
                    return Expression.MemberInit(
                        newQueryResultPropertyExpression,
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("PropertyName"),
                            Expression.Constant(propertyName)),
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("SerializedValue"),
                            GetSerializedObject(propertyType, obj)));
                }
                else
                {
                    return Expression.MemberInit(
                        newQueryResultPropertyExpression,
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("PropertyName"),
                            Expression.Constant(propertyName)),
                        Expression.Bind(
                            typeof(QueryResultProperty).GetProperty("Value"),
                            GetAnonymousType(propertyType, obj)));
                }
            }
        }
        
        protected Expression GetValue(Type type, Expression objExpression)
        {
            int indexEnumerable = 0;
            var typeLoop = type;
            var types = new List<Type>() { type };
            while (typeLoop.IsGenericType && typeLoop.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                indexEnumerable++;
                typeLoop = typeLoop.GetGenericArguments()[0];
                types.Insert(0, typeLoop);
            }
        
            var serializableExpressionProvider = SerializableExpressionProviderFactory();
            var serializableExpressionProviderExpression = ((Expression<Func<ISerializableExpressionProvider>>)(() => SerializableExpressionProviderFactory())).Body;
        
            var originalType = serializableExpressionProvider.GetOriginalType(typeLoop);
        
            if (!(originalType.IsClass || originalType.IsInterface))
                return objExpression;
        
            if (indexEnumerable == 0)
                return Expression.Convert(
                    Expression.Call(
                        serializableExpressionProviderExpression,
                        typeof(ISerializableExpressionProvider).GetMethod("Convert", new Type[] { typeof(object) }),
                        objExpression),
                    originalType);
        
            var originalTypes = new List<Type>() { originalType };
            for (int i = 0; i < indexEnumerable - 1; i++)
                originalTypes.Add(typeof(IEnumerable<>).MakeGenericType(originalTypes[i]));
        
            var selectMethod = typeof(Enumerable).GetMethods().First(m => m.Name == "Select" && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType.IsGenericType && m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 2);
        
            var selectLambdas = new List<LambdaExpression>();
            var convertParameter = Expression.Parameter(typeLoop);
            selectLambdas.Add(
                Expression.Lambda(
                    Expression.Convert(
                            Expression.Call(
                                serializableExpressionProviderExpression,
                                typeof(ISerializableExpressionProvider).GetMethod("Convert", new Type[] { typeof(object) }),
                                convertParameter),
                            originalType), 
                    convertParameter));
            for (int i = 0; i < indexEnumerable - 1; i++)
            {
                var parameterLoop = Expression.Parameter(typeof(IEnumerable<>).MakeGenericType(typeLoop));
                selectLambdas.Add(
                    Expression.Lambda(
                        Expression.Call(
                            selectMethod.MakeGenericMethod(types[i], originalTypes[i]),
                            parameterLoop,
                            selectLambdas[i]),
                    parameterLoop));
            }
            return Expression.Call(selectMethod.MakeGenericMethod(types[indexEnumerable - 1], originalTypes[indexEnumerable - 1]), objExpression, selectLambdas[selectLambdas.Count - 1]);
        }
        
        protected Expression GetSerializedObject(Type type, Expression obj)
        {
            obj = GetValue(type, obj);
        
            if (!(type.IsClass || type.IsInterface))
                obj = Expression.Convert(obj, typeof(object));
        
            var valueVariable = Expression.Variable(typeof(string));
            var memoryStreamVariable = Expression.Variable(typeof(MemoryStream));
            var streamReaderVariable = Expression.Variable(typeof(StreamReader));
            return Expression.Block(
                new ParameterExpression[] { valueVariable, memoryStreamVariable, streamReaderVariable },
                Expression.Assign(
                    memoryStreamVariable,
                    Expression.New(typeof(MemoryStream).GetConstructor(new Type[0]))),
                Expression.Call(
                    Expression.New(
                        typeof(DataContractSerializer).GetConstructor(new Type[] { typeof(Type) }),
                        Expression.Constant(type)),
                    typeof(DataContractSerializer).GetMethod("WriteObject", new Type[] { typeof(Stream), typeof(object) }),
                    memoryStreamVariable,
                    obj),
                Expression.Call(
                    memoryStreamVariable,
                    typeof(MemoryStream).GetMethod("Flush")),
                Expression.Call(
                    memoryStreamVariable,
                    typeof(MemoryStream).GetMethod("Seek"),
                    Expression.Constant(0L),
                    Expression.Constant(SeekOrigin.Begin)),
                Expression.Assign(
                    streamReaderVariable,
                    Expression.New(
                        typeof(StreamReader).GetConstructor(new Type[] { typeof(Stream) }),
                        memoryStreamVariable)),
                Expression.Assign(
                    valueVariable,
                    Expression.Call(
                        streamReaderVariable,
                        typeof(StreamReader).GetMethod("ReadToEnd"))),
                Expression.Call(
                    streamReaderVariable,
                    typeof(StreamReader).GetMethod("Dispose")),
                Expression.Call(
                    memoryStreamVariable,
                    typeof(MemoryStream).GetMethod("Dispose")),
                valueVariable);
        }
        
        protected MemberInitExpression GetGroupingExpression(Type type, Expression obj)
        {
            var keyProp = type.GetProperty("Key");
            return Expression.MemberInit(
                Expression.New(typeof(QueryResultRecord)),
                Expression.Bind(
                    typeof(QueryResultRecord).GetProperty("Properties"),
                    Expression.ListInit(
                        Expression.New(typeof(List<QueryResultProperty>).GetConstructor(new Type[0])),
                            GetPropertyExpression(keyProp, obj),
                            GetPropertyExpression("Values", typeof(IEnumerable<>).MakeGenericType(type.GetGenericArguments()[1]), obj))));
        }
        
        protected MemberInitExpression GetAnonymousType(Type type, Expression obj)
        {
            return Expression.MemberInit(
                Expression.New(typeof(QueryResultRecord)),
                Expression.Bind(
                    typeof(QueryResultRecord).GetProperty("Properties"),
                    Expression.ListInit(
                        Expression.New(typeof(List<QueryResultProperty>).GetConstructor(new Type[0])),
                        type.GetProperties().Select(p => GetPropertyExpression(p, obj)))));
        }
    }
}
