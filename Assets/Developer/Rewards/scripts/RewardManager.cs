using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public enum TypeofReward {None,Currency,XP,Achivemnetpoints,Items,Cosmetics,UIOverlay,Picture, Titles}
    [System.Serializable]
    public class Reward
    {
        public TypeofReward typeofReward;
        public int amount;
        public GameObject yourIntValue;
        public GameObject prefab;
        public int fontsize;
        public string text;
         public Transform PlaceToStoreReward;
    }
  

    public List<Reward> rewards = new List<Reward>();
    public bool GetsReward;

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
