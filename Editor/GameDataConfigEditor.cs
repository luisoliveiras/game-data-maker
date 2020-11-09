using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

namespace loophouse.GameDataMaker
{
    [CustomEditor(typeof(GameDataConfig))]
    public class GameDataConfigEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Use the \"Tools > Game Data Maker\" menu to edit the values.");
        }
    }
}