
using System.ComponentModel;
using System.Security.Policy;
using TMPro;
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
    public void OnEnable()
    {
            rewardsProp = serializedObject.FindProperty("rewards");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        if (GUILayout.Button("Add Reward"))
        {
            rewardsProp.arraySize++;
        }
        
        for (int i = 0; i < rewardsProp.arraySize; i++)
        {
            //you can add your new value in here:  SerializedProperty NameofYourValue = reward.FindPropertyRelative("NameofYourValue");
            SerializedProperty reward = rewardsProp.GetArrayElementAtIndex(i);

            SerializedProperty type = reward.FindPropertyRelative("typeofReward");
            SerializedProperty amount = reward.FindPropertyRelative("amount");
            SerializedProperty yourIntValue = reward.FindPropertyRelative("yourIntValue");

            SerializedProperty prefab = reward.FindPropertyRelative("prefab");
            SerializedProperty PlaceToStoreReward = reward.FindPropertyRelative("PlaceToStoreReward");
            
            SerializedProperty fontsize = reward.FindPropertyRelative("fontsize");
            SerializedProperty text = reward.FindPropertyRelative("text");
            SerializedProperty fontAsset = reward.FindPropertyRelative("fontAsset");
            SerializedProperty Textcolor = reward.FindPropertyRelative("Textcolor");
            SerializedProperty YourTextbox= reward.FindPropertyRelative("YourTextbox");
            EditorGUILayout.PropertyField(type);

            RewardManager.TypeofReward enumValue =
                (RewardManager.TypeofReward)type.enumValueIndex;

            switch (enumValue)
            {
                //add your value and or type to the switch like:case RewardManager.TypeofReward.NameofYournew Type: EditorGUILayout.PropertyField(NameofYourValue); break;
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
                    EditorGUILayout.PropertyField(fontsize); EditorGUILayout.PropertyField(fontAsset); EditorGUILayout.PropertyField(Textcolor); 
                    EditorGUILayout.PropertyField(text, GUILayout.Height(80)); EditorGUILayout.PropertyField(YourTextbox);
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


