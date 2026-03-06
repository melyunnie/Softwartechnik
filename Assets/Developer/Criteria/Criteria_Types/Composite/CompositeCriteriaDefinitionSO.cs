using System.Collections.Generic;
using Achievements.Criteria;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/Criteria/Composite")]
public class CompositeCriteriaDefinitionSO : ScriptableObject, ICriteriaDefinition
{
    public string id;
    public string eventChannel;
    public CompositeType compositeType;
    public List<ScriptableObject> childCriteriaDefinitions = new List<ScriptableObject>();
}
