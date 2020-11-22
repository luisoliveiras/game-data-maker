using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterUI : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private ScriptablePlayerData _scriptablePlayerData;
    [Header("UI elements")]
    [SerializeField] private InputField _nameInput;
    [SerializeField] private InputField _numberInput;
    [SerializeField] private ToggleGroup _colorToggle;

    CharacterData _characterData;

    private void Start()
    {
        ResetValues();
    }

    private void OnEnable()
    {
        ResetValues();
    }

    private void ResetValues()
    {
        _characterData = new CharacterData();
        _nameInput.text = string.Empty;
        _numberInput.text = string.Empty;
        _colorToggle.SetAllTogglesOff();
    }

    public void OnToggleValueChange(GameObject gameObject)
    {
        _characterData.color.Color = gameObject.GetComponent<Image>().color;
    }

    public void OnNameChange(string name)
    {
        _characterData.name = name;
    }

    public void OnNumberChange(string number)
    {
        _characterData.luckyNumber = int.Parse(number);
    }

    public void CreateCharacter()
    {
        _scriptablePlayerData.PlayerData.AddCharacter(_characterData);
        _scriptablePlayerData.SavePlayerData();
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
