using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementLogController : UIAchievementController
{  
    [Header("---Achievement Log Components----")]
    [SerializeField] protected Transform _AchievementLog;
    [SerializeField] public GameObject _AchievementLotPrefab;
    [SerializeField] protected Sprite _Test;

    [Header("---Achievement Description Components----")]
    public Image achievementDescriptionImage;
    public TMP_Text achievementDescriptionName;
    [SerializeField] protected TMP_Text _AchievementDescriptionCriterias;
    [SerializeField] protected Slider _AchievementDescriptionProgressBar;
    [SerializeField] protected TMP_Text _AchievementDescriptionProgress;
    public TMP_Text achievementDescriptionReward;

    public override void ShowLogController(bool status)
    {
        if (status)
            GetComponent<CanvasGroup>().alpha = 1;
        else
            GetComponent<CanvasGroup>().alpha = 0;
    }

    public override void AddAchievementToLog(AchievementsSO achievementsSO)
    {
        if (CheckAchievementOnList(achievementsSO,_AchievementList))
        {
            Debug.Log("This achievement has been already added");
            return;
        }

        _AchievementList.Add(achievementsSO);

        GameObject achievement = Instantiate(_AchievementLotPrefab);
        achievement.transform.SetParent(_AchievementLog);

        AchievementSlot achievementSlot = achievement.GetComponent<AchievementSlot>();
        _AchievementSlotList.Add(achievementSlot);

        achievementSlot.AddDataToAchievement(achievementsSO);
        achievementSlot.AddDescriptionComponents(achievementDescriptionImage, achievementDescriptionName, _AchievementDescriptionCriterias, _AchievementDescriptionProgressBar, _AchievementDescriptionProgress, achievementDescriptionReward, _AchievementSlotList);

        Debug.Log("Achievement Added to Log");
    }

    public override void UpdateProgressAchievement(AchievementsSO achievementsSO)
    {

    }

    public override void UpdateAchievementCompleted(AchievementsSO achievementsSO)
    {
        for (int slot = 0; slot < _AchievementSlotList.Count; slot++)
        {
            if (_AchievementSlotList[slot]._AchievementID == achievementsSO.GetInstanceID() && !CheckAchievementOnList(achievementsSO, _AchievementCompletedList))
            {
                achievementsSO.achievementStatus = status.Completed;

                _AchievementCompletedList.Add(achievementsSO);

                _AchievementSlotList[slot].CheckAchievementStatus(achievementsSO);
                Debug.Log("Achievement Completed");
            }
        }    
    }
}
