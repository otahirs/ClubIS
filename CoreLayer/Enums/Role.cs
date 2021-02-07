using System.Collections.Generic;

namespace ClubIS.CoreLayer.Enums
{
    public class Role
    {
        public const string Admin = "admin";
        public const string News = "news";
        public const string Finance = "finance";
        public const string Events = "events";
        public const string Users = "users";
        public const string Entries = "entries";
        public static List<string> GetAll()
        {
            return new List<string>()
            {
                Admin,
                News,
                Finance,
                Events,
                Users,
                Entries
            };
        }
    }
}
