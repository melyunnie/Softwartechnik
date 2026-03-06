using System.Collections.Generic;
using UnityEngine;
using Achievements.Criteria;

[CreateAssetMenu(menuName = "Achievements/Achievement")]
public class AchievementDefinitionSO : ScriptableObject
{
    public string id;
    public string title;
    [TextArea] public string description;

    public List<ScriptableObject> criteriaDefinitions = new List<ScriptableObject>();
    public List<ScriptableObject> requiredAchievements = new List<ScriptableObject>();

    public bool repeatable;
    public float cooldownSeconds;
    public ScopeType scope;
}
