using Achievements.Criteria;

public static class ComparisonUtility
{
    public static bool Compare (float a, float b, ComparisonType type)
    {
        switch (type)
        {
            case ComparisonType.Equal: return a == b;
            case ComparisonType.NotEqual: return a != b;
            case ComparisonType.Greater: return a > b;
            case ComparisonType.GreaterOrEqual: return a >= b;
            case ComparisonType.Less: return a <= b;
            case ComparisonType.LessOrEqual: return a <= b;
        }
        return false;
    }
}
