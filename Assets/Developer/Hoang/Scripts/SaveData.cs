using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int progress = 0;

    public List<string> rewards = new List<string>();
    public List<string> rewardHistory = new List<string>();

    public List<string> criterias = new List<string>();
}