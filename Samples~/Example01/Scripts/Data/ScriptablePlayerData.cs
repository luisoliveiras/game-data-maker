using loophouse.GameDataMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class ScriptablePlayerData : ScriptableObject
{
    private const string PLAYER_DATA_KEY = "PlayerData";

    [SerializeField] private PlayerData _playerdata;

    public PlayerData PlayerData { get => _playerdata; }

    public Action onPlayerDataSaved;

    public void SavePlayerData()
    {
        GameDataManager.Save(_playerdata, PLAYER_DATA_KEY);
        onPlayerDataSaved?.Invoke();
    }

    public void LoadPlayerData()
    {
        _playerdata = GameDataManager.Load<PlayerData>(PLAYER_DATA_KEY);
        if (_playerdata == null)
        {
            _playerdata = new PlayerData();
        }
    }

    public void DeletePlayerData()
    {
        GameDataManager.DeleteSave(PLAYER_DATA_KEY);
        _playerdata = new PlayerData();
    }
}
