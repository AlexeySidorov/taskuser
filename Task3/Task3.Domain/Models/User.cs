using System;
using System.Collections.Generic;
using SQLite;
using Task3.Core.Attributes;
using Task3.Core.Data;

namespace Task3.Domain.Models
{
    public class User : IEntity
    {
        [PrimaryKey]
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public bool IsActive { get; set; }

        public string Balance { get; set; }

        public int Age { get; set; }

        public ColorType EyeColor { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string About { get; set; }

        public DateTime Registered { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Ignore]
        public IList<string> Tags { get; set; }

        [Ignore]
        public IList<Friend> Friends { get; set; }

        public Figure FavoriteFruit { get; set; }

        public string Gender { get; set; }
    }

    public enum Figure
    {
        [Description("apple")]
        Apple,
        [Description("banana")]
        Banana,
        [Description("strawberry")]
        Strawberry
    }

    public enum ColorType
    {
        [Description("brown")]
        Brown,
        [Description("blue")]
        Blue,
        [Description("green")]
        Green,
        None
    }
}
