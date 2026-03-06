using UnityEngine;
using NUnit.Framework;

public class BooleanCriteriaTests
{
    private BooleanCriteria criteria;
    private BooleanCriteriaDefinitionSO definition;


    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<BooleanCriteriaDefinitionSO>();
        definition.id = "boolean_test";

        criteria = new BooleanCriteria(definition);
    }


    [TearDown]
    public void TearDown()
    {
        criteria.Dispose();
    }

    [Test]
    public void BooleanCriteria_IsNotMet_Initially()
    {
        Assert.IsFalse(criteria.IsMet);
    }


    [Test]
    public void BooleanCritera_BecomesMet_WhenTriggered()
    {
        criteria.Trigger();
        Assert.IsTrue(criteria.IsMet);
    }

    [Test]
    public void BooleanCriteria_FiresCompletedEvent_WhenTriggered()
    {
        bool eventfired = false;

        criteria.OnCompleted += _ => eventfired = true;

        criteria.Trigger();

        Assert.IsTrue(eventfired);
    }


    [Test]
    public void BooleanCriteria_Reset_Works()
    {
        criteria.Trigger();
        Assert.IsTrue(criteria.IsMet);

        criteria.Reset();
        Assert.IsFalse(criteria.IsMet);
    }

    [Test]
    public void BooleanCriteria_DoesNotCompleteTwice()
    {
        int completedCount = 0;

        criteria.OnCompleted += _ => completedCount++;

        criteria.Trigger();
        criteria.Trigger();

        Assert.AreEqual(1, completedCount);
    }
}
