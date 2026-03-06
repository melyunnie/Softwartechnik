using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/Criteria/Boolean")]
public class BooleanCriteriaDefinitionSO : ScriptableObject, ICriteriaDefinition
{
    public string id;
    public string eventChannel;
}
