using System.Collections.Generic;
public class SequenceCriteria : BaseCriteria
{
    private readonly SequenceCriteriaDefinitionSO definition;
    private readonly List<ICriteria> steps = new();
    private readonly List<System.Action<ICriteria>> handlers = new();
    private int currentIndex;

    public override string Id => definition.id;

    public SequenceCriteria(SequenceCriteriaDefinitionSO def, List<ICriteria> runtimeSteps)
    {
        definition = def;
        steps = runtimeSteps;

        for (int i = 0; i < steps.Count; i++)
        {
            int index = i;

            System.Action<ICriteria> handler = _ => OnStepCompleted(index);

            handlers.Add(handler);
            steps[i].OnCompleted += handler;
        }
    }

    protected override bool CheckCondition()
    {
        if (steps == null || steps.Count == 0)
            return false;

        return currentIndex >= steps.Count;
    }

    private void OnStepCompleted(int index)
    {
        if (index == currentIndex)
        {
            currentIndex++;
            Evaluate();
        }
    }

    public override void Initialize()
    {
        foreach (ICriteria criteria in steps)
        {
            criteria.Initialize();
        }
    }

    public override void Dispose()
    {
        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].OnCompleted -= handlers[i];
            steps[i].Dispose();
        }
    }


    public override void Reset()
    {
        isCompleted = false;

        currentIndex = 0;
        foreach (ICriteria criteria in steps)
        {
            criteria.Reset();
        }
    }
}
