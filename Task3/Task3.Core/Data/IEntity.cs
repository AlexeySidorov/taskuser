namespace Task3.Core.Data
{
    /// <summary>
    /// Базовый интерфейс сущности
    /// </summary>
    public interface IEntity : IEntity<int>
    {
    }

    /// <summary>
    /// Базовый generic интерфейс сущности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T>
    {
        /// <summary>
        ///Уникальный Идентификатор сущности
        /// </summary>
        /// 
      
        T Id { get; set; }
    }
}