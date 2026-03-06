using Achievements.Criteria;
using UnityEngine;
[CreateAssetMenu(menuName = "Achievements/Criteria/ValueThreshold")]
public class ValueThresholdCriteriaDefinitionSO : ScriptableObject, ICriteriaDefinition
{
    public string id;
    public string eventChannel;
    public float targetValue;
    public ComparisonType comparisonType;
}
