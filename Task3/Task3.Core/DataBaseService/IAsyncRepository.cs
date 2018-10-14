using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Task3.Core.Data;

namespace Task3.Core.DataBaseService
{
    /// <summary>
    /// Асинхронный репозиторий для работы с БД
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAsyncRepository<TEntity> : IDependency, IDisposable where TEntity : class, IEntity
    {
       
        /// <summary>
        /// Создать запись
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> CreateAsync(TEntity entity);
        
        /// <summary>
        /// Массовая вставка записей
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task CreateAllAsync(IEnumerable<TEntity> entities);
        
        /// <summary>
        /// Обновить запись
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);
        
        /// <summary>
        /// Удалить запись
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);
       
        /// <summary>
        /// Получение записи по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(long id);
       
        /// <summary>
        /// Получение записи по условию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
      
        /// <summary>
        /// Количество всех записей
        /// </summary>
        /// <returns></returns>
        Task<long> CountAsync();
        
        /// <summary>
        /// Количество записей удовлетворяющих условию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate);
        
        /// <summary>
        /// Загрузить все записи
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FetchAsync();
        
        /// <summary>
        /// Загрузить записи по условию
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<TEntity>> FetchAsync(Expression<Func<TEntity, bool>> predicate);
       
        /// <summary>
        /// Загрузить все записи и отсортировать
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FetchAsync(Action<IOrderable<TEntity>> order);
        
        /// <summary>
        /// Загрузить записи по условию и отсортировать
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FetchAsync(Expression<Func<TEntity, bool>> predicate, Action<IOrderable<TEntity>> order);
       
        /// <summary>
        /// Загрузить count записей начиная с skip записи и отсортировать
        /// </summary>
        /// <param name="order"></param>
        /// <param name="skip"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IList<TEntity>> FetchAsync(Action<IOrderable<TEntity>> order, int skip, int count);
        
        /// <summary>
        /// Загрузить count записей начиная с skip записи удовлетворяющих условию
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="skip"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FetchAsync(Expression<Func<TEntity, bool>> predicate, int skip, int count);
        
        /// <summary>
        /// Загрузить count записей начиная с skip записи удовлетворяющих условию и отсортировать
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <param name="skip"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FetchAsync(Expression<Func<TEntity, bool>> predicate, Action<IOrderable<TEntity>> order, int skip, int count);
        
        
/// <summary>
        /// Загрузить count записей удовлетворяющих условию и отсортировать
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FetchAsync(Expression<Func<TEntity, bool>> predicate, Action<IOrderable<TEntity>> order, int count);
        
        ///// <summary>
        ///// Join 2х таблиц
        ///// </summary>
        ///// <param name="sourceColumn"></param>
        ///// <param name="destinationColumn"></param>
        ///// <param name="sourceTableColumnSelection"></param>
        ///// <param name="destinationTableColumnSelection"></param>
        ///// <param name="sourceWhere"></param>
        ///// <param name="destinationWhere"></param>
        ///// <typeparam name="TSourceTable"></typeparam>
        ///// <typeparam name="TDestinationTable"></typeparam>
        ///// <returns></returns>
        //Task<IEnumerable<TEntity>> Join<TSourceTable, TDestinationTable>(
        //Expression<Func<TSourceTable, object>> sourceColumn,
        //Expression<Func<TDestinationTable, object>> destinationColumn,
        //Expression<Func<TSourceTable, object>> sourceTableColumnSelection = null,
        //Expression<Func<TDestinationTable, object>> destinationTableColumnSelection = null,
        //Expression<Func<TSourceTable, bool>> sourceWhere = null,
        //Expression<Func<TDestinationTable, bool>> destinationWhere = null);

        /*  Task<IEnumerable<TEntity>> Join<TSourceTable, TDestinationTable>(
        Expression<Func<TSourceTable, object>> sourceColumn,
Expression<Func<TDestinationTable, object>> destinationColumn,
Expression<Func<TSourceTable, object>> sourceTableColumnSelection = null,
Expression<Func<TDestinationTable, object>> destinationTableColumnSelection = null,
Expression<Func<TSourceTable, bool>> sourceWhere = null,
Expression<Func<TDestinationTable, bool>> destinationWhere = null, int? skip = null, int? count = null);
        */
        //Task<T> QueryScalar<T>(string sqlQuery);
        /// <summary>
        ///  Join 2х таблиц
        /// </summary>
        /// <param name="sourceColumn"></param>
        /// <param name="destinationColumn"></param>
        /// <param name="sourceTableColumnSelection"></param>
        /// <param name="destinationTableColumnSelection"></param>
        /// <param name="sourceWhere"></param>
        /// <param name="destinationWhere"></param>
        /// <param name="skip"></param>
        /// <param name="count"></param>
        /// <typeparam name="TSourceTable"></typeparam>
        /// <typeparam name="TDestinationTable"></typeparam>
        /// <returns></returns>
        /// <summary>
        /// Скалярный запрос к БД
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="array"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <summary>
        /// Начать транзакцию
        /// </summary>
        /// <returns></returns>
        //  Task BeginTransaction(IEnumerable<TEntity> T);

        // Task<IEnumerable<TEntity>> FetchAsync(List<TEntity> array, Expression<Func<TEntity, bool>> predicate);

        Task UpdateAllAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// Создать или обновить элемент
        /// </summary>
        /// <param name="entity">Элемент</param>
        /// <returns></returns>
        Task<TEntity> CreateOrUpdateAsync(TEntity entity);
        /// <summary>
        /// Создать или обновить элементы
        /// </summary>
        /// <param name="entities">Элементы</param>
        /// <returns></returns>
        Task CreateOrUpdateAllAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// Удалить элементы по условию
        /// </summary>
        /// <param name="predicate">Условие</param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}