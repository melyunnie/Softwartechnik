using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public enum TypeofReward {None,Currency,XP,Achivemnetpoints,Items,Cosmetics,UItheams,Picture, Titles}
    [SerializeField] public TypeofReward typeofReward;
    [SerializeField] public float amount;
    [SerializeField] public GameObject prefab;
    [SerializeField] public string text;
    [SerializeField] public float fontsize;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //name reward:
         //(int)currency/level-> how much
        // object/gameobject
        //images
        //strings

    //number of rewarts-> + add more

    //einzelne reward nur einmal oder mehrmals?

}
