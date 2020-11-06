using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace devludico.GameDataMaker
{
    public static class GameDataManager
    {
        private const string TAG = "[GameDataMaker] ";
        private static GameDataConfig config;

        public static Action OnSaveSuccess;
        public static Action OnSaveFail;
        public static Action OnLoadSuccess;
        public static Action OnLoadFail;
        public static Action OnDeleteSuccess;
        public static Action OnDeleteFail;

        public static void Save<T>(T data, string item) where T : class
        {
            GetConfig();
            string path = config.GetDataItemPath(item);
            string folderPath = config.GetDataItemFolderPath(item);
            if (!string.IsNullOrEmpty(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            binaryFormatter.Serialize(stream, data);
            stream.Close();
            Log($"[GameDataMaker] {typeof(T)} successfully saved at {path}");
            OnSaveSuccess?.Invoke();
        }

        public static T Load<T>(string item) where T : class
        {
            GetConfig();
            string path = config.GetDataItemPath(item);

            T data;
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                data = binaryFormatter.Deserialize(stream) as T;
                stream.Close();
                Log($"Save file retrieved from {path}");
                OnLoadSuccess?.Invoke();
            }
            else
            {
                data = null;
                Log($"No save file found at {path}");
                OnLoadFail?.Invoke();
            }

            return data;
        }

        public static void DeleteSave(string item)
        {
            string path = config.GetDataItemPath(item);
            if (File.Exists(path))
            {
                File.Delete(path);
                Log($"Save file deleted from {path}");
                OnDeleteSuccess?.Invoke();
            }
            else
            {
                Log($"No save file found at {path}");
                OnDeleteFail?.Invoke();
            }
        }

        public static bool SaveExists(string item)
        {
            string path = config.GetDataItemPath(item);
            return File.Exists(path);
        }

        private static void GetConfig()
        {
            if (config != null)
                return;

            config = Resources.Load("SaveConfig") as GameDataConfig;
            Log($"{config.name} successfully loaded");
        }

        private static void Log(string message)
        {
            if (config.ShowLogs)
            {
                Debug.Log(string.Concat(TAG,message));
            }
        }
    }
}