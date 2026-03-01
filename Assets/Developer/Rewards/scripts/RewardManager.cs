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
         public Transform PlaceToStoreReward;

        public int fontsize;
        public TMP_FontAsset fontAsset;
       
        public Color Textcolor;
        public string text;
        public TMP_Text YourTextbox;
        
       
    }
    //rewards nur einmal oder mehrmals

    public List<Reward> rewards = new List<Reward>();
    public bool GetsReward;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

}
