using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public SaveData data = new SaveData();

    public string activeProfile = "Profile1"; // aktuelles Profil

    // Key für PlayerPrefs
    private string SaveKey()
    {
        return "SAVE_" + activeProfile;
    }

    void Start()
    {
        Load();
        Debug.Log("Aktives Profil: " + activeProfile);
    }

    // ---------------- SAVE ----------------
    public void Save()
    {
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(SaveKey(), json);
        PlayerPrefs.SetString(SaveKey() + "_backup", json);

        PlayerPrefs.Save();

        Debug.Log("Game gespeichert für Profil: " + activeProfile);
    }

    // ---------------- LOAD ----------------
    public void Load()
    {
        if (PlayerPrefs.HasKey(SaveKey()))
        {
            string json = PlayerPrefs.GetString(SaveKey());
            data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Save geladen für Profil: " + activeProfile);
        }
        else if (PlayerPrefs.HasKey(SaveKey() + "_backup"))
        {
            string json = PlayerPrefs.GetString(SaveKey() + "_backup");
            data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Backup geladen für Profil: " + activeProfile);
        }
        else
        {
            data = new SaveData();
            Debug.Log("Neuer Save erstellt für Profil: " + activeProfile);
        }
    }

    // ---------------- PROFILE ----------------
    public void SwitchProfile(string profile)
    {
        Save(); // vorheriges Profil sichern

        activeProfile = profile;

        Load();

        Debug.Log("Profil gewechselt zu: " + activeProfile);
    }

    // ---------------- REWARDS ----------------
    public void AddReward(string reward)
    {
        data.rewards.Add(reward);
        data.rewardHistory.Add(reward);

        Save();

        Debug.Log("Reward hinzugefügt: " + reward);
    }

    public void RollbackReward()
    {
        if (data.rewardHistory.Count > 0)
        {
            string last = data.rewardHistory[data.rewardHistory.Count - 1];

            data.rewards.Remove(last);
            data.rewardHistory.RemoveAt(data.rewardHistory.Count - 1);

            Save();

            Debug.Log("Rollback Reward: " + last);
        }
    }

    // ---------------- CRITERIAS ----------------
    public void CompleteCriteria(string c)
    {
        if (!data.criterias.Contains(c))
        {
            data.criterias.Add(c);
        }

        Save();

        Debug.Log("Criteria erfüllt: " + c);
    }

    public void ResetCriterias()
    {
        data.criterias.Clear();

        Save();

        Debug.Log("Criterias wurden zurückgesetzt");
    }

    // ---------------- PROGRESS ----------------
    public void AddProgress()
    {
        data.progress++;

        Save();

        Debug.Log("Progress: " + data.progress + " | Profil: " + activeProfile);
    }

    // ---------------- PRINT ----------------
    public void PrintData()
    {
        Debug.Log("Profil: " + activeProfile + " | SaveData: " + JsonUtility.ToJson(data));
    }

    // ---------------- DELETE ALL SAVES ----------------
    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();

        data = new SaveData();

        Debug.Log("ALLE SAVES GELÖSCHT");
    }
}