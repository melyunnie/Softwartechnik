using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopUp : AchievementToastNotifications
{
    [Header("----AchievementPopUp Components----")]
    [SerializeField] private Image _AchievementIcon;
    [SerializeField] private TMP_Text _AchievementNameText;

    public override void SetCompletedPopUp(AchievementsSO achievement)
    {
        _AchievementIcon.sprite = achievement.achievementSprite;
        _AchievementNameText.text = achievement.achievementName;

        if (!CheckAchievementOnList(achievement,_AchievementCompletedList) && !_DisturbModeActive)
            StartCoroutine(ShowPopUp());
        else if (_DisturbModeActive)
            Debug.Log("Disturb Mode Active");
    }
}
