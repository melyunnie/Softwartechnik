using UnityEngine;
using UnityEngine.InputSystem;

public class RewardTestAchivement : MonoBehaviour
{
    public Reward reward;
    int buttoncount;
    public int maxCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && buttoncount < maxCount) { buttoncount++; }
        if (buttoncount == maxCount) {reward.IsGetReward = true; buttoncount=0; }
    }
}
