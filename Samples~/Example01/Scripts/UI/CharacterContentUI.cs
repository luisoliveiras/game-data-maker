using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CharacterContentUI : MonoBehaviour
{
    [HideInInspector] private CharacterData _characterData;
    [Header("UI elements")]
    [SerializeField] private Text _characterName;
    [SerializeField] private Text _characterLuckyNumber;
    [SerializeField] private Image _characterColor;

    private Action<CharacterData> _onCharacterDelete;

    public void Setup(CharacterData characterData, Action<CharacterData> OnCharacterDelete)
    {
        _characterData = characterData;
        _characterName.text = characterData.name;
        _characterLuckyNumber.text = characterData.luckyNumber.ToString();
        _characterColor.color = characterData.color.Color;
        _onCharacterDelete = OnCharacterDelete;
    }

    public void DeleteCharacter()
    {
        _onCharacterDelete.Invoke(_characterData);
        _onCharacterDelete = null;
    }
}