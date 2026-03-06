using System.Collections.Generic;
using System.Linq;
using Achievements.Criteria;
public class CompositeCriteria : BaseCriteria
{
    private readonly CompositeCriteriaDefinitionSO definition;
    private readonly List<ICriteria> childCriteria = new();

    public override string Id => definition.id;


    public CompositeCriteria(CompositeCriteriaDefinitionSO def, List<ICriteria> children)
    {
        definition = def;
        childCriteria = children;

        foreach (var child in childCriteria)
        {
            child.OnCompleted += OnChildCompleted;
        }
    }


    public override void Initialize()
    {
        foreach (ICriteria criteria in childCriteria)
        {
            criteria.Initialize();
        }
    }

    public override void Dispose()
    {
        foreach (var child in childCriteria)
        {
            child.OnCompleted -= OnChildCompleted;
            child.Dispose();
        }
    }


    protected override bool CheckCondition()
    {
        if (childCriteria == null || childCriteria.Count == 0)
            return false;

        switch (definition.compositeType)
        {
            case CompositeType.AND:
                return childCriteria.All(c => c.IsMet);

            case CompositeType.OR:
                return childCriteria.Any(c => c.IsMet);

            case CompositeType.NOT:
                if (childCriteria.Count != 1)
                    throw new System.Exception("NOT Composite must have exactly one child");
                return !childCriteria[0].IsMet;

            default:
                return false;
        }
    }

    private void OnChildCompleted(ICriteria _)
    {
        Evaluate();
    }


    public override void Reset()
    {
        isCompleted = false;

        foreach (var child in childCriteria)
        {
            child.Reset();
        }
    }
}
