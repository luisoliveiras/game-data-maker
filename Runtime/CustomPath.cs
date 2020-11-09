using System.IO;
using UnityEngine;

namespace loophouse.GameDataMaker
{
    [System.Serializable]
    public struct CustomPath
    {
        public string folder;
        public string file;
        public string extension;

        public override string ToString()
        {
            return Path.Combine(Application.persistentDataPath, folder, string.Concat(file, ".", extension));
        }
    }
}
