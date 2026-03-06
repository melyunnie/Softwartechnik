using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/Criteria/Sequence")]
public class SequenceCriteriaDefinitionSO : ScriptableObject, ICriteriaDefinition
{
    public string id;
    public string eventChannel;
    public List<ScriptableObject> stepDefinitions = new List<ScriptableObject>();
}
