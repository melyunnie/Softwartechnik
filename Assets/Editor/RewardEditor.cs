
using System.Security.Policy;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(RewardManager))]

public class RewardEditor : Editor
{
    #region SerilazedProperty
    SerializedProperty typeofReward;
    SerializedProperty amount;
    SerializedProperty prefab;

    SerializedProperty text;
    SerializedProperty fontsize;

    bool Isnew=false;
    #endregion
    private void OnEnable()
    {
        typeofReward = serializedObject.FindProperty("typeofReward");
        amount = serializedObject.FindProperty("amount");
        prefab = serializedObject.FindProperty("prefab");
        text = serializedObject.FindProperty("text");
        fontsize = serializedObject.FindProperty("fontsize");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //add new rewards
        //eimnalige rewards
        //event binding?
        EditorGUILayout.PropertyField(typeofReward);
        RewardManager _rewardManager = (RewardManager)target;
       

        if (_rewardManager.typeofReward == RewardManager.TypeofReward.Currency)
        { EditorGUILayout.PropertyField(amount); }
        if (_rewardManager.typeofReward == RewardManager.TypeofReward.XP)
        { EditorGUILayout.PropertyField(amount); }
        if (_rewardManager.typeofReward == RewardManager.TypeofReward.Achivemnetpoints)
        { EditorGUILayout.PropertyField(amount); }
        if (_rewardManager.typeofReward == RewardManager.TypeofReward.Items)
        { EditorGUILayout.ObjectField(prefab); }
        if (_rewardManager.typeofReward == RewardManager.TypeofReward.Cosmetics)
        {EditorGUILayout.ObjectField(prefab);}
        if (_rewardManager.typeofReward == RewardManager.TypeofReward.UItheams)
          { EditorGUILayout.ObjectField(prefab);}
        if (_rewardManager.typeofReward == RewardManager.TypeofReward.Picture)
        { EditorGUILayout.ObjectField(prefab); }
        if (_rewardManager.typeofReward == RewardManager.TypeofReward.Titles)
        {EditorGUILayout.PropertyField(fontsize);
         EditorGUILayout.PropertyField(text, GUILayout.Height(80));
            //customfond
        }

        serializedObject.ApplyModifiedProperties();
    }
}


