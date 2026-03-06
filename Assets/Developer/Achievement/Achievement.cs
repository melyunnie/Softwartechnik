using System;
using System.Collections.Generic;
using System.Linq;
using Achievements.Criteria;

public class Achievement
{
    public string Id => definition.id;
    public ScopeType Scope => definition.scope;
    public bool IsCompleted => isCompleted;
    public bool IsAvailable => CanActivate();

    public event Action<Achievement> OnCompleted;

    private readonly AchievementDefinitionSO definition;
    private readonly List<ICriteria> criteria;

    private bool isCompleted;
    private DateTime lastCompletedTime;

    public Achievement(AchievementDefinitionSO def, List<ICriteria> runtimeCriteria)
    {
        definition = def;
        criteria = runtimeCriteria;

        foreach (var c in criteria)
        {
            c.OnCompleted += _ => Evaluate();
        }
    }

    public void Initialize()
    {
        foreach (var c in criteria)
        {
            c.Initialize();
        }
    }

    public void Dispose()
    {
        foreach (var c in criteria)
        {
            c.Dispose();
        }
    }


    public void OnScopeReset()
    {
        if (Scope == ScopeType.PerLevel || Scope == ScopeType.PerSession)
            Reset();
    }



    private bool CanActivate()
    {
        if (!definition.repeatable && isCompleted)
            return false;

        if (definition.cooldownSeconds > 0)
        {
            var timeSinceLast = (DateTime.UtcNow - lastCompletedTime).TotalSeconds;
            if (timeSinceLast < definition.cooldownSeconds)
                return false;
        }

        return true;
    }


    private void Evaluate()
    {
        if (!CanActivate() || isCompleted)
            return;

        if (criteria.All(c => c.IsMet))
        {
            isCompleted = true;
            lastCompletedTime = DateTime.UtcNow;

            OnCompleted?.Invoke(this);
        }
    }

    public void CheckRepeatable(Achievement ach)
    {
        if (!ach.definition.repeatable)
            return;

        var timeSinceLast = (DateTime.UtcNow - ach.lastCompletedTime).TotalSeconds;
        if (timeSinceLast >= ach.definition.cooldownSeconds)
            ach.Reset();
    }


    public void Reset()
    {
        isCompleted = false;

        foreach (var c in criteria)
            c.Reset();

        if (Scope == ScopeType.PerLevel || Scope == ScopeType.PerSession)
        {
            lastCompletedTime = DateTime.MinValue;
        }
    }
}
