using Newtonsoft.Json;
using SQLite;
using Task3.Core.Data;

namespace Task3.Domain.Models
{
    public class Friend : IEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int FriendId { get; set; }
    }

}
