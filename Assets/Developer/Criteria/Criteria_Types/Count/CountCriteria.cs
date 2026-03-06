public class CountCriteria : BaseCriteria
{
    private readonly CountCriteriaDefinitionSO definition;
    private int currentValue;

    public override string Id => definition.id;


    public CountCriteria(CountCriteriaDefinitionSO def)
    {
        definition = def;
    }


    public override void Initialize()
    {
        // EventManager.Subscribe(definition.eventChannel, OnEventRaised);
    }

    public override void Dispose()
    {
        // EventManager.Unsubscribe(definition.eventChannel, OnEventRaised);
    }


    protected override bool CheckCondition()
    {
        return ComparisonUtility.Compare(currentValue, definition.targetValue, definition.comparisonType);
    }

    private void OnEventRaised()
    {
        currentValue++;
        Evaluate();
    }


    public override void Reset()
    {
        currentValue = 0;
        isCompleted = false;
    }


    public void AddProgress(int amount = 1)//UnitTesting
    {
        currentValue += amount;
        Evaluate();
    }
}
