using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace loophouse.GameDataMaker
{
    public static class GameDataManager
    {
        private const string TAG = "[GameDataMaker]";
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

            try
            {
                binaryFormatter.Serialize(stream, data);
                Log($"{typeof(T)} successfully saved: \n Path: {path}");
                OnSaveSuccess?.Invoke();
            }
            catch (Exception e)
            {
                LogError($"Unable to save {typeof(T)} : \n {e.Message} ");
                OnSaveFail?.Invoke();
            }

            stream.Close();

            
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
                try
                {
                    data = binaryFormatter.Deserialize(stream) as T;
                    Log($"Save file {item} retrieved from given path. \n Path: {path}");
                    OnLoadSuccess?.Invoke();
                }
                catch (Exception e)
                {
                    LogError($"Failed to load file {item}: \n {e.Message}");
                    OnLoadFail?.Invoke();
                    data = null;
                }
                
                stream.Close();
                
            }
            else
            {
                data = null;
                LogError($"No {item} save file found at given path. \n Path: {path}");
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
                Log($"Save file {item} deleted from given path. \n Path: {path}");
                OnDeleteSuccess?.Invoke();
            }
            else
            {
                LogError($"No {item} save file found at given path. \n Path: {path}");
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
                Debug.Log(string.Concat(TAG," ",message));
            }
        }

        private static void LogError(string message)
        {
            if (config.ShowLogs)
            {
                Debug.LogError(string.Concat(TAG," ", message));
            }
        }
    }
}