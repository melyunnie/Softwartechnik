using TMPro;
using UnityEditor;
using UnityEngine;
using static RewardManager;

public class Reward : MonoBehaviour,IRewardable
{

    public bool IsGetReward;
    public RewardManager rewardManager;
    int i;
    
    void Start()
    {
        
    }
    void Update()
    {
        GetReward();
    }
    public void GetReward()
    {
        if (IsGetReward == true && rewardManager.rewards != null)
        { Debug.Log("player gets reward");
            for ( i = 0; i < rewardManager.rewards.Count; i++)
            {
                { // to use your new types use: if (rewardManager.rewards[i].typeofReward == TypeofReward.YouyNewTYype { yourenewTypeMechanik()}
                        //yourenewTypeMechanik(): should contains what should happen when the player reseves your new rewardtype

                  
                    if (rewardManager.rewards[i].typeofReward == TypeofReward.Currency) { CurrencyReward();  }
                    if (rewardManager.rewards[i].typeofReward == TypeofReward.XP) { XpReward();  }
                    if (rewardManager.rewards[i].typeofReward == TypeofReward.Achivemnetpoints) { AchivementReward();  }

                    if (rewardManager.rewards[i].typeofReward == TypeofReward.Items || rewardManager.rewards[i].typeofReward == TypeofReward.Cosmetics
                        || rewardManager.rewards[i].typeofReward == TypeofReward.UIOverlay|| rewardManager.rewards[i].typeofReward == TypeofReward.Picture) 
                        { 
                        InstanziateGameobject();
                        }

                    if (rewardManager.rewards[i].typeofReward == TypeofReward.Titles)
                    { TextReward(); }
                   
                }
            } IsGetReward = false; Debug.Log("player should have reward now");
        }
    }  
    
    void CurrencyReward()
    {
        int currencyAmount = rewardManager.rewards[i].amount;
        CurrencyValueTextExample CurrencyScript = rewardManager.rewards[i].yourIntValue.GetComponent<CurrencyValueTextExample>();
        int YourCurrency = CurrencyScript.Currency;
        CurrencyScript.Currency = currencyAmount + YourCurrency;
        Debug.Log("curency reward:"+ currencyAmount + YourCurrency);
    }
    void XpReward()
    {
        int xpAmount = rewardManager.rewards[i].amount;
        XpValueTestExample XpScript = rewardManager.rewards[i].yourIntValue.GetComponent<XpValueTestExample>();
        int YourXp = XpScript.XP;
        XpScript.XP = xpAmount + YourXp;
        Debug.Log("xp reward:" + xpAmount + YourXp);
    }
    void AchivementReward()
    {
        int AchivementAmount = rewardManager.rewards[i].amount;
        AchivementValueTestExample AchivementPointsScript = rewardManager.rewards[i].yourIntValue.GetComponent<AchivementValueTestExample>();
        int YourPoints = AchivementPointsScript.points;
        AchivementPointsScript.points = AchivementAmount + YourPoints;
        Debug.Log("achivementpoints reward:" + AchivementAmount + YourPoints);
    }
    void InstanziateGameobject() 
    {  
        GameObject InstantiatedGameObject = rewardManager.rewards[i].prefab;
        Instantiate(InstantiatedGameObject).transform.SetParent(rewardManager.rewards[i].PlaceToStoreReward);
        Debug.Log(InstantiatedGameObject+"stored in"+ rewardManager.rewards[i].PlaceToStoreReward);
    }
    void TextReward()
    {
        Debug.Log("Text" + i);
        string RewardText = rewardManager.rewards[i].text;
        TMP_Text YourTextBox = rewardManager.rewards[i].YourTextbox;
        int fontsize = rewardManager.rewards[i].fontsize;
        Color Textcolor = rewardManager.rewards[i].Textcolor;

       TMP_FontAsset fontasset= rewardManager.rewards[i].fontAsset;
        YourTextBox.fontSize = fontsize;
        YourTextBox.text = RewardText;
        YourTextBox.color = Textcolor;
        YourTextBox.font = fontasset;
        Debug.Log("text in textbox"+ YourTextBox+"changed to "+ RewardText);
    }
}
