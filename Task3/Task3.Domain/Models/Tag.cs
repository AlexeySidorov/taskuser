using SQLite;
using Task3.Core.Data;

namespace Task3.Domain.Models
{
    public class Tag : IEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }
    }
}
