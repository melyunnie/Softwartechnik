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
        if (IsGetReward == true&& rewardManager.rewards[0]!=null)
        {
            switch (rewardManager.rewards[0].typeofReward)
            {
                case TypeofReward.Currency:
                    CurrencyReward();
                    break;
                case TypeofReward.XP:
                    XpReward();
                    break;
                case TypeofReward.Achivemnetpoints:
                    AchivementReward();
                    break;

            }
            IsGetReward = false;
        }
    }
    void CurrencyReward() 
    {
        int currencyAmount = rewardManager.rewards[0].amount;

        CurrencyValueTextExample CurrencyScript = rewardManager.rewards[0].yourIntValue.GetComponent<CurrencyValueTextExample>();
        int YourCurrency = CurrencyScript.Currency;
        Debug.Log(currencyAmount + YourCurrency);
        CurrencyScript.Currency = currencyAmount + YourCurrency;
       
    }
    void XpReward() 
    {
        int xpAmount = rewardManager.rewards[0].amount;
    }
    void AchivementReward() 
    {
        int AchivementAmount = rewardManager.rewards[0].amount;
    }

}
