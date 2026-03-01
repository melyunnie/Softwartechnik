using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayMode
{
    //private AchievementsSO GetAchievement()
    //{
    //    EventsController eventsController = GameObject.FindFirstObjectByType<EventsController>();

    //    //AchievementsSO achievement = eventsController.achievementsSO[0];

    //    //return achievement;
    //}

    //[UnityTest]
    //public IEnumerator Check_AddAchievementToLog()
    //{
    //    SceneManager.LoadScene("Demo");
    //    yield return new WaitForSeconds(1f);

    //    AchievementLogController achievementLogController = GameObject.FindFirstObjectByType<AchievementLogController>();
    //    AchievementsSO achievement = GetAchievement();

    //    achievementLogController.AddAchievementToLog(achievement);

    //    yield return null;

    //    Assert.IsTrue(UIAchievementController._AchievementList.Contains(achievement));
    //}

    //[UnityTest]
    //public IEnumerator Check_IF_AchievementSlotIsClicked()
    //{
    //    SceneManager.LoadScene("Demo");
    //    yield return new WaitForSeconds(1f);

    //    AchievementsSO achievement = GetAchievement();

    //    AchievementSlot achievementSlot = new GameObject().AddComponent<AchievementSlot>();

    //    achievementSlot.AddDataToAchievement(achievement);
    //    achievementSlot.OnClick();

    //    yield return null;

    //    Assert.AreEqual(achievementSlot.achievementDescriptionImage.sprite, achievementSlot.achievementSprite);

    //}
}
