using System;
using UnityEngine;

[Serializable]
public class VisibilityEntry
{
    public visibility achievementVisibility;
    public string achievementSecretName;
    public string achievementSecretReward;
    public Color achievementSecretColor;

    public enum visibility
    {
        Public,
        Hidden,
        Secret
    }
}
