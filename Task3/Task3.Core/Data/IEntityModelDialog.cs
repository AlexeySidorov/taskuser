
namespace Task3.Core.Data
{
    public interface IEntityModelDialog : IEntityModelDialog<string>, IEntity<int>
    {
    }

    /// <summary>
    /// Базовый generic интерфейс сущности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityModelDialog<T>
    {
        /// <summary>
        /// Заголовок строки в диалоговом окне
        /// </summary>
        T Title { get; set; }
    }
}
