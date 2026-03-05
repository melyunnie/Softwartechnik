using UnityEngine;
using System.Collections;
using System;

public class AchievementToastNotifications : UIAchievementController
{
    [Header("----AchievementPopUp Components----")]
    [SerializeField] protected CanvasGroup _AchievementPopUpCanvasGroup;

    [Header("----AchievementPopUp Variables----")]
    [SerializeField] protected static bool _DisturbModeActive;
    [SerializeField] protected float _PopUpDuration = 3f;

    public override void UpdateAchievementCompleted(AchievementsSO achievement)
    {
        if(CheckAchievementOnList(achievement, _AchievementList))
        {
            SetCompletedPopUp(achievement);
            return;
        }

        Debug.Log("Achievement not found in log");
    }

    public override void UpdateProgressAchievement(AchievementsSO achievement)
    {
        if (CheckAchievementOnList(achievement, _AchievementList))
        {
            SetProgressPopUP(achievement);
            return;
        }

        Debug.Log("Achievement not found in log");
    }

    public virtual void SetCompletedPopUp(AchievementsSO achievement) {}

    public virtual void SetProgressPopUP(AchievementsSO achievement) {}

    protected IEnumerator ShowPopUp()
    {
        _AchievementPopUpCanvasGroup.alpha = 1;

        yield return new WaitForSeconds(_PopUpDuration);
        _AchievementPopUpCanvasGroup.alpha = 0;
    }
}
