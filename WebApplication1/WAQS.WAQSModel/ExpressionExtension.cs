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

namespace WCFAsyncQueryableServices.Common
{
    public static class ExpressionExtension
    {
        public static Expression ReplaceExpression(this Expression expression, Expression source, Expression replace)
        {
            return ReplaceExpression(expression, e => e == source ? replace : e);
        }
                        
        public static Expression ReplaceExpression(this Expression expression, Func<Expression, Expression> replace)
        {
            return new ExpressionReplaceRewriter { ReplaceExpressionFunc = replace }.Visit(expression);
        }
                    
        public static Expression ReplaceParameter(this Expression expression, ParameterExpression parameter, Expression replace)
        {
            return ReplaceParameter(expression, n => n == parameter ? replace : n);
        }
                    
        public static Expression ReplaceParameter(this Expression expression, Func<ParameterExpression, Expression> replace)
        {
            return new ExpressionReplaceRewriter { ReplaceParameterFunc = replace }.Visit(expression);
        }
                    
        public static Expression ReplaceBodyParameter(this LambdaExpression expression, Expression replace)
        {
            return ReplaceParameter(expression.Body, n => n == expression.Parameters[0] ? replace : n);
        }
                    
        public static Expression ReplaceMethodCall(this Expression expression, MethodCallExpression methodCall, Expression replace)
        {
            return ReplaceMethodCall(expression, n => n == methodCall ? replace : n);
        }
                    
        public static Expression ReplaceMethodCall(this Expression expression, Func<MethodCallExpression, Expression> replace)
        {
            return new ExpressionReplaceRewriter { ReplaceMethodCallFunc = replace }.Visit(expression);
        }
                
        public static Expression ReplaceConstant(this Expression expression, ConstantExpression constant, Expression replace)
        {
            return ReplaceConstant(expression, n => n == constant ? replace : n);
        }
                
        public static Expression ReplaceConstant(this Expression expression, Func<ConstantExpression, Expression> replace)
        {
            return new ExpressionReplaceRewriter { ReplaceConstantFunc = replace }.Visit(expression);
        }
            
        public static Expression ReplaceInvocation(this Expression expression, InvocationExpression invocation, Expression replace)
        {
            return ReplaceInvocation(expression, n => n == invocation ? replace : n);
        }
            
        public static Expression ReplaceInvocation(this Expression expression, Func<InvocationExpression, Expression> replace)
        {
            return new ExpressionReplaceRewriter { ReplaceInvocationFunc = replace }.Visit(expression);
        }
            
        public static Expression ReplaceBinary(this Expression expression, BinaryExpression invocation, Expression replace)
        {
            return ReplaceBinary(expression, n => n == invocation ? replace : n);
        }
            
        public static Expression ReplaceBinary(this Expression expression, Func<BinaryExpression, Expression> replace)
        {
            return new ExpressionReplaceRewriter { ReplaceBinaryFunc = replace }.Visit(expression);
        }
        
        public static Expression ReplaceMember(this Expression expression, MemberExpression invocation, Expression replace)
        {
            return ReplaceMember(expression, n => n == invocation ? replace : n);
        }
        
        public static Expression ReplaceMember(this Expression expression, Func<MemberExpression, Expression> replace)
        {
            return new ExpressionReplaceRewriter { ReplaceMemberFunc = replace }.Visit(expression);
        }
    
        private static Type ReplaceType(Type type, Dictionary<Type, Type> replaceTypes)
        {
            Type value;
            if (replaceTypes.TryGetValue(type, out value))
                return value;
            if (type.IsGenericType)
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();
                Type newGenericTypeDefinition;
                if (replaceTypes.TryGetValue(genericTypeDefinition, out newGenericTypeDefinition))
                    genericTypeDefinition = newGenericTypeDefinition;
                if (! genericTypeDefinition.IsGenericType)
                    return genericTypeDefinition;
                return genericTypeDefinition.MakeGenericType(type.GetGenericArguments().Select(t => ReplaceType(t, replaceTypes)).ToArray());
            }
            return type;
        }
    
