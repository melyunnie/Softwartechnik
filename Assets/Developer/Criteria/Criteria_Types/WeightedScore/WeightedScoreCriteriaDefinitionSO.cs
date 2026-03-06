using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievements/Criteria/WeightedScore")]
public class WeightedCriteriaDefinitionSO : ScriptableObject, ICriteriaDefinition
{
    public string id;

    public int targetScore;

    public List<WeightedEvent> weightedEvents = new();
}


[Serializable]
public class WeightedEvent
{
    public string eventChannel;
    public int score;
}