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
using System.Threading;
using System.Threading.Tasks;
using WCFAsyncQueryableServices.Common;
using WCFAsyncQueryableServices.Entities;

namespace WCFAsyncQueryableServices.DAL.Interfaces
{
    public class WAQSQuery : IWAQSQuery
    {
        private IQueryable _queryable;
                    
        public WAQSQuery(IWAQSQuery source)
            : this(source.DataContext, source, source.AsyncQueryProviderFactory, source.ExpressionTransformation)
        {
        }
        public WAQSQuery(IDataContext dataContext, IQueryable queryable, IAsyncQueryProviderFactory asyncQueryProviderFactory, Func<Expression, Expression> expressionTransformation)
        {
            DataContext = dataContext;
            _queryable = queryable;
            AsyncQueryProviderFactory = asyncQueryProviderFactory;
            ExpressionTransformation = expressionTransformation;
        }
                    
        private static Dictionary<Type, WithType> _withTypes;
        public static Dictionary<Type, WithType> WithTypes
        {
            get { return _withTypes ?? (_withTypes = new Dictionary<Type, WithType>()); }
        }
                    
        public IDataContext DataContext { get; private set; }
        public IAsyncQueryProviderFactory AsyncQueryProviderFactory { get; private set; }
        public Func<Expression, Expression> ExpressionTransformation { get; private set; }
        public bool FromQuery { get; set; }
                    
        public Type ElementType
        {
            get { return _queryable.ElementType; }
        }
                    
        public Expression Expression
        {
            get { return _queryable.Expression; }
        }
                    
        private IQueryProvider _provider;
        public IQueryProvider Provider
        {
            get { return _provider ?? (_provider = new WAQSQueryProvider(DataContext, _queryable.Provider, AsyncQueryProviderFactory, ExpressionTransformation)); }
        }
        
        private Expression InitWith()
        {
            return ApplyWith().Expression;
        }
        
        private IEnumerable<T> GetEnumerableWithoutInclude<T>(Func<IQueryProvider, Tuple<IEnumerator, Func<T>>> enumeratorFactory)
        {
            var enumerator = enumeratorFactory(((WAQSQueryProvider)Provider).SourceProvider);
            while (enumerator.Item1.MoveNext())
            {
                EntitiesInitializer.FromQuery = true;
                var o = enumerator.Item2();
                EntitiesInitializer.FromQuery = false;
                WithType withType;
                if (WAQSQuery.WithTypes.TryGetValue(typeof(T), out withType))
                    o = (T)withType.TransformToOriginalType(o);
                yield return o;
            }
        }
        
        protected IEnumerable<T> GetEnumerable<T>()
        {
            var expression = InitWith();
            try
            {
                if (!(FromQuery || QueryableIncludes == null) && QueryableIncludes.Any())
                {
                    var value = new List<T>(GetEnumerableWithoutInclude<T>(provider => GetQueryEnumerator<T>(provider, expression)));
                    LoadIncludes(this, value: value, withValue: true);
                    return value;
                }
                return GetEnumerableWithoutInclude<T>(provider => GetQueryEnumerator<T>(provider, expression));
            }
            finally
            {
                EntitiesInitializer.FromQuery = false;
            }
        }
                
        protected internal virtual IQueryable ApplyWith()
        {
            return this;
        }
        
        protected virtual Tuple<IEnumerator, Func<T>> GetQueryEnumerator<T>(IQueryProvider provider, Expression expression)
        {
            var q = provider.CreateQuery(expression);
            var enumerator = q.GetEnumerator();
            return new Tuple<IEnumerator, Func<T>>(enumerator, () => (T)enumerator.Current);
        }
                    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerable<object>().GetEnumerator();
        }
                    
        public IEnumerable<Func<IWAQSQueryBase, QueryableInclude>> QueryableIncludes { get; set; }
        public IEnumerable<string> WithSpecifications { get; set; }
                    
