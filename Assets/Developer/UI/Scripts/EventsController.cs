using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsController : MonoBehaviour
{
    public static EventsController eventsController;

    public event Action<AchievementsSO> onAchievementAdd;
    public event Action<AchievementsSO> onAchievementCompleted;
    public event Action<AchievementsSO> onAchievementCriteriaFilled;
    public event Action onOpenLogController;

    public List<AchievementsSO> achievementsSO;

    public int achievementCount = 0;

    private Dictionary<KeyCode, Action> _KeyInputs;

    [SerializeField] private KeyCode _KeyToOpenLog = KeyCode.Escape;
    [SerializeField] private KeyCode _CompletedAchievement = KeyCode.A;
    [SerializeField] private KeyCode _CriteriaFilledAchievement = KeyCode.D;
    [SerializeField] private KeyCode _AddAchievement = KeyCode.Space;

    private void Awake()
    {
        eventsController = this;
    }

    private void Start()
    {
        _KeyInputs = new()
        {
            {_AddAchievement, () => AchievementIsAdd(achievementsSO[achievementCount])},
            {_CompletedAchievement, () => AchievementCompleted(achievementsSO[achievementCount])},
            {_CriteriaFilledAchievement, () => AchievementCriteriaFilled(achievementsSO[achievementCount])},
            {_KeyToOpenLog, OpenLogController},
        };
    }

    private void Update()
    {
        CheckKeyInput(_KeyToOpenLog);
        CheckKeyInput(_CompletedAchievement);
        CheckKeyInput(_CriteriaFilledAchievement);
        CheckKeyInput(_AddAchievement);
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

    public void OpenLogController()
    {
        if (onOpenLogController != null)
            onOpenLogController();
    }

    private void CheckKeyInput(KeyCode key)
    {
        if (Input.GetKeyDown(key) && _KeyInputs.ContainsKey(key))
        {
            _KeyInputs[key].Invoke();
        }
    }
}
