﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameDataMaker
{
    static GameDataConfig config;

    public static Action OnSaveSuccess;
    public static Action OnSaveFail;
    public static Action OnLoadSuccess;
    public static Action OnLoadFail;
    public static Action OnDeleteSuccess;
    public static Action OnDeleteFail;

    public static string SavePath { get => config.FilePath; }

    public static void Save<T>(T data) where T: class
    {
        GetConfig();
        string path = config.FilePath;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        binaryFormatter.Serialize(stream, data);
        stream.Close();
        Debug.Log($"[GameDataMaker] {typeof(T)} successfully saved at {path}");
        OnSaveSuccess?.Invoke();
    }

    public static T Load<T>() where T: class
    {
        GetConfig();
        string path = config.FilePath;

        T data;
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = binaryFormatter.Deserialize(stream) as T;
            stream.Close();

            Debug.Log($"[GameDataMaker] Save file retrieved from {path}");

            OnLoadSuccess?.Invoke();
        }
        else
        {
            data = null;

            Debug.Log($"[GameDataMaker] No save file found at {path}");
            OnLoadFail?.Invoke();
        }

        return data;
    }

    public static void DeleteSave()
    {
        string path = config.FilePath;
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"[GameDataMaker] Save file deleted from {path}");
            OnDeleteSuccess?.Invoke();
        }
        else
        {
            Debug.Log($"[GameDataMaker] No save file found at {path}");
            OnDeleteFail?.Invoke();
        }
    }

    private static void GetConfig()
    {
        if (config != null)
            return;

        config = Resources.Load("SaveConfig") as GameDataConfig;
        Debug.Log($"[GameDataMaker] {config.name} successfully loaded");
    }
}