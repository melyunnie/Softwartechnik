using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementProgressionUI : AchievementToastNotifications
{
    [Header("----AchievementPopUp Components")]
    [SerializeField] private TMP_Text _AchievementNameText;
    [SerializeField] private TMP_Text _AchievementCriteriaText;
    [SerializeField] private Slider _AchievementProgressBar;
    [SerializeField] private TMP_Text _AchievementProgressText;

    public override void SetPopUp(AchievementsSO achievement)
    {
        _AchievementNameText.text = achievement.achievementName;
        _AchievementCriteriaText.text = achievement.achievementDescriptionCriterias;

        if (!_DisturbModeActive && !CheckAchievementOnList(achievement, _AchievementCompletedList))
            StartCoroutine(ShowPopUp());
        else if (_DisturbModeActive)
            Debug.Log("Disturb Mode Active");
    }
}
