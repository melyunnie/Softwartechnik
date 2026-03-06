public class ValueThresholdCriteria : BaseCriteria
{
    private readonly ValueThresholdCriteriaDefinitionSO definition;
    private float currentValue;

    public override string Id => definition.id;


    public ValueThresholdCriteria(ValueThresholdCriteriaDefinitionSO def)
    {
        definition = def;
    }


    protected override bool CheckCondition()
    {
        return ComparisonUtility.Compare(currentValue, definition.targetValue, definition.comparisonType);
    }


    public override void Initialize() 
    {
        // EventManager.Subscribe(definition.eventChannel, OnValueChanged);
    }


    public override void Dispose()
    {
        // EventManager.Unsubscribe(definition.eventChannel, OnValueChanged);
    }


    public void OnValuechanged(object data)
    {
        if (data is float f)
        {
            currentValue = f;
            Evaluate();
        }
        else if (data is int i)
        {
            currentValue = i;
            Evaluate();
        }
    }


    public override void Reset()
    {
        isCompleted = false;
        currentValue = 0f;
    }
}