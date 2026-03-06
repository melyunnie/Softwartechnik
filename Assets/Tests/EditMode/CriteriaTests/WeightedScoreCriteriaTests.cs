using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class WeightedScoreCriteriaTests
{
    private WeightedScoreCriteria criteria;
    private WeightedCriteriaDefinitionSO definition;


    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<WeightedCriteriaDefinitionSO>();
        {
            definition.id = "weigthedScore_test";
            definition.targetScore = 10;
            definition.weightedEvents = new List<WeightedEvent> { new WeightedEvent { eventChannel = "Kill", score = 3 }, new WeightedEvent { eventChannel = "Headshot", score = 5 } };
        }

        criteria = new WeightedScoreCriteria(definition);
    }



    [Test]
    public void Score_Increases_When_EventAdded()
    {
        criteria.AddScore("Kill");

        Assert.IsFalse(criteria.IsMet);
    }



    [Test]
    public void Multiple_Events_Add_Score()
    {
        criteria.AddScore("Kill");     // 3
        criteria.AddScore("Headshot"); // 5

        Assert.IsFalse(criteria.IsMet);
    }


    [Test]
    public void Criteria_Completes_When_TargetScore_Reached()
    {
        criteria.AddScore("Headshot"); // 5
        criteria.AddScore("Headshot"); // 10

        Assert.IsTrue(criteria.IsMet);
    }



    [Test]
    public void Unknown_Event_Does_Not_Add_Score()
    {
        criteria.AddScore("Jump");

        Assert.IsFalse(criteria.IsMet);
    }



    [Test]
    public void Reset_Clears_Score()
    {
        criteria.AddScore("Headshot");
        criteria.AddScore("Headshot");

        Assert.IsTrue(criteria.IsMet);

        criteria.Reset();

        Assert.IsFalse(criteria.IsMet);
    }


    [Test]
    public void OnCompleted_Event_Is_Raised_When_TargetReached()
    {
        bool completed = false;
        criteria.OnCompleted += _ => completed = true;

        criteria.AddScore("Headshot");
        criteria.AddScore("Headshot");

        Assert.IsTrue(completed);
    }
}
