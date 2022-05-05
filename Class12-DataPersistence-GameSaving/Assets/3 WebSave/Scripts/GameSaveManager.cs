using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GameSaveGeneral;

namespace GameSaveWeb
{
    public class GameSaveManager : ManagerBase
    {
        public static GameSaveManager instance;

        public bool isDataLoaded;
        public Vector3 playerPosition;


        // JS interaction with browser to force file saving on system
        [DllImport("__Internal")]
        private static extern void SyncFiles();


        // Singleton
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public override void Initialise()
        {
            LoadGameData();
        }

        public void SaveGame()
        {
            // ==== Save code just like other GameSaveManager ====
            BinaryFormatter formatter = new BinaryFormatter();
            string savePath = Application.persistentDataPath + "/saveFile.whatever";
            FileStream stream = new FileStream(savePath, FileMode.Create);

            SaveData data = new SaveData();
            Vector3 playerPosition = GameManager.instance.player.transform.position;
            data.SetPlayerPosition(playerPosition);
            
            formatter.Serialize(stream, data);
            stream.Close();

            // ==== Afterwards, we add the WebGL related part ====

            // If running on WebGL, ensure browser syncs save file to local indexed DB file system
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                SyncFiles();
            }
        }

        public void LoadGameData()
        {
            // ==== Load code just like other GameSaveManager ====

            string savePath = Application.persistentDataPath + "/saveFile.whatever";
            if (File.Exists(savePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(savePath, FileMode.Open);

                SaveData data = (SaveData)formatter.Deserialize(stream);

                playerPosition = data.GetPlayerPosition();
                stream.Close();
                isDataLoaded = true;
                print("Save Manager: Data loading complete");
            }
            else
            {
                isDataLoaded = false;
                print("Save Manager: No file to load");
            }
        }
    }
}