using SQLite;
using Task3.Core.Data;

namespace Task3.Domain.Models
{
    public class Friend : IEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
}
