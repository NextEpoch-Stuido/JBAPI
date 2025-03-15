namespace JBAPI.API.Enums
{
    public enum PluginPriority
    {
        Default = Medium,

        Last = int.MinValue,

        Lowest = Last,

        Lower = -500,

        Low = -250,

        Medium = 0,

        High = 250,

        Higher = 500,

        Highest = First,

        First = int.MaxValue,
    }
}
