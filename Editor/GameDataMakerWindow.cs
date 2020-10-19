using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameDataMakerWindow : EditorWindow
{
    static GameDataConfig config;
    static SerializedObject _serializedObject;

    [MenuItem("Tools/Game Data Maker")]
    public static void StartWindow()
    {
        config = Resources.Load("SaveConfig") as GameDataConfig;
        if (config == null)
        {
            config = CreateInstance<GameDataConfig>();
            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }
            AssetDatabase.CreateAsset(config, "Assets/Resources/SaveConfig.asset");
        }
        _serializedObject = new SerializedObject(config);
        GameDataMakerWindow window = GetWindow<GameDataMakerWindow>(false, "Game Data Maker");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Save Options");
        EditorGUILayout.Space();

        _serializedObject.Update();
        EditorGUILayout.PropertyField(_serializedObject.FindProperty("_saveItems"),true);
        _serializedObject.ApplyModifiedProperties();

        EditorGUILayout.Space();
        if (GUILayout.Button("Save Config"))
        {
            Selection.activeObject = config;
            AssetDatabase.SaveAssets();
        }
    }
}
