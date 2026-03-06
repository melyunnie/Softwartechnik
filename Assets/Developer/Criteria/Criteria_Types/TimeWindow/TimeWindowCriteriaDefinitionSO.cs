using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/Criteria/TimeWindow")]
public class TimeWindowCriteriaDefinitionSO : ScriptableObject, ICriteriaDefinition
{
    public string id;
    public string eventChannelStart;
    public string eventChannelEnd;
    public float targetTimeSeconds;
}
