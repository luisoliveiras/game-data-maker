using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Save Manager Config", fileName ="SaveConfig")]
public class GameDataConfig : ScriptableObject
{
    [SerializeField] private List<GameDataItem> _gameDataItems;

    public List<GameDataItem> GameDataItems { get => _gameDataItems; }

    public string GetDataItemPath(string item)
    {
        GameDataItem gameDataItem = _gameDataItems.Find(p => p.name == item);
        return gameDataItem.path.ToString();
    }

    public string GetDataItemFolderPath(string item)
    {
        GameDataItem gameDataItem = _gameDataItems.Find(p => p.name == item);
        if (string.IsNullOrEmpty(gameDataItem.path.folder))
        {
            return "";
        }
        else
        {
            return Path.Combine(Application.persistentDataPath, gameDataItem.path.folder);
        }
    }
}

[System.Serializable]
public struct GameDataItem
{
    public string name;
    public CustomPath path;
}