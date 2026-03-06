using System.Collections.Generic;

public static class AchievementFactory
{
    public static Achievement Create(AchievementDefinitionSO def)
    {
        List<ICriteria> runtimeCriteria = new();

        foreach (var cDef in def.criteriaDefinitions)
        {
            if (cDef is ICriteriaDefinition criteriaDef)
                runtimeCriteria.Add(CriteriaFactory.Create(criteriaDef));
        }

        return new Achievement(def, runtimeCriteria);
    }
}
