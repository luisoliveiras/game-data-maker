using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] private List<CharacterData> _characters;

    public PlayerData()
    {
        _characters = new List<CharacterData>();
    }

    public void AddCharacter(CharacterData characterData)
    {
        _characters.Add(characterData);
    }

    public void RemoveCharacter(CharacterData characterData)
    {
        _characters.Remove(characterData);
    }

    public CharacterData[] Characters { get => _characters.ToArray(); }
}