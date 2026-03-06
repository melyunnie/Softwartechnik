using Achievements.Criteria;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/Criteria/Count")]
public class CountCriteriaDefinitionSO : ScriptableObject, ICriteriaDefinition
{
    public string id;
    public string eventChannel;
    public int targetValue;
    public ComparisonType comparisonType;
}
