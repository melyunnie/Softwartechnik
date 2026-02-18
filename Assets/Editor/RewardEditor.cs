
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(RewardManager))]
public class RewardEditor : Editor
{
    #region SerilazedProperty
    SerializedProperty typeofReward;
    SerializedProperty currenzy;
    SerializedProperty xp;
    SerializedProperty achivemnetpoints;
    SerializedProperty intemGrants;
    SerializedProperty customisation;
    #endregion
    private void OnEnable()
    {
        typeofReward = serializedObject.FindProperty("typeofReward");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(typeofReward);
        serializedObject.ApplyModifiedProperties();
    }
}
