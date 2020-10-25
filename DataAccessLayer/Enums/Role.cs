using System;

namespace DataAccessLayer.Enums
{
    [Flags]
    public enum Role
    {
        Member,
        Financier,
        EventManager,
        News,
        EntriesManager,
        AccountManager,
        Admin
    }
}
