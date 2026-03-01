using UnityEngine;
using static UIAchievementController;

[CreateAssetMenu(fileName = "AchievementsSO", menuName = "Scriptable Objects/AchievementsSO")]
public class AchievementsSO : ScriptableObject
{
    public string achievementName;
    public Sprite achievementSprite;
    public status achievementStatus;
    public string achievementDescriptionCriterias;
    public string reward;

    public RarityEntry rarity;
    public CategoryEntry category;
    public VisibilityEntry visibility;
}