        protected internal static object LoadIncludes(IWAQSQueryBase queryBase, Dictionary<string, object> addedIncludesPathes = null, object value = null, bool withValue = false, string path = null)
        {
            if (addedIncludesPathes == null)
                addedIncludesPathes = new Dictionary<string, object>();
            if (!withValue)
            {
                var query = queryBase as IWAQSQuery;
                IWAQSQueryValue queryValue;
                if (query != null)
                {
                    var queryType = query.GetType();
                    if (!queryType.IsGenericType)
                        throw new InvalidOperationException();
                    query.FromQuery = true;
                    value = typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(queryType.GetGenericArguments()[0]).Invoke(null, new object[] { query });
                }
                else if ((queryValue = queryBase as IWAQSQueryValue) != null)
                {
                    queryValue.FromQuery = true;
                    value = queryValue.Execute();
                }
                else
                    throw new InvalidOperationException();
            }
            if (queryBase.QueryableIncludes != null)
                foreach (var include in queryBase.QueryableIncludes)
                {
                    var queryableInclude = include(queryBase);
                    object includeValue = null;
                    bool includeWithValue = false;
                    if (queryableInclude.Path == null || !(includeWithValue = addedIncludesPathes.TryGetValue(queryableInclude.Path, out includeValue)))
                        queryableInclude.Load(value, queryableInclude.Queries.Select(q => LoadIncludes(q, addedIncludesPathes, includeValue, includeWithValue, queryableInclude.Path)).ToArray());
                    else
                        foreach (var query in queryableInclude.Queries)
                            LoadIncludes(query, addedIncludesPathes, includeValue, includeWithValue, queryableInclude.Path);
                }
            return value;
        }
            
        protected virtual Tuple<IAsyncEnumerator, Func<T>> GetQueryAsyncEnumerator<T>(IQueryProvider provider, Expression expression)
        {
            var q = provider.CreateQuery(expression);
            var enumerator = AsyncQueryProviderFactory.AsyncEnumerableFactory.GetAsyncEnumerable(q).GetAsyncEnumerator();
            return new Tuple<IAsyncEnumerator, Func<T>>(enumerator, () => (T)enumerator.Current);
        }
    
        protected async internal static Task<object> LoadIncludesAsync(IWAQSQueryBase queryBase, Dictionary<string, object> addedIncludesPathes = null, object value = null, bool withValue = false, string path = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (addedIncludesPathes == null)
                addedIncludesPathes = new Dictionary<string, object>();
            if (!withValue)
            {
                var query = queryBase as IWAQSQuery;
                IWAQSQueryValue queryValue;
                if (query != null)
                {
                    var queryType = query.GetType();
                    if (!queryType.IsGenericType)
                        throw new InvalidOperationException();
                    value = await ((Task<object>)typeof(WAQSQuery).GetMethod("GetIncludeListAsync").MakeGenericMethod(queryType.GetGenericArguments()[0]).Invoke(null, new object[] { query, cancellationToken }));
                }
                else if ((queryValue = queryBase as IWAQSQueryValue) != null)
                {
                    queryValue.FromQuery = true;
                    value = await queryValue.ExecuteAsync(cancellationToken);
                }
                else
                    throw new InvalidOperationException();
            }
            if (queryBase.QueryableIncludes != null)
                foreach (var include in queryBase.QueryableIncludes)
                {
                    var queryableInclude = include(queryBase);
                    object includeValue = null;
                    bool includeWithValue = false;
                    if (queryableInclude.Path == null || !(includeWithValue = addedIncludesPathes.TryGetValue(queryableInclude.Path, out includeValue)))
                    {
                        var includesValues = new object[queryableInclude.Queries.Length];
                        for (int i = 0 ; i < includesValues.Length ; i ++)
                            includesValues[i] = await LoadIncludesAsync(queryableInclude.Queries[i], addedIncludesPathes, includeValue, includeWithValue, queryableInclude.Path, cancellationToken: cancellationToken);
                        queryableInclude.Load(value, includesValues);
                    }
                    else
                        foreach (var query in queryableInclude.Queries)
                            await LoadIncludesAsync(query, addedIncludesPathes, includeValue, includeWithValue, queryableInclude.Path, cancellationToken: cancellationToken);
                }
            return value;
        }
        
        private async Task<object> GetIncludeListAsync<T>(IWAQSQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            query.FromQuery = true;
            var values = new List<T>();
            await query.ForeachAsync(o => values.Add((T) o), cancellationToken);
            return values;
        }
        
        private async Task GetEnumerableWithoutIncludeAsync<T>(Func<IQueryProvider, Tuple<IAsyncEnumerator, Func<T>>> asyncEnumeratorFactory, Action<T> action, CancellationToken cancellationToken)
        {
            var asyncEnumerator = asyncEnumeratorFactory(((WAQSQueryProvider)Provider).SourceProvider);
            var values = new List<T>();
            while (await asyncEnumerator.Item1.MoveNextAsync(cancellationToken))
            {
                EntitiesInitializer.FromQuery = true;
                var o = asyncEnumerator.Item2();
                EntitiesInitializer.FromQuery = false;
                WithType withType;
                if (WAQSQuery.WithTypes.TryGetValue(typeof(T), out withType))
                    o = (T)withType.TransformToOriginalType(o);
                action(o);
            }
        }
        
