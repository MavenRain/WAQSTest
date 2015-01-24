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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WebApplication1.DAL.Interfaces;
using WebApplication1.Service.Interfaces;
using WCFAsyncQueryableServices.SerializableExpressions;
using WCFAsyncQueryableServices.Service.Interfaces;
using WCFAsyncQueryableServices.Service;

namespace WebApplication1.Service
{
    public class WAQSModelServiceL2E : WAQSModelService
    {
        public WAQSModelServiceL2E(Func<IWAQSModelContainer> contextFactory, Func<IWAQSModelContainer, ISerializableExpressionProvider> serializableExpressionProviderFactory, Func<WAQSModelServiceL2E> serviceFactory)
            : base(contextFactory, serializableExpressionProviderFactory, serviceFactory)
        {
        }
    
        public WAQSModelServiceL2E(IWAQSModelContainer context)
            : base(context, () => new WAQSModelServiceL2E(context))
        {
        }
    
        public WAQSModelServiceL2E(Func<IWAQSModelContainer> contextFactory)
            : this(contextFactory, () => new WAQSModelServiceL2E(contextFactory))
        {
        }
    
        protected WAQSModelServiceL2E(Func<IWAQSModelContainer> contexFactory, Func<WAQSModelServiceL2E> serviceFactory)
            : base (contexFactory, serviceFactory)
        {
        }
    
        public static WAQSModelServiceL2E Create<DataContextT>()
            where DataContextT : IWAQSModelContainer, new()
        {
            return new WAQSModelServiceL2E(() => new DataContextT { UseWAQSProvider = true });
        }
    
        public override WAQSModelQueryResultPage LoadPage(int pageSize, SerializableExpression querySerializableExpression, IEnumerable<string> withSpecificationsProperties, LoadPageParameter[] identifiersSerializableExpression)
        {
            if (identifiersSerializableExpression.Length == 0)
                throw new InvalidOperationException();
    
            var queryExpression = SerializableExpressionProvider(Context).ToExpression(querySerializableExpression, withSpecificationsProperties);
            Expression exp = Expression.Constant(1);
            var queryType = GetGenericType(queryExpression.Type);
            var parameterExp = Expression.Parameter(queryType);
            foreach (var identifierSerializableExpression in identifiersSerializableExpression.Reverse())
                exp = Expression.Condition(GetLogicalBinaryExpression(parameterExp, queryType, identifierSerializableExpression.Descending ? ExpressionType.GreaterThan : ExpressionType.LessThan, identifierSerializableExpression), Expression.Constant(1), Expression.Condition(GetLogicalBinaryExpression(parameterExp, queryType, identifierSerializableExpression.Descending ? ExpressionType.LessThan : ExpressionType.GreaterThan, identifierSerializableExpression), Expression.Constant(0), exp));
            var provider = ((IQueryable)Context.Entity1).Provider;
            int rowIndex = (int)provider.Execute(Expression.Call(typeof(Queryable).GetMethods().First(m => m.Name == "Sum" && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType.GetGenericArguments()[0].GetGenericArguments()[1] == typeof(int)).MakeGenericMethod(new Type[] { queryType }), queryExpression, Expression.Lambda(exp, parameterExp)));
            int pageIndex = rowIndex / pageSize;
            if (rowIndex % pageSize != 0)
                pageIndex++;
            return new WAQSModelQueryResultPage { PageIndex = pageIndex - 1, Result = new WAQSModelQueryResult { Records = ((IEnumerable)provider.CreateQuery(Expression.Call(typeof(Queryable).GetMethod("Take").MakeGenericMethod(queryType), Expression.Call(typeof(Queryable).GetMethod("Skip").MakeGenericMethod(queryType), queryExpression, Expression.Constant((pageIndex - 1) * pageSize)), Expression.Constant(pageSize)))).Cast<object>().Select(o => GetQueryResult(queryType, o)).ToList()}};
        }
    
        private Expression GetLogicalBinaryExpression(ParameterExpression parameterExp, Type type, ExpressionType expressionType, LoadPageParameter loadPageParameter)
        {
            PropertyInfo prop = type.GetProperty(loadPageParameter.PropertyName);
            Type valueType = prop.PropertyType;
            Expression valueExpression = SerializableExpressionToLINQExpressionConverter.GetConstantExpression(loadPageParameter.Value, valueType);
            Expression propExpression = Expression.MakeMemberAccess(parameterExp, prop);
            bool nullable = false;
            if (valueType == typeof(string))
                switch (expressionType)
                {
                    case ExpressionType.LessThan:
                        return Context.LessThanString(propExpression, valueExpression);
                    case ExpressionType.GreaterThan:
                        return Context.GreaterThanString(propExpression, valueExpression);
                    default:
                        throw new NotImplementedException();
                }
            else if (typeof(Enum).IsAssignableFrom(valueType) || (nullable = valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Nullable<>) && typeof(Enum).IsAssignableFrom(valueType.GetGenericArguments()[0])))
            {
                Type intType = nullable ? typeof(int?) : typeof(int);
                return Expression.MakeBinary(expressionType, Expression.Convert(propExpression, intType), Expression.Convert(valueExpression, intType));
            }
            else
                return Expression.MakeBinary(expressionType, propExpression, valueExpression);
        }
    
        private Expression GetExpression<T>(T value)
        {
            Expression<Func<T>> exp = () => value;
            return exp;
        }
    }
}