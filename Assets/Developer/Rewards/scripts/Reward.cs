using UnityEngine;
using static RewardManager;

public class Reward : MonoBehaviour,IRewardable
{

    public bool IsGetReward;
    public RewardManager rewardManager;

    void Start()
    {
        
    }
    void Update()
    {
        
        GetReward();
    }
    public void GetReward()
    {
        if (IsGetReward == true &&   rewardManager.rewards != null )
        {
            if (rewardManager.rewards[0].typeofReward == TypeofReward.Currency)
            { CurrencyReward(); IsGetReward = false; }
            if (rewardManager.rewards[1].typeofReward == TypeofReward.XP) { XpReward(); IsGetReward = false; }
            if (rewardManager.rewards[2].typeofReward == TypeofReward.Achivemnetpoints) { AchivementReward(); IsGetReward = false; }

            
        }
    }
    void CurrencyReward() 
    {

        int currencyAmount = rewardManager.rewards[0].amount;

        CurrencyValueTextExample CurrencyScript = rewardManager.rewards[0].yourIntValue.GetComponent<CurrencyValueTextExample>();
        int YourCurrency = CurrencyScript.Currency;
       
        CurrencyScript.Currency = currencyAmount + YourCurrency;
       
    }
    void XpReward() 
    {
        int xpAmount = rewardManager.rewards[1].amount;
        XpValueTestExample XpScript = rewardManager.rewards[1].yourIntValue.GetComponent<XpValueTestExample>();
        int YourXp= XpScript.XP;
        
        XpScript.XP = xpAmount + YourXp;
    }
    void AchivementReward() 
    {
        int AchivementAmount = rewardManager.rewards[2].amount;
        AchivementValueTestExample AchivementPointsScript = rewardManager.rewards[2].yourIntValue.GetComponent<AchivementValueTestExample>();
        int YourXp = AchivementPointsScript.points;

        AchivementPointsScript.points = AchivementAmount + YourXp;
    }

}
