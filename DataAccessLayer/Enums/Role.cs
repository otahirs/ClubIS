using System;

namespace clubIS.DataAccessLayer.Enums
{
    [Flags]
    public enum Role
    {
        Member = 0,
        Financier = 1 << 0,
        EventManager = 1 << 1,
        News = 1 << 2,
        EntriesManager = 1 << 3,
        AccountManager = 1 << 4,
        Admin = 1 << 5
    }
}
