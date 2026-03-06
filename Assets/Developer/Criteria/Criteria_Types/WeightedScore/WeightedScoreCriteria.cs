using System.Collections.Generic;

public class WeightedScoreCriteria : BaseCriteria
{
    private readonly WeightedCriteriaDefinitionSO definition;

    private int currentScore;

    private Dictionary<string, int> eventScores = new();

    public override string Id => definition.id;


    public WeightedScoreCriteria(WeightedCriteriaDefinitionSO def)
    {
        definition = def;

        foreach (var e in def.weightedEvents)
        {
            eventScores[e.eventChannel] = e.score;
        }
    }


    public override void Initialize()
    {
        foreach (var evt in eventScores.Keys)
        {
            // EventManager.Subscribe(evt, OnEventRaised);
        }
    }


    public override void Dispose()
    {
        foreach (var evt in eventScores.Keys)
        {
            // EventManager.Unsubscribe(evt, OnEventRaised);
        }
    }


    protected override bool CheckCondition()
    {
        return currentScore >= definition.targetScore;
    }


    private void OnEventRaised(object data)
    {
        if(data is string eventName)
            AddScore(eventName);
    }


    public override void Reset()
    {
        currentScore = 0;
        isCompleted = false;
    }


    public void AddScore(string eventName)//UnitTests
    {
        if (eventScores.ContainsKey(eventName))
        {
            currentScore += eventScores[eventName];
            Evaluate();
        }
    }
}
