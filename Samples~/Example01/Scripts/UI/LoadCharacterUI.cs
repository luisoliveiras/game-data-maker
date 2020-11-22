using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterUI : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private ScriptablePlayerData _scriptablePlayerData;
    [Header("UI elements")]
    [SerializeField] private Transform _content;
    [SerializeField] private CharacterContentUI _characterContent;

    private List<CharacterContentUI> _characterList;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (_characterList != null)
        {
            foreach (var character in _characterList)
            {
                Destroy(character.gameObject);
            }
            _characterList.Clear();
        }
        else
        {
            _characterList = new List<CharacterContentUI>();
        }
        foreach (var character in _scriptablePlayerData.PlayerData.Characters)
        {
            CharacterContentUI characterContent = Instantiate(_characterContent, _content);
            characterContent.Setup(character,DeleteCharacter);
            _characterList.Add(characterContent);
        }
    }

    void DeleteCharacter(CharacterData character)
    {
        _scriptablePlayerData.PlayerData.RemoveCharacter(character);
        _scriptablePlayerData.SavePlayerData();
        Refresh();

    }


}
