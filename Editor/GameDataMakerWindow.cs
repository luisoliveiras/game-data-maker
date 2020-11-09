using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace loophouse.GameDataMaker
{
    public class GameDataMakerWindow : EditorWindow
    {
        static GameDataConfig _config;
        static SerializedObject _serializedObject;

        [MenuItem("Tools/Game Data Maker")]
        public static void StartWindow()
        {
            LoadConfig();
            GetWindow<GameDataMakerWindow>(false, "Game Data Maker");
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Save Options");
            EditorGUILayout.Space();

            _serializedObject.Update();
            EditorGUILayout.PropertyField(_serializedObject.FindProperty("_showLogs"), true);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(_serializedObject.FindProperty("_gameDataItems"), true);
            _serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();
            if (GUILayout.Button("Save Config"))
            {
                Selection.activeObject = _config;
                AssetDatabase.SaveAssets();
            }
        }

        private void OnEnable()
        {
            LoadConfig();
            Repaint();
        }

        private static void LoadConfig()
        {
            _config = Resources.Load("SaveConfig") as GameDataConfig;
            if (_config == null)
            {
                _config = CreateInstance<GameDataConfig>();
                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }
                AssetDatabase.CreateAsset(_config, "Assets/Resources/SaveConfig.asset");
            }
            _serializedObject = new SerializedObject(_config);
        }
    }
}