public class BooleanCriteria : BaseCriteria
{
    private readonly BooleanCriteriaDefinitionSO definition;
    private bool conditionTriggered;

    public override string Id => definition.id;


    public BooleanCriteria(BooleanCriteriaDefinitionSO def)
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
        return conditionTriggered;
    }


    private void OnEventRaised(object data)
    {
        conditionTriggered = true;
        Evaluate();
    }


    public override void Reset()
    {
        conditionTriggered = false;
        isCompleted = false;
    }

    public void Trigger()//UnitTesting
    {
        conditionTriggered = true;
        Evaluate();
    }
}
