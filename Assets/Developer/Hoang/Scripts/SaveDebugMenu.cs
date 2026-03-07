using UnityEngine;

public class SaveDebugMenu : MonoBehaviour
{
    public SaveManager save;

    void OnGUI()
    {
        float width = 320;
        float height = 1000;

        float x = Screen.width / 2 - width / 2;
        float y = Screen.height / 2 - height / 2;

        GUILayout.BeginArea(new Rect(x, y, width, height));

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 22;
        buttonStyle.fixedHeight = 60;

        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.fontSize = 24;
        labelStyle.alignment = TextAnchor.MiddleCenter;

        GUILayout.Label("SAVE SYSTEM DEBUG", labelStyle);

        GUILayout.Space(20);

        if (GUILayout.Button("Profile 1", buttonStyle))
        {
            save.SwitchProfile("Profile1");
        }

        if (GUILayout.Button("Profile 2", buttonStyle))
        {
            save.SwitchProfile("Profile2");
        }

        if (GUILayout.Button("Profile 3", buttonStyle))
        {
            save.SwitchProfile("Profile3");
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Add Progress", buttonStyle))
        {
            save.AddProgress();
        }

        if (GUILayout.Button("Add Reward", buttonStyle))
        {
            save.AddReward("Sword");
        }

        if (GUILayout.Button("Rollback Reward", buttonStyle))
        {
            save.RollbackReward();
        }

        if (GUILayout.Button("Complete Criteria", buttonStyle))
        {
            save.CompleteCriteria("Kill10Enemies");
        }

        if (GUILayout.Button("Reset Criterias", buttonStyle))
        {
            save.ResetCriterias();
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Print SaveData", buttonStyle))
        {
            save.PrintData();
        }

        if (GUILayout.Button("DELETE ALL SAVES", buttonStyle))
        {
            save.DeleteAllSaves();
        }

        GUILayout.Space(20);

        GUILayout.Label("Aktives Profil: " + save.activeProfile, labelStyle);
        GUILayout.Label("Progress: " + save.data.progress, labelStyle);

        GUILayout.EndArea();
    }
}