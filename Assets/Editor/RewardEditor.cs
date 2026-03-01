
using System.ComponentModel;
using System.Security.Policy;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using static RewardManager;

[CustomEditor(typeof(RewardManager))]

public class RewardEditor : Editor
{
    #region SerilazedProperty
 
   SerializedProperty rewardsProp;
    #endregion
    //?????????????????-> muss nochmal schauen wie ich das machen kann
    #region Uservariables
    //Note:for declearing int values

    //name of the Script Intvalue

    //your int value needts to be public to be used



    #endregion

    #region Examples of Uservariables
    CurrencyValueTextExample Intvalue;

    #endregion
    //?????????????????
    public void OnEnable()
    {
        
        
            rewardsProp = serializedObject.FindProperty("rewards");
        


    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
       
        //event binding?
        
        if (GUILayout.Button("Add Reward"))
        {
            rewardsProp.arraySize++;
        }
        
        for (int i = 0; i < rewardsProp.arraySize; i++)
        {
            SerializedProperty reward = rewardsProp.GetArrayElementAtIndex(i);

            SerializedProperty type = reward.FindPropertyRelative("typeofReward");
            SerializedProperty amount = reward.FindPropertyRelative("amount");
            SerializedProperty prefab = reward.FindPropertyRelative("prefab");
            SerializedProperty yourIntValue = reward.FindPropertyRelative("yourIntValue");
            SerializedProperty fontsize = reward.FindPropertyRelative("fontsize");
            SerializedProperty text = reward.FindPropertyRelative("text");
            SerializedProperty PlaceToStoreReward = reward.FindPropertyRelative("PlaceToStoreReward");
            EditorGUILayout.PropertyField(type);

            RewardManager.TypeofReward enumValue =
                (RewardManager.TypeofReward)type.enumValueIndex;

            switch (enumValue)
            {
                case RewardManager.TypeofReward.Currency:
                case RewardManager.TypeofReward.XP:
                case RewardManager.TypeofReward.Achivemnetpoints:
                    EditorGUILayout.PropertyField(amount); EditorGUILayout.PropertyField(yourIntValue);
                    break;

                case RewardManager.TypeofReward.Items:
                case RewardManager.TypeofReward.Cosmetics:
                case RewardManager.TypeofReward.UIOverlay:
                case RewardManager.TypeofReward.Picture:
                    EditorGUILayout.PropertyField(prefab); EditorGUILayout.PropertyField(PlaceToStoreReward);
                    break;

                case RewardManager.TypeofReward.Titles:
                    EditorGUILayout.PropertyField(fontsize);
                    EditorGUILayout.PropertyField(text, GUILayout.Height(80)); EditorGUILayout.PropertyField(PlaceToStoreReward);
                    break;
            }

            EditorGUILayout.Space();
        }
        if (GUILayout.Button("remove Reward")&& rewardsProp.arraySize!=0)
        {
            rewardsProp.arraySize--;
        }
        

        serializedObject.ApplyModifiedProperties();
    }
}


