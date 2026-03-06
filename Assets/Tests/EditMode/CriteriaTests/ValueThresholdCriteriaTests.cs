using Achievements.Criteria;
using NUnit.Framework;
using UnityEngine;

public class ValueThresholdCriteriaTests
{
    private ValueThresholdCriteria criteria;
    private ValueThresholdCriteriaDefinitionSO definition;
    private bool completed;


    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<ValueThresholdCriteriaDefinitionSO>();
        definition.id = "valueThreshold_test";
        definition.targetValue = 100f;
        definition.comparisonType = ComparisonType.GreaterOrEqual;

        criteria = new ValueThresholdCriteria(definition);

        criteria.OnCompleted += _ => completed = true;
    }

    [Test]
    public void ValueThresholdCriteria_Completes_WhenValueReached()
    {
        completed = false;

        criteria.OnValuechanged(120f);

        Assert.IsTrue(completed);
    }



    [Test]
    public void ValueThresholdCriteria_DoesNotComplete_WhenValueTooLow()
    {
        completed = false;
        criteria.OnCompleted += _ => completed = true;

        criteria.OnValuechanged(50f);

        Assert.IsFalse(completed);
    }



    [Test]
    public void ValueThresholdCriteria_RespectsComparisonType()
    {
        completed = false;

        definition.comparisonType = ComparisonType.Greater;

        criteria.OnValuechanged(100f);

        Assert.IsFalse(completed);
    }



    [Test]
    public void ValueThresholdCriteria_Reset_ClearsState()
    {
        criteria.OnValuechanged(150f);

        Assert.IsTrue(criteria.IsMet);

        criteria.Reset();

        Assert.IsFalse(criteria.IsMet);
    }



    [Test]
    public void ValueThresholdCriteria_UpdatesValueMultipleTimes()
    {
        completed = false;

        criteria.OnValuechanged(30f);
        criteria.OnValuechanged(60f);
        criteria.OnValuechanged(120f);

        Assert.IsTrue(completed);
    }
}    
