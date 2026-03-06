namespace Achievements.Criteria
{
   public enum ComparisonType
    {
        Equal,
        NotEqual,
        Greater,
        GreaterOrEqual,
        Less,
        LessOrEqual
    }


    public enum ScopeType
    {
        PerSession,
        PerLevel,
        Lifetime
    }


    public enum CompositeType
    {
        AND,
        OR,
        NOT
    }
}
