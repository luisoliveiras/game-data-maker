using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameDataMakerWindow : EditorWindow
{
    static GameDataConfig config;

    string _folder;
    string _fileName;
    string _extension;


    [MenuItem("Tools/Game Data Maker")]
    public static void StartWindow()
    {
        config = Resources.Load("SaveConfig") as GameDataConfig;
        if (config == null)
        {
            config = CreateInstance<GameDataConfig>();
            AssetDatabase.CreateAsset(config, "Assets/Resources/SaveConfig.asset");
        }

        GameDataMakerWindow window = GetWindow<GameDataMakerWindow>(false, "Game Data Maker");
        window._folder = config.Folder;
        window._fileName = config.FileName;
        window._extension = config.Extension;
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Save Options");
        EditorGUILayout.Space();
        _folder = EditorGUILayout.TextField("Folder", _folder);
        _fileName = EditorGUILayout.TextField("File Name", _fileName);
        _extension = EditorGUILayout.TextField("Extension", _extension);


        EditorGUILayout.Space();
        if (GUILayout.Button("Save"))
        {
            config.Setup(_folder, _fileName, _extension);
            Selection.activeObject = config;
            AssetDatabase.SaveAssets();
        }
    }
}