        public static Expression UseQueryable(this Expression expression)
        {
            ExpressionReplaceRewriter useQueryableExpressionReplaceRewriter = null;
            useQueryableExpressionReplaceRewriter = new ExpressionReplaceRewriter
            {
                ReplaceMethodCallFunc = m =>
                    {
                        if (m.Method.DeclaringType == typeof(Enumerable))
                        {
                            var method = typeof(Queryable).GetMethods().FirstOrDefault(m2 =>
                            {
                                var m1 = m.Method.IsGenericMethod ? m.Method.GetGenericMethodDefinition() : m.Method;
                                if (m2.Name != m1.Name)
                                    return false;
                                if (m1.IsGenericMethod ^ m2.IsGenericMethod || m1.IsGenericMethod && m1.GetGenericArguments().Length != m2.GetGenericArguments().Length)
                                    return false;
                                var mParameters = m1.GetParameters();
                                var m2Parameters = m2.GetParameters();
                                if (mParameters.Length != m2Parameters.Length)
                                    return false;
                                for (int parameterIndex = 0 ; parameterIndex < mParameters.Length ; parameterIndex ++)
                                {
                                    var mParameterType = mParameters[parameterIndex].ParameterType;
                                    var m2ParameterType = m2Parameters[parameterIndex].ParameterType;
                                    if (mParameterType == m2ParameterType)
                                        continue;
                                    if (mParameterType == typeof(IEnumerable) && m2ParameterType == typeof(IQueryable))
                                        continue;
                                    if (! (mParameterType.IsGenericType && m2ParameterType.IsGenericType))
                                        return false;
                                    var replacesTypes = new Dictionary<Type, Type>() { { typeof(IEnumerable<>), typeof(IQueryable<>) } };
                                    if (m1.IsGenericMethod)
                                    {
                                        var mGenericArguments = m1.GetGenericArguments();
                                        var m2GenericArguments = m2.GetGenericArguments();
                                        for (int genericArgumentIndex = 0 ; genericArgumentIndex < mGenericArguments.Length ; genericArgumentIndex ++)
                                            replacesTypes.Add(mGenericArguments[genericArgumentIndex], m2GenericArguments[genericArgumentIndex]);
                                    }
                                    mParameterType = ReplaceType(mParameterType, replacesTypes);
                                    if (m2ParameterType == mParameterType)
                                        continue;
                                    if (m2ParameterType == typeof(Expression<>).MakeGenericType(mParameterType))
                                        continue;
                                    return false;
                                }
                                return true;
                            });
                            if (method != null)
                            {
                                if (m.Method.IsGenericMethod)
                                    method = method.MakeGenericMethod(m.Method.GetGenericArguments());
                                var parameterRewriter = new ExpressionReplaceRewriter { ReplaceLambdaFunc = e => Expression.Quote(e) };
                                return Expression.Call(method, m.Arguments.Take(1).Select(a => useQueryableExpressionReplaceRewriter.Visit(a)).Union(m.Arguments.Skip(1).Select(a => parameterRewriter.Visit(a))));
                            }
                        }
                        return Expression.Call(m.Object, m.Method, m.Arguments);
                    }
            };
            return useQueryableExpressionReplaceRewriter.Visit(expression);
        }
    
        public class ExpressionReplaceRewriter : ExpressionVisitor
        {
            public Func<Expression, Expression> ReplaceExpressionFunc { get; set; }
            public override Expression Visit(Expression node)
            {
                if (ReplaceExpressionFunc != null)
                {
                    var value = ReplaceExpressionFunc(node);
                    if (value != node)
                        return value;
                }
                return base.Visit(node);
            }
                    
            public Func<ParameterExpression, Expression> ReplaceParameterFunc { get; set; }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (ReplaceParameterFunc != null)
                {
                    var value = ReplaceParameterFunc(node);
                    if (value != node)
                        return value;
                }
                return base.VisitParameter(node);
            }
                    
            public Func<MethodCallExpression, Expression> ReplaceMethodCallFunc { get; set; }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (ReplaceMethodCallFunc != null)
                {
                    var value = ReplaceMethodCallFunc(node);
                    if (value != node)
                        return value;
                }
                return base.VisitMethodCall(node);
            }
                
            public Func<ConstantExpression, Expression> ReplaceConstantFunc { get; set; }
            protected override Expression VisitConstant(ConstantExpression node)
            {
                if (ReplaceConstantFunc != null)
                {
                    var value = ReplaceConstantFunc(node);
                    if (value != node)
                        return value;
                }
                return base.VisitConstant(node);
            }
            
            public Func<InvocationExpression, Expression> ReplaceInvocationFunc { get; set; }
            protected override Expression VisitInvocation(InvocationExpression node)
            {
                if (ReplaceInvocationFunc != null)
                {
                    var value = ReplaceInvocationFunc(node);
                    if (value != node)
                        return value;
                }
                return base.VisitInvocation(node);
            }
            
            public Func<BinaryExpression, Expression> ReplaceBinaryFunc { get; set; }
            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (ReplaceBinaryFunc != null)
                {
                    var value = ReplaceBinaryFunc(node);
                    if (value != node)
                        return value;
                }
                return base.VisitBinary(node);
            }
        
            public Func<MemberExpression, Expression> ReplaceMemberFunc { get; set; }
            protected override Expression VisitMember(MemberExpression node)
            {
                if (ReplaceMemberFunc != null)
                {
                    var value = ReplaceMemberFunc(node);
                    if (value != node)
                        return value;
                }
                return base.VisitMember(node);
            }
    
            public Func<LambdaExpression, Expression> ReplaceLambdaFunc { get; set; }
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                if (ReplaceLambdaFunc != null)
                {
                    var value = ReplaceLambdaFunc(node);
                    if (value != node)
                        return value;
                }
                return base.VisitLambda(node);
            }
        }
    }
}