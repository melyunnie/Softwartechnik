using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Unity.PerformanceTesting;

public class PlayMode
{
    private AchievementsSO GetAchievement()
    {
        EventsController eventsController = GameObject.FindFirstObjectByType<EventsController>();

        AchievementsSO achievement = eventsController.achievementsSO[0];

        return achievement;
    }

    [UnityTest, Performance]
    public IEnumerator Check_AddAchievementToLog()
    {
        SceneManager.LoadScene("DemoScene");
        yield return new WaitForSeconds(1f);

        AchievementLogController achievementLogController = GameObject.FindFirstObjectByType<AchievementLogController>();
        AchievementsSO achievement = GetAchievement();

        achievementLogController.AddAchievementToLog(achievement);

        yield return null;

        Assert.IsTrue(UIAchievementController._AchievementList.Contains(achievement));

        Measure.Method(() =>
        {
            Check_AddAchievementToLog();
        }).WarmupCount(10).MeasurementCount(30).Run();
    }

    [UnityTest]
    public IEnumerator Check_UpdateProgressAchievement()
    {
        SceneManager.LoadScene("DemoScene");
        yield return new WaitForSeconds(1f);


        yield return null;

    }

    [UnityTest, Performance]
    public IEnumerator Check_IF_AchievementIsCompleted()
    {
        SceneManager.LoadScene("DemoScene");
        yield return new WaitForSeconds(1f);

        AchievementsSO achievement = GetAchievement();

        UIAchievementController UIAchievementController = new GameObject().AddComponent<UIAchievementController>();

        float achievementID = achievement.GetInstanceID();

        if (achievementID == achievement.GetInstanceID() && !UIAchievementController.CheckAchievementOnList(achievement, UIAchievementController._AchievementCompletedList))
        {
            Debug.Log("Achievement Completed");
        }

        yield return null;

        LogAssert.Expect(LogType.Log, "Achievement Completed");

        Measure.Method(() =>
        {
            Check_IF_AchievementIsCompleted();
        }).WarmupCount(10).MeasurementCount(30).Run();
    }
}
