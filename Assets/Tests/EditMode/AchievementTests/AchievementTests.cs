using System.Collections.Generic;
using Achievements.Criteria;
using NUnit.Framework;
using UnityEngine;

public class AchievementTests
{
    private AchievementDefinitionSO definition;


    [SetUp]
    public void Setup()
    {
        definition = ScriptableObject.CreateInstance<AchievementDefinitionSO>();
        definition.id = "ACH_001";
        definition.repeatable = true;
        definition.cooldownSeconds = 1f;
        definition.scope = ScopeType.Lifetime;
    }



    [Test]
    public void Achievement_Completes_When_AllCriteriaMet()
    {
        var criteria = new List<ICriteria>
        {
            new FakeCriteria("C1"),
            new FakeCriteria("C2")
        };

        var achievement = new Achievement(definition, criteria);
        bool completedEventFired = false;
        achievement.OnCompleted += _ => completedEventFired = true;

        achievement.Initialize();

        ((FakeCriteria)criteria[0]).Trigger();
        Assert.IsFalse(achievement.IsCompleted, "Achievement should not complete yet");

        ((FakeCriteria)criteria[1]).Trigger();

        Assert.IsTrue(achievement.IsCompleted, "Achievement should complete when all criteria met");
        Assert.IsTrue(completedEventFired, "OnCompleted event should be fired");
    }



    [Test]
    public void Achievement_Resets_After_Cooldown_For_Repeatable()
    {
        definition.cooldownSeconds = 0f;
        definition.repeatable = true;

        var criteria = new List<ICriteria> { new FakeCriteria("C1") };
        var achievement = new Achievement(definition, criteria);
        achievement.Initialize();

        ((FakeCriteria)criteria[0]).Trigger();
        Assert.IsTrue(achievement.IsCompleted, "Achievement should complete");

        achievement.Reset();

        Assert.IsFalse(achievement.IsCompleted, "Achievement should be reset");
        Assert.IsFalse(criteria[0].IsMet, "Criteria should also be reset");
    }



    [Test]
    public void Achievement_PerLevel_Resets_OnLevelEnd()
    {
        definition.scope = ScopeType.PerLevel;

        var criteria = new List<ICriteria> { new FakeCriteria("C1") };
        var achievement = new Achievement(definition, criteria);
        achievement.Initialize();

        ((FakeCriteria)criteria[0]).Trigger();
        Assert.IsTrue(achievement.IsCompleted, "Achievement should complete after criterion met");

        achievement.OnScopeReset();

        Assert.IsFalse(achievement.IsCompleted, "Achievement should be reset after PerLevel scope reset");
        Assert.IsFalse(criteria[0].IsMet, "Criteria should also be reset");
    }



    [Test]
    public void Achievement_PerSession_Resets_OnSessionEnd()
    {
        definition.scope = ScopeType.PerSession;

        var criteria = new List<ICriteria> { new FakeCriteria("C1") };
        var achievement = new Achievement(definition, criteria);
        achievement.Initialize();

        ((FakeCriteria)criteria[0]).Trigger();
        Assert.IsTrue(achievement.IsCompleted, "Achievement should complete after criterion met");

        achievement.OnScopeReset();

        Assert.IsFalse(achievement.IsCompleted, "Achievement should be reset after PerSession scope reset");
        Assert.IsFalse(criteria[0].IsMet, "Criteria should also be reset");
    }
}
