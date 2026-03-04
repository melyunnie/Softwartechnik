using System.Collections.Generic;
using UnityEngine;

public class UIAchievementController : MonoBehaviour
{
    protected EventsController eventsController;

    [HideInInspector] public List<AchievementSlot> _AchievementSlotList = new List<AchievementSlot>();
    [HideInInspector] public static List<AchievementsSO> _AchievementList = new List<AchievementsSO>();
    public static List<AchievementsSO> _AchievementCompletedList = new List<AchievementsSO>();

    private void Start()  
    {
        eventsController = EventsController.eventsController;

        eventsController.onAchievementAdd += AddAchievementToLog;
        eventsController.onAchievementCompleted += UpdateAchievementCompleted;
        eventsController.onAchievementCriteriaFilled += UpdateProgressAchievement;
        eventsController.onOpenLogController += ShowLogController;

    }

    public virtual void ShowLogController(bool status) {}

    public virtual void AddAchievementToLog(AchievementsSO achievementSO) {}

    public virtual void UpdateAchievementCompleted(AchievementsSO achievement)  {}

    public virtual void UpdateProgressAchievement(AchievementsSO achievement) {}

    public AchievementsSO CheckAchievementOnList(AchievementsSO achievement,List<AchievementsSO> achievementList)
    {
        if (achievementList.Contains(achievement))
            return achievement;

        return null;
    }

    public enum status
    {
        Completed,
        Blocked
    }
}
