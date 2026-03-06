using Achievements.Criteria;
using NUnit.Framework;
using UnityEngine;

public class TimeWindowCriteriaTests
{
    private TimeWindowCriteria criteria;
    private TimeWindowCriteriaDefinitionSO definition;


    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<TimeWindowCriteriaDefinitionSO>();
        definition.id = "timeWindow_test";
        definition.targetTimeSeconds = 3;

        criteria = new TimeWindowCriteria(definition);
    }



    [Test]
    public void TimeWindowCriteria_Completes_WhenWithinTimeWindow()
    {
        definition.targetTimeSeconds = 5f;

        bool completed = false;
        criteria.OnCompleted += _ => completed = true;

        criteria.TestStart(0f);
        criteria.TestEnd(3f);

        Assert.IsTrue(completed);
    }


    [Test]
    public void TimeWindowCriteria_DoesNotComplete_WhenOutsideTimeWindow()
    {
        definition.targetTimeSeconds = 5f;

        bool completed = false;
        criteria.OnCompleted += _ => completed = true;

        criteria.TestStart(0f);
        criteria.TestEnd(8f);

        Assert.IsFalse(completed);
    }



    [Test]
    public void TimeWindowCriteria_DoesNotComplete_WhenEndWithoutStart()
    {
        definition.targetTimeSeconds = 5f;


        bool completed = false;
        criteria.OnCompleted += _ => completed = true;

        criteria.TestEnd(2f);

        Assert.IsFalse(completed);
    }



    [Test]
    public void TimeWindowCriteria_Reset_ClearsCompletion()
    {
        definition.targetTimeSeconds = 5f;

        criteria.TestStart(0f);
        criteria.TestEnd(3f);

        Assert.IsTrue(criteria.IsMet);

        criteria.Reset();

        Assert.IsFalse(criteria.IsMet);
    }
}
