namespace splendor.net5.core.enums
{
    /// Enum list for dynamic filters operators use to implement queries to data stores
    public enum DFilterOperators
    {
        Equals,
        NoEquals,
        LessThan,
        GreaterThan,
        LessThanEquals,
        GreaterThanEquals,
        Like,
        StartsWith,
        Contains,
        IsNull,
        NotNull
    }
}