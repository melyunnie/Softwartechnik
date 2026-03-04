using System;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    public static EventsController eventsController;

    public event Action<AchievementsSO> onAchievementAdd;
    public event Action<AchievementsSO> onAchievementCompleted;
    public event Action<AchievementsSO> onAchievementCriteriaFilled;
    public event Action<bool> onOpenLogController;

    public List<AchievementsSO> achievementsSO;

    private bool status;
    public int achievementC = 0;

    [SerializeField] private KeyCode _KeyToOpenLog = KeyCode.Escape;

    private void Awake()
    {
        eventsController = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AchievementIsAdd(achievementsSO[achievementC]);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AchievementCompleted(achievementsSO[achievementC]);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AchievementCriteriaFilled(achievementsSO[achievementC]);
        }

        if (Input.GetKeyDown(_KeyToOpenLog))
        {
            status = !status;
            OpenLogController(status);
        }
    }

    public void AchievementIsAdd(AchievementsSO achievementsSO)
    {
        if (onAchievementAdd != null)
            onAchievementAdd(achievementsSO);
    }

    public void AchievementCompleted(AchievementsSO achievement)
    {
        if (onAchievementCompleted != null)
            onAchievementCompleted(achievement);
    }

    public void AchievementCriteriaFilled(AchievementsSO achievement)
    {
        if (onAchievementCriteriaFilled != null)
            onAchievementCriteriaFilled(achievement);
    }

    public void OpenLogController(bool status)
    {
        if (onOpenLogController != null)
            onOpenLogController(status);
    }
}
