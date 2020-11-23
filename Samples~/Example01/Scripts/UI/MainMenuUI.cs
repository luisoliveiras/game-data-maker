using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private ScriptablePlayerData _scriptablePlayerData;
    [Header("UI elements")]
    [SerializeField] private Button _loadButton;

    private void Start()
    {
        _scriptablePlayerData.LoadPlayerData();
        _scriptablePlayerData.onPlayerDataSaved += Refresh;
        Refresh();
    }

    private void OnDestroy()
    {
        _scriptablePlayerData.onPlayerDataSaved -= Refresh;
    }

    public void Refresh()
    {
        _loadButton.interactable = _scriptablePlayerData.PlayerData.Characters.Length > 0;
    }

}
