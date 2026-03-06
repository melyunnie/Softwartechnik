using Achievements.Criteria;
using NUnit.Framework;
using UnityEngine;

public class CountCriteriaTests
{
    private CountCriteriaDefinitionSO definition;
    private CountCriteria criteria;

    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<CountCriteriaDefinitionSO>();
        definition.id = "count_test";
        definition.targetValue = 3;
        definition.comparisonType = ComparisonType.GreaterOrEqual;

        criteria = new CountCriteria(definition); 
    }


    [Test]
    public void Criteria_Is_Not_Met_Initially()
    {
        Assert.IsFalse(criteria.IsMet);
    }

    [Test]
    public void Criteria_Is_Met_After_Reaching_Target()
    {
        criteria.AddProgress(3);
        Assert.IsTrue(criteria.IsMet);
    }

    [Test]
    public void Criteria_Reset_Works()
    {
        criteria.AddProgress(3);
        Assert.IsTrue(criteria.IsMet);

        criteria.Reset();
        Assert.IsFalse(criteria.IsMet);
    }


    [Test]
    public void OnCompleted_Is_Triggered()
    {
        bool completed = false;
        criteria.OnCompleted += _ => completed = true;

        criteria.AddProgress(3);
        Assert.IsTrue(completed);
    }


}
