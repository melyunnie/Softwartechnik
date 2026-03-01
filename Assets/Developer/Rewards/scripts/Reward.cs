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
        {
            for ( i = 0; i < rewardManager.rewards.Count; i++)
            {
                {
                    if (rewardManager.rewards[i].typeofReward == TypeofReward.Currency)
                    { CurrencyReward();  }
                    if (rewardManager.rewards[i].typeofReward == TypeofReward.XP) { XpReward();  }
                    if (rewardManager.rewards[i].typeofReward == TypeofReward.Achivemnetpoints) { AchivementReward();  }
                    if (rewardManager.rewards[i].typeofReward == TypeofReward.Items || rewardManager.rewards[i].typeofReward == TypeofReward.Cosmetics|| rewardManager.rewards[i].typeofReward == TypeofReward.UIOverlay|| rewardManager.rewards[i].typeofReward == TypeofReward.Picture) { InstanziateGameobject(); }


                }
            }IsGetReward = false;  
        }
    }  
    void CurrencyReward()
    {
        int currencyAmount = rewardManager.rewards[i].amount;
        CurrencyValueTextExample CurrencyScript = rewardManager.rewards[i].yourIntValue.GetComponent<CurrencyValueTextExample>();
        int YourCurrency = CurrencyScript.Currency;
        CurrencyScript.Currency = currencyAmount + YourCurrency;

    }
    void XpReward()
    {
        int xpAmount = rewardManager.rewards[i].amount;
        XpValueTestExample XpScript = rewardManager.rewards[i].yourIntValue.GetComponent<XpValueTestExample>();
        int YourXp = XpScript.XP;
        XpScript.XP = xpAmount + YourXp;
    }
    void AchivementReward()
    {
        int AchivementAmount = rewardManager.rewards[i].amount;
        AchivementValueTestExample AchivementPointsScript = rewardManager.rewards[i].yourIntValue.GetComponent<AchivementValueTestExample>();
        int YourXp = AchivementPointsScript.points;
        AchivementPointsScript.points = AchivementAmount + YourXp;
    }
    void InstanziateGameobject() { Debug.Log("gameobject"+ i); GameObject InstantiatedGameObject = rewardManager.rewards[i].prefab;
        InstantiatedGameObject.transform.SetParent(rewardManager.rewards[i].PlaceToStoreReward);
    }     
}
