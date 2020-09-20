using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Save Manager Config", fileName ="SaveConfig")]
public class GameDataConfig : ScriptableObject
{
    [HideInInspector] [SerializeField] private string _folder;
    [HideInInspector] [SerializeField] private string _fileName;
    [HideInInspector] [SerializeField] private string _extension;

    public string Folder { get => _folder; }
    public string FileName { get => _fileName; }
    public string Extension { get => _extension; }

    public string FilePath
    {
        get
        {
            string fullFileName = string.Concat(_fileName, ".", _extension);
            string fullPath = Path.Combine(Application.persistentDataPath, _folder, fullFileName);
            return fullPath;
        }
    }

    public void Setup(string folder,string fileName, string extension)
    {
        _folder = folder;
        _fileName = fileName;
        _extension = extension;
    }
}
