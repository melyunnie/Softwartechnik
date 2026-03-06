using UnityEngine;

public class TimeWindowCriteria : BaseCriteria
{
    private readonly TimeWindowCriteriaDefinitionSO definition;

    private float startTime;
    private bool timerRunning;

    public override string Id => definition.id;

    public TimeWindowCriteria(TimeWindowCriteriaDefinitionSO def)
    {
        definition = def; 
    }

    public override void Initialize()
    {
        // EventManager.Subscribe(definition.eventChannelStart, OnStart);
        // EventManager.Subscribe(definition.eventChannelEnd, OnEnd);
    }

    public override void Dispose()
    {
        // EventManager.Unsubscribe(definition.eventChannelStart, OnStart);
        // EventManager.Unsubscribe(definition.eventChannelEnd, OnEnd);
    }

    private void OnStart(object data)
    {
        startTime = Time.time;
        timerRunning = true;
    }


    private void OnEnd(object data)
    {
        if (!timerRunning)
            return;

        float duration = Time.time - startTime;

        if (duration <= definition.targetTimeSeconds)
            Evaluate();

        timerRunning = false;
    }

    protected override bool CheckCondition()
    {
        return true;
    }

    public override void Reset()
    {
        isCompleted = false;
        timerRunning = false;
    }



    public void TestStart(float fakeTime)//UnitTests
    {
        startTime = fakeTime;
        timerRunning = true;
    }

    public void TestEnd(float fakeTime)//UnitTests
    {
        if (!timerRunning)
            return;

        float duration = fakeTime - startTime;

        if (duration <= definition.targetTimeSeconds)
            Evaluate();

        timerRunning = false;
    }

}
