using System;

namespace clubIS.DataAccessLayer.Enums
{
    [Flags]
    public enum EventProperty
    {
        Open = 0,
        National = 1 << 0,
        Bohemian = 1 << 1,
        Moravian = 1 << 2,
        Regional = 1 << 3,
        Championship = 1 << 4,
        Relay = 1 << 5,
    }
}
