using UnityEngine;

public class Reward : MonoBehaviour,IRewardable
{

    public bool IsGetReward;
    public RewardManager rewardManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetReward();
    }
    public void GetReward()
    {
        if (IsGetReward == true)
        {
            int amount = rewardManager.rewards[0].amount;
           
            CurrencyValueTextExample Yourscript= rewardManager.rewards[0].yourIntValue.GetComponent<CurrencyValueTextExample>();
            int Yourvalue = Yourscript.Currency;
            Debug.Log(amount+ Yourvalue);
        }
    }
}
