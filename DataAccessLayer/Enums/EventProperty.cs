using System;

namespace DataAccessLayer.Enums
{
    [Flags]
    public enum EventProperty
    {
        National,
        Bohemian,
        Moravian,
        Regional,
        Championship,
        Relay,
        Open
    }
}