        protected async Task ForeachAsync<T>(Action<T> action, CancellationToken cancellationToken = default(CancellationToken))
        {
            var expression = InitWith();
            try
            {
                if (!(FromQuery || QueryableIncludes == null) && QueryableIncludes.Any())
                {
                    var value = new List<T>();
                    await GetEnumerableWithoutIncludeAsync<T>(provider => GetQueryAsyncEnumerator<T>(provider, expression), item => value.Add(item), cancellationToken);
                    await LoadIncludesAsync(this, value: value, withValue: true);
                    foreach (T item in value)
                        action(item);
                }
                await GetEnumerableWithoutIncludeAsync<T>(provider => GetQueryAsyncEnumerator<T>(provider, expression), action, cancellationToken);
            }
            finally
            {
                EntitiesInitializer.FromQuery = false;
            }
        }
        
        public Task ForeachAsync(Action<object> action, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ForeachAsync<object>(action, cancellationToken);
        }
    }
                    
    public class WAQSQuery<T> : WAQSQuery, IWAQSQuery<T>
    {
        public WAQSQuery(IWAQSQuery<T> source)
            : this(source.DataContext, source, source.AsyncQueryProviderFactory, source.ExpressionTransformation)
        {
        }
        public WAQSQuery(IDataContext dataContext, IQueryable<T> queryable, IAsyncQueryProviderFactory asyncQueryProviderFactory, Func<Expression, Expression> expressionTransformation)
            : base(dataContext, queryable, asyncQueryProviderFactory, expressionTransformation)
        {
        }
        
        protected override Tuple<IEnumerator, Func<T2>> GetQueryEnumerator<T2>(IQueryProvider provider, Expression expression)
        {
            if (typeof(T2) != typeof(T))
                return base.GetQueryEnumerator<T2>(provider, expression);
            var q = provider.CreateQuery<T2>(expression);
            var enumerator = q.GetEnumerator();
            return new Tuple<IEnumerator, Func<T2>>(enumerator, () => enumerator.Current);
        }
                
        protected internal override IQueryable ApplyWith()
        {
            if (WithSpecifications == null || !WithSpecifications.Any())
                return this;
                
            WithType withType;
            if (!WithTypes.TryGetValue(typeof(T), out withType))
                throw new InvalidOperationException();
            ParameterExpression lambdaParameter = Expression.Parameter(typeof(T));
            var bindings = new List<MemberAssignment>();
            bindings.Add(Expression.Bind(withType.Type.GetProperty(typeof(T).Name), lambdaParameter));
            foreach (var with in WithSpecifications)
                bindings.Add(Expression.Bind(withType.Type.GetProperty(with), DataContext.GetExpression(typeof(T), with, lambdaParameter)));
            var expression = Expression.Call(typeof(Queryable).GetMethods().First(m => m.Name == "Select" && m.GetParameters()[1].ParameterType.GetGenericArguments()[0].GetGenericArguments().Length == 2).MakeGenericMethod(typeof(T), withType.Type), Expression, Expression.Lambda(Expression.MemberInit(Expression.New(withType.Type.GetConstructor(new Type[0])), bindings), lambdaParameter));
            return Provider.CreateQuery<T>(expression);
        }
                    
        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerable<T>().GetEnumerator();
        }
                    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        protected override Tuple<IAsyncEnumerator, Func<T2>> GetQueryAsyncEnumerator<T2>(IQueryProvider provider, Expression expression)
        {
            if (typeof(T2) != typeof(T))
                return base.GetQueryAsyncEnumerator<T2>(provider, expression);
            var q = provider.CreateQuery<T2>(expression);
            var enumerator = AsyncQueryProviderFactory.AsyncEnumerableFactory.GetAsyncEnumerable<T2>(q).GetAsyncEnumerator();
            return new Tuple<IAsyncEnumerator, Func<T2>>(enumerator, () => enumerator.Current);
        }
        
        public Task ForeachAsync(Action<T> action, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ForeachAsync<T>(action, cancellationToken);
        }
    }
}