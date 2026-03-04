                                              using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public enum TypeofReward {None,Currency,XP,Achivemnetpoints,Items,Cosmetics,UIOverlay,Picture, Titles}
    [System.Serializable]
    //for more type add them in TypeofReward 
    // for a new variable add them in the Reward class, they need to be public
    // have you set it up go to the RewardEditor in the Editor Folder script, than to the Reward Script
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
    

    public List<Reward> rewards = new List<Reward>();
    public bool GetsReward;

}
