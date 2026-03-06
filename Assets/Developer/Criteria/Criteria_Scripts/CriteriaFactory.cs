using System;
using System.Linq;

public static class CriteriaFactory
{
    public static ICriteria Create(ICriteriaDefinition def)
    {
        switch (def)
        {
            case CountCriteriaDefinitionSO countDef:
                return new CountCriteria(countDef);

            case ValueThresholdCriteriaDefinitionSO valueThresholdDef:
                return new ValueThresholdCriteria(valueThresholdDef);

            case BooleanCriteriaDefinitionSO boolDef:
                return new BooleanCriteria(boolDef);

            case CompositeCriteriaDefinitionSO compositeDef:
                {
                    var children = compositeDef.childCriteriaDefinitions.OfType<ICriteriaDefinition>().Select(Create).ToList();
                    return new CompositeCriteria(compositeDef, children);
                }

            case SequenceCriteriaDefinitionSO sequenceDef:
                {
                    var steps = sequenceDef.stepDefinitions.OfType<ICriteriaDefinition>().Select(Create).ToList();
                    return new SequenceCriteria(sequenceDef, steps);
                }

            case TimeWindowCriteriaDefinitionSO timeWindowDef:
                return new TimeWindowCriteria(timeWindowDef);

            case WeightedCriteriaDefinitionSO weightedDef:
                return new WeightedScoreCriteria(weightedDef);

            default:
                throw new Exception($"Unknown criteria type: {def.GetType().Name}");
        }
    }
}
